// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Views.Login
{
	[Register ("LoginView")]
	partial class LoginView
	{
		[Outlet]
		UIKit.UILabel ErrorText { get; set; }

		[Outlet]
		UIKit.UITextField LoginText { get; set; }

		[Outlet]
		UIKit.UITextField PasswordText { get; set; }

		[Outlet]
		UIKit.UIButton SigninButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (LoginText != null) {
				LoginText.Dispose ();
				LoginText = null;
			}

			if (PasswordText != null) {
				PasswordText.Dispose ();
				PasswordText = null;
			}

			if (SigninButton != null) {
				SigninButton.Dispose ();
				SigninButton = null;
			}

			if (ErrorText != null) {
				ErrorText.Dispose ();
				ErrorText = null;
			}
		}
	}
}
