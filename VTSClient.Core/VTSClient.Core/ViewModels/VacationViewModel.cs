using System;
using MvvmCross.Core.ViewModels;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.Core.Test;
using VTSClient.DAL.Repositories;
using VTSClient.DataAccess.Enums;

namespace VTSClient.Core.ViewModels
{
    public class VacationViewModel: MvxViewModel
    {
        private readonly IApiVacationService _vacationService;

        public MvxObservableCollection<VacationDto> Vacations { get; set; } = new MvxObservableCollection<VacationDto>();

        public VacationViewModel()
        {
			AutoMapperCoreConfiguration.Configure();

			var repo = new CommonApiRepository();

			_vacationService = new ApiVacationService(repo);

            SetVacations();
        }

        private async void SetVacations()
        {
			var vacations = await _vacationService.GetVacationAsync();

			foreach(var vacation in vacations){
			Vacations.Add(vacation);
            }
        }       		       	
    }
}
