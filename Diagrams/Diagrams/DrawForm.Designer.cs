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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.изменитьРазмерПоляToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьПолеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSize = new System.Windows.Forms.Label();
            this.pbDraw = new System.Windows.Forms.PictureBox();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.trackBarSize = new System.Windows.Forms.TrackBar();
            this.удалитьЗаданиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьРазмерПоляToolStripMenuItem,
            this.очиститьПолеToolStripMenuItem,
            this.удалитьЗаданиеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(940, 24);
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
            // очиститьПолеToolStripMenuItem
            // 
            this.очиститьПолеToolStripMenuItem.Name = "очиститьПолеToolStripMenuItem";
            this.очиститьПолеToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.очиститьПолеToolStripMenuItem.Text = "Очистить поле";
            this.очиститьПолеToolStripMenuItem.Click += new System.EventHandler(this.очиститьПолеToolStripMenuItem_Click);
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
            // pbDraw
            // 
            this.pbDraw.Location = new System.Drawing.Point(12, 92);
            this.pbDraw.Name = "pbDraw";
            this.pbDraw.Size = new System.Drawing.Size(928, 454);
            this.pbDraw.TabIndex = 0;
            this.pbDraw.TabStop = false;
            this.pbDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDraw_Paint);
            // 
            // tbSpeed
            // 
            this.tbSpeed.AutoSize = false;
            this.tbSpeed.LargeChange = 8;
            this.tbSpeed.Location = new System.Drawing.Point(358, 55);
            this.tbSpeed.Maximum = 600;
            this.tbSpeed.Minimum = 100;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbSpeed.Size = new System.Drawing.Size(277, 21);
            this.tbSpeed.SmallChange = 8;
            this.tbSpeed.TabIndex = 7;
            this.tbSpeed.TabStop = false;
            this.tbSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbSpeed.Value = 300;
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.Location = new System.Drawing.Point(413, 39);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(180, 13);
            this.lbSpeed.TabIndex = 8;
            this.lbSpeed.Text = "Скорость выполнения алгоритма:";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Карандаш 1.png");
            this.imageList1.Images.SetKeyName(1, "Карандаш 2.png");
            this.imageList1.Images.SetKeyName(2, "Карандаш 3.png");
            // 
            // trackBarSize
            // 
            this.trackBarSize.AutoSize = false;
            this.trackBarSize.LargeChange = 8;
            this.trackBarSize.Location = new System.Drawing.Point(12, 55);
            this.trackBarSize.Maximum = 100;
            this.trackBarSize.Minimum = 10;
            this.trackBarSize.Name = "trackBarSize";
            this.trackBarSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBarSize.Size = new System.Drawing.Size(277, 21);
            this.trackBarSize.SmallChange = 8;
            this.trackBarSize.TabIndex = 10;
            this.trackBarSize.TabStop = false;
            this.trackBarSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarSize.Value = 30;
            this.trackBarSize.Scroll += new System.EventHandler(this.trackBarSize_Scroll);
            // 
            // удалитьЗаданиеToolStripMenuItem
            // 
            this.удалитьЗаданиеToolStripMenuItem.Name = "удалитьЗаданиеToolStripMenuItem";
            this.удалитьЗаданиеToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.удалитьЗаданиеToolStripMenuItem.Text = "Удалить задание";
            this.удалитьЗаданиеToolStripMenuItem.Click += new System.EventHandler(this.удалитьЗаданиеToolStripMenuItem_Click);
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(933, 640);
            this.Controls.Add(this.trackBarSize);
            this.Controls.Add(this.lbSpeed);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.pbDraw);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DrawForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Поле";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lbSize;
        private System.Windows.Forms.ToolStripMenuItem изменитьРазмерПоляToolStripMenuItem;
        public System.Windows.Forms.PictureBox pbDraw;
        public System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label lbSpeed;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TrackBar trackBarSize;
        private System.Windows.Forms.ToolStripMenuItem очиститьПолеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗаданиеToolStripMenuItem;
    }
}