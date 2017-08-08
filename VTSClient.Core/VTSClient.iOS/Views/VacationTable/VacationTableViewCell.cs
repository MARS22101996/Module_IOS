using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using VTSClient.BLL.Dto;
using VTSClient.DAL.Entities;

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
				set.Bind(TextDate).To(m => m.CreateDate);
				set.Bind(TextStatus).To(m => m.VacationStatus);
				set.Bind(TextType).To(m => m.VacationType);				
				set.Apply();
			});
        }		
    }
}
