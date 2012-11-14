using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
namespace EM
{
	public class QuickGrid : ScrollableControl, IFocusChanged
	{

		public Button dataGridButton = new Button();
		public EventHandler lastEventRegistered;
		public Hashtable handlerTable = new Hashtable();

		struct ButtonInfo
		{
			public string buttonTitle;
			public EventHandler handler;
		}
		public void AddButtonHandler(int columnNumber,string buttonTitle,EventHandler handler)
		{
			ButtonInfo info = new ButtonInfo();
			info.buttonTitle = buttonTitle;
			info.handler = handler;
			handlerTable.Add(columnNumber,info);
		}
		public void ClearAllHandlers()
		{
			ClearButton();
			handlerTable.Clear();
		}

		void PlaceButton(Index current)
		{
			object item = handlerTable[current.column];
			if (item == null)
			{
				ClearButton();
				return;
			}
			ButtonInfo info = (ButtonInfo)item;
			dataGridButton.Click -= lastEventRegistered;
			dataGridButton.Click += info.handler;
			lastEventRegistered = info.handler;
			dataGridButton.Text = info.buttonTitle;
			dataGridButton.Parent = this;
			RectangleF rect = m_textRects[current.row,current.column];
			int size = 15;
			Point upperLeft = new Point((int)(rect.Right - size)+AutoScrollPosition.X,
				(int)(rect.Bottom - size) + AutoScrollPosition.Y);
			dataGridButton.Location = upperLeft;
			dataGridButton.Size = new Size(size,size);
			dataGridButton.Show();
			dataGridButton.BringToFront();
		}

		void ClearButton()
		{
			dataGridButton.Hide();
			dataGridButton.Visible = false;
			if (lastEventRegistered != null)
				dataGridButton.Click -= lastEventRegistered;
			lastEventRegistered = null;
		}

		public struct ColumnProperties
		{
			public int size;
			public bool variable;
			public bool multiline;
			public string formatString;
			public bool readOnly;
			public HorizontalAlignment alignment;
			public string heading;
			public string[] comboBoxValues;

		}
	
		bool m_allowNew;
		public void Setup(DataTable tableIn,ColumnProperties[] propsIn,
						bool allowNew)
		{
			KillFocus();
			m_currentIndex = new Index();
			m_allowNew = allowNew;
			props= propsIn;
			ArrayList typeConverters = new ArrayList();
			DataColumnCollection columns = tableIn.Columns;
			for (int i=0;i<tableIn.Columns.Count;i++)
			{
				DataColumn column = columns[i];
				typeConverters.Add(TypeDescriptor.GetConverter(column.DataType));
			}
			m_converters = (TypeConverter[])typeConverters.ToArray(typeof(TypeConverter));
			table = tableIn;
			AddExtraRowsIfNeeded();

			// Initialize component
			base.AutoScroll = true;
			base.AutoScrollMinSize = new Size(MinSize,100);
			base.ResizeRedraw = true;
			base.TabStop = true;
			this.KeyDown += new KeyEventHandler(this.QuickGrid_OnKeyDown);
			ChangeRectsSize();
			Invalidate();
		}
		public QuickGrid()
		{
			Setup(new DataTable(),new ColumnProperties[0],false);
		}

		TypeConverter[] m_converters;

		void ChangeRectsSize()
		{
			RectangleF[,] rects = new RectangleF[table.Rows.Count,props.Length];
			if (m_textRects != null)
			{
				for (int i=0;i<rects.GetLength(0);i++)
					for (int j=0;j<rects.GetLength(1);j++)
					{
						if (i < m_textRects.GetLength(0))
							if (j < m_textRects.GetLength(1))
								rects[i,j] = m_textRects[i,j];
					}
			}
			m_textRects = rects;
		}


		void OnEditLineCountChanged(object o, EventArgs e)
		{
			string s = currentEdit.Text;
			table.Rows[m_currentIndex.row][m_currentIndex.column] = s;
			Invalidate();
		}
		ColumnProperties[] props;
		DataTable table = new DataTable();
		IGridTextBox currentEdit;


        int m_cancelColumn = -1;

