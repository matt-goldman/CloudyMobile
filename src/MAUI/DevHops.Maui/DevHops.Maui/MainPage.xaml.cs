using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using DevHops.Maui.ViewModels;

namespace DevHops.Maui
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainViewModel viewModel)
		{
			InitializeComponent();
			viewModel.Navigation = Navigation;
			BindingContext = viewModel;
		}
	}
}
