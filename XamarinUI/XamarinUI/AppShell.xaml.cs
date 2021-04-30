using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinUI.ViewModels;
using XamarinUI.Views;

namespace XamarinUI
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(History), typeof(History));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
