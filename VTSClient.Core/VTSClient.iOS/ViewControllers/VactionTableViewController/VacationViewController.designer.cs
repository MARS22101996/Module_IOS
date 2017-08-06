// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace VTSClient.iOS
{
    [Register ("VacationViewController")]
    partial class VacationViewController
    {
        [Outlet]
        UIKit.UITableView TableViewVacation { get; set; }


        [Outlet]
        UIKit.UIToolbar ToolBarTop { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (TableViewVacation != null) {
                TableViewVacation.Dispose ();
                TableViewVacation = null;
            }
        }
    }
}