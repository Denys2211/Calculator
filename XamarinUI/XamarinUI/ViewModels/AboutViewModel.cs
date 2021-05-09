using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinUI.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand[] OpenWebCommands { get; }
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommands = new ICommand[] { new Command(async () => await Browser.OpenAsync("https://www.instagram.com/tsurkanovsky/?hl=ru")),
            new Command(async () => await Browser.OpenAsync("https://www.facebook.com/denis.tsurkanovskyy")) };
        }

    }
}