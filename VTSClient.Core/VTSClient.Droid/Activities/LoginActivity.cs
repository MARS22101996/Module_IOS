using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using Autofac;
using VTSClient.BLL.Dto;
using VTSClient.BLL.Interfaces;
using VTSClient.Droid.Autofac;

namespace VTSClient.Droid.Activities
{
	[Activity(Label = "LoginActivity", Theme = "@style/MyTheme.Login")]
	public class LoginActivity : AppCompatActivity
	{
		private Button _buttonSignIn;
		private TextView _login, _password, _error;

		private IAccountService _loginService;

		private bool IsValid
		{
			get
			{
				var color = ContextCompat.GetColor(this, Resource.Color.white_back);

				if (string.IsNullOrEmpty(_login.Text))
				{
					_error.Text = "The login is empty!";
					_error.Background = new ColorDrawable(new Color(color));
					return false;
				}

				if (!string.IsNullOrEmpty(_password.Text)) return true;
				_error.Text = "The password is empty!";
				_error.Background = new ColorDrawable(new Color(color));
				return false;
			}
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			_loginService = AutofacSetting.Container.Resolve<IAccountService>();
			SetContentView(Resource.Layout.LoginView);

			_buttonSignIn = FindViewById<Button>(Resource.Id.buttonSignIn);
			_login = FindViewById<TextView>(Resource.Id.login);
			_password = FindViewById<TextView>(Resource.Id.password);
			_error = FindViewById<TextView>(Resource.Id.errorText);

			BindEvents();
		}

		protected override void OnDestroy()
		{
			UnbindEvents();
			base.OnDestroy();
		}

		private async void OrderButton_Click(object sender, EventArgs e)
		{
			if (!IsValid) return;
			var user = new LoginDto
			{
				Login = _login.Text,
				Password = _password.Text
			};
			var tocken = await _loginService.Login(user);
			if (string.IsNullOrEmpty(tocken))
			{
				_error.Text = "Login or password isn't correct";
				_error.Background = new ColorDrawable(Color.White);
			}
			else
			{
				//StartActivity(new Intent(this, typeof(MainScreenActivity)));
			}
		}

		private void BindEvents()
		{
			_buttonSignIn.Click += OrderButton_Click;
		}

		private void UnbindEvents()
		{
			_buttonSignIn.Click -= OrderButton_Click;
		}
	}
}