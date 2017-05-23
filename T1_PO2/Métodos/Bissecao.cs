using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1_PO2.Data;
using T1_PO2.Helpers;

namespace T1_PO2.Métodos
{
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
            return (infos.a + infos.b) / 2;
        }

        public void OnFinishCalculating()
        {
            FinishCalculating?.Invoke(this, new DadosEventData() { Type = this.GetType(), Log = Iterações });
        }
    }

}
