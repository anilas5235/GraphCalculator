namespace GraphCalculator
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbFunctions = new System.Windows.Forms.GroupBox();
            this.tbxFormula = new System.Windows.Forms.TextBox();
            this.palGraphView = new System.Windows.Forms.Panel();
            this.tbxFormula2 = new System.Windows.Forms.TextBox();
            this.gbFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFunctions
            // 
            this.gbFunctions.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbFunctions.Controls.Add(this.tbxFormula2);
            this.gbFunctions.Controls.Add(this.tbxFormula);
            this.gbFunctions.Location = new System.Drawing.Point(12, 12);
            this.gbFunctions.Name = "gbFunctions";
            this.gbFunctions.Size = new System.Drawing.Size(154, 800);
            this.gbFunctions.TabIndex = 1;
            this.gbFunctions.TabStop = false;
            this.gbFunctions.Text = "Functions";
            // 
            // tbxFormula
            // 
            this.tbxFormula.Location = new System.Drawing.Point(7, 20);
            this.tbxFormula.Name = "tbxFormula";
            this.tbxFormula.Size = new System.Drawing.Size(141, 20);
            this.tbxFormula.TabIndex = 0;
            this.tbxFormula.TextChanged += new System.EventHandler(this.tbxFormula_TextChanged);
            // 
            // palGraphView
            // 
            this.palGraphView.Location = new System.Drawing.Point(172, 12);
            this.palGraphView.Name = "palGraphView";
            this.palGraphView.Size = new System.Drawing.Size(1000, 1000);
            this.palGraphView.TabIndex = 2;
            this.palGraphView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palGraphView_MouseDown);
            this.palGraphView.MouseLeave += new System.EventHandler(this.palGraphView_MouseLeave);
            this.palGraphView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.palGraphView_MouseMove);
            this.palGraphView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.palGraphView_MouseUp);
            // 
            // tbxFormula2
            // 
            this.tbxFormula2.Location = new System.Drawing.Point(6, 46);
            this.tbxFormula2.Name = "tbxFormula2";
            this.tbxFormula2.Size = new System.Drawing.Size(141, 20);
            this.tbxFormula2.TabIndex = 1;
            this.tbxFormula2.TextChanged += new System.EventHandler(this.tbxFormula2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 1016);
            this.Controls.Add(this.palGraphView);
            this.Controls.Add(this.gbFunctions);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Zoom);
            this.gbFunctions.ResumeLayout(false);
            this.gbFunctions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbFunctions;
        private System.Windows.Forms.Panel palGraphView;
        private System.Windows.Forms.TextBox tbxFormula;
        private System.Windows.Forms.TextBox tbxFormula2;
    }
}

