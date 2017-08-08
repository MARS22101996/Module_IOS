// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Views
{
    [Register ("MyViewController")]
    partial class MyViewController
    {
        [Outlet]
        UIKit.UIActivityIndicatorView Test { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Test != null) {
                Test.Dispose ();
                Test = null;
            }
        }
    }
}