        public void SetCancelColumn(string columnName)
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (table.Columns[i].ColumnName == columnName)
                {
                    m_cancelColumn = i;
                    return;
                }
            }
            throw new Exception("Invalid column name");
        }

        public struct Index
		{
			public Index(int rowIn,int columnIn)
			{
				row = rowIn;
				column = columnIn;
			}
			public int row;
			public int column;
		}

		public Index GetCurrentIndex()
		{
			return m_currentIndex;
		}
		Index m_currentIndex = new Index();
		
		override protected void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int X = e.X;
				int Y = e.Y;
				for (int i=0;i<m_textRects.GetLength(0);i++)
					for (int j=0;j<m_textRects.GetLength(1);j++)
					{
						RectangleF currentRect = m_textRects[i,j];
						currentRect.Offset(AutoScrollPosition.X,AutoScrollPosition.Y);
						if (currentRect.Contains(new PointF(X,Y)))
						{
							SetNewFocus(i,j);
							return;
						}
					}
				

			}
		}
		
		void Expand(ref int val,int current)
		{
			if (val < current)
				val = current;
		}
		void Shrink(ref int val,int current)
		{
			if (val > current)
				val = current;
		}

		ColumnProperties GetVariableColumn()
		{
			for (int i=0;i<props.Length;i++)
			{
				if (props[i].variable == true)
					return props[i];
			}
			throw new Exception("Can't find variable column");
		}
		
		int GetVariableColumnWidth()
		{
			ColumnProperties variableColumn = GetVariableColumn();
			return variableColumn.size;
		}

		public void MoveUp()
		{
			int currentRow = m_currentIndex.row;
			if (currentRow == 0)
			{
				currentRow = table.Rows.Count -1;
			}
			else
				currentRow--;
			SetNewFocus(currentRow,m_currentIndex.column,true); // true here indicates that we want the last line
												// in a multiline edit box to be selected.
		}
		public void MoveDown()
		{
			int currentRow = m_currentIndex.row;
			if (currentRow == table.Rows.Count -1)
			{
				currentRow = 0;
			}
			else
				currentRow++;
			SetNewFocus(currentRow,m_currentIndex.column);

		}

		public void TabNext(bool reverse)
		{
			TabNext(reverse,m_currentIndex);
		}

		public void TabNext(bool reverse, Index newIndex)
		{
			if (currentEdit == null)
				return;
			if (!reverse)
			{
				if (newIndex.column == props.Length -1 )
					if (newIndex.row == table.Rows.Count-1)
					{
						//Control c = this.Parent.
						//this.Parent.GetNextControl(this,false).Focus();
						return;
					}
				newIndex.column++;
			}
			else
			{
				if (newIndex.column == 0)
					if (newIndex.row == 0)
					{
						//this.Parent.GetNextControl(this,false).Focus();
						return;
					}
				newIndex.column--;
			}
			if (newIndex.column >= props.Length)
			{
				newIndex.column = 0;
				newIndex.row++;
			}
			if (newIndex.column < 0)
			{
				newIndex.column = props.Length -1;
				newIndex.row--;
			}
			RectangleF targetRect = m_textRects[newIndex.row,newIndex.column];
			if (targetRect.X == -1 && 
				targetRect.Y == -1 &&
				targetRect.Width == 0)
			{
				// This means we have hit a "dummy" rectangle
				TabNext(reverse,newIndex);
				return;
			}
			SetNewFocus(newIndex.row,newIndex.column);
		}
		void KillFocus()
		{
			if (currentEdit != null)
			{
				ClearButton();
				if (currentEdit.IsChanged())
				{
					DataRow row = table.Rows[m_currentIndex.row];
					SetItem(m_currentIndex,currentEdit.Text);
				}
				currentEdit.Dispose();
				currentEdit = null;
				Invalidate();
				AddExtraRowsIfNeeded();
			}
		}


		public object GetItem(Index index)
		{
			return table.Rows[index.row][index.column];
		}
		public string GetItemAsText(Index index)
		{
			int column = index.column;
			object o = GetItem(index);
			if (o is DBNull)
				return "";
			if (props[column].formatString != null)
			{
				IFormattable formattable = (IFormattable)o;
				return formattable.ToString(props[column].formatString,null);
			}
			else
			{
				return o.ToString();
			}
		}
		public void SetCurrentItem(string itemText)
		{
			this.currentEdit.Text = itemText;
			this.currentEdit.SetChanged(true);
		}
		public void SetItem(Index index,string itemText)
		{
			Invalidate();
			int row = index.row;
			int column = index.column;
			DataRow dataRow = table.Rows[row];
			if (itemText == "")
			{
				dataRow[column] = DBNull.Value;
				return;
			}
			else
				try
				{
					// Remove '$' or ',' found. These will be show up in the formatted one
					// but the converter can't handle them.
					StringBuilder builder = new StringBuilder(itemText);
					for (int i=0;i<builder.Length;i++)
					{
						if ((builder[i] == ',') || (builder[i] == '$'))
							builder.Remove(i,1);
					}
					itemText = builder.ToString();
					dataRow[column] = m_converters[column].ConvertFromString(itemText);
				}
				catch(Exception)
				{
				}
		}

		bool IsEmptyRow(DataRow row)
		{
			for (int i=0;i<props.Length;i++)
			{
				if (!row.IsNull(i))
					return false;
			}
			return true;
		}
		int GetLastNonEmptyRow()
		{
			int non_emptyRow = -1;
			for (int i=0;i<table.Rows.Count;i++)
			{
				if (!IsEmptyRow(table.Rows[i]))
					non_emptyRow = i;
			}
			return non_emptyRow;
		}

		void AddExtraRowsIfNeeded()
		{
			int EXTRA_ROWS;
			if (m_allowNew)
				EXTRA_ROWS = 10;
			else
				EXTRA_ROWS = 0;
			int total_rows = table.Rows.Count;
			int empty_rows = total_rows - (GetLastNonEmptyRow()+1);
			int rows_needed = EXTRA_ROWS - empty_rows;
			for (int i=0;i<rows_needed;i++)
			{
				DataRow row = table.NewRow();
				table.Rows.Add(row);
			}
			int extra_rows = rows_needed * -1;
			for (int i=0;i<extra_rows;i++)
			{
				// Remove the last row
				table.Rows[table.Rows.Count -1].Delete();
				table.AcceptChanges();
			}
			ChangeRectsSize();
		}
		public DataTable GetTableQuietly() // ie without removing rows or making a copy...
		{
			return table;
		}
		public DataTable GetTable() 
		{
			KillFocus();
			DataTable copy = table.Copy();
			// Remove empty rows that are on the end

			bool done = false;
			while (!done)
			{
				int lastIndex = copy.Rows.Count -1;
				if (lastIndex == -1) // we've managed to empty the table
					return copy;
				DataRow lastRow = copy.Rows[lastIndex];
				if (IsEmptyRow(lastRow))
				{
					lastRow.Delete();
					copy.AcceptChanges();
				}
				else
				{
					return copy; // we've managed to remove all the empty rows
				}
			}
			throw new Exception("uh oh. logic error");
		}
		public void SetNewFocus(int row,int column)
		{
			SetNewFocus(row,column,false);
		}
		public delegate void OnNewFocusDelegate(int row,int column);
		public OnNewFocusDelegate m_onNewFocus = null;
		public void OnButtonClicked()
		{
			int currentColumn = m_currentIndex.column;
			object item = handlerTable[currentColumn];
			if (item == null)
				return;
			ButtonInfo info = (ButtonInfo)item;
			info.handler(dataGridButton,new EventArgs());
			
		}
		public void SetNewFocus(int row,int column,bool setToLastLine)
		{
			KillFocus();
			m_currentIndex.row = row;
			m_currentIndex.column = column;
			RectangleF currentRect = m_textRects[m_currentIndex.row,m_currentIndex.column];
			MultilineTextBox multiline = null;
			if (props[column].multiline)
			{
				multiline = new MultilineTextBox(this);
				multiline.LineCountChanged += new EventHandler(this.OnEditLineCountChanged);
				multiline.MoveCurrentToLastLine();
				currentEdit = multiline;
			}
			else if (props[column].comboBoxValues != null)
			{
				currentEdit = new GridComboBox(this,props[column].comboBoxValues);
			}
			else
				currentEdit = new SinglelineTextBox(this);
			currentEdit.Visible = false;
			currentEdit.TextAlign = props[column].alignment;
			currentEdit.Parent = this;
			currentEdit.AcceptsTab = false;
			currentRect.Offset(AutoScrollPosition.X,AutoScrollPosition.Y);
			currentEdit.Location = new Point((int)currentRect.X,(int)currentRect.Y);
			currentEdit.Size = new Size((int)currentRect.Width,(int)currentRect.Height);
			currentEdit.Show();
			currentEdit.ButtonPressHandler = new PressButtonDelegate(OnButtonClicked);

			currentEdit.ReadOnly = props[column].readOnly;
			currentEdit.BringToFront();
			currentEdit.Focus();
			currentEdit.Font = defaultFont;
			if (!table.Rows[row].IsNull(column))			
				currentEdit.Text = GetItemAsText(m_currentIndex);
			currentEdit.SelectAllText();
			if (setToLastLine && (multiline != null))
			{
				multiline.MoveCurrentToLastLine();
			}
			ArrayList listOfAutoComplete = new ArrayList();
			for (int i=0;i<table.Rows.Count;i++)
			{
				string current = GetItemAsText(new Index(i,column));
				if (current != "")
					listOfAutoComplete.Add(current);
			}
			string[] autoCompleters = (string[])listOfAutoComplete.ToArray(typeof(string));
			System.Array.Reverse(autoCompleters);
			currentEdit.MatchCandidates = autoCompleters;
			PlaceButton(m_currentIndex);
			Invalidate();
			if (m_onNewFocus != null)
			{
				m_onNewFocus(row,column);
			}
		}
		public int VisibleColumns
		{
			get
			{
				return props.Length;
			}
		}
		void QuickGrid_OnKeyDown(object sender,KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case (Keys.Tab):
				{
					TabNext(e.Shift);
					break;
				}
			}
		}

		StringFormat FromHorizontalAlignment(HorizontalAlignment alignment)
		{
			StringFormat outFormat = new StringFormat();
			switch (alignment)
			{
				case (HorizontalAlignment.Left):
				{
					outFormat.Alignment = StringAlignment.Near;
					break;
				}
				case (HorizontalAlignment.Right):
				{
					outFormat.Alignment = StringAlignment.Far;
					break;
				}
				case (HorizontalAlignment.Center):
				{
					outFormat.Alignment = StringAlignment.Center;
					break;
				}
				default:
					throw new Exception("uh oh");
			}
			return outFormat;
		}

		protected override bool IsInputKey(Keys keyData)
		{
			if ((Keys.Tab & keyData)!=0)
				return true;
			return base.IsInputKey(keyData);
		}

        protected void DrawRow(Graphics backBlt, Pen gridPen,
                           float lineHeight,
                        int gridLeft,Point bottomRight,
                        ref int currentY,
                        int row,ref int currentRowHeight)
        {
            int currentX = gridLeft;
            
            bool draw = currentRowHeight != 0;
            int i = row;
            if (draw && m_cancelColumn != -1)
            {
                Rectangle rect =
                    new Rectangle(currentX, currentY, bottomRight.X-currentX,
                    currentRowHeight);
                if (!(this.table.Rows[row][m_cancelColumn] is System.DBNull))
                    backBlt.FillRectangle(Brushes.Pink, rect);
            }
            if (draw)
                backBlt.DrawLine(gridPen, new Point(0, currentY),
            new Point(bottomRight.X, currentY));
            for (int j = 0; j < props.Length; j++)
            {
                StringFormat alignment = FromHorizontalAlignment(props[j].alignment);

                int left = currentX;
                int width;
                if (props[j].variable)
                    width = GetVariableColumnWidth();
                else
                    width = props[j].size;
                int top = currentY;
                RectangleF textRect = new RectangleF(left, top, width, lineHeight);
                string currentCellValue = GetItemAsText(new Index(i, j));

                Brush brush;
                if (props[j].readOnly)
                {
                    brush = Brushes.Chocolate;
                }
                else
                    brush = Brushes.Black;
                if (props[j].multiline)
                {
                    SizeF stringSize =
                        backBlt.MeasureString(currentCellValue, defaultFont, (int)textRect.Width,
                        alignment);
                    textRect.Height = stringSize.Height;
                    if (textRect.Height == 0)
                    {
                        textRect.Height = lineHeight;
                    }
                    if (draw)
                        backBlt.DrawString(currentCellValue, defaultFont, brush,
                        textRect, alignment);
                }
                else
                {
                    alignment.FormatFlags &= StringFormatFlags.NoWrap;
                    if (draw)
                        backBlt.DrawString(currentCellValue, defaultFont, brush,
                        textRect, alignment);
                }
                m_textRects[i, j] = textRect;
                if (j == 0) // for the first column, reset the height of the text
                    currentRowHeight = (int)textRect.Height;
                else // for the other columns, we take the larger of the two
                    Expand(ref currentRowHeight, (int)textRect.Height);
                if (j == props.Length - 1)
                    currentRowHeight += 5;
                currentX += width;
            }
            // Resize all the columns to be the same size as the largest
            for (int j = 0; j < props.Length; j++)
            {
                m_textRects[i, j].Height = currentRowHeight;
            }
            currentY += currentRowHeight + 2;
        }

		RectangleF dummyRect = new RectangleF(-1,-1,0,0);
		RectangleF[,] m_textRects;
		Font defaultFont = new Font("Arial",9);
		protected override void OnPaint(PaintEventArgs e)
		{
			int gridLeft = 5;
			Graphics g = e.Graphics;
			using (Bitmap backBitmap = new Bitmap(DisplayRectangle.Width,DisplayRectangle.Height))
			{
				using (Graphics backBlt = Graphics.FromImage(backBitmap))
				{
					int textHeight = 20;
					float lineHeight = backBlt.MeasureString("a",defaultFont).Height;
					textHeight = (int)lineHeight;		
					Point bottomRight = new Point(DisplayRectangle.Width-1,DisplayRectangle.Height-1);
					Pen gridPen = System.Drawing.Pens.DarkGray;
					backBlt.FillRectangle(Brushes.White,0,0,bottomRight.X,bottomRight.Y);
					backBlt.DrawRectangle(gridPen,0,0,
						bottomRight.X,bottomRight.Y);
					backBlt.FillRectangle(System.Drawing.Brushes.DarkGray,0,0,bottomRight.X,textHeight);
					int currentX = gridLeft;
					for (int i=0;i<props.Length;i++)
					{
						ColumnProperties prop = props[i];
						int left = currentX;
						int width;
						if (prop.variable)
							width = GetVariableColumnWidth();
						else 
							width = props[i].size;
						if (width < 0)
							width = 0;
						int top = 0;
						StringFormat alignment = new StringFormat();
						alignment.Alignment = StringAlignment.Center;
						RectangleF textRect = new RectangleF(left,top,width,textHeight);
						string title = props[i].heading;
						backBlt.DrawString(title,defaultFont,Brushes.White,
							textRect,alignment);

						currentX += width;
						backBlt.DrawLine(gridPen,
							new Point(currentX,top + textHeight),
							new Point(currentX,bottomRight.Y));
					}
					int currentY = textHeight;
					for (int i=0;i<table.Rows.Count;i++)
					{
                        int currentRowHeight = 0;
                        //once for calculated
                        //and the other for drawing
                        int currentYCopy = currentY;
                        DrawRow(backBlt, gridPen,lineHeight,
                            gridLeft,bottomRight,
                            ref currentYCopy, 
                            i, ref currentRowHeight);
                        DrawRow(backBlt, gridPen, lineHeight, 
                            gridLeft, bottomRight,
                            ref currentY, i, 
                            ref currentRowHeight);
					}
					base.AutoScrollMinSize = new Size(base.AutoScrollMinSize.Width,currentY);

					// Draw a rectangle that indicates the selected row
					if (m_textRects.GetLength(0) != 0 &&
						m_textRects.GetLength(1) != 0)
					{
						int selectedRow = m_currentIndex.row;
						RectangleF leftSelectedRectangle = m_textRects[selectedRow,0];
						backBlt.FillRectangle(Brushes.Blue,0,leftSelectedRectangle.Top,leftSelectedRectangle.Left,
							leftSelectedRectangle.Height);
					}
				
				}
				
				g.DrawImage(backBitmap,this.AutoScrollPosition.X,
					this.AutoScrollPosition.Y);
			}
			base.OnPaint (e);
		{
			if (currentEdit != null)
			{
				RectangleF currentRect = m_textRects[m_currentIndex.row,m_currentIndex.column];
				currentRect.Offset(AutoScrollPosition.X,AutoScrollPosition.Y);
				
				currentEdit.Location = new Point((int)currentRect.X,(int)currentRect.Y);
				currentEdit.Size = new Size((int)currentRect.Width,currentEdit.Size.Height);
				
				IMultilineTextBox multiline = currentEdit as IMultilineTextBox;
				if (multiline != null)
					multiline.CheckLineCount();
			}
		}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			//KillFocus();
			base.OnSizeChanged(e);
		}
		
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
		}

		public int MinSize
		{
			get
			{
				int width = 0;
				foreach (ColumnProperties prop in props)
				{
					width+= prop.size;
					
				}
				return width;

			}
			
		}

	};
}
