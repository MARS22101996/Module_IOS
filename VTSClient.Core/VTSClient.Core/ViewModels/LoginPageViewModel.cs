using System.Threading.Tasks;
using Autofac;
using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.Core.Infrastructure.DI;

namespace VTSClient.Core.ViewModels
{
	public class LoginPageViewModel : MvxViewModel
	{
		private readonly IAccountService _loginService;

		private IMvxCommand _signInCommand;

		public string LoginTextValue { get; private set; }

		public string PasswordTextValue { get; private set; }

		public string ErrorTextValue { get; private set; }

		public string ErrorBackgroundColor { get; private set; }

		public LoginPageViewModel()
		{
			_loginService = DISSetup.Container.Resolve<IAccountService>();
		}

		public IMvxCommand SignInCommand
		{
			get
			{
				return _signInCommand ??
					(_signInCommand = new MvxCommand(
						async () =>
						{
							if (!IsFieldsCorrect()) return;

							var status = await LoginUser();

							if (!status) return;



						}));
			}
		}

		private bool IsFieldsCorrect()
		{
			if (string.IsNullOrEmpty(LoginTextValue) || string.IsNullOrEmpty(PasswordTextValue))
			{
				ErrorTextValue = "The login or password is empty!";
				return false;
			}
			return true;
		}

		private async Task<bool> LoginUser()
		{
			var loginDto = new LoginDto
			{
				Login = LoginTextValue,
				Password = PasswordTextValue
			};
			var token = await _loginService.Login(loginDto);

			if (string.IsNullOrEmpty(token))
			{
				ErrorTextValue = "The login or password isn't correct!";
				return false;
			}

			return true;
		}
	}
}
