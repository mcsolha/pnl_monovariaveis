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

namespace T1_PO2
{
    public struct Dados
    {
        public string func;
        public ExpressionParser parser;
        public double a, b, delta, l, e;
    }

    public class DadosEventData : EventArgs
    {
        public Type Type { get; set; }

        public string Log { get; set; }
    }

    public interface Calculating
    {
        event EventHandler<DadosEventData> FinishCalculating;
        void OnFinishCalculating();
    }

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

    public class SecAurea : Calculating
    {
        public Dados infos;

        string Iterações;

        public event EventHandler<DadosEventData> FinishCalculating;

        public double? Calcular()
        {
            int cont = 1;
            double a = infos.a, mi, lamb, alpha = (-1 + Math.Sqrt(5))/2, beta = 1 - alpha, fmi, flamb;
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
                }else if (fmi < flamb)
                {
                    infos.b = lamb;
                    lamb = mi;
                    mi = infos.a + ((1 - alpha) * (infos.b - infos.a));
                }
                cont++;
            }
            OnFinishCalculating();
            return (infos.a + infos.b)/2;
        }

        public void OnFinishCalculating()
        {
            FinishCalculating?.Invoke(this, new DadosEventData() { Type = this.GetType(), Log = Iterações });
        }
    }

    public class Fibonacci : Calculating
    {
        public Dados infos;

        string Iterações;

        double[] fib = new double[30];
        int n=1;

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
                fmi,flamb;

            infos.parser = new ExpressionParser();
            var valueParser = new DoubleValue();
            infos.parser.Values.Add("x", valueParser);
            Iterações += "------- " + infos.func + " -------" + Environment.NewLine;

            while (cont < n-1 && Math.Abs(infos.b - infos.a) > infos.l)
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

    public class Bissecao : Derivadas, Calculating
    {
        public event EventHandler<DadosEventData> FinishCalculating;

        string Iterações;

        public double? Calcular()
        {
            int cont = 0;
            double n = (Math.Log(1) - Math.Log(infos.l / (infos.b - infos.a))) / Math.Log(2);
            if (n % 1 != 0)
                n = Math.Truncate(n) + 1;
            double pMedio, der_pMedio = 1;
            Iterações += "------- " + infos.func + " -------" + Environment.NewLine;

            while (cont < n && der_pMedio != 0)
            {
                pMedio = (infos.a + infos.b) / 2;
                der_pMedio = Derivada_1(pMedio);
                Iterações += "Iter. " + (cont + 1) + " ->" + Environment.NewLine;
                Iterações += "a = " + infos.a + Environment.NewLine;
                Iterações += "b = " + infos.b + Environment.NewLine;
                Iterações += "pontoMedio = " + pMedio + Environment.NewLine;
                Iterações += "der_PontoMedio " + der_pMedio + Environment.NewLine;

                if (der_pMedio > 0)
                    infos.b = pMedio;
                else if (der_pMedio < 0)
                    infos.a = pMedio;
                cont++;
            }
            OnFinishCalculating();
            return (infos.a + infos.b)/2;
        }

        public void OnFinishCalculating()
        {
            FinishCalculating?.Invoke(this, new DadosEventData() { Type = this.GetType(), Log = Iterações });
        }
    }

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
            double x=infos.a,x_= infos.a, f_ = Derivada_1(x_), f__ = Derivada_2(x_);
            Iterações += "------- " + infos.func + " -------" + Environment.NewLine;
            
            
            Iterações += "b = " + infos.b + Environment.NewLine;

            do
            {
                Iterações += "Iter. " + (cont + 1) + " ->" + Environment.NewLine;
                Iterações += "x["+ cont +"]" + "=" + x + Environment.NewLine;
                x = x_;
                x_ = x_ - (f_ / f__);
                Iterações += "x[" + (cont+1) + "]" + "=" + x_ + Environment.NewLine;
                f_ = Derivada_1(x_);
                Iterações += "fx[" + (cont + 1) + "]" + "=" + x_ + Environment.NewLine;
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
