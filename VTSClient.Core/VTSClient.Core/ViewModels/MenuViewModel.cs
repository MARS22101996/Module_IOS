using MvvmCross.Core.ViewModels;

namespace VTSClient.Core.ViewModels
{
	public class MenuViewModel : MvxViewModel
	{
		public MvxObservableCollection<SectionViewModel> Sections { get; set; } =
			new MvxObservableCollection<SectionViewModel>();

		private IMvxCommand _addCommand;

		public MenuViewModel()
		{
			AddSections();
		}

		private void AddSections()
		{
			Sections.Add(new SectionViewModel { Name = "All" });

			Sections.Add(new SectionViewModel { Name = "Open" });

			Sections.Add(new SectionViewModel { Name = "Closed" });
		}

		public IMvxCommand AddCommand => _addCommand ??
								   (_addCommand = new MvxCommand(
									   () =>
									   {
										   ShowViewModel<DetailViewModel>();
									   }));

	}
}
