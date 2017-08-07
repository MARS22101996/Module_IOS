// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Cells
{
	[Register ("VacationTableCell")]
	partial class VacationTableCell
	{
		[Outlet]
		UIKit.UIImageView ImageType { get; set; }

		[Outlet]
		UIKit.UILabel TextDate { get; set; }

		[Outlet]
		UIKit.UITextView TextStatus { get; set; }

		[Outlet]
		UIKit.UILabel TextType { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageType != null) {
				ImageType.Dispose ();
				ImageType = null;
			}

			if (TextDate != null) {
				TextDate.Dispose ();
				TextDate = null;
			}

			if (TextStatus != null) {
				TextStatus.Dispose ();
				TextStatus = null;
			}

			if (TextType != null) {
				TextType.Dispose ();
				TextType = null;
			}
		}
	}
}
