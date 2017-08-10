using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.Core.ViewModels;

namespace VTSClient.iOS.Views.Details
{
	public partial class DetailVacationView : MvxViewController<DetailViewModel>
	{
		public DetailVacationView() : base("DetailVacationView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			NavigationItem.BackBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Action);

			NavigationItem.Title = "Request";

			NavigationItem.RightBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Save);

			ApplyBindings();
		}


		private void ApplyBindings()
		{
			var bindingSet = this.CreateBindingSet<DetailVacationView, DetailViewModel>();

			bindingSet.Bind(StartDay)
			   .For("Title")
			   .To(vm => vm.StartDay);

			bindingSet.Bind(StartMonth)
			   .For("Title")
			   .To(vm => vm.StartMonth);

			bindingSet.Bind(StartYear)
			  .For("Title")
			  .To(vm => vm.StartYear);

			bindingSet.Bind(EndDay)
			  .For("Title")
			  .To(vm => vm.EndDay);

			bindingSet.Bind(EndMonth)
			  .For("Title")
			  .To(vm => vm.EndMonth);

			bindingSet.Bind(EndYear)
			  .For("Title")
			   .To(vm => vm.EndYear);

			bindingSet.Bind(StatusButton)
			  .For("SelectedSegment")
			   .To(vm => vm.StatusButtonSelectedSegment);

			bindingSet.Bind(TypeText)
				.For("Text")
				.To(vm => vm.TypeText);

			bindingSet.Bind(Page)
				.For("CurrentPage")
				.To(vm => vm.Page);

			bindingSet.Apply();
		}
	}
}

