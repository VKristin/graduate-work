namespace Diagrams
{
    partial class AlgForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьЗаданиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьАлгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьАлгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            this.нарисоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdDiagram = new System.Windows.Forms.SaveFileDialog();
            this.ofdDiagram = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btm1 = new System.Windows.Forms.Button();
            this.btm2 = new System.Windows.Forms.Button();
            this.btm3 = new System.Windows.Forms.Button();
            this.btm7 = new System.Windows.Forms.Button();
            this.btm4 = new System.Windows.Forms.Button();
            this.btm5 = new System.Windows.Forms.Button();
            this.btm6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dbDiagram = new Diagrams.DiagramBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dbDiagramS = new Diagrams.DiagramBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dbDiagramT = new Diagrams.DiagramBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.нарисоватьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(937, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.открытьЗаданиеToolStripMenuItem,
            this.открытьАлгоритмToolStripMenuItem,
            this.сохранитьАлгоритмToolStripMenuItem,
            this.miExport,
            this.toolStripMenuItem2,
            this.miClose});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem1.Text = "Файл";
            // 
            // miNew
            // 
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(231, 22);
            this.miNew.Text = "Новая диаграмма";
            this.miNew.Click += new System.EventHandler(this.miNewDiagram_Click);
            // 
            // открытьЗаданиеToolStripMenuItem
            // 
            this.открытьЗаданиеToolStripMenuItem.Name = "открытьЗаданиеToolStripMenuItem";
            this.открытьЗаданиеToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.открытьЗаданиеToolStripMenuItem.Text = "Открыть задание";
            this.открытьЗаданиеToolStripMenuItem.Click += new System.EventHandler(this.открытьЗаданиеToolStripMenuItem_Click);
            // 
            // открытьАлгоритмToolStripMenuItem
            // 
            this.открытьАлгоритмToolStripMenuItem.Name = "открытьАлгоритмToolStripMenuItem";
            this.открытьАлгоритмToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.открытьАлгоритмToolStripMenuItem.Text = "Открыть алгоритм";
            this.открытьАлгоритмToolStripMenuItem.Click += new System.EventHandler(this.открытьАлгоритмToolStripMenuItem_Click);
            // 
            // сохранитьАлгоритмToolStripMenuItem
            // 
            this.сохранитьАлгоритмToolStripMenuItem.Name = "сохранитьАлгоритмToolStripMenuItem";
            this.сохранитьАлгоритмToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.сохранитьАлгоритмToolStripMenuItem.Text = "Сохранить алгоритм";
            this.сохранитьАлгоритмToolStripMenuItem.Click += new System.EventHandler(this.сохранитьАлгоритмToolStripMenuItem_Click);
            // 
            // miExport
            // 
            this.miExport.Name = "miExport";
            this.miExport.Size = new System.Drawing.Size(231, 22);
            this.miExport.Text = "Сохранить как изображение";
            this.miExport.Click += new System.EventHandler(this.miExport_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(228, 6);
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(231, 22);
            this.miClose.Text = "Выход";
            this.miClose.Click += new System.EventHandler(this.miExit_Click);
            // 
            // нарисоватьToolStripMenuItem
            // 
            this.нарисоватьToolStripMenuItem.Name = "нарисоватьToolStripMenuItem";
            this.нарисоватьToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.нарисоватьToolStripMenuItem.Text = "Нарисовать";
            this.нарисоватьToolStripMenuItem.Click += new System.EventHandler(this.нарисоватьToolStripMenuItem_Click);
            // 
            // sfdDiagram
            // 
            this.sfdDiagram.DefaultExt = "diagram";
            this.sfdDiagram.Filter = "Diagram|*.diagram";
            // 
            // ofdDiagram
            // 
            this.ofdDiagram.DefaultExt = "diagram";
            this.ofdDiagram.Filter = "Diagram|*.diagram";
            // 
            // sfdImage
            // 
            this.sfdImage.Filter = "PNG Image(*.png)|*.png|Metafile(*.emf)|*.emf";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.flowLayoutPanel1.Controls.Add(this.btm1);
            this.flowLayoutPanel1.Controls.Add(this.btm2);
            this.flowLayoutPanel1.Controls.Add(this.btm3);
            this.flowLayoutPanel1.Controls.Add(this.btm7);
            this.flowLayoutPanel1.Controls.Add(this.btm4);
            this.flowLayoutPanel1.Controls.Add(this.btm5);
            this.flowLayoutPanel1.Controls.Add(this.btm6);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(137, 406);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btm1
            // 
            this.btm1.BackColor = System.Drawing.Color.Lavender;
            this.btm1.Location = new System.Drawing.Point(3, 3);
            this.btm1.Name = "btm1";
            this.btm1.Size = new System.Drawing.Size(134, 45);
            this.btm1.TabIndex = 5;
            this.btm1.Text = "Вызов подпрограммы";
            this.btm1.UseVisualStyleBackColor = false;
            this.btm1.Visible = false;
            this.btm1.Click += new System.EventHandler(this.btm1_Click);
            // 
            // btm2
            // 
            this.btm2.BackColor = System.Drawing.Color.Lavender;
            this.btm2.Location = new System.Drawing.Point(3, 54);
            this.btm2.Name = "btm2";
            this.btm2.Size = new System.Drawing.Size(134, 45);
            this.btm2.TabIndex = 6;
            this.btm2.Text = "Развилка";
            this.btm2.UseVisualStyleBackColor = false;
            this.btm2.Visible = false;
            this.btm2.Click += new System.EventHandler(this.btm2_Click);
            // 
            // btm3
            // 
            this.btm3.BackColor = System.Drawing.Color.Lavender;
            this.btm3.Location = new System.Drawing.Point(3, 105);
            this.btm3.Name = "btm3";
            this.btm3.Size = new System.Drawing.Size(134, 45);
            this.btm3.TabIndex = 7;
            this.btm3.Text = "Цикл с предусловием";
            this.btm3.UseVisualStyleBackColor = false;
            this.btm3.Click += new System.EventHandler(this.btm3_Click);
            // 
            // btm7
            // 
            this.btm7.BackColor = System.Drawing.Color.Lavender;
            this.btm7.Location = new System.Drawing.Point(3, 156);
            this.btm7.Name = "btm7";
            this.btm7.Size = new System.Drawing.Size(134, 45);
            this.btm7.TabIndex = 11;
            this.btm7.Text = "Цикл с постусловием";
            this.btm7.UseVisualStyleBackColor = false;
            this.btm7.Visible = false;
            this.btm7.Click += new System.EventHandler(this.button1_Click);
            // 
            // btm4
            // 
            this.btm4.BackColor = System.Drawing.Color.Lavender;
            this.btm4.Location = new System.Drawing.Point(3, 207);
            this.btm4.Name = "btm4";
            this.btm4.Size = new System.Drawing.Size(134, 45);
            this.btm4.TabIndex = 8;
            this.btm4.Text = "Цикл с счётчиком";
            this.btm4.UseVisualStyleBackColor = false;
            this.btm4.Click += new System.EventHandler(this.btm4_Click);
            // 
            // btm5
            // 
            this.btm5.BackColor = System.Drawing.Color.Lavender;
            this.btm5.Location = new System.Drawing.Point(3, 258);
            this.btm5.Name = "btm5";
            this.btm5.Size = new System.Drawing.Size(134, 45);
            this.btm5.TabIndex = 9;
            this.btm5.Text = "Действие";
            this.btm5.UseVisualStyleBackColor = false;
            this.btm5.Click += new System.EventHandler(this.btm5_Click);
            // 
            // btm6
            // 
            this.btm6.BackColor = System.Drawing.Color.Lavender;
            this.btm6.Location = new System.Drawing.Point(3, 309);
            this.btm6.Name = "btm6";
            this.btm6.Size = new System.Drawing.Size(134, 45);
            this.btm6.TabIndex = 10;
            this.btm6.Text = "Исключение";
            this.btm6.UseVisualStyleBackColor = false;
            this.btm6.Click += new System.EventHandler(this.btm6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Controls.Add(this.dbDiagram);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(137, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(250, 406);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // dbDiagram
            // 
            this.dbDiagram.AutoScroll = true;
            this.dbDiagram.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dbDiagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbDiagram.Diagram = null;
            this.dbDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbDiagram.ForeColor = System.Drawing.Color.Black;
            this.dbDiagram.Location = new System.Drawing.Point(2, 15);
            this.dbDiagram.Margin = new System.Windows.Forms.Padding(4);
            this.dbDiagram.Name = "dbDiagram";
            this.dbDiagram.SelectedFigure = null;
            this.dbDiagram.Size = new System.Drawing.Size(246, 389);
            this.dbDiagram.TabIndex = 3;
            this.dbDiagram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbDiagram_KeyDown);
            this.dbDiagram.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagram_MouseClick);
            this.dbDiagram.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagram_MouseDoubleClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(387, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 406);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.groupBox2.Controls.Add(this.dbDiagramS);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(388, 24);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(250, 406);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // dbDiagramS
            // 
            this.dbDiagramS.AutoScroll = true;
            this.dbDiagramS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dbDiagramS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbDiagramS.Diagram = null;
            this.dbDiagramS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbDiagramS.ForeColor = System.Drawing.Color.Black;
            this.dbDiagramS.Location = new System.Drawing.Point(2, 15);
            this.dbDiagramS.Margin = new System.Windows.Forms.Padding(4);
            this.dbDiagramS.Name = "dbDiagramS";
            this.dbDiagramS.SelectedFigure = null;
            this.dbDiagramS.Size = new System.Drawing.Size(246, 389);
            this.dbDiagramS.TabIndex = 9;
            this.dbDiagramS.DoubleClick += new System.EventHandler(this.dbDiagramS_DoubleClick);
            this.dbDiagramS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbDiagramS_KeyDown_1);
            this.dbDiagramS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagramS_MouseClick);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(638, 24);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1, 406);
            this.splitter2.TabIndex = 15;
            this.splitter2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox3.Controls.Add(this.dbDiagramT);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(639, 24);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(250, 406);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            // 
            // dbDiagramT
            // 
            this.dbDiagramT.AutoScroll = true;
            this.dbDiagramT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dbDiagramT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbDiagramT.Diagram = null;
            this.dbDiagramT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbDiagramT.ForeColor = System.Drawing.Color.Black;
            this.dbDiagramT.Location = new System.Drawing.Point(2, 15);
            this.dbDiagramT.Margin = new System.Windows.Forms.Padding(4);
            this.dbDiagramT.Name = "dbDiagramT";
            this.dbDiagramT.SelectedFigure = null;
            this.dbDiagramT.Size = new System.Drawing.Size(246, 389);
            this.dbDiagramT.TabIndex = 11;
            this.dbDiagramT.DoubleClick += new System.EventHandler(this.dbDiagramT_DoubleClick);
            this.dbDiagramT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbDiagramT_KeyDown);
            this.dbDiagramT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagramT_MouseClick);
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(889, 24);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 406);
            this.splitter3.TabIndex = 17;
            this.splitter3.TabStop = false;
            // 
            // AlgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(937, 430);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AlgForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Чертёжник";
            this.Load += new System.EventHandler(this.AlgForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SaveFileDialog sfdDiagram;
        private System.Windows.Forms.OpenFileDialog ofdDiagram;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miClose;
        private System.Windows.Forms.ToolStripMenuItem miExport;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btm1;
        private System.Windows.Forms.Button btm2;
        private System.Windows.Forms.Button btm3;
        private System.Windows.Forms.Button btm4;
        private System.Windows.Forms.Button btm5;
        private System.Windows.Forms.Button btm6;
        private System.Windows.Forms.Button btm7;
        private System.Windows.Forms.ToolStripMenuItem нарисоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьЗаданиеToolStripMenuItem;
        public DiagramBox dbDiagram;
        private System.Windows.Forms.ToolStripMenuItem сохранитьАлгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьАлгоритмToolStripMenuItem;
        public DiagramBox dbDiagramS;
        public DiagramBox dbDiagramT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Splitter splitter3;
    }
}

