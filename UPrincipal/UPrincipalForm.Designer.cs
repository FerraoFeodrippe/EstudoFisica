namespace UPrincipal
{
    partial class UPrincialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UPrincialForm));
            this.MenuPrincial = new System.Windows.Forms.MenuStrip();
            this.açõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carregarMóduloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Visor = new System.Windows.Forms.PictureBox();
            this.MenuPrincial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Visor)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPrincial
            // 
            this.MenuPrincial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.açõesToolStripMenuItem,
            this.opçõesToolStripMenuItem});
            resources.ApplyResources(this.MenuPrincial, "MenuPrincial");
            this.MenuPrincial.Name = "MenuPrincial";
            // 
            // açõesToolStripMenuItem
            // 
            this.açõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.carregarMóduloToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.açõesToolStripMenuItem.Name = "açõesToolStripMenuItem";
            resources.ApplyResources(this.açõesToolStripMenuItem, "açõesToolStripMenuItem");
            // 
            // carregarMóduloToolStripMenuItem
            // 
            this.carregarMóduloToolStripMenuItem.Name = "carregarMóduloToolStripMenuItem";
            resources.ApplyResources(this.carregarMóduloToolStripMenuItem, "carregarMóduloToolStripMenuItem");
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            resources.ApplyResources(this.sairToolStripMenuItem, "sairToolStripMenuItem");
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            resources.ApplyResources(this.opçõesToolStripMenuItem, "opçõesToolStripMenuItem");
            // 
            // Visor
            // 
            this.Visor.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.Visor, "Visor");
            this.Visor.Name = "Visor";
            this.Visor.TabStop = false;
            this.Visor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Visor_MouseDown);
            this.Visor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Visor_MouseMove);
            // 
            // UPrincialForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.Visor);
            this.Controls.Add(this.MenuPrincial);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.MenuPrincial;
            this.Name = "UPrincialForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UPrincialForm_KeyDown);
            this.MenuPrincial.ResumeLayout(false);
            this.MenuPrincial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Visor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincial;
        private System.Windows.Forms.ToolStripMenuItem açõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carregarMóduloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.PictureBox Visor;
    }
}

