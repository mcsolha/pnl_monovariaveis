using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3_MNC_BarbaraMatheusLuizG
{
    public partial class Form1 : Form
    {
        public delegate double PassaFun(double x);
        PassaFun funparam;
        public Form1()
        {
            InitializeComponent();
            this.Text = "T3 - Barbara C. - Luiz G. - Matheus S.";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private double Sec(double x)
        {
            return 1 / Math.Cos(x);
        }

        private double Cossec(double x)
        {
            return 1 / Math.Sin(x);
        }

        private double Cotan(double x)
        {
            return 1 / Math.Tan(x);
        }

        private void Calc_Click(object sender, EventArgs e)
        {
            double x = 0;
            int erro = 0;
            if(!double.TryParse(xbox.Text,out x))
            {
                xbox.Text = "Insira um valor válido";
                xbox.SelectAll();
                xbox.Focus();
            }
            switch (funcs.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Name)
            {
                case "exp":
                    funparam = Math.Exp;
                    break;
                case "ln":
                    funparam = Math.Log;
                    break;
                case "sin":
                    funparam = Math.Sin;
                    break;
                case "cos":
                    funparam = Math.Cos;
                    break;
                case "tan":
                    funparam = Math.Tan;
                    break;
                case "sec":
                    funparam = Sec;
                    break;
                case "cossec":
                    funparam = Cossec;
                    break;
                case "cotan":
                    funparam = Cotan;
                    break;
                case "asin":
                    funparam = Math.Asin;
                    break;
                case "acos":
                    funparam = Math.Acos;
                    break;
                case "atan":
                    funparam = Math.Atan;
                    break;
                case "sinh":
                    funparam = Math.Sinh;
                    break;
                case "cosh":
                    funparam = Math.Cosh;
                    break;
                case "tanh":
                    funparam = Math.Tanh;
                    break;
                case "sqrt":
                    funparam = Math.Sqrt;
                    break;
                default:
                    funparam = ApresentaErro;
                    break;
            }
            switch (derivs.SelectedIndex)
            {
                case 0:
                    resultbox.Text = Derivadas.Derivada_1(funparam, x,out erro).ToString();
                    break;
                case 1:
                    resultbox.Text = Derivadas.Derivada_2(funparam, x, out erro).ToString();
                    break;
                case 2:
                    resultbox.Text = Derivadas.Derivada_3(funparam, x, out erro).ToString();
                    break;
            }
        }

        private double ApresentaErro(double x)
        {
            resultbox.Text = "Selecione uma função";
            return 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            derivs.SelectedIndex = 0;
            (funcs.Controls[0] as RadioButton).Checked = true;
        }
    }
    public static class Derivadas
    {
        public static double Derivada_1(Form1.PassaFun funcParam, double _x, out int erro)
        {
            erro = 0;
            double h = 0.5;
            double fx_linha = 0, auxfx_linha = 0;
            do
            {
                auxfx_linha = fx_linha;
                fx_linha = (funcParam(_x + h) - funcParam(_x - h)) / (2 * h);
                h /= 2;
            } while ((Math.Abs(fx_linha) - Math.Abs(auxfx_linha)) > 0.0000001);

            return fx_linha;
        }

        public static double Derivada_2(Form1.PassaFun funcParam, double _x, out int erro)
        {
            erro = 0;
            double h = 0.5;
            double fx_linha = 0, auxfx_linha = 0;
            do
            {
                auxfx_linha = fx_linha;
                fx_linha = (funcParam(_x + (2*h)) - (2*funcParam(_x)) + funcParam(_x - (2*h))   ) / (4 * Math.Pow(h,2));
                h /= 2;
            } while ((Math.Abs(fx_linha) - Math.Abs(auxfx_linha)) > 0.0000001);

            return fx_linha;
        }

        public static double Derivada_3(Form1.PassaFun funcParam, double _x, out int erro)
        {
            erro = 0;
            double h = 0.5;
            double fx_linha = 0, auxfx_linha = 0;
            do
            {
                auxfx_linha = fx_linha;
                fx_linha = (funcParam(_x + (3*h)) - (3*funcParam(_x + h)) + (3*funcParam(_x - h)) - funcParam(_x - (3*h))) / (8 * Math.Pow(h, 3));
                h /= 2;
            } while ((Math.Abs(fx_linha) - Math.Abs(auxfx_linha)) > 0.0000001);

            return fx_linha;
        }
    }
}
