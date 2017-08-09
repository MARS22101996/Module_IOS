using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.Core.ViewModels;

namespace VTSClient.iOS.Views.Menu
{
	public partial class MenuView : MvxViewController<SectionsViewModel>
    {
        public MenuView() : base("MenuView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			NavigationItem.Title = "Menu";

			var source = new MvxSimpleTableViewSource(SectionTable, "MenuTableViewCell", MenuTableViewCell.Key);
			
            SectionTable.RowHeight = 50;

			var set = this.CreateBindingSet<MenuView, SectionsViewModel>();

			set.Bind(source).To(vm => vm.Sections);

			set.Apply();

			SectionTable.Source = source;

			SectionTable.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

