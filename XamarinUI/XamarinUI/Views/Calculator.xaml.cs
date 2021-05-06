using System;
using Calculator;
using Exceptions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinUI.ViewModels;
using XamarinUI.Views;

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