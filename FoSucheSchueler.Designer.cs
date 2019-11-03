namespace ProExcelImportExport
{
    partial class FoSucheSchueler
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
            this.btClose = new System.Windows.Forms.Button();
            this.tBEingabeSuchBegriff = new System.Windows.Forms.TextBox();
            this.lBAuswahlListe = new System.Windows.Forms.ListBox();
            this.cLBSuchErgebnis = new System.Windows.Forms.CheckedListBox();
            this.bTAswahlAllerEintraege = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(623, 28);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Schließen";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tBEingabeSuchBegriff
            // 
            this.tBEingabeSuchBegriff.Location = new System.Drawing.Point(265, 31);
            this.tBEingabeSuchBegriff.Name = "tBEingabeSuchBegriff";
            this.tBEingabeSuchBegriff.Size = new System.Drawing.Size(197, 20);
            this.tBEingabeSuchBegriff.TabIndex = 1;
            this.tBEingabeSuchBegriff.TextChanged += new System.EventHandler(this.tBEingabeSuchBegriff_TextChanged);
            // 
            // lBAuswahlListe
            // 
            this.lBAuswahlListe.FormattingEnabled = true;
            this.lBAuswahlListe.Location = new System.Drawing.Point(404, 94);
            this.lBAuswahlListe.Name = "lBAuswahlListe";
            this.lBAuswahlListe.Size = new System.Drawing.Size(294, 238);
            this.lBAuswahlListe.TabIndex = 2;
            // 
            // cLBSuchErgebnis
            // 
            this.cLBSuchErgebnis.FormattingEnabled = true;
            this.cLBSuchErgebnis.Location = new System.Drawing.Point(21, 94);
            this.cLBSuchErgebnis.Name = "cLBSuchErgebnis";
            this.cLBSuchErgebnis.Size = new System.Drawing.Size(302, 244);
            this.cLBSuchErgebnis.TabIndex = 3;
            this.cLBSuchErgebnis.SelectedValueChanged += new System.EventHandler(this.cLBSuchErgebnis_SelectedValueChanged);
            // 
            // bTAswahlAllerEintraege
            // 
            this.bTAswahlAllerEintraege.Location = new System.Drawing.Point(21, 344);
            this.bTAswahlAllerEintraege.Name = "bTAswahlAllerEintraege";
            this.bTAswahlAllerEintraege.Size = new System.Drawing.Size(302, 23);
            this.bTAswahlAllerEintraege.TabIndex = 4;
            this.bTAswahlAllerEintraege.Text = "Kein Eintrag vorhanden.";
            this.bTAswahlAllerEintraege.UseVisualStyleBackColor = true;
            this.bTAswahlAllerEintraege.Visible = false;
            this.bTAswahlAllerEintraege.Click += new System.EventHandler(this.bTAswahlAllerEintraege_Click);
            // 
            // FoSucheSchueler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bTAswahlAllerEintraege);
            this.Controls.Add(this.cLBSuchErgebnis);
            this.Controls.Add(this.lBAuswahlListe);
            this.Controls.Add(this.tBEingabeSuchBegriff);
            this.Controls.Add(this.btClose);
            this.Name = "FoSucheSchueler";
            this.Text = "FoSucheSchueler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.TextBox tBEingabeSuchBegriff;
        private System.Windows.Forms.ListBox lBAuswahlListe;
        private System.Windows.Forms.CheckedListBox cLBSuchErgebnis;
        private System.Windows.Forms.Button bTAswahlAllerEintraege;
    }
}