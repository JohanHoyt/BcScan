using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bcScan
{
    class Detalle
    {
        public int id { get; set; }
        public int codigo { get; set; }
        public int cantidad { get; set; }
        public string error { get; set; }

        public Detalle()
        {
            error = "";
        }
    }
}
