using Foundation;
using System;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using VTSClient.Core.ViewModels;

namespace VTSClient.iOS
{
	public partial class LoginPageView : MvxViewController<LoginPageViewModel>
	{

		public LoginPageView() : base("LoginPageView", null)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var bindingSet = this.CreateBindingSet<LoginPageView, LoginPageViewModel>();

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

		//protected void ApplyBindings()
		//{
			//var bindingSet = this.CreateBindingSet<LoginPageView, LoginPageViewModel>();

			//bindingSet.Bind(LoginText)
			//   .For("Text")
			//   .To(vm => vm.LoginTextValue);

			//bindingSet.Bind(PasswordText)
			//   .For("Text")
			//   .To(vm => vm.PasswordTextValue);

			//bindingSet.Bind(ErrorText)
			//	.For("Text")
			//	.To(vm => vm.ErrorTextValue);

			//bindingSet.Bind(ErrorText)
			//	.For("BackgroundColor")
			//	.To(vm => vm.ErrorBackgroundColor);

			//bindingSet.Bind(SiginButton)
			//	.To(vm => vm.SignInCommand);

			//bindingSet.Apply();
		//}
	}
}