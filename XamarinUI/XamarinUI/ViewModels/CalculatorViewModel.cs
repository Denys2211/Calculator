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
    class CalculatorViewModel : BaseViewModel
    {
        public CalculatorViewModel()
        {

            Canculator = new AppCalculator();

            AddCharCommand = new Command<string>((key) =>
            {
                InputString += key;
            });

            DeleteCharCommand = new Command(() =>
            {
                InputString = InputString[0..^1];
            },
                () =>
                {
                    return InputString.Length > 0;
                });

            DeleteEverything = new Command(() => InputString ="");

            CalculateCommand = new Command(() => OnCalculate());

            ViewHistoryCommand = new Command(OnViewHistory);
        }

        public ICommand DeleteEverything { protected set; get; }

        public ICommand AddCharCommand { protected set; get; }

        public ICommand DeleteCharCommand { protected set; get; }

        public ICommand CalculateCommand { get; }

        public ICommand ViewHistoryCommand { get; }

        string inputString = "";

        public IEnumerable<AppData.History> HistoryData { get; set; }

        public string InputString
        {
            protected set
            {
                
                inputString = value;
                OnPropertyChanged("InputString");

                ((Command)DeleteCharCommand).ChangeCanExecute();
               
            }

            get { return inputString; }
        }

        void OnCalculate()
        {
            try
            {
                double result = Canculator.IDE.Start(inputString);
                InputString = result.ToString();
            }
            catch (DataBExceptions ex)
            {

                DisplayMessage(ex.Message);
            }
            catch (CalcExceptions ex)
            {
                DisplayMessage(ex.Message);
            }
            catch (AudExceptions ex)
            {
                DisplayMessage(ex.Message);
            }
            catch
            {
                DisplayMessage("An error has occurred!");
            }

        }
         async void OnViewHistory(object obj)
        {

            await Shell.Current.GoToAsync(nameof(History));

        }

    }
}
