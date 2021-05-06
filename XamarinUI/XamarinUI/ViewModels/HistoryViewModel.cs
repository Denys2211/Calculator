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

        public string TextHistory_Expression { get; set; }

        public string TextHistory_DateTime { get; set; }

        public HistoryViewModel()
        {

            RedDataBase();

            Clean = new Command(() =>CleanHistory()); 

        }
        public void RedDataBase()
        {
            var historyData = Canculator.IDE.Calculation_history();

            foreach (AppData.History row in historyData)
            {
                TextHistory_Expression += $"{row.Id} -> ";

                TextHistory_Expression += $"{row.Expression}";

                TextHistory_Expression += $" = {row.Result}";

                TextHistory_Expression += $"-> {row.DateTime}\n";

                TextHistory_Expression += new string('_', 44) + "\n";


            }
        }
        public void CleanHistory()
        {

            Canculator.IDE.Clean_history();

            TextHistory_Expression = "";
            OnPropertyChanged("TextHistory_Expression");

            TextHistory_DateTime = "";
            OnPropertyChanged("TextHistory_DateTime");

        }
        
    }
}
