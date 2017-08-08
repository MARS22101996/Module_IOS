// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MonkeyList.Core.iOS
{
    [Register ("MonkeyView")]
    partial class MonkeysView
    {
        [Outlet]
        UIKit.UITableView MonkeyTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MonkeyTableView != null) {
                MonkeyTableView.Dispose ();
                MonkeyTableView = null;
            }
        }
    }
}