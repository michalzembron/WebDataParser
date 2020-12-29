namespace WebDataParser
{
    partial class WebDataParser
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_AllCasesPL = new System.Windows.Forms.Button();
            this.btn_AllCasesWorld = new System.Windows.Forms.Button();
            this.btn_ConfirmedPL = new System.Windows.Forms.Button();
            this.btn_Summary = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_AllCasesPL
            // 
            this.btn_AllCasesPL.Location = new System.Drawing.Point(12, 12);
            this.btn_AllCasesPL.Name = "btn_AllCasesPL";
            this.btn_AllCasesPL.Size = new System.Drawing.Size(165, 23);
            this.btn_AllCasesPL.TabIndex = 0;
            this.btn_AllCasesPL.Text = "Wszystkie przypadki (Polska)";
            this.btn_AllCasesPL.UseVisualStyleBackColor = true;
            this.btn_AllCasesPL.Click += new System.EventHandler(this.btn_AllCasesPL_Click);
            // 
            // btn_AllCasesWorld
            // 
            this.btn_AllCasesWorld.Location = new System.Drawing.Point(12, 41);
            this.btn_AllCasesWorld.Name = "btn_AllCasesWorld";
            this.btn_AllCasesWorld.Size = new System.Drawing.Size(165, 23);
            this.btn_AllCasesWorld.TabIndex = 1;
            this.btn_AllCasesWorld.Text = "Wszystkie (Świat)";
            this.btn_AllCasesWorld.UseVisualStyleBackColor = true;
            this.btn_AllCasesWorld.Click += new System.EventHandler(this.btn_AllCasesWorld_Click);
            // 
            // btn_ConfirmedPL
            // 
            this.btn_ConfirmedPL.Location = new System.Drawing.Point(12, 70);
            this.btn_ConfirmedPL.Name = "btn_ConfirmedPL";
            this.btn_ConfirmedPL.Size = new System.Drawing.Size(165, 23);
            this.btn_ConfirmedPL.TabIndex = 2;
            this.btn_ConfirmedPL.Text = "Potwierdzone (Polska)";
            this.btn_ConfirmedPL.UseVisualStyleBackColor = true;
            this.btn_ConfirmedPL.Click += new System.EventHandler(this.btn_ConfirmedPL_Click);
            // 
            // btn_Summary
            // 
            this.btn_Summary.Location = new System.Drawing.Point(12, 99);
            this.btn_Summary.Name = "btn_Summary";
            this.btn_Summary.Size = new System.Drawing.Size(165, 23);
            this.btn_Summary.TabIndex = 3;
            this.btn_Summary.Text = "Podsumowanie";
            this.btn_Summary.UseVisualStyleBackColor = true;
            this.btn_Summary.Click += new System.EventHandler(this.btn_Summary_Click);
            // 
            // WebDataParser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 462);
            this.Controls.Add(this.btn_Summary);
            this.Controls.Add(this.btn_ConfirmedPL);
            this.Controls.Add(this.btn_AllCasesWorld);
            this.Controls.Add(this.btn_AllCasesPL);
            this.MinimumSize = new System.Drawing.Size(210, 180);
            this.Name = "WebDataParser";
            this.Text = "WebDataParser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_AllCasesPL;
        private System.Windows.Forms.Button btn_AllCasesWorld;
        private System.Windows.Forms.Button btn_ConfirmedPL;
        private System.Windows.Forms.Button btn_Summary;
    }
}

