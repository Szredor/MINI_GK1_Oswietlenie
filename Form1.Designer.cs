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
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.buttonColorObject = new System.Windows.Forms.Button();
            this.pictureBoxSchemat = new System.Windows.Forms.PictureBox();
            this.colorDialogObject = new System.Windows.Forms.ColorDialog();
            this.colorDialogLight = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSchemat)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxOptions, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxSchemat, 0, 0);
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
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.buttonColorObject);
            this.groupBoxOptions.Location = new System.Drawing.Point(1287, 3);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(174, 735);
            this.groupBoxOptions.TabIndex = 0;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Opcje";
            // 
            // buttonColorObject
            // 
            this.buttonColorObject.Location = new System.Drawing.Point(23, 23);
            this.buttonColorObject.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.buttonColorObject.Name = "buttonColorObject";
            this.buttonColorObject.Size = new System.Drawing.Size(125, 23);
            this.buttonColorObject.TabIndex = 0;
            this.buttonColorObject.Text = "Kolor obiektu";
            this.buttonColorObject.UseVisualStyleBackColor = true;
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
            this.groupBoxOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSchemat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxSchemat;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.Button buttonColorObject;
        private System.Windows.Forms.ColorDialog colorDialogObject;
        private System.Windows.Forms.ColorDialog colorDialogLight;
    }
}

