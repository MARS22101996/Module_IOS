using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.Core.ViewModels;

namespace VTSClient.iOS.Views.VacationTable
{
    public partial class VacationTableView : MvxViewController<VacationViewModel>
    {
        public VacationTableView() : base("VacationTableView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			NavigationItem.Title = "Vacations";

			var source = new MvxSimpleTableViewSource(VacationTable, "VacationTableViewCell", VacationTableViewCell.Key);
			VacationTable.RowHeight = 50;

			var set = this.CreateBindingSet<VacationTableView, VacationViewModel>();
			set.Bind(source).To(vm => vm.Vacations);
			set.Apply();

			VacationTable.Source = source;
			VacationTable.ReloadData();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

