﻿using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;
using VTSClient.Core.Test;
using VTSClient.iOS.Views.Vacations.CustomCells;

namespace MonkeyList.Core.iOS
{
    public partial class MonkeysView : MvxViewController<MonkeysViewModel>
    {
        public MonkeysView() : base("MonkeysView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.Title = "Monkeys";

            var source = new MvxSimpleTableViewSource(MonkeyTableView, "MonkeyCell", MonkeyCell.Key);
            MonkeyTableView.RowHeight = 130;

            var set = this.CreateBindingSet<MonkeysView, MonkeysViewModel>();
            set.Bind(source).To(vm => vm.Monkeys);
            set.Apply();

            MonkeyTableView.Source = source;
            MonkeyTableView.ReloadData();
        }
    }
}

