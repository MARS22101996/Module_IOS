﻿// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace VTSClient.iOS
{
	[Register ("LoginPageView")]
	partial class LoginPageView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UILabel ErrorText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextField LoginText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UITextField PasswordText { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIKit.UIButton SiginButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ErrorText != null) {
				ErrorText.Dispose ();
				ErrorText = null;
			}

			if (LoginText != null) {
				LoginText.Dispose ();
				LoginText = null;
			}

			if (PasswordText != null) {
				PasswordText.Dispose ();
				PasswordText = null;
			}

			if (SiginButton != null) {
				SiginButton.Dispose ();
				SiginButton = null;
			}
		}
	}
}
