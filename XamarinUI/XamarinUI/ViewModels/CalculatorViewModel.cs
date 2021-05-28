using Calculator;
using System.Collections.Generic;
using XamarinUI.Views;
using Xamarin.Forms;
using System.Windows.Input;
using Calculator.CustomerFacade.Exceptions;

namespace XamarinUI.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
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

            DeleteEverything = new Command(() => InputString = "");

            CalculateCommand = new Command(() => OnCalculate());

            ViewCommand = new ICommand[] { new Command(OnViewHistory), new Command(OnViewLog) };
        }

        public ICommand DeleteEverything { protected set; get; }

        public ICommand AddCharCommand { protected set; get; }

        public ICommand DeleteCharCommand { protected set; get; }

        public ICommand CalculateCommand { get; }

        public ICommand[] ViewCommand { get; }

        string inputString = "";

        public IEnumerable<Calculator.CustomerFacade.CoreModels.History> HistoryData { get; set; }

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

                App.Current.MainPage.DisplayAlert("Notification",ex.Message,"Ok");
            }
            catch (CalcExceptions ex)
            {
                App.Current.MainPage.DisplayAlert("Notification", ex.Message, "Ok");
            }
            catch (AudExceptions ex)
            {
                App.Current.MainPage.DisplayAlert("Notification", ex.Message, "Ok");
            }
            catch
            {
                App.Current.MainPage.DisplayAlert("Notification", "An error has occurred!", "Ok");

            }

        }
        async void OnViewHistory(object obj)
        {

            await Shell.Current.GoToAsync(nameof(HistoryPage));

        }
        async void OnViewLog(object obj)
        {

            await Shell.Current.GoToAsync(nameof(LogPage));

        }

    }
}
