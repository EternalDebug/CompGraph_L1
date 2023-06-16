using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Laba1
{
	public partial class Form1 : Form
	{
		private Graphics g;

		public delegate double Fnc(double x);

		Fnc func;
		double a = 0;
		double b = 0;
		int det = 0;
		double h = 0;
		double sootnX = 0;

		public Form1()
		{
			InitializeComponent();
			g = this.CreateGraphics();
		}

		//1
		public double sx(double x)
		{
			return Math.Sin(x);
		}

		//2
		public double xq(double x)
		{
			return x*x;
		}

		//3
		public double third(double x)
		{
			return x * x * x;
		}

		private void Label2_Click(object sender, EventArgs e)
		{

		}

		private void Button1_Click(object sender, EventArgs e)
		{
			//g.Clear(Color.FromArgb(0, 0, 0, 0));
			a = double.Parse(textBox1.Text);
			b = double.Parse(textBox2.Text);
			det = int.Parse(textBox4.Text);
			h = (b - a) / det;
			sootnX = Width / (b - a);


			Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
			//g.DrawLine(pen, 0, Height / 2, Width, Height / 2);
			if (a<0 && b >0)
				g.DrawLine(pen, Width/2 - (int)(sootnX * (a+b)/2), 0, Width / 2 - (int)(sootnX * (a + b) / 2), this.Height);
			else
			{
				if (a == 0)
					g.DrawLine(pen, 0, 0, 0, this.Height);
				else
				if (b == 0)
					g.DrawLine(pen, Width, 0, Width, this.Height);
			}
			//реализовать параметры смещения осей. Нужен для расчета координат в отрисовке

			DrawThisFunc();

		}

		private void DrawThisFunc()
		{
			Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
			//double[] Xpoints = new double[21];
			//double[] Ypoints = new double[21];
			List<double> Xpoints = new List<double>();
			List<double> Ypoints = new List<double>();
			for (int i = 0; i <= det; i++)
			{
				//Xpoints[i] = a + h * i;
				Xpoints.Add(a + h * i);
				//Ypoints[i] = func(Xpoints[i]);
				Ypoints.Add(func(Xpoints[i]));
			}

			var yMin = Ypoints.Min();
			var yMax = Ypoints.Max();

			double sootnY = (Height / (yMax - yMin))*0.9;

			if (yMin < 0 && yMax > 0)
				g.DrawLine(pen, 0, Height/2 + (int)(sootnY * (yMax + yMin) / 2) -41, Width, Height / 2 + (int)(sootnY * (yMax + yMin) / 2) - 41);
			else
			{
				if (yMin == 0)
					g.DrawLine(pen, 0, Height, Width, Height);
				else
				if (b == 0)
					g.DrawLine(pen, 0, 0, Width, 0);
			}

			
			double aa = a;
			double x = a * sootnX;
			//double y = func(a) * sootnY;
			for (int i = 0; i< det; i++)
			{
				g.DrawLine(pen, (int)((Xpoints[i] - a)*sootnX) - 8, Height - 41 - (int)((Ypoints[i] - yMin)*sootnY), (int)((Xpoints[i+1] - a) * sootnX) -8, Height- 41 - (int)((Ypoints[i+1] - yMin) * sootnY));
			}
		}

		//селектор функции. Очень кустарный
		private void TextBox3_TextChanged(object sender, EventArgs e)
		{
			if (textBox3.Text == "1")
				func = sx;
			else
			if (textBox3.Text == "2")
				func = xq;
			else
			if (textBox3.Text == "3")
				func = third;
			else
				func = third;
		}

		private void TextBox1_TextChanged(object sender, EventArgs e)
		{
			//a = double.Parse(textBox1.Text);
			//h = (b - a) / det;
			//sootnX = Width / (b - a);
		}

		private void TextBox2_TextChanged(object sender, EventArgs e)
		{
		//	b = double.Parse(textBox2.Text);
			//h = (b - a) / det;
			//sootnX = Width / (b - a);
		}

		private void TextBox4_TextChanged(object sender, EventArgs e)
		{
			//det = int.Parse(textBox4.Text);
			//h = (b - a) / det;
			//sootnX = Width / (b - a);

			//Если раскомментить, то будет лажа с парсингом минусов
		}
	}
}
