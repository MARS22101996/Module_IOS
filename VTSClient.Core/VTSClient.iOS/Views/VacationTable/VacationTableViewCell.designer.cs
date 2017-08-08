// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Views.VacationTable
{
    [Register ("VacationTableViewCell")]
    partial class VacationTableViewCell
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