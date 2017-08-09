// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Views.VacationTable
{
	[Register ("VacationTableViewCell")]
	partial class VacationTableViewCell
	{
		[Outlet]
		UIKit.UILabel Date { get; set; }

		[Outlet]
		UIKit.UITextView Status { get; set; }

		[Outlet]
		UIKit.UILabel Type { get; set; }

		[Outlet]
		UIKit.UIImageView VacationPicture { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Status != null) {
				Status.Dispose ();
				Status = null;
			}

			if (Type != null) {
				Type.Dispose ();
				Type = null;
			}

			if (VacationPicture != null) {
				VacationPicture.Dispose ();
				VacationPicture = null;
			}

			if (Date != null) {
				Date.Dispose ();
				Date = null;
			}
		}
	}
}
