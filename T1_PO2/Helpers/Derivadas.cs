using info.lundin.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1_PO2.Data;

namespace T1_PO2.Helpers
{
    public class Derivadas
    {
        public Dados infos;

        public double Derivada_1(double _x)
        {
            double h = 0.5;
            double fx_linha = 0, auxfx_linha = 0, f1, f2;
            infos.parser = new ExpressionParser();
            var valueParser = new DoubleValue();
            infos.parser.Values.Add("x", valueParser);

            do
            {
                auxfx_linha = fx_linha;
                valueParser.Value = _x + h;
                f1 = infos.parser.Parse(infos.func);
                valueParser.Value = _x - h;
                f2 = infos.parser.Parse(infos.func);
                fx_linha = (f1 - f2) / (2 * h);
                h /= 2;
            } while ((Math.Abs(fx_linha) - Math.Abs(auxfx_linha)) > 0.0000001);

            return fx_linha;
        }

        public double Derivada_2(double _x)
        {
            double h = 0.5;
            double fx_linha = 0, auxfx_linha = 0, f1, f2, f3;
            infos.parser = new ExpressionParser();
            var valueParser = new DoubleValue();
            infos.parser.Values.Add("x", valueParser);

            do
            {
                auxfx_linha = fx_linha;
                valueParser.Value = _x + (2 * h);
                f1 = infos.parser.Parse(infos.func);
                valueParser.Value = _x;
                f2 = infos.parser.Parse(infos.func);
                valueParser.Value = _x - (2 * h);
                f3 = infos.parser.Parse(infos.func);

                fx_linha = (f1 - (2 * f2) + f3) / (4 * Math.Pow(h, 2));
                h /= 2;
            } while ((Math.Abs(fx_linha) - Math.Abs(auxfx_linha)) > 0.0000001);

            return fx_linha;
        }
    }

}
