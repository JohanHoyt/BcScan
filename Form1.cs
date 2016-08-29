using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bcScan
{
    public partial class Form1 : Form
    {
        //GLOBALS
        int counter = 1;
        bool isCapturaLoaded = false;
        bool isPathFound = false;
        
        // paths para configurar
        string pathListaAnaq = @"C:\Database\ListaAnaq.txt";
        string pathinventarioEnScanner = @"f|F|\Application\Inventory\export.txt";
        string pathInventarioExport = @"C:\Database\temp\export.txt";



        //datagridview sources and lists declaration
        BindingList<Anaquel> anaqueles = new BindingList<Anaquel>();
        BindingSource bindingSourceAnaquel = new BindingSource();

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
                    this.logBox.AppendText(pathListaAnaq + "\r\n");

                    
                    string line, anaq, cont;

                    // Read the file and display it line by line.
                    System.IO.StreamReader file =
                       new System.IO.StreamReader(pathListaAnaq);
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
                            id = counter,
                            detalles = new List<Detalle>()
                        //pistol = 0
                    });

                        //debug log
                        this.logBox.AppendText(anaq + cont + "\r\n");
                        counter++;
                    }

                    file.Close();

                    //Load into anaqueles gridview
                    viewAnaqueles.AutoGenerateColumns = false;
                    bindingSourceAnaquel.DataSource = anaqueles;
                    viewAnaqueles.DataSource = bindingSourceAnaquel;

                    viewAnaqueles.Columns["Anaquel"].DataPropertyName = "anaquel";
                    viewAnaqueles.Columns["Contado"].DataPropertyName = "contado";
                    viewAnaqueles.Columns["Pistol"].DataPropertyName = "pistol";

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
                if(current != null)
                {
                    labelDetalleAnaquel.Text = current.anaquel;
        
                    detalles.Clear();

                    foreach(var anaquel in anaqueles)
                    {
                        if(anaquel.anaquel == current.anaquel)
                        {
                            if (anaquel.detalles != null)
                            {
                                foreach (var detalle in anaquel.detalles)
                                {
                                    detalles.Add(detalle);
                                }
                                break;
                            }
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
                saveDetalle.Add(detalle.anaquel + "," + detalle.codigo.ToString() + "," + detalle.cantidad.ToString() + "," +
                    detalle.error);
            }

            System.IO.File.WriteAllLines(@"C:\Database\saves\Anaqueles.txt", saveAnaq.ToArray());
            System.IO.File.WriteAllLines(@"C:\Database\saves\Detalles.txt", saveDetalle.ToArray());
            MessageBox.Show("Guardado.", "Success", MessageBoxButtons.OK);
            this.logBox.AppendText("Captura Guardada \r\n");
        }

        private void buttonDescargar_Click(object sender, EventArgs e)
        {
            if (isCapturaLoaded == true)
            {

                this.logBox.AppendText("Buscando archivo para descarga..." + "\r\n");

                var collection = new PortableDeviceCollection();

                collection.Refresh();

                foreach (var device in collection)
                {
                    device.Connect();
                    this.logBox.AppendText(device.FriendlyName + "\r\n");

                    var folder = device.GetContents();

                    isPathFound = false;

                    foreach (var item in folder.Files)
                    {
                        if (isPathFound == false)
                        {
                            DisplayObject(item, device);
                        }
                        else { break; }

                    }
                    if (isPathFound == false)
                    {
                        MessageBox.Show("No se encontro archivo para descargar", "Advertencia", MessageBoxButtons.OK);
                        this.logBox.AppendText("No se encontro archivo para descargar" + "\r\n");
                    }
                    else
                    {
                        this.logBox.AppendText("Descarga Exitosa" + "\r\n");
                        descargar();
                    }
                    device.Disconnect();
                }
                refresh();
            }
            else
            {
                MessageBox.Show("Debe iniciar captura antes de descargar", "Advertencia", MessageBoxButtons.OK);
            }
        }

        // Portable device enumarate files methods
        public void DisplayObject(PortableDeviceObject portableDeviceObject, PortableDevice device)
        {
            //this.logBox.Text += portableDeviceObject.Name + "\r\n";
           
            if (portableDeviceObject is PortableDeviceFolder)
            {
                    DisplayFolderContents((PortableDeviceFolder)portableDeviceObject, device);
            }
        }
        // Portable device enumarate files methods
        public void DisplayFolderContents(PortableDeviceFolder folder, PortableDevice device)
        {
            foreach (var item in folder.Files)
            {
                //DOWNLOAD
                if (item is PortableDeviceFile)
                {
                    if (item.Id == pathinventarioEnScanner)
                    {
                        isPathFound = true;
                        this.logBox.AppendText("found export.txt" + "\r\n");
                        device.DownloadFile((PortableDeviceFile)item, @"c:\Database\temp");
                        break;
                    }
                }

                //this.logBox.Text += item.Id + "\r\n";

                if (item is PortableDeviceFolder)
                {
                    DisplayFolderContents((PortableDeviceFolder)item, device);
                }

               
            }
        }

        public void descargar()
        {

            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader(pathInventarioExport);

            string currentAnaquel = "";
            //int detallesCount = detallesList.Count();
            bool matchFound;

            while ((line = file.ReadLine()) != null)
            {
                //this.logBox.AppendText(line + "\r\n");

                // PARSE export.txt

                //check if blank spaces in export.txt? CORREGIR
                if(line.Length >= 25 )
                {
                    break;
                }

                if(Regex.Matches(line, @"[a-zA-Z]").Count >= 5)
                {
                    currentAnaquel = line.Substring(6).ToUpper();
                }
                else
                {
                    foreach(var anaquel in anaqueles)
                    {
                        if(anaquel.anaquel == currentAnaquel)
                        {
                            //if detalles is empty, add
                            if(anaquel.detalles.Count() == 0)
                            {
                                anaquel.detalles.Add(new Detalle
                                {
                                    anaquel = currentAnaquel,
                                    codigo = line,
                                    cantidad = 1
                                });
                                break;
                            }
                            //if detalles is not empty, check if there is one with same code
                            matchFound = false;
                            foreach (var detalle in anaquel.detalles) //allows modifications?
                            {
                                //if there is one, cantidad + 1
                                if(detalle.codigo == line)
                                {
                                    detalle.cantidad++;
                                    matchFound = true;
                                    break;
                                }
                            }
                            //if doesn't exist, add
                            if(matchFound == false)
                            {
                                anaquel.detalles.Add(new Detalle
                                {
                                    anaquel = currentAnaquel,
                                    codigo = line,
                                    cantidad = 1
                                });
                            }
                        }
                    } 
                }
            }
            ////debug
            //this.logBox.AppendText("/////////////" + "\r\n");
            //foreach (var item in detallesList)
            //{
            //    this.logBox.AppendText(item.anaquel + item.codigo + item.cantidad + "\r\n");
            //}
        }

        public void refresh()
        {

            //stats
            int ParesEnAnaquel;
            int totalAnaquelesContados = 0;    //los siguientes son la caja de info en la derecha superior
            int totalAnaquelesPistol = 0;
            int totalParesContados = 0;
            int totalParesPistol = 0;

            foreach (var anaquel in anaqueles)
            {
                //stats
                ParesEnAnaquel = 0;
                bool isAnaquelPistolFound = false;

                totalAnaquelesContados++;
                totalParesContados += anaquel.contado;

                if(anaquel.detalles.Count() != 0)
                {
                    isAnaquelPistolFound = true;
                    foreach (var detalle in anaquel.detalles)
                    { 
                        ParesEnAnaquel += detalle.cantidad;
                        totalParesPistol += detalle.cantidad;
                    }
                }
                
                if(isAnaquelPistolFound == true)
                {
                    totalAnaquelesPistol++;
                }
                //set new anaquel.pistol
                anaquel.pistol = ParesEnAnaquel;
            }

                //set new data
                bindingSourceAnaquel.ResetBindings(true);
            textAnaqContados.Text = totalAnaquelesContados.ToString();
            textAnaqPistol.Text = totalAnaquelesPistol.ToString();
            textParesContados.Text = totalParesContados.ToString();
            textParesPistol.Text = totalParesPistol.ToString();
        }
    }
}
