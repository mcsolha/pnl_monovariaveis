using info.lundin.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_PO2
{
    public struct Dados
    {
        public string func;
        public ExpressionParser parser;
        public double a, b, delta, l, e;
    }

    public class BuscaUniforme
    {
        public Dados dados;

        public double? Calcular()
        {
            double fx,fxk,x;
            bool refinou = false;
            dados.parser = new ExpressionParser();
            var xParser = new DoubleValue();
            xParser.Value = x = dados.a;
            dados.parser.Values.Add("x", xParser);
            fx = dados.parser.Parse(dados.func);
            do
            {
                xParser.Value = x + dados.delta;
                fxk = dados.parser.Parse(dados.func);
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
                    return x;
                }
            } while (xParser.Value <= dados.b);
            return x;
        }
    }
    
    public class BuscaDic
    {
        public Dados infos;

        public double? Calcular()
        {
            int cont = 1;
            double x, z, fx, fz;
            infos.parser = new ExpressionParser();
            var valueParser = new DoubleValue();
            infos.parser.Values.Add("x", valueParser);
            while (infos.b - infos.a >= infos.l)
            {
                valueParser.Value = x = ((infos.a + infos.b) / 2) - infos.e;
                fx = infos.parser.Parse(infos.func);
                valueParser.Value = z = ((infos.a + infos.b) / 2) + infos.e;
                fz = infos.parser.Parse(infos.func);
                if (fx > fz)
                    infos.a = x;
                else
                    infos.b = z;
                cont = cont + 1;
            }
            return (infos.a + infos.b) / 2;
        }
    }

    public class SecAurea
    {
        public Dados infos;
        public double? Calcular()
        {
            int cont = 1;
            double a = infos.a, mi, lamb, alpha = (-1 + Math.Sqrt(5))/2, beta = 1 - alpha, fmi, flamb;
            infos.parser = new ExpressionParser();
            var valueParser = new DoubleValue();
            infos.parser.Values.Add("x", valueParser);

            mi = infos.a + ((1 - alpha) * (infos.b - infos.a));
            lamb = infos.a + (alpha * (infos.b - infos.a));
            
            while (infos.b - infos.a > infos.l)
            {
                valueParser.Value = mi;
                fmi = infos.parser.Parse(infos.func);
                valueParser.Value = lamb;
                flamb = infos.parser.Parse(infos.func);
                if (fmi > flamb)
                {
                    infos.a = mi;
                    mi = lamb;
                    lamb = infos.a + (alpha * (infos.b - infos.a));
                }else if (fmi < flamb)
                {
                    infos.b = lamb;
                    lamb = mi;
                    mi = infos.a + ((1 - alpha) * (infos.b - infos.a));
                }
                cont++;
            }

            return (infos.a + infos.b)/2;
        }
    }
}
