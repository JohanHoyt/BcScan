using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bcScan
{
    class Anaquel
    {

        public int id { get; set; }
        public string anaquel { get; set; }
        public int contado { get; set; }
        public int pistol { get; set; }
        public int status { get; set; }
        public string error { get; set; }

        public Anaquel()
        {
            pistol = 0;
            status = 0;
            error = "";
        }


    }
}
