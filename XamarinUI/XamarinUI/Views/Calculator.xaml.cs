using System;
using Xamarin.Forms;
using XamarinUI.ViewModels;

namespace XamarinUI.Views
{
    public partial class Calculator : ContentPage
    {
		public Calculator()
        {
            InitializeComponent();

            BaseViewModel.DisplayMessage += (mess) => DisplayAlert("Notification", $"{mess}", "ОK");
		}

        
    }
}