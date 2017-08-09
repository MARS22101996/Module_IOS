using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using VTSClient.Core.Models;

namespace VTSClient.iOS.Views.Menu
{
    public partial class MenuTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MenuTableViewCell");
        public static readonly UINib Nib;

        static MenuTableViewCell()
        {
            Nib = UINib.FromName("MenuTableViewCell", NSBundle.MainBundle);
        }

        protected MenuTableViewCell(IntPtr handle) : base(handle)
        {
			// Note: this .ctor should not contain any initialization logic.
			this.DelayBind(() =>
			{
				var set = this.CreateBindingSet<MenuTableViewCell, Section>();

				set.Bind(GoToVacations)
                   .For("Title")
			       .To(vm => vm.Name);

				set.Bind(GoToVacations)
                   .To(vm => vm.GoToVacationsCommand);

				set.Apply();
			});
        }
    }
}
