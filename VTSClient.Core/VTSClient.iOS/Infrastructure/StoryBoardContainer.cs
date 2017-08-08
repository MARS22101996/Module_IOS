using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.Core.ViewModels;
using UIKit;

namespace VTSClient.iOS.Infrastructure
{
	//public class StoryBoardContainer : MvxTouchViewsContainer
	//{
	//	protected override IMvxTouchView CreateViewOfType(Type viewType, MvxViewModelRequest request)
	//	{
	//		UIStoryboard storyboard;
	//		try
	//		{
	//			storyboard = UIStoryboard.FromName(viewType.Name, null);
	//		}
	//		catch (Exception)
	//		{
	//			storyboard = UIStoryboard.FromName("StoryBoard", null);
	//		}
	//		return (IMvxTouchView)storyboard.InstantiateViewController(viewType.Name);
	//	}
	//}
}