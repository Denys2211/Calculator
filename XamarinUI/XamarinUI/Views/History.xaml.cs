using Calculator;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinUI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace XamarinUI.Views
{

    public partial class History : ContentPage
    {
        public static StackLayout ViewHistoryStackLayout { get; private set; }

        public History()
        {
            InitializeComponent();

            ViewHistoryStackLayout = new StackLayout();
            foreach (AppData.History row in HistoryViewModel.ReadDataBase())
            {
                Label label = new Label {
                    Margin = new Thickness(0, 0, 23, -10),
                    Text = $"-{row.Id}-{new string(' ', 55)}{row.DateTime}",
                    FontSize = 14,
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.End,
                };

                Frame frame = new Frame
                {
                    Margin = new Thickness(10, 10, 10, 0),
                    Padding = new Thickness(10, 10, 10, 10),
                    BorderColor = Color.Gray,
                    BackgroundColor = Color.WhiteSmoke,
                    CornerRadius = 20,
                    HasShadow = true,
                    Content = new Label
                    {
                        Text = $"{row.Expression} = {row.Result}",
                        FontSize = 16,
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Center,
                    }
                };
                ViewHistoryStackLayout.Children.Add(label);
                ViewHistoryStackLayout.Children.Add(frame);
            }
            RefreshView refreshView = new RefreshView();
            ICommand refreshCommand = new Command(() =>
            {
                refreshView.IsRefreshing = false;
            });
            refreshView.Command = refreshCommand;

            ScrollView scrollView = new ScrollView
            {
                Content = ViewHistoryStackLayout
            };
            refreshView.Content = scrollView;
            this.Content = refreshView;
        }
       
    }
}