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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.miSave = new System.Windows.Forms.ToolStripMenuItem();
            this.miExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdDiagram = new System.Windows.Forms.SaveFileDialog();
            this.ofdDiagram = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.cmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAddRect = new System.Windows.Forms.ToolStripMenuItem();
            this.addRoundRectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRhombToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addParalelogrammToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEllipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прямоугольникСРамкойToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шестиугольникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSelectedFigure = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miEditText = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddLine = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddLedgeLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.bringToFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendToBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.двойнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btm1 = new System.Windows.Forms.Button();
            this.btm2 = new System.Windows.Forms.Button();
            this.btm3 = new System.Windows.Forms.Button();
            this.btm7 = new System.Windows.Forms.Button();
            this.btm4 = new System.Windows.Forms.Button();
            this.btm5 = new System.Windows.Forms.Button();
            this.btm6 = new System.Windows.Forms.Button();
            this.dbDiagram = new Diagrams.DiagramBox();
            this.menuStrip1.SuspendLayout();
            this.cmMain.SuspendLayout();
            this.cmSelectedFigure.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(739, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNew,
            this.miLoad,
            this.miSave,
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
            this.miNew.Size = new System.Drawing.Size(172, 22);
            this.miNew.Text = "Новая диаграмма";
            this.miNew.Click += new System.EventHandler(this.miNewDiagram_Click);
            // 
            // miLoad
            // 
            this.miLoad.Name = "miLoad";
            this.miLoad.Size = new System.Drawing.Size(172, 22);
            this.miLoad.Text = "Open";
            this.miLoad.Click += new System.EventHandler(this.miLoad_Click);
            // 
            // miSave
            // 
            this.miSave.Name = "miSave";
            this.miSave.Size = new System.Drawing.Size(172, 22);
            this.miSave.Text = "Save";
            this.miSave.Click += new System.EventHandler(this.miSave_Click);
            // 
            // miExport
            // 
            this.miExport.Name = "miExport";
            this.miExport.Size = new System.Drawing.Size(172, 22);
            this.miExport.Text = "Export as Image";
            this.miExport.Click += new System.EventHandler(this.miExport_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(169, 6);
            // 
            // miClose
            // 
            this.miClose.Name = "miClose";
            this.miClose.Size = new System.Drawing.Size(172, 22);
            this.miClose.Text = "Exit";
            this.miClose.Click += new System.EventHandler(this.miExit_Click);
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
            // cmMain
            // 
            this.cmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddRect,
            this.addRoundRectToolStripMenuItem,
            this.addRhombToolStripMenuItem,
            this.addParalelogrammToolStripMenuItem,
            this.addEllipseToolStripMenuItem,
            this.addStackToolStripMenuItem,
            this.addFrameToolStripMenuItem,
            this.прямоугольникСРамкойToolStripMenuItem,
            this.шестиугольникToolStripMenuItem});
            this.cmMain.Name = "cmMain";
            this.cmMain.Size = new System.Drawing.Size(218, 202);
            // 
            // miAddRect
            // 
            this.miAddRect.Name = "miAddRect";
            this.miAddRect.Size = new System.Drawing.Size(217, 22);
            this.miAddRect.Text = "Add Rectangle";
            this.miAddRect.Click += new System.EventHandler(this.miAddRect_Click);
            // 
            // addRoundRectToolStripMenuItem
            // 
            this.addRoundRectToolStripMenuItem.Name = "addRoundRectToolStripMenuItem";
            this.addRoundRectToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addRoundRectToolStripMenuItem.Text = "Add RoundRect";
            this.addRoundRectToolStripMenuItem.Click += new System.EventHandler(this.addRoundRectToolStripMenuItem_Click);
            // 
            // addRhombToolStripMenuItem
            // 
            this.addRhombToolStripMenuItem.Name = "addRhombToolStripMenuItem";
            this.addRhombToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addRhombToolStripMenuItem.Text = "Add Rhomb";
            this.addRhombToolStripMenuItem.Click += new System.EventHandler(this.addRhombToolStripMenuItem_Click);
            // 
            // addParalelogrammToolStripMenuItem
            // 
            this.addParalelogrammToolStripMenuItem.Name = "addParalelogrammToolStripMenuItem";
            this.addParalelogrammToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addParalelogrammToolStripMenuItem.Text = "Add Paralelogramm";
            this.addParalelogrammToolStripMenuItem.Click += new System.EventHandler(this.addParalelogrammToolStripMenuItem_Click);
            // 
            // addEllipseToolStripMenuItem
            // 
            this.addEllipseToolStripMenuItem.Name = "addEllipseToolStripMenuItem";
            this.addEllipseToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addEllipseToolStripMenuItem.Text = "Add Ellipse";
            this.addEllipseToolStripMenuItem.Click += new System.EventHandler(this.addEllipseToolStripMenuItem_Click);
            // 
            // addStackToolStripMenuItem
            // 
            this.addStackToolStripMenuItem.Name = "addStackToolStripMenuItem";
            this.addStackToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addStackToolStripMenuItem.Text = "Add Stack";
            this.addStackToolStripMenuItem.Click += new System.EventHandler(this.addStackToolStripMenuItem_Click);
            // 
            // addFrameToolStripMenuItem
            // 
            this.addFrameToolStripMenuItem.Name = "addFrameToolStripMenuItem";
            this.addFrameToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.addFrameToolStripMenuItem.Text = "Add Frame";
            this.addFrameToolStripMenuItem.Click += new System.EventHandler(this.addFrameToolStripMenuItem_Click);
            // 
            // прямоугольникСРамкойToolStripMenuItem
            // 
            this.прямоугольникСРамкойToolStripMenuItem.Name = "прямоугольникСРамкойToolStripMenuItem";
            this.прямоугольникСРамкойToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.прямоугольникСРамкойToolStripMenuItem.Text = "Прямоугольник с рамкой";
            this.прямоугольникСРамкойToolStripMenuItem.Click += new System.EventHandler(this.прямоугольникСРамкойToolStripMenuItem_Click);
            // 
            // шестиугольникToolStripMenuItem
            // 
            this.шестиугольникToolStripMenuItem.Name = "шестиугольникToolStripMenuItem";
            this.шестиугольникToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.шестиугольникToolStripMenuItem.Text = "Шестиугольник";
            this.шестиугольникToolStripMenuItem.Click += new System.EventHandler(this.шестиугольникToolStripMenuItem_Click);
            // 
            // cmSelectedFigure
            // 
            this.cmSelectedFigure.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miEditText,
            this.miAddLine,
            this.miAddLedgeLine,
            this.toolStripSeparator1,
            this.miDelete,
            this.toolStripMenuItem1,
            this.bringToFrontToolStripMenuItem,
            this.sendToBackToolStripMenuItem,
            this.двойнаяToolStripMenuItem});
            this.cmSelectedFigure.Name = "cmSelectedFigure";
            this.cmSelectedFigure.Size = new System.Drawing.Size(157, 170);
            // 
            // miEditText
            // 
            this.miEditText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.miEditText.Name = "miEditText";
            this.miEditText.Size = new System.Drawing.Size(156, 22);
            this.miEditText.Text = "Edit text ...";
            this.miEditText.Click += new System.EventHandler(this.editTextToolStripMenuItem_Click);
            // 
            // miAddLine
            // 
            this.miAddLine.Name = "miAddLine";
            this.miAddLine.Size = new System.Drawing.Size(156, 22);
            this.miAddLine.Text = "Add Line";
            this.miAddLine.Click += new System.EventHandler(this.miAddLine_Click);
            // 
            // miAddLedgeLine
            // 
            this.miAddLedgeLine.Name = "miAddLedgeLine";
            this.miAddLedgeLine.Size = new System.Drawing.Size(156, 22);
            this.miAddLedgeLine.Text = "Add Ledge Line";
            this.miAddLedgeLine.Click += new System.EventHandler(this.miAddLedgeLine_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(156, 22);
            this.miDelete.Text = "Delete Figure";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
            // 
            // bringToFrontToolStripMenuItem
            // 
            this.bringToFrontToolStripMenuItem.Name = "bringToFrontToolStripMenuItem";
            this.bringToFrontToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.bringToFrontToolStripMenuItem.Text = "Bring to Front";
            this.bringToFrontToolStripMenuItem.Click += new System.EventHandler(this.bringToFrontToolStripMenuItem_Click);
            // 
            // sendToBackToolStripMenuItem
            // 
            this.sendToBackToolStripMenuItem.Name = "sendToBackToolStripMenuItem";
            this.sendToBackToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.sendToBackToolStripMenuItem.Text = "Send to Back";
            this.sendToBackToolStripMenuItem.Click += new System.EventHandler(this.sendToBackToolStripMenuItem_Click);
            // 
            // двойнаяToolStripMenuItem
            // 
            this.двойнаяToolStripMenuItem.Name = "двойнаяToolStripMenuItem";
            this.двойнаяToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.двойнаяToolStripMenuItem.Text = "Двойная";
            this.двойнаяToolStripMenuItem.Click += new System.EventHandler(this.двойнаяToolStripMenuItem_Click);
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(137, 622);
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
            this.btm6.Text = "Условие";
            this.btm6.UseVisualStyleBackColor = false;
            this.btm6.Click += new System.EventHandler(this.btm6_Click);
            // 
            // dbDiagram
            // 
            this.dbDiagram.AutoScroll = true;
            this.dbDiagram.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dbDiagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbDiagram.ContextMenuStrip = this.cmMain;
            this.dbDiagram.Diagram = null;
            this.dbDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbDiagram.ForeColor = System.Drawing.Color.Black;
            this.dbDiagram.Location = new System.Drawing.Point(137, 24);
            this.dbDiagram.Name = "dbDiagram";
            this.dbDiagram.SelectedFigure = null;
            this.dbDiagram.Size = new System.Drawing.Size(602, 622);
            this.dbDiagram.TabIndex = 3;
            this.dbDiagram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dbDiagram_KeyDown);
            this.dbDiagram.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagram_MouseDoubleClick);
            this.dbDiagram.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dbDiagram_MouseUp);
            // 
            // AlgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 646);
            this.Controls.Add(this.dbDiagram);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AlgForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Чертёжник";
            this.Load += new System.EventHandler(this.AlgForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmMain.ResumeLayout(false);
            this.cmSelectedFigure.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SaveFileDialog sfdDiagram;
        private System.Windows.Forms.OpenFileDialog ofdDiagram;
        private DiagramBox dbDiagram;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miClose;
        private System.Windows.Forms.ToolStripMenuItem miExport;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.ContextMenuStrip cmMain;
        private System.Windows.Forms.ToolStripMenuItem miAddRect;
        private System.Windows.Forms.ToolStripMenuItem addRoundRectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRhombToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addParalelogrammToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEllipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFrameToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmSelectedFigure;
        private System.Windows.Forms.ToolStripMenuItem miEditText;
        private System.Windows.Forms.ToolStripMenuItem miAddLine;
        private System.Windows.Forms.ToolStripMenuItem miAddLedgeLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bringToFrontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendToBackToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btm1;
        private System.Windows.Forms.ToolStripMenuItem прямоугольникСРамкойToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шестиугольникToolStripMenuItem;
        private System.Windows.Forms.Button btm2;
        private System.Windows.Forms.Button btm3;
        private System.Windows.Forms.Button btm4;
        private System.Windows.Forms.Button btm5;
        private System.Windows.Forms.ToolStripMenuItem двойнаяToolStripMenuItem;
        private System.Windows.Forms.Button btm6;
        private System.Windows.Forms.Button btm7;
    }
}

