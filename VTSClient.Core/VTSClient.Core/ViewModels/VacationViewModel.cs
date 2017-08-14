using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MvvmCross.Core.ViewModels;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.Core.Models;
using VTSClient.DAL.Repositories;
using VTSClient.DAL.Enums;

namespace VTSClient.Core.ViewModels
{
    public class VacationViewModel : MvxViewModel<VacationData>
    {
        private readonly IApiVacationService _vacationService;

        private IEnumerable<VacationCoreModel> _vacations;

	    public MvxObservableCollection<VacationCoreModel> Vacations { get; set; } = new MvxObservableCollection<VacationCoreModel>();

		private IMvxCommand _addCommand;

		public VacationViewModel()
        {
            AutoMapperCoreConfiguration.Configure();

            var repo = new CommonApiRepository();

            _vacationService = new ApiVacationService(repo);
        }

		public IMvxCommand AddCommand => _addCommand ??
										   (_addCommand = new MvxCommand(
											   () =>
											   {
												   ShowViewModel<DetailViewModel>();
											   }));

		public override async Task Initialize(VacationData parameter)
        {
            
        }

        public async Task Init(VacationData parameter)
        {
	        IEnumerable<VacationDto> vacationsDto;
	        if (parameter.VacationStatus != FilterEnum.All)
	        {
		        vacationsDto = await GetFilteredVacations(parameter);
				_vacations = Mapper.Map<IEnumerable<VacationCoreModel>>(vacationsDto);
			}
	        else
	        {
				vacationsDto = await GetAllVacations();
	        }

			_vacations = Mapper.Map<IEnumerable<VacationCoreModel>>(vacationsDto);
	        foreach (var vacation in _vacations)
	        {
		        Vacations.Add(vacation);
	        }
        }

	    private async Task<IEnumerable<VacationDto>> GetFilteredVacations(VacationData parameter)
        {
			var vacations = await _vacationService.FilterVacations(parameter.VacationStatus);

            return vacations;
        }

		private async Task<IEnumerable<VacationDto>> GetAllVacations()
		{
			var vacations = await _vacationService.GetVacationAsync();

			return vacations;
		}
	}
}

