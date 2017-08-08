using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace VTSClient.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            Mvx.RegisterSingleton<IMvxAppStart>(new CustomAppStart());
        }
    }
}

