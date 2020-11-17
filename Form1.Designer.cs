namespace Oswietlenie
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSchemat = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxParameters = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownWave = new System.Windows.Forms.NumericUpDown();
            this.numericKS = new System.Windows.Forms.NumericUpDown();
            this.numericKD = new System.Windows.Forms.NumericUpDown();
            this.numericM = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxObjCol = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxNorMap = new System.Windows.Forms.GroupBox();
            this.radioWaveNM = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButtonNMFile = new System.Windows.Forms.RadioButton();
            this.radioButtonNMStatic = new System.Windows.Forms.RadioButton();
            this.groupBoxLightVec = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxLightMove = new System.Windows.Forms.GroupBox();
            this.radioButtonLightStatic = new System.Windows.Forms.RadioButton();
            this.radioButtonLightMove = new System.Windows.Forms.RadioButton();
            this.groupBoxColorMethod = new System.Windows.Forms.GroupBox();
            this.radioButtonLightAcurate = new System.Windows.Forms.RadioButton();
            this.radioButtonLightApprox = new System.Windows.Forms.RadioButton();
            this.groupBoxMesh = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.colorDialogObject = new System.Windows.Forms.ColorDialog();
            this.colorDialogLight = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSchemat)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericKS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericKD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericM)).BeginInit();
            this.groupBoxObjCol.SuspendLayout();
            this.groupBoxNorMap.SuspendLayout();
            this.groupBoxLightVec.SuspendLayout();
            this.groupBoxLightMove.SuspendLayout();
            this.groupBoxColorMethod.SuspendLayout();
            this.groupBoxMesh.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxSchemat, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 741F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 741F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 741F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 741F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1464, 741);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxSchemat
            // 
            this.pictureBoxSchemat.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxSchemat.Name = "pictureBoxSchemat";
            this.pictureBoxSchemat.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxSchemat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSchemat.TabIndex = 1;
            this.pictureBoxSchemat.TabStop = false;
            this.pictureBoxSchemat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSchemat_MouseDown);
            this.pictureBoxSchemat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSchemat_MouseMove);
            this.pictureBoxSchemat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSchemat_MouseUp);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBoxParameters, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxObjCol, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxNorMap, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxLightVec, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxLightMove, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxColorMethod, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxMesh, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1287, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(174, 735);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // groupBoxParameters
            // 
            this.groupBoxParameters.Controls.Add(this.label10);
            this.groupBoxParameters.Controls.Add(this.label9);
            this.groupBoxParameters.Controls.Add(this.numericUpDownWave);
            this.groupBoxParameters.Controls.Add(this.numericKS);
            this.groupBoxParameters.Controls.Add(this.numericKD);
            this.groupBoxParameters.Controls.Add(this.numericM);
            this.groupBoxParameters.Controls.Add(this.label6);
            this.groupBoxParameters.Controls.Add(this.label4);
            this.groupBoxParameters.Controls.Add(this.label3);
            this.groupBoxParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxParameters.Location = new System.Drawing.Point(3, 431);
            this.groupBoxParameters.Name = "groupBoxParameters";
            this.groupBoxParameters.Size = new System.Drawing.Size(168, 145);
            this.groupBoxParameters.TabIndex = 4;
            this.groupBoxParameters.TabStop = false;
            this.groupBoxParameters.Text = "Parametry";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "fala";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-39, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "label9";
            // 
            // numericUpDownWave
            // 
            this.numericUpDownWave.Location = new System.Drawing.Point(42, 109);
            this.numericUpDownWave.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWave.Name = "numericUpDownWave";
            this.numericUpDownWave.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownWave.TabIndex = 5;
            this.numericUpDownWave.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWave.ValueChanged += new System.EventHandler(this.numericUpDownWave_ValueChanged);
            // 
            // numericKS
            // 
            this.numericKS.DecimalPlaces = 2;
            this.numericKS.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericKS.Location = new System.Drawing.Point(42, 51);
            this.numericKS.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericKS.Name = "numericKS";
            this.numericKS.Size = new System.Drawing.Size(120, 23);
            this.numericKS.TabIndex = 4;
            this.numericKS.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericKS.ValueChanged += new System.EventHandler(this.numericKS_ValueChanged);
            // 
            // numericKD
            // 
            this.numericKD.DecimalPlaces = 2;
            this.numericKD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericKD.Location = new System.Drawing.Point(42, 22);
            this.numericKD.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericKD.Name = "numericKD";
            this.numericKD.Size = new System.Drawing.Size(120, 23);
            this.numericKD.TabIndex = 4;
            this.numericKD.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericKD.ValueChanged += new System.EventHandler(this.numericKD_ValueChanged);
            // 
            // numericM
            // 
            this.numericM.Location = new System.Drawing.Point(42, 80);
            this.numericM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericM.Name = "numericM";
            this.numericM.Size = new System.Drawing.Size(120, 23);
            this.numericM.TabIndex = 3;
            this.numericM.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericM.ValueChanged += new System.EventHandler(this.numericM_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "m";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "ks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "kd";
            // 
            // groupBoxObjCol
            // 
            this.groupBoxObjCol.Controls.Add(this.button2);
            this.groupBoxObjCol.Controls.Add(this.button1);
            this.groupBoxObjCol.Controls.Add(this.label2);
            this.groupBoxObjCol.Controls.Add(this.label1);
            this.groupBoxObjCol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxObjCol.Location = new System.Drawing.Point(3, 3);
            this.groupBoxObjCol.Name = "groupBoxObjCol";
            this.groupBoxObjCol.Size = new System.Drawing.Size(168, 94);
            this.groupBoxObjCol.TabIndex = 0;
            this.groupBoxObjCol.TabStop = false;
            this.groupBoxObjCol.Text = "Kolor obiektu";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(51, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Plik...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kolor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tekstura z pliku";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stały kolor";
            // 
            // groupBoxNorMap
            // 
            this.groupBoxNorMap.Controls.Add(this.radioWaveNM);
            this.groupBoxNorMap.Controls.Add(this.button3);
            this.groupBoxNorMap.Controls.Add(this.radioButtonNMFile);
            this.groupBoxNorMap.Controls.Add(this.radioButtonNMStatic);
            this.groupBoxNorMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNorMap.Location = new System.Drawing.Point(3, 103);
            this.groupBoxNorMap.Name = "groupBoxNorMap";
            this.groupBoxNorMap.Size = new System.Drawing.Size(168, 102);
            this.groupBoxNorMap.TabIndex = 1;
            this.groupBoxNorMap.TabStop = false;
            this.groupBoxNorMap.Text = "Normal Map";
            // 
            // radioWaveNM
            // 
            this.radioWaveNM.AutoSize = true;
            this.radioWaveNM.Location = new System.Drawing.Point(7, 73);
            this.radioWaveNM.Name = "radioWaveNM";
            this.radioWaveNM.Size = new System.Drawing.Size(74, 19);
            this.radioWaveNM.TabIndex = 5;
            this.radioWaveNM.TabStop = true;
            this.radioWaveNM.Text = "Mapa fali";
            this.radioWaveNM.UseVisualStyleBackColor = true;
            this.radioWaveNM.CheckedChanged += new System.EventHandler(this.radioWaveNM_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(100, 47);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Plik...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // radioButtonNMFile
            // 
            this.radioButtonNMFile.AutoSize = true;
            this.radioButtonNMFile.Location = new System.Drawing.Point(7, 47);
            this.radioButtonNMFile.Name = "radioButtonNMFile";
            this.radioButtonNMFile.Size = new System.Drawing.Size(92, 19);
            this.radioButtonNMFile.TabIndex = 3;
            this.radioButtonNMFile.TabStop = true;
            this.radioButtonNMFile.Text = "Mapa z pliku";
            this.radioButtonNMFile.UseVisualStyleBackColor = true;
            this.radioButtonNMFile.CheckedChanged += new System.EventHandler(this.radioButtonNMFile_CheckedChanged);
            // 
            // radioButtonNMStatic
            // 
            this.radioButtonNMStatic.AutoSize = true;
            this.radioButtonNMStatic.Checked = true;
            this.radioButtonNMStatic.Location = new System.Drawing.Point(6, 22);
            this.radioButtonNMStatic.Name = "radioButtonNMStatic";
            this.radioButtonNMStatic.Size = new System.Drawing.Size(131, 19);
            this.radioButtonNMStatic.TabIndex = 2;
            this.radioButtonNMStatic.TabStop = true;
            this.radioButtonNMStatic.Text = "Wektor stały [0, 0, 1]";
            this.radioButtonNMStatic.UseVisualStyleBackColor = true;
            this.radioButtonNMStatic.CheckedChanged += new System.EventHandler(this.radioButtonNMStatic_CheckedChanged_1);
            // 
            // groupBoxLightVec
            // 
            this.groupBoxLightVec.Controls.Add(this.button4);
            this.groupBoxLightVec.Controls.Add(this.label5);
            this.groupBoxLightVec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLightVec.Location = new System.Drawing.Point(3, 211);
            this.groupBoxLightVec.Name = "groupBoxLightVec";
            this.groupBoxLightVec.Size = new System.Drawing.Size(168, 49);
            this.groupBoxLightVec.TabIndex = 2;
            this.groupBoxLightVec.TabStop = false;
            this.groupBoxLightVec.Text = "Kolor światła";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(100, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(51, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Kolor";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Stały kolor";
            // 
            // groupBoxLightMove
            // 
            this.groupBoxLightMove.Controls.Add(this.radioButtonLightStatic);
            this.groupBoxLightMove.Controls.Add(this.radioButtonLightMove);
            this.groupBoxLightMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxLightMove.Location = new System.Drawing.Point(3, 266);
            this.groupBoxLightMove.Name = "groupBoxLightMove";
            this.groupBoxLightMove.Size = new System.Drawing.Size(168, 76);
            this.groupBoxLightMove.TabIndex = 3;
            this.groupBoxLightMove.TabStop = false;
            this.groupBoxLightMove.Text = "Zachowanie światła";
            // 
            // radioButtonLightStatic
            // 
            this.radioButtonLightStatic.AutoSize = true;
            this.radioButtonLightStatic.Checked = true;
            this.radioButtonLightStatic.Location = new System.Drawing.Point(6, 22);
            this.radioButtonLightStatic.Name = "radioButtonLightStatic";
            this.radioButtonLightStatic.Size = new System.Drawing.Size(131, 19);
            this.radioButtonLightStatic.TabIndex = 2;
            this.radioButtonLightStatic.TabStop = true;
            this.radioButtonLightStatic.Text = "Wektor stały [0, 0, 1]";
            this.radioButtonLightStatic.UseVisualStyleBackColor = true;
            this.radioButtonLightStatic.CheckedChanged += new System.EventHandler(this.radioButtonLightStatic_CheckedChanged);
            // 
            // radioButtonLightMove
            // 
            this.radioButtonLightMove.AutoSize = true;
            this.radioButtonLightMove.Location = new System.Drawing.Point(6, 47);
            this.radioButtonLightMove.Name = "radioButtonLightMove";
            this.radioButtonLightMove.Size = new System.Drawing.Size(115, 19);
            this.radioButtonLightMove.TabIndex = 3;
            this.radioButtonLightMove.Text = "Poruszaj w spirali";
            this.radioButtonLightMove.UseVisualStyleBackColor = true;
            this.radioButtonLightMove.CheckedChanged += new System.EventHandler(this.radioButtonLightMove_CheckedChanged);
            // 
            // groupBoxColorMethod
            // 
            this.groupBoxColorMethod.Controls.Add(this.radioButtonLightAcurate);
            this.groupBoxColorMethod.Controls.Add(this.radioButtonLightApprox);
            this.groupBoxColorMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxColorMethod.Location = new System.Drawing.Point(3, 348);
            this.groupBoxColorMethod.Name = "groupBoxColorMethod";
            this.groupBoxColorMethod.Size = new System.Drawing.Size(168, 77);
            this.groupBoxColorMethod.TabIndex = 4;
            this.groupBoxColorMethod.TabStop = false;
            this.groupBoxColorMethod.Text = "Model oświetlenia";
            // 
            // radioButtonLightAcurate
            // 
            this.radioButtonLightAcurate.AutoSize = true;
            this.radioButtonLightAcurate.Checked = true;
            this.radioButtonLightAcurate.Location = new System.Drawing.Point(6, 22);
            this.radioButtonLightAcurate.Name = "radioButtonLightAcurate";
            this.radioButtonLightAcurate.Size = new System.Drawing.Size(75, 19);
            this.radioButtonLightAcurate.TabIndex = 2;
            this.radioButtonLightAcurate.TabStop = true;
            this.radioButtonLightAcurate.Text = "Dokładny";
            this.radioButtonLightAcurate.UseVisualStyleBackColor = true;
            this.radioButtonLightAcurate.CheckedChanged += new System.EventHandler(this.radioButtonLightAcurate_CheckedChanged);
            // 
            // radioButtonLightApprox
            // 
            this.radioButtonLightApprox.AutoSize = true;
            this.radioButtonLightApprox.Location = new System.Drawing.Point(6, 47);
            this.radioButtonLightApprox.Name = "radioButtonLightApprox";
            this.radioButtonLightApprox.Size = new System.Drawing.Size(85, 19);
            this.radioButtonLightApprox.TabIndex = 3;
            this.radioButtonLightApprox.Text = "Przyblizony";
            this.radioButtonLightApprox.UseVisualStyleBackColor = true;
            this.radioButtonLightApprox.CheckedChanged += new System.EventHandler(this.radioButtonLightApprox_CheckedChanged);
            // 
            // groupBoxMesh
            // 
            this.groupBoxMesh.Controls.Add(this.label8);
            this.groupBoxMesh.Controls.Add(this.label7);
            this.groupBoxMesh.Controls.Add(this.numericUpDownRows);
            this.groupBoxMesh.Controls.Add(this.numericUpDownCols);
            this.groupBoxMesh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxMesh.Location = new System.Drawing.Point(3, 582);
            this.groupBoxMesh.Name = "groupBoxMesh";
            this.groupBoxMesh.Size = new System.Drawing.Size(168, 88);
            this.groupBoxMesh.TabIndex = 5;
            this.groupBoxMesh.TabStop = false;
            this.groupBoxMesh.Text = "Siatka";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "kolumny";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "wiersze";
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(68, 51);
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(94, 23);
            this.numericUpDownRows.TabIndex = 1;
            this.numericUpDownRows.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRows.ValueChanged += new System.EventHandler(this.numericUpDownRows_ValueChanged);
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.Location = new System.Drawing.Point(68, 22);
            this.numericUpDownCols.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(94, 23);
            this.numericUpDownCols.TabIndex = 0;
            this.numericUpDownCols.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCols.ValueChanged += new System.EventHandler(this.numericUpDownCols_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = ".\\Images\\Textures\\";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.InitialDirectory = ".\\Images\\NormalMaps\\";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 741);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSchemat)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBoxParameters.ResumeLayout(false);
            this.groupBoxParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericKS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericKD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericM)).EndInit();
            this.groupBoxObjCol.ResumeLayout(false);
            this.groupBoxObjCol.PerformLayout();
            this.groupBoxNorMap.ResumeLayout(false);
            this.groupBoxNorMap.PerformLayout();
            this.groupBoxLightVec.ResumeLayout(false);
            this.groupBoxLightVec.PerformLayout();
            this.groupBoxLightMove.ResumeLayout(false);
            this.groupBoxLightMove.PerformLayout();
            this.groupBoxColorMethod.ResumeLayout(false);
            this.groupBoxColorMethod.PerformLayout();
            this.groupBoxMesh.ResumeLayout(false);
            this.groupBoxMesh.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxSchemat;
        private System.Windows.Forms.ColorDialog colorDialogObject;
        private System.Windows.Forms.ColorDialog colorDialogLight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBoxObjCol;
        private System.Windows.Forms.GroupBox groupBoxNorMap;
        private System.Windows.Forms.GroupBox groupBoxLightVec;
        private System.Windows.Forms.GroupBox groupBoxLightMove;
        private System.Windows.Forms.GroupBox groupBoxColorMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonNMFile;
        private System.Windows.Forms.RadioButton radioButtonNMStatic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonLightStatic;
        private System.Windows.Forms.RadioButton radioButtonLightMove;
        private System.Windows.Forms.RadioButton radioButtonLightAcurate;
        private System.Windows.Forms.RadioButton radioButtonLightApprox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBoxParameters;
        private System.Windows.Forms.NumericUpDown numericKD;
        private System.Windows.Forms.NumericUpDown numericM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericKS;
        private System.Windows.Forms.GroupBox groupBoxMesh;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.NumericUpDown numericUpDownWave;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioWaveNM;
    }
}

