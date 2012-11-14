using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace EM
{
	/// <summary>
	/// Summary description for AutoCompleteTextBox.
	/// </summary>
	public class AutoCompleteTextBox : TextBox
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		
		string[] matchCandidates = new string[]{};
		public string[] MatchCandidates
		{
			set
			{
				if (value == null)
					value = new string[]{};
				matchCandidates = value;
			}
		}

		DateTime lastEnter;
		bool onGotFocus = false;
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			onGotFocus = true;
			lastEnter = DateTime.Now; 
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			if (onGotFocus && 
				((DateTime.Now - lastEnter).TotalMilliseconds < 1000))
			{
				SelectAll();
			}
			onGotFocus = false;
		}
		bool IsPrefix(string fullText,string prefix)
		{
			if (fullText.Length <= prefix.Length)
				return false;
			for (int i=0;i<prefix.Length;i++)
			{
				if (fullText[i] != prefix[i])
					return false;
			}
			return true;
		}

		bool letterClicked = false;

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if (char.IsLetterOrDigit(e.KeyChar) ||
				char.IsWhiteSpace(e.KeyChar))			
			{
				letterClicked = true;
			}
			else
				letterClicked = false;

		}

		public bool enableAutoComplete = true;
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			if (!enableAutoComplete)
				return;
			TextBox box = (TextBox)this;
			string current = box.Text;
			if (!letterClicked)
				return;
			letterClicked = false;
			foreach (string key in matchCandidates)
			{
				if (IsPrefix(key,current))
				{
					// Found an auto-complete suggestion
					box.Text = key;
					int selectionLength = box.Text.Length-(current.Length);
					if (selectionLength >0)
						box.Select(current.Length,selectionLength);
					break;
				}
			}
		}


		public AutoCompleteTextBox()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
	}
}
