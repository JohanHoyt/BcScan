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
    public partial class Form1 : Form
    {
        //GLOBALS
        string anaquelPath = @"C:\Database\ListaAnaq.txt";

            //datagridview sources and lists declaration
            BindingList<Anaquel> anaqueles = new BindingList<Anaquel>();
            BindingSource bindingSourceAnaquel = new BindingSource();

            List<Detalle> detallesList = new List<Detalle>();
            BindingList<Detalle> detalles = new BindingList<Detalle>();
            BindingSource bindingSourceDetalle = new BindingSource();



        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        // parse text file listaAnaq y cargar a datagridview
        private void buttonCapturar_Click(object sender, EventArgs e)
        {
            this.logBox.Text += anaquelPath + "\r\n";

            int counter = 1;
            string line, anaq, cont;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(anaquelPath);
            while ((line = file.ReadLine()) != null)
            {
                //parse text file ListaAnaq
                string[] split = line.Split(',');
                anaq = split[0];
                anaq = anaq.Replace("\"", string.Empty);
                cont = split[1];

                //add into anaqueles binding list
                anaqueles.Add(new Anaquel
                {
                    anaquel = anaq,
                    contado = cont,
                    id = counter
                });

                //add into detallesList TEST DETALLE
                for (int i = 0; i <= counter; i++)
                {
                    detallesList.Add(new Detalle
                    {
                        id = counter,
                        codigo = counter * 3,
                        cantidad = i * 2
                    });
                }


                //debug log
                this.logBox.Text += anaq + cont + "\r\n";
                counter++;
            }

            file.Close();

            //Load into anaqueles gridview
            viewAnaqueles.AutoGenerateColumns = false;
            bindingSourceAnaquel.DataSource = anaqueles;
            viewAnaqueles.DataSource = bindingSourceAnaquel;

            viewAnaqueles.Columns["Anaquel"].DataPropertyName = "anaquel";
            viewAnaqueles.Columns["Contado"].DataPropertyName = "contado";

            //set event handler for selected row
            viewAnaqueles.SelectionChanged += new EventHandler(
            viewAnaqueles_SelectionChanged);
        }

        // Select row from anaquel gridview when clicked
        // Get id and search for detalles with same id
        // Add those detalles to binding list
        // Bind into detalles gridview
        //(Hay un List completo con todos los detalles, y un binding list con los detalles de anaquel seleccionado)

        private void viewAnaqueles_SelectionChanged(object sender, EventArgs e)
        {
            Anaquel current = (Anaquel)viewAnaqueles.CurrentRow.DataBoundItem;
            labelDetalleAnaquel.Text = current.anaquel;
            int idAnaquel = current.id;

            detalles.Clear();
            foreach(var item in detallesList)
            {
                if(item.id == idAnaquel)
                {
                    detalles.Add(item);
                }
            }

            //bind data to viewDetalles gridview
            viewDetalles.AutoGenerateColumns = false;
            bindingSourceDetalle.DataSource = detalles;
            viewDetalles.DataSource = bindingSourceDetalle;

            viewDetalles.Columns["Codigo"].DataPropertyName = "codigo";
            viewDetalles.Columns["Cant"].DataPropertyName = "cantidad";

        }

        private void viewAnaqueles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
