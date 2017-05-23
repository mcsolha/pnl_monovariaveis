using info.lundin.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1_PO2.Data;
using T1_PO2.Helpers;

namespace T1_PO2.Métodos
{
    public class Fibonacci : Calculating
    {
        public Dados infos;

        string Iterações;

        double[] fib = new double[30];
        int n = 1;

        public event EventHandler<DadosEventData> FinishCalculating;

        public double F(double parada)
        {
            fib[0] = 1;
            fib[1] = 1;
            do
            {
                n++;
                fib[n] = fib[n - 2] + fib[n - 1];
            } while (fib[n] < parada);
            return fib[n];
        }

        public double? Calcular()
        {
            int cont = 0;
            double fn = F((infos.b - infos.a) / infos.l);
            double mi = infos.a + ((fib[n - cont - 2] / fib[n - cont]) * (infos.b - infos.a)),
                lamb = infos.a + ((fib[n - cont - 1] / fib[n - cont]) * (infos.b - infos.a)),
                fmi, flamb;

            infos.parser = new ExpressionParser();
            var valueParser = new DoubleValue();
            infos.parser.Values.Add("x", valueParser);
            Iterações += "------- " + infos.func + " -------" + Environment.NewLine;

            while (cont < n - 1 && Math.Abs(infos.b - infos.a) > infos.l)
            {
                valueParser.Value = mi;
                fmi = infos.parser.Parse(infos.func);
                valueParser.Value = lamb;
                flamb = infos.parser.Parse(infos.func);
                Iterações += "Iter. " + (cont + 1) + " ->" + Environment.NewLine;
                Iterações += "a = " + infos.a + Environment.NewLine;
                Iterações += "b = " + infos.b + Environment.NewLine;
                Iterações += "mi = " + mi + Environment.NewLine;
                Iterações += "fmi = " + fmi + Environment.NewLine;
                Iterações += "lamb = " + lamb + Environment.NewLine;
                Iterações += "flamb = " + flamb + Environment.NewLine;

                if (fmi > flamb)
                {
                    infos.a = mi;
                    mi = lamb;
                    lamb = infos.a + ((fib[n - cont - 1] / fib[n - cont]) * (infos.b - infos.a));
                }
                else if (fmi < flamb)
                {
                    infos.b = lamb;
                    lamb = mi;
                    mi = infos.a + ((fib[n - cont - 2] / fib[n - cont]) * (infos.b - infos.a));
                }
                cont++;
            }
            OnFinishCalculating();
            return (infos.a + infos.b) / 2;
        }

        public void OnFinishCalculating()
        {
            FinishCalculating?.Invoke(this, new DadosEventData() { Type = this.GetType(), Log = Iterações });
        }
    }

}
