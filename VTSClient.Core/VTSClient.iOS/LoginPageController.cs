using Foundation;
using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.Core.ViewModels;

namespace VTSClient.iOS
{
	[MvxFromStoryboard]
	public partial class LoginPageController : MvxViewController
	{
        public LoginPageController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var bindingSet = this.CreateBindingSet<LoginPageController, LoginPageViewModel>();

			bindingSet.Bind(LoginText)
			   .For("Text")
			   .To(vm => vm.LoginTextValue);

			bindingSet.Bind(PasswordText)
			   .For("Text")
			   .To(vm => vm.PasswordTextValue);

			bindingSet.Bind(ErrorText)
				.For("Text")
				.To(vm => vm.ErrorTextValue);

			bindingSet.Bind(ErrorText)
				.For("BackgroundColor")
				.To(vm => vm.ErrorBackgroundColor);

			bindingSet.Bind(SiginButton)
				.To(vm => vm.SignInCommand);

			bindingSet.Apply();
		}
	}
}