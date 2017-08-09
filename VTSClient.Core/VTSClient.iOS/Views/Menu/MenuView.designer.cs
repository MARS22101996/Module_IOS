// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Views.Menu
{
	[Register ("MenuView")]
	partial class MenuView
	{
		[Outlet]
		UIKit.UITableView SectionTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SectionTable != null) {
				SectionTable.Dispose ();
				SectionTable = null;
			}
		}
	}
}
