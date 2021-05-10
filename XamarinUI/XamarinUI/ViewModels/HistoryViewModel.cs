using System;
using Calculator;
using Exceptions;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XamarinUI.Views;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using Xamarin.Essentials;
using System.Globalization;

namespace XamarinUI.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        public ICommand Clean { get; set; }

        public HistoryViewModel()
        {

            Clean = new Command(() =>CleanHistory()); 

        }
        public static IEnumerable<AppData.History> ReadDataBase()
        {
            return Canculator.IDE.Calculation_history();

        }
        public void CleanHistory()
        {

            Canculator.IDE.Clean_history();

            History.ViewHistoryStackLayout.Children.Clear();

        }
        
    }
}
