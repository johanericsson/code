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
	interface IFocusChanged
	{
		void TabNext(bool forward);
		void MoveUp();
		void MoveDown();
	}

	
	delegate void PressButtonDelegate();
	interface IGridTextBox :  IDisposable
	{
		void SelectAllText();
		bool Visible {set;get;}
		HorizontalAlignment TextAlign{get;set;}
		Control Parent{get;set;}
		bool AcceptsTab{get;set;}
		Point Location{get;set;}
		Size Size{get;set;}
		void Show();
		bool ReadOnly{get;set;}
		void BringToFront();
		bool Focus();
		Font Font{get;set;}
		bool IsChanged();
		string[] MatchCandidates{set;}
		void SetChanged(bool isChanged);
		string Text{get;set;}
		PressButtonDelegate ButtonPressHandler
		{
			get;set;
		}
	};

	class GridComboBox : ComboBox, IGridTextBox
	{
		public PressButtonDelegate ButtonPressHandler
		{
			get
			{
				return null;
			}
			set{}
		}
		protected override bool IsInputKey(Keys keyData)
		{
			if ((keyData & Keys.Tab) != 0)
				return true;
			return base.IsInputKey(keyData);
		}

		public void SelectAllText()
		{
		}

		IFocusChanged m_callback;
		public GridComboBox(IFocusChanged focus,string[] items)
		{
			m_callback = focus;
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.KeyDown += new KeyEventHandler(GridTextBox_OnKeyDown);
            Items.Add("");
			Items.AddRange(items);
		}
		public bool AcceptsTab
		{
			get	{return false;}
			set {}
		}
		void GridTextBox_OnKeyDown(object sender,KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case (Keys.Down):
					if (this.SelectedIndex == Items.Count - 1)
						m_callback.MoveDown();
					break;
				case (Keys.Up):
					if (this.SelectedIndex == 0)
						m_callback.MoveUp();
					break;
				case (Keys.Left):
					m_callback.TabNext(true);
					break;
				case (Keys.Right):
					m_callback.TabNext(false);
					break;
				case (Keys.Tab):
				{
					m_callback.TabNext(e.Shift);
					break;
				}
			}
		}
		public bool IsChanged()
		{
			return true;
		}
		public string[] MatchCandidates{set{}}
		public bool ReadOnly{get {return false;}set{}}
		public void SetChanged(bool isChanged){}
		public HorizontalAlignment TextAlign
		{						 
			get {return HorizontalAlignment.Left;}
			set{}
		}
}

	class GridTextBox : AutoCompleteTextBox,
		IGridTextBox
	{
		PressButtonDelegate m_buttonPressHandler;
		public PressButtonDelegate ButtonPressHandler
		{
			get
			{
				return m_buttonPressHandler;
			}
			set
			{
				m_buttonPressHandler = value;
			}
		}
		public void SelectAllText()
		{
			base.SelectAll();
		}
		public IFocusChanged m_callback;
		public GridTextBox(IFocusChanged callback)
		{
			m_callback = callback;
			this.KeyDown += new KeyEventHandler(GridTextBox_OnKeyDown);
			this.TextChanged += new EventHandler(OnTextChanged);
		}
		void GridTextBox_OnKeyDown(object sender,KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case (Keys.Space):
				{
					if (e.Control)
					{
						if (m_buttonPressHandler != null)
							m_buttonPressHandler();
					}
					break;
				}
				case (Keys.Tab):
				{
					m_callback.TabNext(e.Shift);
					break;
				}
			}
		}
		public bool IsChanged()
		{
			return m_changed;
		}
		public void SetChanged(bool changed)
		{
			m_changed = changed;
		}
		bool m_changed = false;
		private void OnTextChanged(object sender, EventArgs e)
		{
			m_changed = true;
		}
		public new string Text
		{
			set
			{
				bool oldChanged = m_changed;
				base.Text = value;
				m_changed = oldChanged;
			}
			get
			{
				return base.Text;
			}
		}
		
		protected override bool IsInputKey(Keys keyData)
		{
			if ((keyData & Keys.Tab) != 0)
				return true;
			return base.IsInputKey(keyData);
		}
	}

	class SinglelineTextBox : GridTextBox
	{
		public SinglelineTextBox(IFocusChanged focusChanged)
			:base(focusChanged)
		{
			this.KeyDown += new KeyEventHandler(SinglelineTextBox_OnKeyDown);
		}
		void SinglelineTextBox_OnKeyDown(object sender,KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case (Keys.Up):
				{
					m_callback.MoveUp();
					break;
				}
				case (Keys.Down):
				{
					m_callback.MoveDown();
					break;
				}
			}
		}

	}

	interface IMultilineTextBox
	{
		void CheckLineCount();
	}
	class MultilineTextBox : GridTextBox, IMultilineTextBox
	{
		float heightFactor;
		float fuzzyHeight;
		public event EventHandler LineCountChanged;
		public MultilineTextBox(IFocusChanged callback):base(callback)
		{
			base.Multiline = true;
			base.AcceptsReturn = true;
			base.WordWrap = true;
			base.enableAutoComplete = false;
			using (Graphics g = Graphics.FromHwnd(this.Handle))
			{
				heightFactor = g.MeasureString("qA",base.Font).Height;
				float fontHeight = base.Font.Height;
				fuzzyHeight = base.Size.Height - heightFactor;
			}
			this.KeyDown += new KeyEventHandler(MultilineTextBox_OnKeyDown);
		}
		public void MoveCurrentToLastLine()
		{	
			int lastLine = GetLineCount()-1;
			int firstCharOfLastLine = 
				(int)SendMessage(base.Handle,EM_LINEINDEX,new UIntPtr((uint)lastLine),(IntPtr)0);
			this.SelectionStart = firstCharOfLastLine;
			this.SelectionLength = 0;
		}
		string[] MySplit(string input,string splitChars)
		{
			ArrayList stringList = new ArrayList();
			for (int i=0;i<input.Length;i++)
			{
				foreach(char c in splitChars)
				{
					if (c==input[i])
					{
						// perform splitting
						string newPart = input.Substring(0,i+1);
						stringList.Add(newPart);
						input = input.Substring(i+1,input.Length - (i+1));
						i=0;
					}
				}
			}
			stringList.Add(input);
			return (string[])stringList.ToArray(typeof(string));
		}
		[DllImport("user32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd,uint MSG,UIntPtr wParam,
			IntPtr lParam);
		const uint EM_GETLINECOUNT = 186;
		const uint EM_LINEINDEX = 0x00BB;
		const uint EM_GETRECT = 0x00B2;
		const uint EM_LINELENGTH = 0x00C1;
		const uint EM_LINEFROMCHAR = 0x00C9;
		override protected void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			bool lineChanged = InternalCheckLineCount();
			if (lineChanged)
			{
				if (LineCountChanged != null)
					LineCountChanged(this,new EventArgs());
			}
		}
		void MultilineTextBox_OnKeyDown(object sender,KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case (Keys.Up):
				{
					int currentLine = GetCurrentLine();
					if (currentLine == 0)
						m_callback.MoveUp();
					break;
				}
				case (Keys.Down):
				{
					int currentLine = GetCurrentLine();
					int lineCount = GetLineCount();
					if (currentLine == lineCount -1)
						m_callback.MoveDown();
					break;
				}
			}
		}

		int GetLineCount()
		{
			int lineCount = (int)SendMessage(base.Handle,EM_GETLINECOUNT,(UIntPtr)0,(IntPtr)0);
			return lineCount;			
		}

		int GetCurrentLine()
		{
			unchecked 
			{
				
				int lineIndex = (int)SendMessage(base.Handle,EM_LINEFROMCHAR,new UIntPtr((uint)-1),(IntPtr)0);
				return lineIndex;
			}
		}
		bool InternalCheckLineCount()
		{
			int lineCount = GetLineCount();
			if (lineCount ==0)
				lineCount = 1;
			if (lineCount!= numberOfLines)
			{
				numberOfLines = lineCount;
				float newHeight = (heightFactor+2) * numberOfLines + fuzzyHeight;
				int newHeightAsInt = (int)newHeight + 1;
				base.Size = new Size(base.Size.Width,newHeightAsInt);
				return true;
			}
			return false;
			
		}
		int numberOfLines=0;
		public void CheckLineCount()
		{
			InternalCheckLineCount();
		}
			
	}

}
