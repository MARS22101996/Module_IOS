using System;
using MvvmCross.Core.ViewModels;
using VTSClient.Core.ViewModels;
using VTSClient.DAL.Enums;

namespace VTSClient.Core.Models
{
	public class VacationCoreModel : MvxViewModel
	{
		public Guid Id { get; set; }

		public DateTime Start { get; set; }

		public DateTime End { get; set; }

		public DateTime CreateDate { get; set; }

		public string CreatedBy { get; set; }

		public VacationStatus VacationStatus { get; set; }

		public VacationType VacationType { get; set; }

		public virtual string Period => $"{Start.Date:d} - {End.Date:d}";


		private IMvxCommand _detailCommand;

		public virtual string ImageUrl => GetBoundle(VacationType);

		private string GetBoundle(VacationType type)
		{
			switch (type)
			{
				case VacationType.Regular:
					return "Icon_Request_Green";

				case VacationType.Exceptional:
					return "Icon_Request_Gray";

				case VacationType.Sick:
					return "Icon_Request_Plum";

				case VacationType.Overtime:
					return "Icon_Request_Blue";

				default:
					return "Icon_Request_Dark";
			}
		}

		public IMvxCommand DetailCommand => _detailCommand ??
		                                    (_detailCommand = new MvxCommand(
			                                    () =>
			                                    {
				                                    ShowViewModel<DetailViewModel>(new VacationData
				                                    {
					                                    Id = Id
				                                    });
			                                    }));

	}
}
