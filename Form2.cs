using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bcScan
{
    public partial class Form2 : Form
    {
        public int codigo = 0;
        public int cantidad = 0;

        public Form2()
        {
            InitializeComponent();
            
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {

            //Detalle detalle = new Detalle();
            //detalle.codigo = textBoxCodigo.Value.ToString();
            //detalle.cantidad = Convert.ToInt32(textBoxCantidad.Value);
            codigo = Convert.ToInt32(textBoxCodigo.Value);
            cantidad = Convert.ToInt32(textBoxCantidad.Value);
            Close();

            //return detalle;
            //return Tuple.Create(Convert.ToInt32(textBoxCodigo.Value), Convert.ToInt32(textBoxCantidad.Value));
        }
    }
}
