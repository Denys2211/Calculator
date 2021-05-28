using System;
using System.Linq;
using Xamarin.Forms;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Calculator.CustomerFacade.CoreModels;

namespace XamarinUI.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        public ICommand Clean { get; set; }

        public ObservableCollection<History> ListHistory { get; private set; }

        public HistoryViewModel()
        {

            Clean = new Command(() => CleanHistory());

            ListHistory = ReadDataBase();

        }
        public ObservableCollection<History> ReadDataBase()
        {

            ObservableCollection<History> historyReverse = new ObservableCollection<History>(Canculator.IDE.Calculation_history().Reverse());
            
            return historyReverse;

        }
        public void CleanHistory()
        {

            Canculator.IDE.Clean_history();
            ListHistory.Clear();

        }
        
    }
}
