using System.Threading.Tasks;
using Autofac;
using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using MvvmCross.Platform;
using VTSClient.Bll.Services;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.Core.Infrastructure.DI;
using VTSClient.DAL.Repositories;

namespace VTSClient.Core.ViewModels
{
	public class LoginPageViewModel : MvxViewModel
	{
		private readonly IAccountService _loginService;

		private IMvxCommand _signInCommand;

        private string _loginTextValue;
        public string LoginTextValue { get{
                return _loginTextValue;
            }  
            set
           {
                _loginTextValue = value;

                RaisePropertyChanged(() => LoginTextValue);
            } }

		public string PasswordTextValue { get; set; }

		public string ErrorTextValue { get;  set; }

		public string ErrorBackgroundColor { get; private set; }

		public LoginPageViewModel()
		{
            AutoMapperCoreConfiguration.Configure();
            var repo = new UserRepository();
			_loginService = new AccountService(repo);
		}

        public IMvxCommand SignInCommand => _signInCommand ??
                    (_signInCommand = new MvxCommand(
                        () =>
                        {
                            if (!IsFieldsCorrect()) return;

                            var status = LoginUser().Result;

                            if (!status) return;

                            ShowViewModel<VacationViewModel>();

                        }));

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
