using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Data.OleDb;

namespace EM
{
	/// <summary>
	/// Summary description for EMForm.
	/// </summary>
	public class EMForm : //System.Windows.Forms.Form,
		BaseEMForm,
		IToolbarInterface
	{
		public virtual DataView GetHeaderTable() {Debug.Assert(false);return null;}
		public virtual DataView GetHeaderTableBase()
		{
			DataView view = GetHeaderTable();
			view.RowStateFilter = DataViewRowState.CurrentRows | DataViewRowState.Deleted;
			return view;
		}
		public virtual void RefreshMainTableFromDataSource() {Debug.Assert(false);}
		public virtual void RefreshOtherTablesFromDataSource() {}
		public virtual void CommitTablesToDataSource() {Debug.Assert(false);}
		public virtual void UpdateControls() {Debug.Assert(false);}
		public override void FromControls() {Debug.Assert(false);}
		public virtual void ChangingStatusChanged() {Debug.Assert(false);}
			
		public virtual DataRow CreateFreshRow() {Debug.Assert(false);return null;}
		public virtual int AddNewRow(DataRow row) {Debug.Assert(false);return -1;}
		public virtual OleDbConnection GetConnection() {Debug.Assert(false);return null;}
		public virtual DataSet GetDataSet() {Debug.Assert(false);return null;}
		public virtual bool IsDeleteAllowed() {return true;}

		public override bool IsChanged()
		{

			DataTable changedTable = GetHeaderTableBase().Table.GetChanges();
			bool isChanged = (changedTable != null);
			return isChanged;
		}
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// IToolbarInterface members
		public void OnAdd()
		{
			try
			{
				if (!TryToCommit())
					return;
				Refresh();
				int newPosition = AddNewRow(CreateFreshRow());
				if (newPosition != -1) // -1 indicates that we don't want to go into editing mode
				{
					this.m_currentRow = newPosition;
				}
				UpdateControls();
			}			
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		public int GetRecordCount()
		{
			return GetHeaderTableBase().Table.Rows.Count;

		}

		public override void Refresh()
		{
			using (new OpenConnection(IsWrite.No,GetConnection()))
			using (new TurnOffConstraints(GetDataSet()))
			{
				RefreshMainTableFromDataSource();
				if (Position < 0)
					m_currentRow = 0;
				else
					if (!IsEmptyTable())
					if (m_currentRow >= GetRecordCount())
						m_currentRow = GetRecordCount() -1;
				RefreshOtherTablesFromDataSource();
			}
			UpdateControls();
		}
		
		void Assert(bool param)
		{
			System.Diagnostics.Debug.Assert(param);

		}

		public void DeleteInternal(bool askUser)
		{			
				if (IsEmptyTable())
					return;		
				
				if (!IsDeleteAllowed())
					return;

				// If this row was never added to the database yet, 
				// there is no need to push anything out the database
				if (GetHeaderRow().RowState == DataRowState.Added)
				{
					GetHeaderRow().Delete();
					Refresh();
					Position = Position;
					return;
				}

				if (askUser)
				{
					DialogResult res = 
						MessageBox.Show("Are you sure you would like to delete this selection?",
						"Are you sure?",MessageBoxButtons.YesNo);
					if (res != DialogResult.Yes)
						return;
				}
				TryToCommit(false); // force an update to the database
				GetHeaderRow().Delete();
				Commit();
				Refresh();
				Position = Position;
		}
		public void OnDelete()
		{	
			try
			{
				DeleteInternal(true);
			}			
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		public new bool TryToCommit()
		{
			return TryToCommit(true);
		}

		public new bool TryToCommit(bool confirm)
		{
			return TryToCommit(confirm,MessageBoxButtons.YesNoCancel);
		}
		/*public bool TryToCommit(bool confirm,MessageBoxButtons buttonType)
		{
			if (IsEmptyTable())
				return true;
			GetHeaderRow().EndEdit();
			FromControls();
			if (!IsChanged())
				return true;
			if (confirm)
			{
				DialogResult res = 
					MessageBox.Show("Do you want to save your changes",
					"Save changes?",buttonType,MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button2);
				if (res == DialogResult.Cancel)
					return false;
				if (res == DialogResult.No)
				{
					return true;	
				}
			}
			Commit();
			Refresh();
			return true;
		}
*/
		public override void Commit()
		{
			CommitTablesToDataSource();
		}

		public void OnCancel()
		{
			if (IsEmptyTable())
				return;
			GetHeaderRow().CancelEdit();
			GetDataSet().RejectChanges();
			try 
			{
				Refresh();
				Position = Position;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		public void OnNext()
		{
			try
			{
				Position++;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		public void OnPrevious()
		{
			try
			{
				Position--;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		public void OnRefresh()
		{
		}
		public void OnUpdate()
		{
			if (!IsEditing) 
				return;
			if (IsEmptyTable())
				return;
			try
			{
				if (!TryToCommit(false))
					return;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		public bool IsEditing
		{
			get
			{
				return true;
			}
		}

		public void SetPosition(int position)
		{
			if (!TryToCommit())
				return;

			if (position < 0)
				position = 0;
			if (position > GetRecordCount() - 1)
				position = GetRecordCount() - 1;
			if (m_currentRow == position)
				return;
			m_currentRow = position;
			Refresh();
		}

		public override bool IsEmptyTable()
		{
			return (GetHeaderTableBase().Count == 0);
		}
		public override DataRow GetHeaderRow()
		{
			if (IsEmptyTable())
				return CreateFreshRow();
			else
				return GetHeaderTableBase()[m_currentRow].Row;
		}
		protected int m_currentRow;
		public int Position
		{
			get
			{
				return m_currentRow;
			}
			set
			{
				SetPosition(value);
			}
		}

		public void SelectRow(string fieldName,string fieldData)
		{
			long count = GetRecordCount();
			DataView table = GetHeaderTableBase();
			for (int i=0;i<count;i++)
			{
				DataRowView row = table[i];
				if (((string)row[fieldName]) == (string)fieldData)
				{
					Position = i;
					break;
				}
			}
		}
		public EMForm()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		public virtual bool OnUpdateAdd()
		{
			return true;
		}
		public virtual bool OnUpdateChange()
		{
			return false;
		}
		public virtual bool OnUpdateDelete()
		{
			return !IsEmptyTable();
		}
		public virtual bool OnUpdateCancel()
		{
			return !IsEmptyTable();
		}
		public virtual bool OnUpdateNext()
		{
			return !IsEmptyTable() && (Position != GetRecordCount() -1);
		}
		public virtual bool OnUpdatePrevious()
		{
			return (Position != 0);
		}
		public virtual bool OnUpdateRefresh()
		{
			return true;
		}
		public virtual bool OnUpdateUpdate()
		{
			return !IsEmptyTable();
		}
	}
}
