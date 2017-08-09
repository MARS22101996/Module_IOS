using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using VTSClient.BLL.Dto;
using VTSClient.DAL.Entities;
using VTSClient.DAL.Enums;
using VTSClient.iOS.Infrastructure;

namespace VTSClient.iOS.Views.VacationTable
{
    public partial class VacationTableViewCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("VacationTableViewCell");
        public static readonly UINib Nib;

        static VacationTableViewCell()
        {
            Nib = UINib.FromName("VacationTableViewCell", NSBundle.MainBundle);
        }

        protected VacationTableViewCell(IntPtr handle) : base(handle)
		{ 
			this.DelayBind(() =>
			{   
                var set = this.CreateBindingSet<VacationTableViewCell, VacationDto>();

				VacationPicture.Image = VacationTypeSetting.GetPicture(VacationType.LeaveWithoutPay);
               
				set.Bind(Date).To(m => m.Period);

				set.Bind(Status).To(m => m.VacationStatus);

				set.Bind(Type).To(m => m.VacationType);
				set.Apply();
			});
        }		
    }
}
