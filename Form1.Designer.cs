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
            this.groupBoxObjCol = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxNorMap = new System.Windows.Forms.GroupBox();
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
            this.colorDialogObject = new System.Windows.Forms.ColorDialog();
            this.colorDialogLight = new System.Windows.Forms.ColorDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSchemat)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxObjCol.SuspendLayout();
            this.groupBoxNorMap.SuspendLayout();
            this.groupBoxLightVec.SuspendLayout();
            this.groupBoxLightMove.SuspendLayout();
            this.groupBoxColorMethod.SuspendLayout();
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
            this.tableLayoutPanel2.Controls.Add(this.groupBoxObjCol, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxNorMap, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxLightVec, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxLightMove, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBoxColorMethod, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1287, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(174, 735);
            this.tableLayoutPanel2.TabIndex = 2;
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
            this.groupBoxNorMap.Controls.Add(this.button3);
            this.groupBoxNorMap.Controls.Add(this.radioButtonNMFile);
            this.groupBoxNorMap.Controls.Add(this.radioButtonNMStatic);
            this.groupBoxNorMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxNorMap.Location = new System.Drawing.Point(3, 103);
            this.groupBoxNorMap.Name = "groupBoxNorMap";
            this.groupBoxNorMap.Size = new System.Drawing.Size(168, 83);
            this.groupBoxNorMap.TabIndex = 1;
            this.groupBoxNorMap.TabStop = false;
            this.groupBoxNorMap.Text = "Normal Map";
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
            this.groupBoxLightVec.Location = new System.Drawing.Point(3, 192);
            this.groupBoxLightVec.Name = "groupBoxLightVec";
            this.groupBoxLightVec.Size = new System.Drawing.Size(168, 54);
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
            this.groupBoxLightMove.Location = new System.Drawing.Point(3, 252);
            this.groupBoxLightMove.Name = "groupBoxLightMove";
            this.groupBoxLightMove.Size = new System.Drawing.Size(168, 74);
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
            this.groupBoxColorMethod.Location = new System.Drawing.Point(3, 332);
            this.groupBoxColorMethod.Name = "groupBoxColorMethod";
            this.groupBoxColorMethod.Size = new System.Drawing.Size(168, 75);
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
    }
}

