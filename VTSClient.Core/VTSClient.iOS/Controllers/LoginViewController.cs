using System;
using System.Threading.Tasks;
using Autofac;
using UIKit;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.iOS.Infrastructure;

namespace VTSClient.iOS.Controllers
{
	public partial class LoginViewController : UIViewController
	{
		private readonly IAccountService _loginService;

		public LoginViewController(IntPtr handle) : base(handle)
		{
			_loginService = IOSSetup.Container.Resolve<IAccountService>();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			SiginButton.TouchUpInside += SigninEvent;
		}

		public override void ViewDidUnload()
		{
			base.ViewDidUnload();

			SiginButton.TouchUpInside -= SigninEvent;
		}

		private async void SigninEvent(object sender, EventArgs e)
		{
			if (!IsFieldsCorrect()) return;

			var status = await LoginUser();
			if (!status) return;

			var board = UIStoryboard.FromName("Main", null);
			var ctrl = board.InstantiateViewController("SplitTableViewController");
			this.PresentViewController(ctrl, true, null);
		}

		private bool IsFieldsCorrect()
		{
			if (string.IsNullOrEmpty(LoginText.Text) || string.IsNullOrEmpty(PasswordText.Text))
			{
				ErrorText.Text = "The login or password is empty!";
				ErrorText.BackgroundColor = UIColor.White;
				return false;
			}
			return true;
		}

		private async Task<bool> LoginUser()
		{
			var loginDto = new LoginDto
			{
				Login = LoginText.Text,
				Password = PasswordText.Text
			};
			var token = await _loginService.Login(loginDto);

			if (string.IsNullOrEmpty(token))
			{
				ErrorText.Text = "The login or password isn't correct!";
				ErrorText.BackgroundColor = UIColor.White;

				return false;
			}

			return true;
		}
	}
}
