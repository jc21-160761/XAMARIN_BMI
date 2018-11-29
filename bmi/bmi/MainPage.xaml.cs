using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace bmi
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			btn.Clicked += keisan;
		}

		private void keisan(object sender, EventArgs e)
		{
			double s=0, t=0;
			int flag = 0, flag2 = 0;
			String kekka = "", errstc = "";

			try
			{
				s = double.Parse(sin.Text);
				if (s <= 0 || s > 272)
				{
					flag += 3;
					errstc += "S001\n";
				}
				s = s / 100;
			}
			catch (FormatException)
			{
				flag2++;
			}

			try
			{
				t = double.Parse(tai.Text);
				if (t <= 0 || t > 300)
				{
					flag += 3;
					errstc += "T001\n";
				}
			}
			catch (FormatException)
			{
				flag2++;
			}

			if (flag > 0)
			{
				kekka += "入力値エラー\n";
				kekka += errstc;
			}

			if (flag2 > 0)
			{
				if (flag == 0)
				{
					kekka += "入力値エラー\n";
				}
				kekka += "N001";
			}
			else if (flag == 0)
			{
				double stac = Math.Round(t / (s * s), 1);
				kekka = stac.ToString() + "\n" + bmi(stac);

			}

			lbl.Text = kekka;

		}
		private String bmi(double stac)
		{
			String st = "";
			if (stac < 18.5)
			{
				st = "低体重(痩せ型)";
			}
			else if (stac < 25)
			{
				st = "普通体重";
			}
			else if (stac < 30)
			{
				st = "肥満(1度)";
			}
			else if (stac < 35)
			{
				st = "肥満(2度)";
			}
			else if (stac < 40)
			{
				st = "肥満(3度)";
			}
			else
			{
				st = "肥満(4度)";
			}
			return st;
		}

	}
}
