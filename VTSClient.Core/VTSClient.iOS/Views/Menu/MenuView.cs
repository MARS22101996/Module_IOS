﻿using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.Core.ViewModels;

namespace VTSClient.iOS.Views.Menu
{
	public partial class MenuView : MvxViewController<MenuViewModel>
    {
        public MenuView() : base("MenuView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			var source = new MvxSimpleTableViewSource(SectionTable, "MenuTableViewCell", MenuTableViewCell.Key);
			
            SectionTable.RowHeight = 50;

			var set = this.CreateBindingSet<MenuView, MenuViewModel>();

			set.Bind(source).To(vm => vm.Sections);

			set.Apply();

			SectionTable.Source = source;

			SectionTable.ReloadData();

			NavigationItem.RightBarButtonItem = new UIBarButtonItem(UIBarButtonSystemItem.Add);
		}
    }
}

