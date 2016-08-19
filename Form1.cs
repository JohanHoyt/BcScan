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
        bool isCapturaLoaded = false;
        int counter = 1;

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
            if (isCapturaLoaded == false)
            {
                if (MessageBox.Show("Desea empezar una nueva captura?", "Nueva Captura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isCapturaLoaded = true;
                    this.logBox.Text += anaquelPath + "\r\n";

                    
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
                            contado = Int32.Parse(cont),
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

                    //set event handler for viewAnaqueles gridview
                    viewAnaqueles.SelectionChanged += new EventHandler(
                    viewAnaqueles_SelectionChanged);
                    viewDetalles.CellValueChanged += new DataGridViewCellEventHandler(
                    viewDetalles_CellValueChanged);
                }
            }
            else
            {
                MessageBox.Show("Captura ya iniciada", "Advertencia", MessageBoxButtons.OK);
            }
        }

        // Select row from anaquel gridview when clicked
        // Get id and search for detalles with same id
        // Add those detalles to binding list
        // Bind into detalles gridview
        //(Hay un List completo con todos los detalles, y un binding list con los detalles de anaquel seleccionado)

        private void viewAnaqueles_SelectionChanged(object sender, EventArgs e)
        {

            //check gridview selection*** note

            DataGridView dgv = sender as DataGridView;

            if (dgv.Name == viewAnaqueles.Name)
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

                

        }

        private void viewAnaqueles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // data grid view edited.
        //talvez no es necesario
        private void viewDetalles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            //detalle currentdetalle = (detalle)viewdetalles.currentrow.databounditem;
            //int iddetalle = currentdetalle.id;
            //if (viewdetalles.columns[e.columnindex].name == "cant")
            //{

            //}
           

            }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            
            var saveAnaq = new List<string>();
            var saveDetalle = new List<string>();

            foreach (var anaq in anaqueles)
            {
                saveAnaq.Add(anaq.id.ToString() + "," + anaq.anaquel + "," + anaq.contado.ToString() + "," +
                    anaq.pistol.ToString() + "," + anaq.status.ToString() + "," + anaq.error);
            }

            foreach (var detalle in detallesList)
            {
                saveDetalle.Add(detalle.id.ToString() + "," + detalle.codigo.ToString() + "," + detalle.cantidad.ToString() + "," +
                    detalle.error);
            }

            System.IO.File.WriteAllLines(@"C:\Database\saves\Anaqueles.txt", saveAnaq.ToArray());
            System.IO.File.WriteAllLines(@"C:\Database\saves\Detalles.txt", saveDetalle.ToArray());
            MessageBox.Show("Guardado.", "Success", MessageBoxButtons.OK);
        }
    }
}
