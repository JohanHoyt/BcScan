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
        public string status { get; set; }
        public string error { get; set; }

        public BindingList<Detalle> detalles { get; set; }
        
        //public List<Detalle> detalles
        //{
        //    get { return detalles; }
        //    set { detalles = value; }
        //}

        public Anaquel()
        {
            pistol = 0;
            status = "";
            error = "";
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
