using System;
using System.Collections.Generic;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using VTSClient.Core.Models;
using VTSClient.DataAccess.Enums;

namespace VTSClient.Core.ViewModels
{
	public class SectionsViewModel : MvxViewModel
	{
		public MvxObservableCollection<Section> Sections { get; set; } = new MvxObservableCollection<Section>();

		public SectionsViewModel()
		{		

			Sections.Add(new Section {Name = "All"});

			Sections.Add(new Section {Name = "Open"});

			Sections.Add(new Section {Name = "Closed"});
		}

	}
}
