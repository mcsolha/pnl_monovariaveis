using info.lundin.math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T1_PO2.Data;
using T1_PO2.Helpers;

namespace T1_PO2.Métodos
{
    public class BuscaUniforme : Calculating
    {
        public Dados dados;        

        public string Iterações;

        public event EventHandler<DadosEventData> FinishCalculating;

        public double? Calcular()
        {
            int cont = 0;
            double fx,fxk,x;
            bool refinou = false;
            dados.parser = new ExpressionParser();
            var xParser = new DoubleValue();
            xParser.Value = x = dados.a;
            dados.parser.Values.Add("x", xParser);
            fx = dados.parser.Parse(dados.func);
            Iterações += "------- " + dados.func + " -------" + Environment.NewLine;
            do
            {
                xParser.Value = x + dados.delta;
                fxk = dados.parser.Parse(dados.func);
                Iterações += "Iter. " + cont + "->" + Environment.NewLine;
                Iterações += "x = " + x + Environment.NewLine +
                    "fx = " + fx + Environment.NewLine +
                    "xk = "+ xParser.Value + Environment.NewLine +
                    "fxk = " + fxk + Environment.NewLine;

                if (fxk < fx)
                {
                    fx = fxk;
                    x = xParser.Value;
                }
                else if(!refinou)
                {
                    xParser.Value = xParser.Value - (2 * dados.delta);
                    dados.delta = dados.delta / 10;
                    refinou = true;
                }else
                {
                    OnFinishCalculating();
                    return x;
                }
                cont++;
            } while (xParser.Value <= dados.b);

            OnFinishCalculating();
            return x;
        }

        public void OnFinishCalculating()
        {
            FinishCalculating?.Invoke(this,new DadosEventData() { Type = this.GetType(), Log = Iterações });
        }
    }
    
}
