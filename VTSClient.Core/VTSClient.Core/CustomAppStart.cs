using System;
using MvvmCross.Core.ViewModels;
using VTSClient.Core.Test;
using VTSClient.Core.ViewModels;

namespace VTSClient.Core
{
	public class CustomAppStart
		: MvxNavigatingObject
		, IMvxAppStart
	{
		public void Start(object hint = null)
		{					
			ShowViewModel<SectionsViewModel>();
		}
	}
}
