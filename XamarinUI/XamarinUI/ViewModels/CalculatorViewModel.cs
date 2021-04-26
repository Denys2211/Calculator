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
		//private string Expression { get; set; }

		public CalculatorViewModel()
        {
            Title = "Calculator";
		}
		//void OnSelectNumber(object sender, EventArgs e)
		//{

		//	Button button = (Button)sender;
		//	string pressed = button.Text;
		//	Expression += pressed;
		
		//		resultText.Text = Expression;

		//}

		//void OnCalculate(object sender, EventArgs e)
		//{
		//	if (resultText.Text != "0")
		//	{
		//		AppCalculator Canculator = new AppCalculator();
		//		double result = Canculator.IDE.Start(resultText.Text);
		//		resultText.Text = result.ToString();
		//		Expression = resultText.Text;

		//	}

		//}
		//void OnClear(object sender, EventArgs e)
		//{
		//	Expression = "";
		//	resultText.Text = "0";

		//}
	}
}
