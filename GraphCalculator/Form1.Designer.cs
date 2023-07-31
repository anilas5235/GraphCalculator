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
            this.palGraphView = new System.Windows.Forms.Panel();
            this.floloFunctions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddSlot = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // floloFunctions
            // 
            this.floloFunctions.AutoScroll = true;
            this.floloFunctions.BackColor = System.Drawing.Color.Silver;
            this.floloFunctions.Location = new System.Drawing.Point(12, 20);
            this.floloFunctions.Name = "floloFunctions";
            this.floloFunctions.Size = new System.Drawing.Size(846, 883);
            this.floloFunctions.TabIndex = 4;
            // 
            // btnAddSlot
            // 
            this.btnAddSlot.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSlot.Location = new System.Drawing.Point(12, 910);
            this.btnAddSlot.Name = "btnAddSlot";
            this.btnAddSlot.Size = new System.Drawing.Size(846, 110);
            this.btnAddSlot.TabIndex = 5;
            this.btnAddSlot.Text = "+";
            this.btnAddSlot.UseVisualStyleBackColor = true;
            this.btnAddSlot.Click += new System.EventHandler(this.btnAddSlot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.btnAddSlot);
            this.Controls.Add(this.floloFunctions);
            this.Controls.Add(this.palGraphView);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Zoom);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel palGraphView;
        private System.Windows.Forms.FlowLayoutPanel floloFunctions;
        private System.Windows.Forms.Button btnAddSlot;
    }
}

