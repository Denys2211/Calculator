using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinUI.Views;

namespace XamarinUI.ViewModels
{
    public class LogViewModel : BaseViewModel
    {

        public string TextLog { get; set; }

        public LogViewModel()
        {

            ReadLog();

        }
        public void ReadLog()
        {
            var log = Canculator.IDE.ReadLogger();
           
                TextLog = $" {log}\n";

        }
        public void CleanHistory()
        {

           
            OnPropertyChanged("TextHistory_Expression");

        }
    }
}
