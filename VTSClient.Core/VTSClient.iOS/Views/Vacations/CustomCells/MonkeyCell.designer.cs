// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Views.Vacations.CustomCells
{
    [Register ("MonkeyCell")]
    partial class MonkeyCell
    {
        [Outlet]
        UIKit.UILabel descriptionLabel { get; set; }


        [Outlet]
        UIKit.UIImageView monkeyImage { get; set; }


        [Outlet]
        UIKit.UILabel nameLabel { get; set; }


        [Outlet]
        UIKit.UILabel originLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (descriptionLabel != null) {
                descriptionLabel.Dispose ();
                descriptionLabel = null;
            }

            if (monkeyImage != null) {
                monkeyImage.Dispose ();
                monkeyImage = null;
            }

            if (nameLabel != null) {
                nameLabel.Dispose ();
                nameLabel = null;
            }

            if (originLabel != null) {
                originLabel.Dispose ();
                originLabel = null;
            }
        }
    }
}