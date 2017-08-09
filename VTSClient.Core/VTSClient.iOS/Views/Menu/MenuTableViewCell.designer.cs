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
	[Register ("MenuTableViewCell")]
	partial class MenuTableViewCell
	{
		[Outlet]
		UIKit.UIButton GoToVacations { get; set; }

		[Outlet]
		UIKit.UIView TypeCell { get; set; }

		[Outlet]
		UIKit.UILabel TypeLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TypeLabel != null) {
				TypeLabel.Dispose ();
				TypeLabel = null;
			}

			if (GoToVacations != null) {
				GoToVacations.Dispose ();
				GoToVacations = null;
			}

			if (TypeCell != null) {
				TypeCell.Dispose ();
				TypeCell = null;
			}
		}
	}
}
