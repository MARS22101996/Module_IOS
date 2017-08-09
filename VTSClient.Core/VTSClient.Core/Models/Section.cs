using System;
using MvvmCross.Core.ViewModels;
using VTSClient.Core.ViewModels;
using VTSClient.DataAccess.Enums;

namespace VTSClient.Core.Models
{
    public class Section : MvxViewModel
    {
        public string Name { get; set; }

        private IMvxCommand _goToVacationsCommand;

        public IMvxCommand GoToVacationsCommand => _goToVacationsCommand ??
                                                   (_goToVacationsCommand = new MvxCommand(
                                                       () =>
                                                       {
                                                           ShowViewModel<VacationViewModel>(new VacationData()
                                                           {
                                                               VacationStatus = GetType()
                                                           });
                                                       }));

        public FilterEnum GetType()
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

