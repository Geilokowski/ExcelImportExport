namespace ProExcelImportExport
{
    partial class FoExcelImportExport
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
            this.btImportZensos = new System.Windows.Forms.Button();
            this.lbZensosDatei = new System.Windows.Forms.Label();
            this.cBZensosDateiExistenz = new System.Windows.Forms.CheckBox();
            this.cBBestandsDateiExistenz = new System.Windows.Forms.CheckBox();
            this.btImportBestand = new System.Windows.Forms.Button();
            this.lbBestandsDatei = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btImportZensos
            // 
            this.btImportZensos.Location = new System.Drawing.Point(210, 75);
            this.btImportZensos.Name = "btImportZensos";
            this.btImportZensos.Size = new System.Drawing.Size(196, 23);
            this.btImportZensos.TabIndex = 1;
            this.btImportZensos.Text = "Wähle eine andere Zensosdatei aus";
            this.btImportZensos.UseVisualStyleBackColor = true;
            this.btImportZensos.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbZensosDatei
            // 
            this.lbZensosDatei.AutoSize = true;
            this.lbZensosDatei.Location = new System.Drawing.Point(20, 124);
            this.lbZensosDatei.Name = "lbZensosDatei";
            this.lbZensosDatei.Size = new System.Drawing.Size(35, 13);
            this.lbZensosDatei.TabIndex = 2;
            this.lbZensosDatei.Text = "label1";
            // 
            // cBZensosDateiExistenz
            // 
            this.cBZensosDateiExistenz.AutoSize = true;
            this.cBZensosDateiExistenz.Location = new System.Drawing.Point(23, 81);
            this.cBZensosDateiExistenz.Name = "cBZensosDateiExistenz";
            this.cBZensosDateiExistenz.Size = new System.Drawing.Size(122, 17);
            this.cBZensosDateiExistenz.TabIndex = 5;
            this.cBZensosDateiExistenz.Text = "Zensosdatei existiert";
            this.cBZensosDateiExistenz.UseVisualStyleBackColor = true;
            // 
            // cBBestandsDateiExistenz
            // 
            this.cBBestandsDateiExistenz.AutoSize = true;
            this.cBBestandsDateiExistenz.Location = new System.Drawing.Point(23, 12);
            this.cBBestandsDateiExistenz.Name = "cBBestandsDateiExistenz";
            this.cBBestandsDateiExistenz.Size = new System.Drawing.Size(131, 17);
            this.cBBestandsDateiExistenz.TabIndex = 6;
            this.cBBestandsDateiExistenz.Text = "Bestandsdatei existiert";
            this.cBBestandsDateiExistenz.UseVisualStyleBackColor = true;
            // 
            // btImportBestand
            // 
            this.btImportBestand.Location = new System.Drawing.Point(210, 6);
            this.btImportBestand.Name = "btImportBestand";
            this.btImportBestand.Size = new System.Drawing.Size(219, 23);
            this.btImportBestand.TabIndex = 7;
            this.btImportBestand.Text = "Wähle eine andere Bestandsdatei aus";
            this.btImportBestand.UseVisualStyleBackColor = true;
            this.btImportBestand.Click += new System.EventHandler(this.btImportBestand_Click);
            // 
            // lbBestandsDatei
            // 
            this.lbBestandsDatei.AutoSize = true;
            this.lbBestandsDatei.Location = new System.Drawing.Point(20, 46);
            this.lbBestandsDatei.Name = "lbBestandsDatei";
            this.lbBestandsDatei.Size = new System.Drawing.Size(35, 13);
            this.lbBestandsDatei.TabIndex = 8;
            this.lbBestandsDatei.Text = "label1";
            // 
            // FoExcelImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cBBestandsDateiExistenz);
            this.Controls.Add(this.lbBestandsDatei);
            this.Controls.Add(this.btImportBestand);
            this.Controls.Add(this.cBZensosDateiExistenz);
            this.Controls.Add(this.lbZensosDatei);
            this.Controls.Add(this.btImportZensos);
            this.Name = "FoExcelImportExport";
            this.Text = "FoExcelImportExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btImportZensos;
        private System.Windows.Forms.Label lbZensosDatei;
        private System.Windows.Forms.CheckBox cBZensosDateiExistenz;
        private System.Windows.Forms.CheckBox cBBestandsDateiExistenz;
        private System.Windows.Forms.Button btImportBestand;
        private System.Windows.Forms.Label lbBestandsDatei;
    }
}