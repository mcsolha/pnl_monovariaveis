using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1_PO2.Data;

namespace T1_PO2.Helpers
{
    interface Calculating
    {
        event EventHandler<DadosEventData> FinishCalculating;
        void OnFinishCalculating();
    }
}
