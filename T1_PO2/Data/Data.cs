using info.lundin.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_PO2.Data
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
}
