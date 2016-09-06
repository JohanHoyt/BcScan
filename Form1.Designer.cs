namespace bcScan
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.viewAnaqueles = new System.Windows.Forms.DataGridView();
            this.Anaquel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pistol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewDetalles = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textAnaqContados = new System.Windows.Forms.TextBox();
            this.textAnaqPistol = new System.Windows.Forms.TextBox();
            this.textAnaqError = new System.Windows.Forms.TextBox();
            this.textAnaqOK = new System.Windows.Forms.TextBox();
            this.textAnaqOKPercent = new System.Windows.Forms.TextBox();
            this.textParesOKPercent = new System.Windows.Forms.TextBox();
            this.textParesOK = new System.Windows.Forms.TextBox();
            this.textParesError = new System.Windows.Forms.TextBox();
            this.textParesPistol = new System.Windows.Forms.TextBox();
            this.textParesContados = new System.Windows.Forms.TextBox();
            this.buttonOrdenar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonBorrarLog = new System.Windows.Forms.Button();
            this.buttonRetomar = new System.Windows.Forms.Button();
            this.buttonDescargar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonCargar = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxTienda = new System.Windows.Forms.ComboBox();
            this.labelDetalleAnaquel = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonCapturar = new System.Windows.Forms.ToolStripButton();
            this.buttonLoadCaptura = new System.Windows.Forms.ToolStripButton();
            this.buttonSettings = new System.Windows.Forms.ToolStripButton();
            this.logBox = new System.Windows.Forms.TextBox();
            this.buttonEliminarDetalle = new System.Windows.Forms.Button();
            this.buttonAgregarDetalle = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonDescargaManual = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewAnaqueles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDetalles)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(827, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printSetupToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(140, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(140, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            // 
            // printSetupToolStripMenuItem
            // 
            this.printSetupToolStripMenuItem.Name = "printSetupToolStripMenuItem";
            this.printSetupToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printSetupToolStripMenuItem.Text = "Print Setup";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Anaqueles";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 20);
            this.textBox1.TabIndex = 3;
            // 
            // viewAnaqueles
            // 
            this.viewAnaqueles.AllowUserToAddRows = false;
            this.viewAnaqueles.AllowUserToDeleteRows = false;
            this.viewAnaqueles.AllowUserToOrderColumns = true;
            this.viewAnaqueles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewAnaqueles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Anaquel,
            this.Contado,
            this.Pistol,
            this.Status,
            this.Error});
            this.viewAnaqueles.Location = new System.Drawing.Point(12, 85);
            this.viewAnaqueles.MultiSelect = false;
            this.viewAnaqueles.Name = "viewAnaqueles";
            this.viewAnaqueles.Size = new System.Drawing.Size(291, 343);
            this.viewAnaqueles.TabIndex = 5;
            this.viewAnaqueles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewAnaqueles_CellContentClick);
            // 
            // Anaquel
            // 
            this.Anaquel.HeaderText = "Anaquel";
            this.Anaquel.Name = "Anaquel";
            this.Anaquel.Width = 50;
            // 
            // Contado
            // 
            this.Contado.HeaderText = "Contado";
            this.Contado.Name = "Contado";
            this.Contado.Width = 50;
            // 
            // Pistol
            // 
            this.Pistol.HeaderText = "Pistol.";
            this.Pistol.Name = "Pistol";
            this.Pistol.Width = 50;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 50;
            // 
            // Error
            // 
            this.Error.HeaderText = "Error";
            this.Error.Name = "Error";
            this.Error.ReadOnly = true;
            this.Error.Width = 50;
            // 
            // viewDetalles
            // 
            this.viewDetalles.AllowUserToAddRows = false;
            this.viewDetalles.AllowUserToDeleteRows = false;
            this.viewDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viewDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Cant});
            this.viewDetalles.Location = new System.Drawing.Point(363, 66);
            this.viewDetalles.Name = "viewDetalles";
            this.viewDetalles.Size = new System.Drawing.Size(204, 362);
            this.viewDetalles.TabIndex = 7;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Cant
            // 
            this.Cant.HeaderText = "Cant";
            this.Cant.Name = "Cant";
            this.Cant.Width = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(656, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Contados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(656, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Pistol.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(656, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Error";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(658, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "OK";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(656, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "OK %";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(771, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Pares";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(680, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Log de Entrada";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(582, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Tienda";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(708, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "Anaqueles";
            // 
            // textAnaqContados
            // 
            this.textAnaqContados.Location = new System.Drawing.Point(714, 82);
            this.textAnaqContados.Name = "textAnaqContados";
            this.textAnaqContados.ReadOnly = true;
            this.textAnaqContados.Size = new System.Drawing.Size(48, 20);
            this.textAnaqContados.TabIndex = 17;
            // 
            // textAnaqPistol
            // 
            this.textAnaqPistol.Location = new System.Drawing.Point(714, 104);
            this.textAnaqPistol.Name = "textAnaqPistol";
            this.textAnaqPistol.ReadOnly = true;
            this.textAnaqPistol.Size = new System.Drawing.Size(48, 20);
            this.textAnaqPistol.TabIndex = 18;
            // 
            // textAnaqError
            // 
            this.textAnaqError.Location = new System.Drawing.Point(714, 126);
            this.textAnaqError.Name = "textAnaqError";
            this.textAnaqError.ReadOnly = true;
            this.textAnaqError.Size = new System.Drawing.Size(48, 20);
            this.textAnaqError.TabIndex = 19;
            // 
            // textAnaqOK
            // 
            this.textAnaqOK.Location = new System.Drawing.Point(714, 149);
            this.textAnaqOK.Name = "textAnaqOK";
            this.textAnaqOK.ReadOnly = true;
            this.textAnaqOK.Size = new System.Drawing.Size(48, 20);
            this.textAnaqOK.TabIndex = 20;
            // 
            // textAnaqOKPercent
            // 
            this.textAnaqOKPercent.Location = new System.Drawing.Point(714, 171);
            this.textAnaqOKPercent.Name = "textAnaqOKPercent";
            this.textAnaqOKPercent.ReadOnly = true;
            this.textAnaqOKPercent.Size = new System.Drawing.Size(48, 20);
            this.textAnaqOKPercent.TabIndex = 21;
            // 
            // textParesOKPercent
            // 
            this.textParesOKPercent.Location = new System.Drawing.Point(768, 171);
            this.textParesOKPercent.Name = "textParesOKPercent";
            this.textParesOKPercent.ReadOnly = true;
            this.textParesOKPercent.Size = new System.Drawing.Size(48, 20);
            this.textParesOKPercent.TabIndex = 26;
            // 
            // textParesOK
            // 
            this.textParesOK.Location = new System.Drawing.Point(768, 149);
            this.textParesOK.Name = "textParesOK";
            this.textParesOK.ReadOnly = true;
            this.textParesOK.Size = new System.Drawing.Size(48, 20);
            this.textParesOK.TabIndex = 25;
            // 
            // textParesError
            // 
            this.textParesError.Location = new System.Drawing.Point(768, 126);
            this.textParesError.Name = "textParesError";
            this.textParesError.ReadOnly = true;
            this.textParesError.Size = new System.Drawing.Size(48, 20);
            this.textParesError.TabIndex = 24;
            // 
            // textParesPistol
            // 
            this.textParesPistol.Location = new System.Drawing.Point(768, 104);
            this.textParesPistol.Name = "textParesPistol";
            this.textParesPistol.ReadOnly = true;
            this.textParesPistol.Size = new System.Drawing.Size(48, 20);
            this.textParesPistol.TabIndex = 23;
            // 
            // textParesContados
            // 
            this.textParesContados.Location = new System.Drawing.Point(768, 82);
            this.textParesContados.Name = "textParesContados";
            this.textParesContados.ReadOnly = true;
            this.textParesContados.Size = new System.Drawing.Size(48, 20);
            this.textParesContados.TabIndex = 22;
            // 
            // buttonOrdenar
            // 
            this.buttonOrdenar.Location = new System.Drawing.Point(12, 434);
            this.buttonOrdenar.Name = "buttonOrdenar";
            this.buttonOrdenar.Size = new System.Drawing.Size(75, 23);
            this.buttonOrdenar.TabIndex = 27;
            this.buttonOrdenar.Text = "Ordenar";
            this.buttonOrdenar.UseVisualStyleBackColor = true;
            this.buttonOrdenar.Click += new System.EventHandler(this.buttonOrdenar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(228, 434);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminar.TabIndex = 28;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonBorrarLog
            // 
            this.buttonBorrarLog.Location = new System.Drawing.Point(699, 432);
            this.buttonBorrarLog.Name = "buttonBorrarLog";
            this.buttonBorrarLog.Size = new System.Drawing.Size(75, 23);
            this.buttonBorrarLog.TabIndex = 29;
            this.buttonBorrarLog.Text = "Borrar Log";
            this.buttonBorrarLog.UseVisualStyleBackColor = true;
            this.buttonBorrarLog.Click += new System.EventHandler(this.buttonBorrarLog_Click);
            // 
            // buttonRetomar
            // 
            this.buttonRetomar.Location = new System.Drawing.Point(166, 434);
            this.buttonRetomar.Name = "buttonRetomar";
            this.buttonRetomar.Size = new System.Drawing.Size(56, 23);
            this.buttonRetomar.TabIndex = 30;
            this.buttonRetomar.Text = "Retomar";
            this.buttonRetomar.UseVisualStyleBackColor = true;
            this.buttonRetomar.Click += new System.EventHandler(this.buttonRetomar_Click);
            // 
            // buttonDescargar
            // 
            this.buttonDescargar.Location = new System.Drawing.Point(576, 386);
            this.buttonDescargar.Name = "buttonDescargar";
            this.buttonDescargar.Size = new System.Drawing.Size(64, 42);
            this.buttonDescargar.TabIndex = 31;
            this.buttonDescargar.Text = "Descargar";
            this.buttonDescargar.UseVisualStyleBackColor = true;
            this.buttonDescargar.Click += new System.EventHandler(this.buttonDescargar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(576, 270);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(64, 66);
            this.buttonGuardar.TabIndex = 32;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonCargar
            // 
            this.buttonCargar.Location = new System.Drawing.Point(576, 222);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(64, 23);
            this.buttonCargar.TabIndex = 35;
            this.buttonCargar.Text = "Cargar";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(93, 438);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 17);
            this.checkBox1.TabIndex = 36;
            this.checkBox1.Text = "OK Abajo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(309, 270);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 43);
            this.label12.TabIndex = 37;
            this.label12.Text = "Detalle de Anaquel";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // textBoxTienda
            // 
            this.textBoxTienda.FormattingEnabled = true;
            this.textBoxTienda.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.textBoxTienda.Location = new System.Drawing.Point(576, 195);
            this.textBoxTienda.MaxDropDownItems = 13;
            this.textBoxTienda.Name = "textBoxTienda";
            this.textBoxTienda.Size = new System.Drawing.Size(61, 21);
            this.textBoxTienda.TabIndex = 38;
            // 
            // labelDetalleAnaquel
            // 
            this.labelDetalleAnaquel.Location = new System.Drawing.Point(312, 316);
            this.labelDetalleAnaquel.Name = "labelDetalleAnaquel";
            this.labelDetalleAnaquel.ReadOnly = true;
            this.labelDetalleAnaquel.Size = new System.Drawing.Size(42, 20);
            this.labelDetalleAnaquel.TabIndex = 39;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonCapturar,
            this.buttonLoadCaptura,
            this.buttonSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(827, 25);
            this.toolStrip1.TabIndex = 40;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonCapturar
            // 
            this.buttonCapturar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonCapturar.Image = ((System.Drawing.Image)(resources.GetObject("buttonCapturar.Image")));
            this.buttonCapturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCapturar.Name = "buttonCapturar";
            this.buttonCapturar.Size = new System.Drawing.Size(94, 22);
            this.buttonCapturar.Text = "Nueva Capturar";
            this.buttonCapturar.Click += new System.EventHandler(this.buttonCapturar_Click);
            // 
            // buttonLoadCaptura
            // 
            this.buttonLoadCaptura.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonLoadCaptura.Image = ((System.Drawing.Image)(resources.GetObject("buttonLoadCaptura.Image")));
            this.buttonLoadCaptura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonLoadCaptura.Name = "buttonLoadCaptura";
            this.buttonLoadCaptura.Size = new System.Drawing.Size(82, 22);
            this.buttonLoadCaptura.Text = "Load Captura";
            this.buttonLoadCaptura.Click += new System.EventHandler(this.buttonLoadCaptura_Click_1);
            // 
            // buttonSettings
            // 
            this.buttonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(53, 22);
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(661, 219);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(155, 209);
            this.logBox.TabIndex = 41;
            // 
            // buttonEliminarDetalle
            // 
            this.buttonEliminarDetalle.Location = new System.Drawing.Point(444, 432);
            this.buttonEliminarDetalle.Name = "buttonEliminarDetalle";
            this.buttonEliminarDetalle.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminarDetalle.TabIndex = 42;
            this.buttonEliminarDetalle.Text = "Eliminar";
            this.buttonEliminarDetalle.UseVisualStyleBackColor = true;
            this.buttonEliminarDetalle.Click += new System.EventHandler(this.buttonEliminarDetalle_Click);
            // 
            // buttonAgregarDetalle
            // 
            this.buttonAgregarDetalle.Location = new System.Drawing.Point(363, 432);
            this.buttonAgregarDetalle.Name = "buttonAgregarDetalle";
            this.buttonAgregarDetalle.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregarDetalle.TabIndex = 43;
            this.buttonAgregarDetalle.Text = "Agregar";
            this.buttonAgregarDetalle.UseVisualStyleBackColor = true;
            this.buttonAgregarDetalle.Click += new System.EventHandler(this.buttonAgregarDetalle_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonDescargaManual
            // 
            this.buttonDescargaManual.Location = new System.Drawing.Point(554, 434);
            this.buttonDescargaManual.Name = "buttonDescargaManual";
            this.buttonDescargaManual.Size = new System.Drawing.Size(114, 23);
            this.buttonDescargaManual.TabIndex = 44;
            this.buttonDescargaManual.Text = "Descarga Manual";
            this.buttonDescargaManual.UseVisualStyleBackColor = true;
            this.buttonDescargaManual.Click += new System.EventHandler(this.buttonDescargaManual_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 464);
            this.Controls.Add(this.buttonDescargaManual);
            this.Controls.Add(this.buttonAgregarDetalle);
            this.Controls.Add(this.buttonEliminarDetalle);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.labelDetalleAnaquel);
            this.Controls.Add(this.textBoxTienda);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonCargar);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonDescargar);
            this.Controls.Add(this.buttonRetomar);
            this.Controls.Add(this.buttonBorrarLog);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonOrdenar);
            this.Controls.Add(this.textParesOKPercent);
            this.Controls.Add(this.textParesOK);
            this.Controls.Add(this.textParesError);
            this.Controls.Add(this.textParesPistol);
            this.Controls.Add(this.textParesContados);
            this.Controls.Add(this.textAnaqOKPercent);
            this.Controls.Add(this.textAnaqOK);
            this.Controls.Add(this.textAnaqError);
            this.Controls.Add(this.textAnaqPistol);
            this.Controls.Add(this.textAnaqContados);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.viewDetalles);
            this.Controls.Add(this.viewAnaqueles);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "BcScan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viewAnaqueles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewDetalles)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView viewAnaqueles;
        private System.Windows.Forms.DataGridView viewDetalles;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textAnaqContados;
        private System.Windows.Forms.TextBox textAnaqPistol;
        private System.Windows.Forms.TextBox textAnaqError;
        private System.Windows.Forms.TextBox textAnaqOK;
        private System.Windows.Forms.TextBox textAnaqOKPercent;
        private System.Windows.Forms.TextBox textParesOKPercent;
        private System.Windows.Forms.TextBox textParesOK;
        private System.Windows.Forms.TextBox textParesError;
        private System.Windows.Forms.TextBox textParesPistol;
        private System.Windows.Forms.TextBox textParesContados;
        private System.Windows.Forms.Button buttonOrdenar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonBorrarLog;
        private System.Windows.Forms.Button buttonRetomar;
        private System.Windows.Forms.Button buttonDescargar;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox textBoxTienda;
        private System.Windows.Forms.TextBox labelDetalleAnaquel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.ToolStripButton buttonCapturar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anaquel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pistol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.Button buttonEliminarDetalle;
        private System.Windows.Forms.Button buttonAgregarDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonDescargaManual;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripButton buttonLoadCaptura;
        private System.Windows.Forms.ToolStripButton buttonSettings;
    }
}

