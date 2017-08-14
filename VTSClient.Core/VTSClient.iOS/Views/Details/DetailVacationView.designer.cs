// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace VTSClient.iOS.Views.Details
{
    [Register ("DetailVacationView")]
    partial class DetailVacationView
    {

        [Outlet]
        UIKit.UIDatePicker DatePickerVacation { get; set; }

        [Outlet]
        UIKit.UIButton EndDay { get; set; }

        [Outlet]
        UIKit.UIButton EndMonth { get; set; }

        [Outlet]
        UIKit.UIButton EndYear { get; set; }

        [Outlet]
        UIKit.UIPageControl Page { get; set; }

        [Outlet]
        UIKit.UIImageView PageImage { get; set; }

        [Outlet]
        UIKit.UIButton StartDay { get; set; }

        [Outlet]
        UIKit.UIButton StartMonth { get; set; }

        [Outlet]
        UIKit.UIButton StartYear { get; set; }

        [Outlet]
        UIKit.UISegmentedControl StatusButton { get; set; }

        [Outlet]
        UIKit.UIView TypeImageView { get; set; }

        [Outlet]
        UIKit.UILabel TypeText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIToolbar DatePickerToolbar { get; set; }


        void ReleaseDesignerOutlets ()
        {
            if (DatePickerToolbar != null) {
                DatePickerToolbar.Dispose ();
                DatePickerToolbar = null;
            }

            if (DatePickerVacation != null) {
                DatePickerVacation.Dispose ();
                DatePickerVacation = null;
            }

            if (EndDay != null) {
                EndDay.Dispose ();
                EndDay = null;
            }

            if (EndMonth != null) {
                EndMonth.Dispose ();
                EndMonth = null;
            }

            if (EndYear != null) {
                EndYear.Dispose ();
                EndYear = null;
            }

            if (Page != null) {
                Page.Dispose ();
                Page = null;
            }

            if (PageImage != null) {
                PageImage.Dispose ();
                PageImage = null;
            }

            if (StartDay != null) {
                StartDay.Dispose ();
                StartDay = null;
            }

            if (StartMonth != null) {
                StartMonth.Dispose ();
                StartMonth = null;
            }

            if (StartYear != null) {
                StartYear.Dispose ();
                StartYear = null;
            }

            if (StatusButton != null) {
                StatusButton.Dispose ();
                StatusButton = null;
            }

            if (TypeImageView != null) {
                TypeImageView.Dispose ();
                TypeImageView = null;
            }

            if (TypeText != null) {
                TypeText.Dispose ();
                TypeText = null;
            }
        }
    }
}