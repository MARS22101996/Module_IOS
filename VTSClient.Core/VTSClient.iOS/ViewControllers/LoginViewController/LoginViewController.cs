using System;
using Autofac;
using UIKit;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Dto;
using VTSClient.iOS.Infrastructure;

namespace VTSClient.iOS.ViewControllers.LoginViewController
{
	public partial class LoginViewController : UIViewController
	{
		private readonly IAccountService _accountService;
		private static IApiVacationService _serviceApi;

		public LoginViewController(IntPtr handle) : base(handle)
		{
			_accountService = IOSSetup.Container.Resolve<IAccountService>();
			_serviceApi = IOSSetup.Container.Resolve<IApiVacationService>();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			TextViewErrorMessage.Text = IOSStrings.LoginViewController.ErrorMessage;
			BindEvents();
		}

		public override void ViewDidUnload()
		{
			base.ViewDidUnload();
			UnbindEvents();
		}

		private async void OnButtonClick(object sender, EventArgs e)
		{
			var loginDto = new LoginDto
			{
				Login = TextFieldLogin.Text,
				Password = TextFieldPassword.Text
			};
			string token = await _accountService.Login(loginDto);

			if (string.IsNullOrEmpty(token))
			{
				TextViewErrorMessage.Hidden = false;
			}
			else
			{
				TextViewErrorMessage.Hidden = true;
				UIStoryboard board = UIStoryboard.FromName(IOSStrings.Storyboard, null);
				UIViewController ctrl = board.InstantiateViewController(IOSStrings.SplitViewControllerName);
				this.PresentViewController(ctrl, true, null);
			}
		}

		private void BindEvents()
		{
			ButtonLogin.TouchUpInside += OnButtonClick;
		}

		private void UnbindEvents()
		{
			ButtonLogin.TouchUpInside -= OnButtonClick;
		}
	}
}