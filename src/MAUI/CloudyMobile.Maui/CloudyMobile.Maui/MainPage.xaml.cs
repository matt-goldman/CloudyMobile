using System;
using CloudyMobile.Maui.Pages.Phone;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace CloudyMobile.Maui
{
	public partial class MainPage : ContentPage, IPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		public void OnAddBatchClicked(object sender, EventArgs e)
        {
			Navigation.PushAsync(new AddBatchPage());
        }

		public void OnViewRecipeClicked(object sender, EventArgs e)
		{

		}

		public void OnViewKegClicked(object sender, EventArgs e)
		{

		}
	}
}
