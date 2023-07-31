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
            this.tbxFormula2 = new System.Windows.Forms.TextBox();
            this.tbxFormula = new System.Windows.Forms.TextBox();
            this.palGraphView = new System.Windows.Forms.Panel();
            this.lbF1 = new System.Windows.Forms.Label();
            this.lbF2 = new System.Windows.Forms.Label();
            this.gbFunctions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFunctions
            // 
            this.gbFunctions.BackColor = System.Drawing.Color.Silver;
            this.gbFunctions.Controls.Add(this.lbF2);
            this.gbFunctions.Controls.Add(this.lbF1);
            this.gbFunctions.Controls.Add(this.tbxFormula2);
            this.gbFunctions.Controls.Add(this.tbxFormula);
            this.gbFunctions.Location = new System.Drawing.Point(24, 20);
            this.gbFunctions.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbFunctions.Name = "gbFunctions";
            this.gbFunctions.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.gbFunctions.Size = new System.Drawing.Size(846, 1007);
            this.gbFunctions.TabIndex = 1;
            this.gbFunctions.TabStop = false;
            this.gbFunctions.Text = "Functions";
            // 
            // tbxFormula2
            // 
            this.tbxFormula2.Location = new System.Drawing.Point(119, 73);
            this.tbxFormula2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxFormula2.Name = "tbxFormula2";
            this.tbxFormula2.Size = new System.Drawing.Size(688, 29);
            this.tbxFormula2.TabIndex = 1;
            this.tbxFormula2.TextChanged += new System.EventHandler(this.tbxFormula2_TextChanged);
            // 
            // tbxFormula
            // 
            this.tbxFormula.Location = new System.Drawing.Point(119, 34);
            this.tbxFormula.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tbxFormula.Name = "tbxFormula";
            this.tbxFormula.Size = new System.Drawing.Size(688, 29);
            this.tbxFormula.TabIndex = 0;
            this.tbxFormula.TextChanged += new System.EventHandler(this.tbxFormula_TextChanged);
            // 
            // palGraphView
            // 
            this.palGraphView.Location = new System.Drawing.Point(889, 20);
            this.palGraphView.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.palGraphView.Name = "palGraphView";
            this.palGraphView.Size = new System.Drawing.Size(1000, 1000);
            this.palGraphView.TabIndex = 2;
            this.palGraphView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.palGraphView_MouseDown);
            this.palGraphView.MouseLeave += new System.EventHandler(this.palGraphView_MouseLeave);
            this.palGraphView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.palGraphView_MouseMove);
            this.palGraphView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.palGraphView_MouseUp);
            // 
            // lbF1
            // 
            this.lbF1.AutoSize = true;
            this.lbF1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbF1.Location = new System.Drawing.Point(9, 34);
            this.lbF1.Name = "lbF1";
            this.lbF1.Size = new System.Drawing.Size(87, 32);
            this.lbF1.TabIndex = 2;
            this.lbF1.Text = "f1(x)=";
            // 
            // lbF2
            // 
            this.lbF2.AutoSize = true;
            this.lbF2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbF2.Location = new System.Drawing.Point(9, 69);
            this.lbF2.Name = "lbF2";
            this.lbF2.Size = new System.Drawing.Size(87, 32);
            this.lbF2.TabIndex = 3;
            this.lbF2.Text = "f2(x)=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.palGraphView);
            this.Controls.Add(this.gbFunctions);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Calculator";
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
        private System.Windows.Forms.Label lbF2;
        private System.Windows.Forms.Label lbF1;
    }
}

