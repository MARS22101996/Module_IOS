// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace VTSClient.iOS
{
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        UIKit.UILabel ErrorText { get; set; }


        [Outlet]
        UIKit.UITextField LoginText { get; set; }


        [Outlet]
        UIKit.UITextField PasswordText { get; set; }


        [Outlet]
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