using Calculator;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinUI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUI.Views
{

    public partial class History : ContentPage
    {
        public History()
        {
            InitializeComponent();
            BindingContext = new HistoryViewModel();
        }
    }
}