using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.Core.ViewModels;

namespace VTSClient.iOS.Views.Login
{
    public partial class LoginView : MvxViewController<LoginPageViewModel>
    {
        public LoginView() : base("LoginView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            ApplyBindings();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

		protected void ApplyBindings()
		{

			var bindingSet = this.CreateBindingSet<LoginView, LoginPageViewModel>();

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

			bindingSet.Bind(SigninButton)
			  .To(vm => vm.SignInCommand);

			bindingSet.Apply();
		}
    }
}

