// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.ViewControllers.LoginViewController
{
    [Register ("LoginViewController")]
    partial class LoginViewController
    {
        [Outlet]
        UIKit.UIButton ButtonLogin { get; set; }



        [Outlet]
        UIKit.UITextField TextFieldLogin { get; set; }



        [Outlet]
        UIKit.UITextField TextFieldPassword { get; set; }



        [Outlet]
        UIKit.UITextView TextViewErrorMessage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonLogin != null) {
                ButtonLogin.Dispose ();
                ButtonLogin = null;
            }

            if (TextFieldLogin != null) {
                TextFieldLogin.Dispose ();
                TextFieldLogin = null;
            }

            if (TextFieldPassword != null) {
                TextFieldPassword.Dispose ();
                TextFieldPassword = null;
            }

            if (TextViewErrorMessage != null) {
                TextViewErrorMessage.Dispose ();
                TextViewErrorMessage = null;
            }
        }
    }
}