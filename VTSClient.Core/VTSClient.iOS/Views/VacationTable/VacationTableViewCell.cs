using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using VTSClient.BLL.Dto;
using VTSClient.DAL.Entities;
using VTSClient.iOS.Infrastracture;

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
			//var imageViewLoader = new MvxImageViewLoader(() => monkeyImage);

			// Note: this .ctor should not contain any initialization logic.
			this.DelayBind(() =>
			{   
                var set = this.CreateBindingSet<VacationTableViewCell, VacationDto>();
				this.VacationPicture.Image = VacationTypeSetting.GetPicture(DataAccess.Enums.VacationType.LeaveWithoutPay);				
                //set.Bind(VacationPicture).To(m => VacationTypeSetting.GetPicture(m.VacationType));
				set.Bind(Date).To(m => m.Period);
				set.Bind(Status).To(m => m.VacationStatus);
				set.Bind(Type).To(m => m.VacationType);				
				set.Apply();
			});
        }		
    }
}
