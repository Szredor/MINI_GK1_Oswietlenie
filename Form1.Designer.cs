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
            this.pictureBoxSchemat = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOptions.Location = new System.Drawing.Point(623, 3);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(174, 444);
            this.groupBoxOptions.TabIndex = 0;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Opcje";
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
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSchemat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.PictureBox pictureBoxSchemat;
    }
}

