using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bcScan
{
    class Detalle
    {
        public string anaquel { get; set; }
        public string codigo { get; set; }
        public int cantidad { get; set; }
        public string error { get; set; }

        public Detalle()
        {
            error = "";
        }
    }
}
