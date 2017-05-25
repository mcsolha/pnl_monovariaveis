using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1_PO2.Data;
using T1_PO2.Helpers;

namespace T1_PO2.Métodos
{
    public class Newton : Derivadas, Calculating
    {
        string Iterações;

        public event EventHandler<DadosEventData> FinishCalculating;

        public double MaiorValor(double a)
        {
            if (a > 1)
                return a;
            else
                return 1;
        }

        public double? Calcular()
        {
            int cont = 0;
            double x = infos.a, x_ = infos.a, f_ = Derivada_1(x_), f__ = Derivada_2(x_);
            Iterações += "------- " + infos.func + " -------" + Environment.NewLine;


            Iterações += "b = " + infos.b + Environment.NewLine;

            do
            {
                Iterações += "Iter. " + (cont + 1) + " ->" + Environment.NewLine;
                Iterações += "x[" + cont + "]" + "=" + x + Environment.NewLine;
                x = x_;
                x_ = x_ - (f_ / f__);
                Iterações += "x[" + (cont + 1) + "]" + "=" + x_ + Environment.NewLine;
                f_ = Derivada_1(x_);
                Iterações += "fx[" + (cont + 1) + "]" + "=" + x_ + Environment.NewLine;
                Iterações += "f'x[" + (cont + 1) + "]" + "=" + f_ + Environment.NewLine;
                f__ = Derivada_2(x_);

                cont++;
            }
            while (Math.Abs(f_) >= infos.e && (Math.Abs(x_ - x) / MaiorValor(x_)) >= infos.e);
            OnFinishCalculating();
            return x_;
        }

        public void OnFinishCalculating()
        {
            FinishCalculating?.Invoke(this, new DadosEventData() { Type = this.GetType(), Log = Iterações });
        }
    }
}
