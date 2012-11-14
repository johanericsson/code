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
	public class EMForm : System.Windows.Forms.Form,
		IToolbarInterface
	{
			public virtual DataView GetHeaderTable() {Debug.Assert(false);return null;}
			public virtual void RefreshMainTableFromDataSource() {Debug.Assert(false);}
		    public virtual void RefreshOtherTablesFromDataSource() {}
			public virtual void CommitTablesToDataSource() {Debug.Assert(false);}
			public virtual void UpdateControls() {Debug.Assert(false);}
			public virtual void FromControls() {Debug.Assert(false);}
			public virtual void ChangingStatusChanged() {Debug.Assert(false);}
			
			public virtual DataRow CreateFreshRow() {Debug.Assert(false);return null;}
			public virtual int AddNewRow(DataRow row) {Debug.Assert(false);return -1;}
			public virtual OleDbConnection GetConnection() {Debug.Assert(false);return null;}
			public virtual DataSet GetDataSet() {Debug.Assert(false);return null;}
			public virtual bool IsDeleteAllowed() {return true;}
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		// IToolbarInterface members
		public void OnAdd()
		{
			try
			{
				if (IsEditing)
					return;
				Refresh();
				int newPosition = AddNewRow(CreateFreshRow());
				if (newPosition != -1) // -1 indicates that we don't want to go into editing mode
				{
					IsEditing = true;
					m_currentRow = newPosition;
				}
				UpdateControls();
			}			
			catch(Exception e)
			{
				IsEditing = false;
				MessageBox.Show(e.Message);
			}
		}
		public int GetRecordCount()
		{
			return GetHeaderTable().Table.Rows.Count;

		}
		public void OnChange()
		{
			try
			{
				
			if (IsEditing)
				return;
			if (IsEmptyTable())
				return;
			Refresh();
			IsEditing = true;
			}			
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
				IsEditing = false;
			}
		}

		public new void Refresh()
		{
			bool wasOpen = (GetConnection().State == ConnectionState.Open);
			if (!wasOpen)
				GetConnection().Open();
			GetDataSet().EnforceConstraints = false;
			try
			{
				try
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
				finally
				{
					GetDataSet().EnforceConstraints = true;
				}
				UpdateControls();
				ChangingStatusChanged();
			}
			finally
			{
				if (!wasOpen)
					GetConnection().Close();
			}
			
		}

		public void OnDelete()
		{
			try
			{
				
			if (IsEditing)
				return;
			if (IsEmptyTable())
				return;
			
			if (!IsDeleteAllowed())
				return;

			DialogResult res = 
				MessageBox.Show("Are you sure you would like to delete this selection?",
						"Are you sure?",MessageBoxButtons.YesNo);
			if (res != DialogResult.Yes)
				return;
			GetHeaderRow().Delete();
			Commit();
			Position = Position;
			Refresh();
			}			
			catch(Exception e)
			{
				IsEditing = false;
				MessageBox.Show(e.Message);
			}
		}

		public void Commit()
		{
			CommitTablesToDataSource();
		}

		public void OnCancel()
		{
			if (!IsEditing)
				return;
			GetHeaderRow().CancelEdit();
			GetHeaderTable().Table.RejectChanges();
			Position = Position;
			IsEditing = false;
			try
			{
				Refresh();
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
				IsEditing = false;
			}
		}
		public void OnNext()
		{
			try
			{
				if (IsEditing)
					return;
				Position++;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
				IsEditing = false;
			}
		}
		public void OnPrevious()
		{
			try
			{
				if (IsEditing)
					return;
				Position--;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
				IsEditing = false;
			}
		}
		public void OnRefresh()
		{
			if (IsEditing)
				return;
			try
			{
				Refresh();
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
				IsEditing = false;
			}
		}
		public void OnUpdate()
		{
			if (!IsEditing) 
				return;
			try
			{
				GetHeaderRow().EndEdit();
				FromControls();
				Commit();
				IsEditing = false;
				Refresh();
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		private bool m_bIsEditing;
		public bool IsEditing
		{
			get
			{
				return m_bIsEditing;
			}
			set
			{
				m_bIsEditing = value;
				ChangingStatusChanged();
			}
		}

		public void SetPosition(int position)
		{
			if (position < 0)
				position = 0;
			if (position > GetRecordCount() - 1)
				position = GetRecordCount() - 1;
			if (m_currentRow == position)
				return;
			
			m_currentRow = position;
			Refresh();
		}

		public bool IsEmptyTable()
		{
			return (GetHeaderTable().Table.Rows.Count == 0);
		}
		public DataRow GetHeaderRow()
		{
			if (IsEmptyTable())
				return CreateFreshRow();
			else
				return GetHeaderTable()[m_currentRow].Row;
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
			DataView table = GetHeaderTable();
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
			return !IsEditing;
		}
		public virtual bool OnUpdateChange()
		{
			return !IsEmptyTable() && !IsEditing;
		}
		public virtual bool OnUpdateDelete()
		{
			return !IsEmptyTable() && !IsEditing;
		}
		public virtual bool OnUpdateCancel()
		{
			return IsEditing;
		}
		public virtual bool OnUpdateNext()
		{
			return !IsEmptyTable() && !IsEditing && (Position != GetRecordCount() -1);
		}
		public virtual bool OnUpdatePrevious()
		{
			return !IsEditing && (Position != 0);
		}
		public virtual bool OnUpdateRefresh()
		{
			return !IsEditing;
		}
		public virtual bool OnUpdateUpdate()
		{
			return IsEditing;
		}
	}
}
