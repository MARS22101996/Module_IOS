using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;


namespace VTSClient.Droid.Activities
{
    [Activity(Label = "Splash Screen", Theme ="@style/MyTheme.Splash", NoHistory = true, MainLauncher = true)]
    public class SplashScreenActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(new Intent(this, typeof(LoginActivity)));
        }
    }
}