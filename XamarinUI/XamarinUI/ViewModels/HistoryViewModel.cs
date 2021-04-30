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

namespace XamarinUI.ViewModels
{
    class HistoryViewModel : BaseViewModel
    {
        public ICommand Clean { get; set; }

        public string TextHistory_Id { get; set; }

        public string TextHistory_Expression { get; set; }

        public string TextHistory_Result { get; set; }

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
                TextHistory_Id += $"{row.Id}\n";

                TextHistory_Expression += $"{row.Expression}\n";

                TextHistory_Result += $"= {row.Result}\n";

                TextHistory_DateTime += $"{row.DateTime}\n";
            }
        }
        public void CleanHistory()
        {

            Canculator.IDE.Clean_history();

        }
        
    }
}
