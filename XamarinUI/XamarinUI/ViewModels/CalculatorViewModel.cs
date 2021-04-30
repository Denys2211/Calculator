﻿using System;
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
                InputString = InputString.Substring(0, InputString.Length - 1);
            },
                () =>
                {
                    return InputString.Length > 0;
                });
            CalculateCommand = new Command(() => OnCalculate());

            ViewHistoryCommand = new Command(OnViewHistory);
        }

        public ICommand AddCharCommand { protected set; get; }

        public ICommand DeleteCharCommand { protected set; get; }

        public ICommand CalculateCommand { get; }

        public ICommand ViewHistoryCommand { get; }

        string inputString = "";

        string displayText = "0";

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

        public string DisplayText
        {
             set
            {
                    displayText = value;
                    OnPropertyChanged("DisplayText");
            }
            get { return displayText; }
        }
        

        void OnCalculate()
        {
            try
            {
                double result = Canculator.IDE.Start(inputString);
                DisplayText = "= " + result.ToString();
            }
            catch (DataBExceptions ex)
            {
                DisplayText = ex.Message;
            }
            catch (CalcExceptions ex)
            {
                DisplayText = ex.Message;
            }
            catch (AudExceptions ex)
            {
                DisplayText = ex.Message;
            }
            catch
            {
                DisplayText = "An error has occurred. Repeat the entry!";
            }

        }
         async void OnViewHistory(object obj)
        {

            await Shell.Current.GoToAsync(nameof(History));

        }

    }
}
