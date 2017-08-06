// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Table
{
    [Register ("TableViewCellVacation")]
    partial class TableViewCellVacation
    {
        [Outlet]
        UIKit.UIImageView ImageViewVacationType { get; set; }


        [Outlet]
        UIKit.UILabel LabelVacationDate { get; set; }


        [Outlet]
        UIKit.UILabel LabelVacationStatus { get; set; }


        [Outlet]
        UIKit.UILabel LabelVacationType { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ImageViewVacationType != null) {
                ImageViewVacationType.Dispose ();
                ImageViewVacationType = null;
            }

            if (LabelVacationDate != null) {
                LabelVacationDate.Dispose ();
                LabelVacationDate = null;
            }

            if (LabelVacationStatus != null) {
                LabelVacationStatus.Dispose ();
                LabelVacationStatus = null;
            }

            if (LabelVacationType != null) {
                LabelVacationType.Dispose ();
                LabelVacationType = null;
            }
        }
    }
}