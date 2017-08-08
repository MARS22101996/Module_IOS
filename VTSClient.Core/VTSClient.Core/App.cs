using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using VTSClient.BLL.Interfaces;
using VTSClient.BLL.Services;
using VTSClient.Core.Infrastructure.Automapper;
using VTSClient.DAL.Interfaces;
using VTSClient.DAL.Repositories;

namespace VTSClient.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            AutoMapperCoreConfiguration.Configure();

            Mvx.RegisterSingleton<IMvxAppStart>(new CustomAppStart());
            			
			Mvx.LazyConstructAndRegisterSingleton<ISqlVacationService,SqlVacationService>();

            Mvx.LazyConstructAndRegisterSingleton<IApiVacationService, ApiVacationService>();

			Mvx.LazyConstructAndRegisterSingleton<IApiRepository, CommonApiRepository>();
		}
    }
}

