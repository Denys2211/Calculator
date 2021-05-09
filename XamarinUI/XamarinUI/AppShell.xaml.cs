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
            Routing.RegisterRoute(nameof(LogPage), typeof(LogPage));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }

        private async void OnMenuItemClickedAbout(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("AboutPage");
        }
    }
}
