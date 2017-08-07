// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace VTSClient.iOS
{
	[Register ("MenuTableViewController")]
	partial class MenuTableViewController
	{
		[Outlet]
		UIKit.UIImageView ImageAvatar { get; set; }

		[Outlet]
		UIKit.UILabel LabelFullName { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LabelFullName != null) {
				LabelFullName.Dispose ();
				LabelFullName = null;
			}

			if (ImageAvatar != null) {
				ImageAvatar.Dispose ();
				ImageAvatar = null;
			}
		}
	}
}
