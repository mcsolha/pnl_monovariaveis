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
    public class SecAurea : Calculating
    {
        public Dados infos;

        string Iterações;

        public event EventHandler<DadosEventData> FinishCalculating;

        public double? Calcular()
        {
            int cont = 1;
            double a = infos.a, mi, lamb, alpha = (-1 + Math.Sqrt(5)) / 2, beta = 1 - alpha, fmi, flamb;
            infos.parser = new ExpressionParser();
            var valueParser = new DoubleValue();
            infos.parser.Values.Add("x", valueParser);
            Iterações += "------- " + infos.func + " -------" + Environment.NewLine;
            mi = infos.a + ((1 - alpha) * (infos.b - infos.a));
            lamb = infos.a + (alpha * (infos.b - infos.a));

            while (infos.b - infos.a > infos.l)
            {
                valueParser.Value = mi;
                fmi = infos.parser.Parse(infos.func);
                valueParser.Value = lamb;
                flamb = infos.parser.Parse(infos.func);
                Iterações += "Iter. " + cont + " ->" + Environment.NewLine;
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
                    lamb = infos.a + (alpha * (infos.b - infos.a));
                }
                else if (fmi < flamb)
                {
                    infos.b = lamb;
                    lamb = mi;
                    mi = infos.a + ((1 - alpha) * (infos.b - infos.a));
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
