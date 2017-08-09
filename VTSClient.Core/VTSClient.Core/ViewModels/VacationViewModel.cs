using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.Core.Models;
using VTSClient.Core.Test;
using VTSClient.DAL.Repositories;
using VTSClient.DataAccess.Enums;

namespace VTSClient.Core.ViewModels
{
    public class VacationViewModel: MvxViewModel<VacationData>
    {
        private readonly IApiVacationService _vacationService;

	    private VacationData _vacationData { get; set; }

        public MvxObservableCollection<VacationDto> Vacations { get; set; } = new MvxObservableCollection<VacationDto>();

        public VacationViewModel()
        {
			AutoMapperCoreConfiguration.Configure();

			var repo = new CommonApiRepository();

			_vacationService = new ApiVacationService(repo);

            SetVacations();

	        var test = _vacationData;
        }

	    private async void SetVacations()
	    {
		    var vacations = await _vacationService.GetVacationAsync();

		    foreach (var vacation in vacations)
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

		public  void Init(VacationData parameter)
		{
			// use the parameters here
			if (parameter.VacationStatus == FilterEnum.Closed)
			{
				
			}
		}
	}
}
