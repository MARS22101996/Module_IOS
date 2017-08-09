using MvvmCross.Core.ViewModels;
using VTSClient.Core.Models;
using VTSClient.DAL.Enums;

namespace VTSClient.Core.ViewModels
{
    public class SectionViewModel : MvxViewModel
    {
	    public string Name { get; set; }

        private IMvxCommand _goToVacationsCommand;

	    public IMvxCommand GoToVacationsCommand => _goToVacationsCommand ??
	                                               (_goToVacationsCommand = new MvxCommand(
		                                               () =>
		                                               {
			                                               ShowViewModel<VacationViewModel>(new VacationData()
			                                               {
				                                               VacationStatus = GetTypeOfVacations()
			                                               });
		                                               }));

	    private  FilterEnum GetTypeOfVacations()
        {
            switch (Name)
            {
                case "Closed":
                    return FilterEnum.Closed;
                case "Open":
                    return FilterEnum.Opened;
                default:
                    return FilterEnum.All;
            }
        }
    }
}

