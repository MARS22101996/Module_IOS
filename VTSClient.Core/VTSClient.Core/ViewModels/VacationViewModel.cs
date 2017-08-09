using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.Core.Models;
using VTSClient.DAL.Repositories;
using VTSClient.DataAccess.Enums;

namespace VTSClient.Core.ViewModels
{
    public class VacationViewModel : MvxViewModel<VacationData>
    {
        private readonly IApiVacationService _vacationService;

        private VacationData _vacationData { get; set; }

        private IEnumerable<VacationDto> _vacations;

        public MvxObservableCollection<VacationDto> Vacations { get; set; } = new MvxObservableCollection<VacationDto>();

        public VacationViewModel()
        {
            AutoMapperCoreConfiguration.Configure();

            var repo = new CommonApiRepository();

            _vacationService = new ApiVacationService(repo);

            //SetVacations();
                      
        }

        private async void SetVacations()
        {
            _vacations = await _vacationService.GetVacationAsync();

            foreach (var vacation in _vacations)
            {
                Vacations.Add(vacation);
            }
        }

        public void Prepare(VacationData parameter)
        {
            _vacationData = parameter;
            //Do anything before navigating to the view
            //Save the parameter to a property if you want to use it later
        }
        public override async Task Initialize(VacationData parameter)
        {
            _vacationData = parameter;
            //Do heavy work and data loading here
        }

        public async Task Init(VacationData parameter)
        {
            // use the parameters here
            if (parameter.VacationStatus != FilterEnum.All)
            {
                //foreach (var vacation in _vacations)
                //{
                //    Vacations.Remove(vacation);
                //}
                _vacations = await GetFilteredVacations(parameter);                                            
            }
            else
            {
				_vacations = await _vacationService.GetVacationAsync();
            }

			foreach (var vacation in _vacations)
			{
				Vacations.Add(vacation);
			}
        }

        public async Task<IEnumerable<VacationDto>> GetFilteredVacations(VacationData parameter)
        {
			var vacations = await _vacationService.FilterVacations(parameter.VacationStatus);

            return vacations;
        }
    }
}

