using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinUI.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        readonly ICommand[] OpenWebCommands;
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommands = new ICommand[] { new Command(async () => await Browser.OpenAsync("https://www.instagram.com/tsurkanovsky/?hl=ru")),
            new Command(async () => await Browser.OpenAsync("https://www.facebook.com/denis.tsurkanovskyy")), };
        }

        public ICommand OpenWebCommand1 { get => OpenWebCommands[0]; }

        public ICommand OpenWebCommand2 { get => OpenWebCommands[1]; }
    }
}