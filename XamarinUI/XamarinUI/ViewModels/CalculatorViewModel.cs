using System;
using Calculator;
using Exceptions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using Xamarin.Essentials;

namespace XamarinUI.ViewModels
{
    class CalculatorViewModel : BaseViewModel
    {
        public ICommand AddCharCommand { protected set; get; }

        public ICommand DeleteCharCommand { protected set; get; }

        public ICommand CalculateCommand { get; }

        public AppCalculator Canculator { get; private set; }

        string inputString = "";

        string displayText = "0";

        public string InputString
        {
            protected set
            {
                if (inputString != value)
                {
                    inputString = value;
                    OnPropertyChanged("InputString");
                    DisplayText = inputString;

                    ((Command)DeleteCharCommand).ChangeCanExecute();
                }
            }

            get { return inputString; }
        }

        public string DisplayText
        {
            protected set
            {
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
                }
            }
            get { return displayText; }
        }
        public CalculatorViewModel()
        {

            Canculator = new AppCalculator();

            AddCharCommand = new Command<string>((key) =>
            {
                InputString += key;
            });

            DeleteCharCommand = new Command(() =>
            {
                InputString = InputString.Substring(0, InputString.Length - 1);
            },
                () =>
                {
                    return InputString.Length > 0;
                });
            CalculateCommand = new Command(() => OnCalculate());
        }

        void OnCalculate()
        {
            if (DisplayText != "0")
            {

                double result = Canculator.IDE.Start(DisplayText);
                DisplayText = result.ToString();

            }

        }
    }
}
