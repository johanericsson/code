using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;


namespace EM
{
	/// <summary>
	/// Summary description for SetupQuickGrid.
	/// </summary>
	public class SetupQuickGrid
	{
		public static void DoIt(QuickGrid grid, 
			PictureBox picture,Control parent, 
			AnchorStyles anchor)
		{
			picture.Visible = false;
			grid.Location = picture.Location;
			grid.Visible = true;
			grid.Size = picture.Size;
			grid.Dock = picture.Dock;
			grid.Parent = parent;
			grid.Anchor = anchor;
		}
		public static void DoIt(QuickGrid grid,
			PictureBox picture,Control parent)
		{
			DoIt(grid,picture,parent,AnchorStyles.Bottom | AnchorStyles.Left |
											AnchorStyles.Right | AnchorStyles.Top);
		}
		public static void DoIt(QuickGrid grid,Control parent)
		{
			grid.Location = new Point(0,0);
			grid.Visible = true;
			grid.Dock = DockStyle.Fill;
			grid.Parent = parent;
        }
	}
}
