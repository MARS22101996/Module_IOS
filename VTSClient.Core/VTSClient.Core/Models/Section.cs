using System;
using MvvmCross.Core.ViewModels;
using VTSClient.Core.ViewModels;

namespace VTSClient.Core.Models
{
    public class Section: MvxViewModel
    {
		public string Name { get; set; }

		private IMvxCommand _goToVacationsCommand;

		public IMvxCommand GoToVacationsCommand => _goToVacationsCommand ??
		   (_goToVacationsCommand = new MvxCommand(
			   () =>
			   {
				   ShowViewModel<VacationViewModel>();

			   }));
    }
}
