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
	/// Summary description for BaseEMForm.
	/// </summary>
	public class BaseEMForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BaseEMForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			this.Closing += new CancelEventHandler(OnClosing);

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		void OnClosing(object o,CancelEventArgs args)
		{
			try
			{
				if (!TryToCommit())
					args.Cancel = true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public virtual bool IsEmptyTable()	{Debug.Assert(false);return false;}
		public virtual DataRow GetHeaderRow() {Debug.Assert(false);return null;}
		public virtual void FromControls() {Debug.Assert(false);}
		public virtual bool IsChanged() {Debug.Assert(false); return false;}
		public virtual void Commit() {Debug.Assert(false);}
		public new virtual void Refresh() {Debug.Assert(false);}
		public virtual bool IsValid() {return true;}

		public bool TryToCommit()
		{
			return TryToCommit(true);
		}

		public bool TryToCommit(bool confirm)
		{
			return TryToCommit(confirm,MessageBoxButtons.YesNoCancel);
		}
		public bool TryToCommit(bool confirm,MessageBoxButtons buttonType)
		{
			if (IsEmptyTable())
				return true;
			GetHeaderRow().EndEdit();
			FromControls();
			if (!IsChanged())
				return true;
			if (confirm)
			{
				DialogResult res;
				if (buttonType == MessageBoxButtons.OKCancel)
				{
					
					res = new SaveCancelDlg().ShowDialog();
				}
				else if (buttonType == MessageBoxButtons.YesNo)
					res = new SaveYesNo().ShowDialog();
				else
					res = new SaveNoSaveCancel().ShowDialog();
				if (res == DialogResult.Cancel)
					return false;
				if (res == DialogResult.No)
				{
					return true;	
				}
			}
			if (GetHeaderRow().RowState != DataRowState.Deleted &&
				!IsValid())
				return false;
			Commit();
			Refresh();
			return true;
		}

		public virtual bool CheckForDirty()
		{
			return TryToCommit();
		}
		
		public virtual void OnFind()
		{
		}
		public virtual bool OnUpdateFind()
		{
			return false;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "BaseEMForm";
		}
		#endregion
	}
}
