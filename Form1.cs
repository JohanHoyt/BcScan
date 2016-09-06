using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        bool isDescargando = false;
        bool isEditando = false;
        bool isGuardado = false;
        private Timer timerAutoSave;
        string hoy = DateTime.Now.ToString("MMddyyyy");
        formCargando mensaje = new formCargando();

        string MSG_RETOMANDO = "Retomando...";
        string MSG_EMPTY = "";


        // paths para configurar
        string pathListaAnaq = @"C:\Database\ListaAnaq.txt";
        string pathinventarioEnScanner = @"f|F|\Application\Inventory\export.txt";
        string pathInventarioExport = @"C:\Database\temp\export.txt";
        string pathGuardarRoot = @"C:\Database\";
        string pathGuardarFile = "save.txt";
        string pathResultadosFile = "CodAnaqGuardado.txt";
        string pathAutoGuardarFile = "autosave.txt";
        string pathDescargaTemp = @"C:\Database\temp";
        int autoSaveTime = 60;

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
                    this.logBox.AppendText(Properties.Settings.Default.pathListaAnaq + "\r\n");


                    string line, anaq, cont;

                    // Read the file and display it line by line.
                    if (!File.Exists(Properties.Settings.Default.pathListaAnaq))
                    {
                        MessageBox.Show("No se encontro lista de anaqueles, presione OK para regresar.", "Advertencia", MessageBoxButtons.OK);
                    }
                    else
                    {
                        System.IO.StreamReader file =
                       new System.IO.StreamReader(Properties.Settings.Default.pathListaAnaq);
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
                                detalles = new BindingList<Detalle>()
                                //pistol = 0
                            });

                            //debug log
                            this.logBox.AppendText(anaq + cont + "\r\n");
                            counter++;
                        }
                        file.Close();
                        bindGrid();
                        setEventHandlers();
                        InitTimer();
                    }

                }
            }
            else
            {
                MessageBox.Show("Captura ya iniciada. Debe reiniciar el programa para empezar una nueva captura", "Advertencia", MessageBoxButtons.OK);
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
                if (current != null)
                {
                    labelDetalleAnaquel.Text = current.anaquel;

                    detalles.Clear();

                    foreach (var anaquel in anaqueles)
                    {
                        if (anaquel.anaquel == current.anaquel)
                        {
                            if (anaquel.detalles != null)
                            {
                                //bind data to viewDetalles gridview
                                viewDetalles.AutoGenerateColumns = false;
                                bindingSourceDetalle.DataSource = anaquel.detalles;
                                viewDetalles.DataSource = bindingSourceDetalle;

                                viewDetalles.Columns["Codigo"].DataPropertyName = "codigo";
                                viewDetalles.Columns["Cant"].DataPropertyName = "cantidad";
                                //foreach (var detalle in anaquel.detalles)
                                //{
                                //    detalles.Add(detalle);
                                //}
                                break;
                            }
                        }
                    }

                    //bind data to viewDetalles gridview
                    //viewDetalles.AutoGenerateColumns = false;
                    //bindingSourceDetalle.DataSource = detalles;
                    //viewDetalles.DataSource = bindingSourceDetalle;

                    //viewDetalles.Columns["Codigo"].DataPropertyName = "codigo";
                    //viewDetalles.Columns["Cant"].DataPropertyName = "cantidad";
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
            guardar("manual");
        }

        private void buttonDescargar_Click(object sender, EventArgs e)
        {
            if (isCapturaLoaded == true)
            {
                //mostrar mensaje de espera
                mensaje.Show();
                this.logBox.AppendText("Buscando archivo para descarga..." + "\r\n");
                //boolean para ver autoguardar
                isDescargando = true;

                var collection = new PortableDeviceCollection();

                if(collection.Refresh() == false)
                {
                    isDescargando = false;
                    mensaje.Hide();
                }

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
                        isDescargando = false;
                        mensaje.Hide();
                    }
                    else
                    {
                        this.logBox.AppendText("Descarga Exitosa" + "\r\n");
                        descargar();
                    }
                    device.Disconnect();
                }
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
                    if (item.Id == Properties.Settings.Default.pathInventarioEnScanner)
                    {
                        isPathFound = true;
                        this.logBox.AppendText("found export.txt in: " + item.Id + "\r\n");
                        (new FileInfo(Properties.Settings.Default.pathDescargaTemp)).Directory.Create();
                        //close?
                        device.DownloadFile((PortableDeviceFile)item, Properties.Settings.Default.pathDescargaTemp);
                        //File.Create(FilePath).Close();
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
               new System.IO.StreamReader(Properties.Settings.Default.pathInventarioExport);

            this.logBox.AppendText("Descargando " + file + "\r\n");

            string currentAnaquel = "";
            //int detallesCount = detallesList.Count();
            bool matchFound;

            while ((line = file.ReadLine()) != null)
            {
                //this.logBox.AppendText(line + "\r\n");

                // PARSE export.txt

                //check if todos los anaqueles ya fueron cargados
                //el export.txt se esta copiando mal. se duplica la lista.
                //se escanea un codigo de barra que diga fin para saber cuando parar de leer
                ///////////////////
                if(line == "FIN")
                {
                    break;
                }
                ///////////////////

                if (Regex.Matches(line, @"[a-zA-Z]").Count >= 5)
                {
                    currentAnaquel = line.Substring(6).ToUpper();
                    //check if anaquel exists, if not, add.

                    bool isRecursive = true;
                    bool isExisteAnaquel = false;

                    while (isRecursive == true)
                    {
                        bool isCargadoAnaquel = false;
                        foreach (var anaquel in anaqueles)
                        {
                            if (anaquel.anaquel == currentAnaquel)
                            {
                                if (anaquel.detalles.Count() != 0)
                                {
                                    isCargadoAnaquel = true;
                                    //si el anaquel ya tiene informacion, crear otro anaquel
                                    //con ! alfrente del nombre
                                    currentAnaquel = "!" + currentAnaquel;
                                    
                                }
                                else
                                {
                                    isRecursive = false;
                                    isExisteAnaquel = true;
                                }
                                break;
                            }
                        }
                        if (isCargadoAnaquel == false)
                        {
                            isRecursive = false;
                        }
                    }

                    if (isExisteAnaquel == false)
                    {
                        anaqueles.Add(new Anaquel
                        {
                            anaquel = currentAnaquel,
                            contado = 0,
                            id = counter,
                            detalles = new BindingList<Detalle>()
                            
                        });
                    }
                    this.logBox.AppendText(currentAnaquel + "\r\n");
                }
                else
                {
                    foreach (var anaquel in anaqueles)
                    {
                        if (anaquel.anaquel == currentAnaquel)
                        {
                            this.logBox.AppendText(line + "\r\n");
                            //if detalles is empty, add
                            if (anaquel.detalles.Count() == 0)
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
                                if (detalle.codigo == line)
                                {
                                    detalle.cantidad++;
                                    matchFound = true;
                                    break;
                                }
                            }
                            //if doesn't exist, add
                            if (matchFound == false)
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

            isDescargando = false;
            mensaje.Hide();
            refresh();
            file.Close();
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
            int totalAnaquelesOK = 0;
            float totalAnaquelesOKPercent = 0;
            int totalParesOK = 0;
            float totalParesOKPercent = 0;
            int totalAnaquelesError = 0;

            foreach (var anaquel in anaqueles)
            {
                //stats
                ParesEnAnaquel = 0;
                bool isAnaquelPistolFound = false; //para ver si se agrega a anaqueles pistoleados

                totalAnaquelesContados++; //agregar a anaqueles contados
                totalParesContados += anaquel.contado; //agregar todos los pares de este anaquel a total de pares contados

                if (anaquel.detalles.Count() != 0)
                {
                    isAnaquelPistolFound = true;
                    foreach (var detalle in anaquel.detalles)
                    {
                        ParesEnAnaquel += detalle.cantidad; //agregar a los pares que hay en este anaquel
                        totalParesPistol += detalle.cantidad; //agregar todos los pares de este anaquel a total de pares pistoleados
                        if (detalle.codigo != null)
                        {
                            if (detalle.codigo.Length >= 8)
                            {
                                anaquel.error = "Codigo Desconocido"; //error de codigo largo. No es nuestra etiqueta
                                totalAnaquelesError++; //agregar a total de anaqueles con error
                            }
                        }
                    }
                }

                if (isAnaquelPistolFound == true)
                {
                    totalAnaquelesPistol++; //agrega a anaqueles pistoleados
                }
                //set new anaquel.pistol
                anaquel.pistol = ParesEnAnaquel;
                //set status y error de anaquel
                if(anaquel.contado == anaquel.pistol)
                {
                    anaquel.status = "OK";
                    anaquel.error = MSG_EMPTY;
                    totalParesOK += ParesEnAnaquel;
                }
                else
                {
                    if(anaquel.pistol != 0)
                    {
                        anaquel.error = "Pistol"; //lo pistoleado no es igual a lo contado
                        totalAnaquelesError++; //agregar a total de anaqueles con error
                    }
                }
                if(anaquel.status =="OK")
                {
                    totalAnaquelesOK++;
                }
                if(anaquel.status == MSG_RETOMANDO)
                {
                    anaquel.status = MSG_EMPTY;
                }
            }

            //set new data
            bindingSourceAnaquel.ResetBindings(true);
            textAnaqContados.Text = totalAnaquelesContados.ToString();
            textAnaqPistol.Text = totalAnaquelesPistol.ToString();
            textAnaqOK.Text = totalAnaquelesOK.ToString();
            textAnaqError.Text = totalAnaquelesError.ToString();
            textParesContados.Text = totalParesContados.ToString();
            textParesPistol.Text = totalParesPistol.ToString();
            textParesOK.Text = totalParesOK.ToString();
            totalAnaquelesOKPercent = ((float)totalAnaquelesOK / (float)totalAnaquelesContados)*100;
            textAnaqOKPercent.Text = totalAnaquelesOKPercent.ToString("0.00") + "%";
            totalParesOKPercent = ((float)totalParesPistol / (float)totalParesContados)*100;
            textParesOKPercent.Text = totalParesOKPercent.ToString("0.00") + "%";

            
        }

        private void viewAnaqueles_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
        {
            // string headerText =
            //viewAnaqueles.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the column.
            //if (!headerText.Equals("Anaquel") || !headerText.Equals("Contado") || 
            //    !headerText.Equals("Pistol")) return;

            // Confirm that the cell is not empty.
            if (e.ColumnIndex != 3 && e.ColumnIndex != 4)
            {
                if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    viewAnaqueles.Rows[e.RowIndex].ErrorText =
                        "No se puede dejar la casilla en blanco.";
                    e.Cancel = true;
                }
            }

            //do not validate new row
            if (viewAnaqueles.Rows[e.RowIndex].IsNewRow) { return; }
        }

        
        private void viewAnaqueles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            viewAnaqueles.Rows[e.RowIndex].ErrorText = String.Empty;
            refresh();
        }
        private void viewAnaqueles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // If the data source raises an exception when a cell value is 
            // commited, display an error message.
            //if (e.Exception != null &&
            //    e.Context == DataGridViewDataErrorContexts.Commit)
            //{
            //    MessageBox.Show("Debe ingresar un numero.");
            //}
            viewAnaqueles.Rows[e.RowIndex].ErrorText =
                   "Debe ingresar un numero.";
        }

        private void viewDetalles_CellValidating(object sender,
        DataGridViewCellValidatingEventArgs e)
        {
            // string headerText =
            //viewAnaqueles.Columns[e.ColumnIndex].HeaderText;

            // Abort validation if cell is not in the column.
            //if (!headerText.Equals("Anaquel") || !headerText.Equals("Contado") || 
            //    !headerText.Equals("Pistol")) return;

            // Confirm that the cell is not empty.
            

            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                viewDetalles.Rows[e.RowIndex].ErrorText =
                    "No se puede dejar la casilla en blanco. ESC para cancelar";
                e.Cancel = true;
            }
            //do not validate new row
            if (viewAnaqueles.Rows[e.RowIndex].IsNewRow) { return; }
        }

        private void viewDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            viewDetalles.Rows[e.RowIndex].ErrorText = String.Empty;
            refresh();
            
        }
        private void viewDetalles_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
          
            viewDetalles.Rows[e.RowIndex].ErrorText =
                   "Debe ingresar un numero.";
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Esta seguro que quiere eliminar este ANAQUEL?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //viewAnaqueles.Rows.RemoveAt(viewAnaqueles.CurrentRow.Index);
                    Anaquel current = (Anaquel)viewAnaqueles.CurrentRow.DataBoundItem;
                    foreach (var anaquel in anaqueles.ToList())
                    {
                        if (current.anaquel == anaquel.anaquel)
                        {
                            anaqueles.Remove(anaquel);
                        } 
                    }
                }
                refresh();
            }
            catch
            { }
        }

        private void buttonRetomar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Desea retomar este anaquel?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Anaquel current = (Anaquel)viewAnaqueles.CurrentRow.DataBoundItem;
                    foreach (var anaquel in anaqueles)
                    {
                        if (current.anaquel == anaquel.anaquel)
                        {
                            anaquel.detalles.Clear();
                            anaquel.status = MSG_RETOMANDO;
                            anaquel.error = MSG_EMPTY;
                        }
                    }
                }
                //refresh();
            }
            catch
            { }
        }

        private void buttonOrdenar_Click(object sender, EventArgs e)
        {
            //viewAnaqueles.Sort(Anaquel, ListSortDirection.Ascending);
           
        }

        private void buttonEliminarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Esta seguro que quiere eliminar este DETALLE?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //viewAnaqueles.Rows.RemoveAt(viewAnaqueles.CurrentRow.Index);
                    Anaquel currentAnaquel = (Anaquel)viewAnaqueles.CurrentRow.DataBoundItem;
                    Detalle currentDetalle = (Detalle)viewDetalles.CurrentRow.DataBoundItem;

                    foreach (var detalle in currentAnaquel.detalles.ToList())
                    {
                        if (detalle.codigo == currentDetalle.codigo)
                        {
                            currentAnaquel.detalles.Remove(detalle);
                        }
                    }
                }
                refresh();
            }
            catch
            { }
        }

        private void buttonAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (isCapturaLoaded == true)
            {
                if (viewAnaqueles.CurrentRow.DataBoundItem != null)
                {
                    Form2 prompt = new Form2();
                    string codigo = "";
                    int cantidad = 0;
                    int codigoTemp = 0;
                    bool isCodigoFound = false;

                    //prompt.ShowDialog();
                    if (prompt.ShowDialog() == DialogResult.OK)
                    {
                        codigoTemp = prompt.codigo;
                        codigo = codigoTemp.ToString();
                        cantidad = prompt.cantidad;
                        Anaquel currentAnaquel = (Anaquel)viewAnaqueles.CurrentRow.DataBoundItem;

                        //check if codigo isn't already in.

                        foreach (var anaquel in anaqueles)
                        {
                            if (anaquel.anaquel == currentAnaquel.anaquel)
                            {
                                foreach (var detalle in anaquel.detalles)
                                {
                                    if (detalle.codigo == codigo)
                                    {
                                        isCodigoFound = true;
                                    }
                                }
                                if (isCodigoFound == true)
                                {
                                    MessageBox.Show("Este codigo ya existe en este anaquel", "Advertencia", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    anaquel.detalles.Add(new Detalle
                                    {
                                        anaquel = currentAnaquel.anaquel,
                                        codigo = codigo,
                                        cantidad = cantidad
                                    });
                                }
                                break;
                            }
                        }
                    }
                }

            }
            refresh();
        }
        
        private void setEventHandlers()
        {
            //set event handler 
            viewAnaqueles.SelectionChanged += new EventHandler(
            viewAnaqueles_SelectionChanged);
            viewDetalles.CellValueChanged += new DataGridViewCellEventHandler(
            viewDetalles_CellValueChanged);
            viewAnaqueles.CellValidating += new

            DataGridViewCellValidatingEventHandler(viewAnaqueles_CellValidating);
            viewAnaqueles.CellEndEdit += new

            DataGridViewCellEventHandler(viewAnaqueles_CellEndEdit);
            viewAnaqueles.DataError +=
                        new DataGridViewDataErrorEventHandler(viewAnaqueles_DataError);
            viewDetalles.CellValidating += new

            DataGridViewCellValidatingEventHandler(viewDetalles_CellValidating);
            viewDetalles.CellEndEdit += new

            DataGridViewCellEventHandler(viewDetalles_CellEndEdit);
            viewDetalles.DataError +=
                        new DataGridViewDataErrorEventHandler(viewDetalles_DataError);


        }

        public void InitTimer()
        {
            timerAutoSave = new Timer();
            timerAutoSave.Tick += new EventHandler(timerAutoSave_Tick);
            timerAutoSave.Interval = autoSaveTime * 1000; // in miliseconds
            timerAutoSave.Start();
        }
        private void timerAutoSave_Tick(object sender, EventArgs e)
        {
            if(isDescargando == false)
            {
                if (isGuardado == true)
                {
                    guardar("auto");
                    this.logBox.AppendText("autosave \r\n");
                }
            }
        }

        public void guardar(string tipo)
        {
            // si no se ha seleccionado una tienda, mostrar mensaje
            if (textBoxTienda.Text == "")
            {
                MessageBox.Show("Debe seleccionar la Tienda.", "Informacion Faltante", MessageBoxButtons.OK);
            }
            else
            {
                var save = new List<string>();
                var saveResultados = new List<string>();
                string ANAQ = "ANAQ";
                string DETALLE = "DETALLE";
                string TIENDA = "TIENDA";

                save.Add(TIENDA + "," + textBoxTienda.Text);
                foreach (var anaq in anaqueles)
                {
                    save.Add(ANAQ + "," + anaq.anaquel + "," + anaq.contado.ToString() + "," +
                        anaq.pistol.ToString());
                    foreach (var detalle in anaq.detalles)
                    {
                        save.Add(DETALLE + "," + detalle.anaquel + "," + detalle.codigo.ToString() + "," + detalle.cantidad.ToString());
                        saveResultados.Add(String.Format("{0}\t{1}\t{2}", detalle.anaquel, detalle.codigo.ToString(), detalle.cantidad.ToString()));
                    }
                }

                //revisa si es auto save o manual. define el path acorde
                string path = "";
                string pathResultados = "";
                if(tipo == "manual")
                {
                    path = Properties.Settings.Default.pathGuardarRoot + @"\" + textBoxTienda.Text + @"\" + hoy + @"\" + Properties.Settings.Default.pathGuardarFile;
                    pathResultados = Properties.Settings.Default.pathGuardarRoot + @"\" + textBoxTienda.Text + @"\" + hoy + @"\" + Properties.Settings.Default.pathResultadosFile;
                    isGuardado = true;
                    MessageBox.Show("Guardado.", "Success", MessageBoxButtons.OK);
                    this.logBox.AppendText("Captura Guardada \r\n");
                    (new FileInfo(path)).Directory.Create();
                    System.IO.File.WriteAllLines(pathResultados, saveResultados.ToArray());
                    //File.Create(path).Close();
                }
                else if (tipo == "auto")
                {
                    path = Properties.Settings.Default.pathGuardarRoot + @"\" + textBoxTienda.Text + @"\" + hoy + @"\autosave\" + Properties.Settings.Default.pathAutoGuardarFile;
                }
                (new FileInfo(path)).Directory.Create();
                System.IO.File.WriteAllLines(path, save.ToArray());
               // File.Create(path).Close();

            }
        }


        //private void buttonLoadCaptura_Click(object sender, EventArgs e)
        //{
        //    DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
        //    if (result == DialogResult.OK)
        //    {
        //        string file = openFileDialog1.FileName;
        //        try
        //        {
        //            //string text = File.ReadAllText(file);
        //            this.logBox.AppendText("Abriendo " + file + "\r\n");
        //            loadCaptura(file);
        //        }
        //        catch (IOException)
        //        {
        //        }
        //    }
        //}

        public void loadCaptura(string path)
        {
            if (isCapturaLoaded == true)
            {
                MessageBox.Show("Captura ya iniciada. Debe reiniciar el programa para empezar una nueva captura", "Advertencia", MessageBoxButtons.OK);
            }
            else
            {
                string line, lineTipo, lineCont, linePistol, lineCodigo, lineCantidad, lineTienda;
                string lineAnaq = "";

                System.IO.StreamReader file =
                           new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    //parse text file 
                    string[] split = line.Split(',');
                    lineTipo = split[0];
                    if (lineTipo == "ANAQ")
                    {
                        lineAnaq = split[1];
                        lineCont = split[2];
                        linePistol = split[3];

                        //add into anaqueles binding list
                        anaqueles.Add(new Anaquel
                        {
                            anaquel = lineAnaq,
                            contado = Int32.Parse(lineCont),
                            pistol = Int32.Parse(linePistol),
                            detalles = new BindingList<Detalle>()
                        });
                    }
                    else if (lineTipo == "DETALLE")
                    {
                        lineCodigo = split[2];
                        lineCantidad = split[3];

                        foreach (var anaquel in anaqueles)
                        {
                            if (anaquel.anaquel == lineAnaq)
                            {
                                anaquel.detalles.Add(new Detalle
                                {
                                    anaquel = lineAnaq,
                                    codigo = lineCodigo,
                                    cantidad = Int32.Parse(lineCantidad)
                                });
                                break;
                            }
                        }
                    }
                    else if(lineTipo == "TIENDA")
                    {
                        lineTienda = split[1];
                        textBoxTienda.Text = lineTienda;
                    }
                }
                file.Close();
                bindGrid();
                setEventHandlers();
                InitTimer();
                refresh();
                isCapturaLoaded = true;
            }
        }

        public void bindGrid()
        {
            //Load into anaqueles gridview
            viewAnaqueles.AutoGenerateColumns = false;
            bindingSourceAnaquel.DataSource = anaqueles;
            viewAnaqueles.DataSource = bindingSourceAnaquel;

            viewAnaqueles.Columns["Anaquel"].DataPropertyName = "anaquel";
            viewAnaqueles.Columns["Contado"].DataPropertyName = "contado";
            viewAnaqueles.Columns["Pistol"].DataPropertyName = "pistol";
            viewAnaqueles.Columns["Status"].DataPropertyName = "status";
            viewAnaqueles.Columns["Error"].DataPropertyName = "error";
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            if(textBoxTienda.Text == "")
            {
                MessageBox.Show("Debe seleccionar la Tienda.", "Informacion Faltante", MessageBoxButtons.OK);
            }
            else
            {
                if (isCapturaLoaded == true)
                {
                    if(MessageBox.Show("Si carga la información guardada, todo lo que tiene hasta ahora se borrará.  ¿Está seguro que desea cargarlo ? ", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string file = Properties.Settings.Default.pathGuardarRoot + textBoxTienda.Text + @"\" + hoy +  @"\autosave\" + Properties.Settings.Default.pathAutoGuardarFile;

                        if (File.Exists(file))
                        {
                            loadCaptura(file);
                        }
                        else
                        {
                            MessageBox.Show("Archivo de autoguardado no se ha encontrado", "Advertencia", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    string file = Properties.Settings.Default.pathGuardarRoot + textBoxTienda.Text + @"\" + hoy + @"\autosave\" + Properties.Settings.Default.pathAutoGuardarFile;
                    this.logBox.AppendText("Abriendo " + file + "\r\n");
                    if (File.Exists(file))
                    {
                        loadCaptura(file);
                    }
                    else
                    {
                        MessageBox.Show("Archivo de autoguardado no se ha encontrado", "Advertencia", MessageBoxButtons.OK);
                    }
                }
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (PreClosingConfirmation() == System.Windows.Forms.DialogResult.Yes)
            {
                Dispose(true);
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = System.Windows.Forms.MessageBox.Show("Esta seguro que desea salir? Recuerde guardar el archivo.", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        private void buttonDescargaManual_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                string file = openFileDialog2.FileName;
                try
                {
                    this.logBox.AppendText("Copiando " + file + "\r\n");
                    string line;
                    var save = new List<string>();
                    System.IO.StreamReader readExport =
                       new System.IO.StreamReader(file);
                    while ((line = readExport.ReadLine()) != null)
                    {
                        save.Add(line);
                    }
                    readExport.Close();
                    (new FileInfo(Properties.Settings.Default.pathInventarioExport)).Directory.Create();
                    System.IO.File.WriteAllLines(Properties.Settings.Default.pathInventarioExport, save.ToArray());
                    descargar();
                    
                    //File.Create(pathInventarioExport).Close();
                }
                catch (IOException ex)
                {
                    this.logBox.AppendText("No se pudo copiar " + file + "\r\n");
                    this.logBox.AppendText(ex+ "\r\n");
                }
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void buttonBorrarLog_Click(object sender, EventArgs e)
        {
            logBox.Clear();
        }

        private void buttonLoadCaptura_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    //string text = File.ReadAllText(file);
                    this.logBox.AppendText("Abriendo " + file + "\r\n");
                    loadCaptura(file);
                    isCapturaLoaded = true;
                }
                catch (IOException)
                {
                }
            }
        }
    }
}
