//using System;
//using MvvmCross.Binding.BindingContext;
//using MvvmCross.Core.ViewModels;
//using MvvmCross.iOS.Views;
//using UIKit;
//using VTSClient.Core.ViewModels;

//namespace VTSClient.iOS.Views
//{
//    public partial class LoginPageViewController : MvxViewController<LoginPageViewModel>
//    {
//        public LoginPageViewController() : base("LoginPageViewController", null)
//        {
            
//        }


//        public override void DidReceiveMemoryWarning()
//        {
//            base.DidReceiveMemoryWarning();
//            // Release any cached data, images, etc that aren't in use.
//        }

//		public override void ViewDidLoad()
//		{
//			base.ViewDidLoad();

//            //ApplyBindings();
//		}

//        protected void ApplyBindings()
//        {

//			//var bindingSet = this.CreateBindingSet<LoginPageViewController, LoginPageViewModel>();

//			//bindingSet.Bind(LoginText)
//			//   .For("Text")
//			//   .To(vm => vm.LoginTextValue);

//			//bindingSet.Bind(PasswordText)
//			//   .For("Text")
//			//   .To(vm => vm.PasswordTextValue);

//			//bindingSet.Bind(ErrorText)
//			//	.For("Text")
//			//	.To(vm => vm.ErrorTextValue);

//			//bindingSet.Bind(ErrorText)
//			//	.For("BackgroundColor")
//			//	.To(vm => vm.ErrorBackgroundColor);

//			//bindingSet.Bind(SigninButton)
//			//	.To(vm => vm.SignInCommand);

//			//bindingSet.Apply();
//        }

//        public override void ViewDidAppear(bool animated)
//        {
//            base.ViewDidAppear(animated);
//        }
//    }
//}

