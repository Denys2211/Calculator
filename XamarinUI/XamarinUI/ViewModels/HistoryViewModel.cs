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
using System.Collections.ObjectModel;

namespace XamarinUI.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        public ICommand Clean { get; set; }

        public ObservableCollection<AppData.History> ListHistory { get; private set; }

        public HistoryViewModel()
        {

            Clean = new Command(() =>CleanHistory());

            ListHistory = ReadDataBase();

        }
        public ObservableCollection<AppData.History> ReadDataBase()
        {

            ObservableCollection<AppData.History> historyReverse = new ObservableCollection<AppData.History>(Canculator.IDE.Calculation_history().Reverse());
            
            return historyReverse;

        }
        public void CleanHistory()
        {

            Canculator.IDE.Clean_history();
            ListHistory.Clear();

        }
        
    }
}
