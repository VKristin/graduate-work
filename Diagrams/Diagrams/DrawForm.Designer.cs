namespace Diagrams
{
    partial class DrawForm
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
            this.pbDraw = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.изменитьРазмерПоляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.lbSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDraw
            // 
            this.pbDraw.Location = new System.Drawing.Point(12, 82);
            this.pbDraw.Name = "pbDraw";
            this.pbDraw.Size = new System.Drawing.Size(928, 454);
            this.pbDraw.TabIndex = 0;
            this.pbDraw.TabStop = false;
            this.pbDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDraw_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьРазмерПоляToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(951, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // изменитьРазмерПоляToolStripMenuItem
            // 
            this.изменитьРазмерПоляToolStripMenuItem.Name = "изменитьРазмерПоляToolStripMenuItem";
            this.изменитьРазмерПоляToolStripMenuItem.Size = new System.Drawing.Size(146, 20);
            this.изменитьРазмерПоляToolStripMenuItem.Text = "Изменить размер поля";
            this.изменитьРазмерПоляToolStripMenuItem.Click += new System.EventHandler(this.изменитьРазмерПоляToolStripMenuItem_Click);
            // 
            // trackBarSize
            // 
            this.trackBarSize.AutoSize = false;
            this.trackBarSize.LargeChange = 8;
            this.trackBarSize.Location = new System.Drawing.Point(12, 55);
            this.trackBarSize.Maximum = 128;
            this.trackBarSize.Minimum = 16;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.Size = new System.Drawing.Size(277, 21);
            this.trackBarSize.SmallChange = 8;
            this.trackBarSize.TabIndex = 4;
            this.trackBarSize.TabStop = false;
            this.trackBarSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarSize.Value = 32;
            this.trackBarSize.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            // 
            // lbSize
            // 
            this.lbSize.AutoSize = true;
            this.lbSize.Location = new System.Drawing.Point(118, 39);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(76, 13);
            this.lbSize.TabIndex = 5;
            this.lbSize.Text = "Размер поля:";
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(951, 550);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.trackBarSize);
            this.Controls.Add(this.pbDraw);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DrawForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Поле";
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.ToolStripMenuItem изменитьРазмерПоляToolStripMenuItem;
        public System.Windows.Forms.PictureBox pbDraw;
        public System.Windows.Forms.TrackBar trackBarSize;
    }
}