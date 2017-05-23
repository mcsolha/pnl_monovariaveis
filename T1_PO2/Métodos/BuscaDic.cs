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
    public class BuscaDic : Calculating
    {
        public Dados infos;

        string Iterações;

        public event EventHandler<DadosEventData> FinishCalculating;

        public double? Calcular()
        {
            int cont = 1;
            double x, z, fx, fz;
            infos.parser = new ExpressionParser();
            var valueParser = new DoubleValue();
            infos.parser.Values.Add("x", valueParser);
            Iterações += "------- " + infos.func + " -------" + Environment.NewLine;
            while (infos.b - infos.a >= infos.l)
            {
                valueParser.Value = x = ((infos.a + infos.b) / 2) - infos.e;
                fx = infos.parser.Parse(infos.func);
                valueParser.Value = z = ((infos.a + infos.b) / 2) + infos.e;
                fz = infos.parser.Parse(infos.func);

                Iterações += "Iter. " + cont + "->" + Environment.NewLine;
                Iterações += "x = " + x + Environment.NewLine;
                Iterações += "fx = " + fx + Environment.NewLine;
                Iterações += "fz = " + fz + Environment.NewLine;
                if (fx > fz)
                    infos.a = x;
                else
                    infos.b = z;
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
