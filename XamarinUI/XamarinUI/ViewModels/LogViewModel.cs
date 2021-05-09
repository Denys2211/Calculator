﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinUI.Views;

namespace XamarinUI.ViewModels
{
    public class LogViewModel : BaseViewModel
    {
        public ICommand CleanLog { get; protected set; }
        public string TextLog { get; set; }

        public LogViewModel()
        {

            ReadLog();

            CleanLog = new Command(() => Clean());

        }
        public void ReadLog()
        {
            var log = Canculator.IDE.ReadLogger();

            TextLog = $" {log}\n";

        }
        public void Clean()
        {

            Canculator.IDE.Clean_Log();
            TextLog = "";
            OnPropertyChanged("TextLog");

        }
    }
}
