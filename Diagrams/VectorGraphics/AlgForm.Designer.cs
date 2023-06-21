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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlgForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьЗаданиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьАлгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьАлгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьПодпрограммуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьПодпрограммуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miExport = new System.Windows.Forms.ToolStripMenuItem();
            this.количествоИсполнителейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.одинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.триToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.развёрткаБлоксхемToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miClose = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повторитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нарисоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шагВперёдToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наНачалоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdDiagram = new System.Windows.Forms.SaveFileDialog();
            this.ofdDiagram = new System.Windows.Forms.OpenFileDialog();
            this.sfdImage = new System.Windows.Forms.SaveFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.xuiButton6 = new XanderUI.XUIButton();
            this.xuiButton2 = new XanderUI.XUIButton();
            this.xuiButton3 = new XanderUI.XUIButton();
            this.xuiButton4 = new XanderUI.XUIButton();
            this.btm7 = new System.Windows.Forms.Button();
            this.xuiButton5 = new XanderUI.XUIButton();
            this.xuiButton1 = new XanderUI.XUIButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dbDiagramT = new Diagrams.DiagramBox();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dbDiagramS = new Diagrams.DiagramBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dbDiagram = new Diagrams.DiagramBox();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.редактированиеToolStripMenuItem,
            this.нарисоватьToolStripMenuItem,
            this.шагВперёдToolStripMenuItem,
            this.наНачалоToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(977, 28);
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
            this.открытьПодпрограммуToolStripMenuItem,
            this.сохранитьПодпрограммуToolStripMenuItem,
            this.miExport,
            this.количествоИсполнителейToolStripMenuItem,
            this.развёрткаБлоксхемToolStripMenuItem,
            this.toolStripMenuItem2,
            this.miClose});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(48, 24);
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
            // открытьПодпрограммуToolStripMenuItem
            // 
            this.открытьПодпрограммуToolStripMenuItem.Name = "открытьПодпрограммуToolStripMenuItem";
            this.открытьПодпрограммуToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.открытьПодпрограммуToolStripMenuItem.Text = "Открыть подпрограмму";
            this.открытьПодпрограммуToolStripMenuItem.Click += new System.EventHandler(this.открытьПодпрограммуToolStripMenuItem_Click);
            // 
            // сохранитьПодпрограммуToolStripMenuItem
            // 
            this.сохранитьПодпрограммуToolStripMenuItem.Name = "сохранитьПодпрограммуToolStripMenuItem";
            this.сохранитьПодпрограммуToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.сохранитьПодпрограммуToolStripMenuItem.Text = "Сохранить подпрограмму";
            this.сохранитьПодпрограммуToolStripMenuItem.Click += new System.EventHandler(this.сохранитьПодпрограммуToolStripMenuItem_Click);
            // 
            // miExport
            // 
            this.miExport.Name = "miExport";
            this.miExport.Size = new System.Drawing.Size(231, 22);
            this.miExport.Text = "Сохранить как изображение";
            this.miExport.Click += new System.EventHandler(this.miExport_Click);
            // 
            // количествоИсполнителейToolStripMenuItem
            // 
            this.количествоИсполнителейToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.одинToolStripMenuItem,
            this.дваToolStripMenuItem,
            this.триToolStripMenuItem});
            this.количествоИсполнителейToolStripMenuItem.Name = "количествоИсполнителейToolStripMenuItem";
            this.количествоИсполнителейToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.количествоИсполнителейToolStripMenuItem.Text = "Количество исполнителей";
            // 
            // одинToolStripMenuItem
            // 
            this.одинToolStripMenuItem.CheckOnClick = true;
            this.одинToolStripMenuItem.Name = "одинToolStripMenuItem";
            this.одинToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.одинToolStripMenuItem.Text = "Один";
            this.одинToolStripMenuItem.Click += new System.EventHandler(this.одинToolStripMenuItem_Click);
            // 
            // дваToolStripMenuItem
            // 
            this.дваToolStripMenuItem.CheckOnClick = true;
            this.дваToolStripMenuItem.Name = "дваToolStripMenuItem";
            this.дваToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.дваToolStripMenuItem.Text = "Два";
            this.дваToolStripMenuItem.Click += new System.EventHandler(this.дваToolStripMenuItem_Click);
            // 
            // триToolStripMenuItem
            // 
            this.триToolStripMenuItem.Checked = true;
            this.триToolStripMenuItem.CheckOnClick = true;
            this.триToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.триToolStripMenuItem.Name = "триToolStripMenuItem";
            this.триToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.триToolStripMenuItem.Text = "Три";
            this.триToolStripMenuItem.Click += new System.EventHandler(this.триToolStripMenuItem_Click);
            // 
            // развёрткаБлоксхемToolStripMenuItem
            // 
            this.развёрткаБлоксхемToolStripMenuItem.Name = "развёрткаБлоксхемToolStripMenuItem";
            this.развёрткаБлоксхемToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.развёрткаБлоксхемToolStripMenuItem.Text = "Развёртка блок-схем";
            this.развёрткаБлоксхемToolStripMenuItem.Click += new System.EventHandler(this.развёрткаБлоксхемToolStripMenuItem_Click);
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
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отменитьToolStripMenuItem,
            this.повторитьToolStripMenuItem});
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.редактированиеToolStripMenuItem.Text = "Редактирование";
            // 
            // отменитьToolStripMenuItem
            // 
            this.отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            this.отменитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.отменитьToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.отменитьToolStripMenuItem.Text = "Отменить";
            this.отменитьToolStripMenuItem.Click += new System.EventHandler(this.отменитьToolStripMenuItem_Click);
            // 
            // повторитьToolStripMenuItem
            // 
            this.повторитьToolStripMenuItem.Name = "повторитьToolStripMenuItem";
            this.повторитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.повторитьToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.повторитьToolStripMenuItem.Text = "Повторить";
            this.повторитьToolStripMenuItem.Click += new System.EventHandler(this.повторитьToolStripMenuItem_Click);
            // 
            // нарисоватьToolStripMenuItem
            // 
            this.нарисоватьToolStripMenuItem.Image = global::Diagrams.Properties.Resources._462e78b93afcc280ca29c0be869fe17f;
            this.нарисоватьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.нарисоватьToolStripMenuItem.Name = "нарисоватьToolStripMenuItem";
            this.нарисоватьToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
            this.нарисоватьToolStripMenuItem.Text = "Нарисовать";
            this.нарисоватьToolStripMenuItem.Click += new System.EventHandler(this.нарисоватьToolStripMenuItem_Click);
            // 
            // шагВперёдToolStripMenuItem
            // 
            this.шагВперёдToolStripMenuItem.Name = "шагВперёдToolStripMenuItem";
            this.шагВперёдToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.шагВперёдToolStripMenuItem.Text = "Шаг вперёд";
            this.шагВперёдToolStripMenuItem.Click += new System.EventHandler(this.шагВперёдToolStripMenuItem_Click);
            // 
            // наНачалоToolStripMenuItem
            // 
            this.наНачалоToolStripMenuItem.Name = "наНачалоToolStripMenuItem";
            this.наНачалоToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.наНачалоToolStripMenuItem.Text = "На начало";
            this.наНачалоToolStripMenuItem.Click += new System.EventHandler(this.наНачалоToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.ShortcutKeyDisplayString = "F1";
            this.справкаToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
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
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.xuiButton6);
            this.flowLayoutPanel1.Controls.Add(this.xuiButton2);
            this.flowLayoutPanel1.Controls.Add(this.xuiButton3);
            this.flowLayoutPanel1.Controls.Add(this.xuiButton4);
            this.flowLayoutPanel1.Controls.Add(this.btm7);
            this.flowLayoutPanel1.Controls.Add(this.xuiButton5);
            this.flowLayoutPanel1.Controls.Add(this.xuiButton1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(137, 413);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // xuiButton6
            // 
            this.xuiButton6.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xuiButton6.ButtonImage = null;
            this.xuiButton6.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton6.ButtonText = "Вызов подпрограммы";
            this.xuiButton6.ClickBackColor = System.Drawing.Color.Silver;
            this.xuiButton6.ClickTextColor = System.Drawing.Color.Black;
            this.xuiButton6.CornerRadius = 5;
            this.xuiButton6.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton6.HoverBackgroundColor = System.Drawing.Color.Silver;
            this.xuiButton6.HoverTextColor = System.Drawing.Color.Black;
            this.xuiButton6.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton6.Location = new System.Drawing.Point(3, 3);
            this.xuiButton6.Name = "xuiButton6";
            this.xuiButton6.Size = new System.Drawing.Size(134, 50);
            this.xuiButton6.TabIndex = 23;
            this.xuiButton6.TextColor = System.Drawing.Color.Black;
            this.xuiButton6.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton6.Click += new System.EventHandler(this.xuiButton6_Click);
            // 
            // xuiButton2
            // 
            this.xuiButton2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xuiButton2.ButtonImage = null;
            this.xuiButton2.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton2.ButtonText = "Цикл с предусловием";
            this.xuiButton2.ClickBackColor = System.Drawing.Color.Silver;
            this.xuiButton2.ClickTextColor = System.Drawing.Color.Black;
            this.xuiButton2.CornerRadius = 5;
            this.xuiButton2.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton2.HoverBackgroundColor = System.Drawing.Color.Silver;
            this.xuiButton2.HoverTextColor = System.Drawing.Color.Black;
            this.xuiButton2.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton2.Location = new System.Drawing.Point(3, 59);
            this.xuiButton2.Name = "xuiButton2";
            this.xuiButton2.Size = new System.Drawing.Size(134, 50);
            this.xuiButton2.TabIndex = 19;
            this.xuiButton2.TextColor = System.Drawing.Color.Black;
            this.xuiButton2.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton2.Click += new System.EventHandler(this.xuiButton2_Click);
            // 
            // xuiButton3
            // 
            this.xuiButton3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xuiButton3.ButtonImage = null;
            this.xuiButton3.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton3.ButtonText = "Цикл с счётчиком";
            this.xuiButton3.ClickBackColor = System.Drawing.Color.Silver;
            this.xuiButton3.ClickTextColor = System.Drawing.Color.Black;
            this.xuiButton3.CornerRadius = 5;
            this.xuiButton3.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton3.HoverBackgroundColor = System.Drawing.Color.Silver;
            this.xuiButton3.HoverTextColor = System.Drawing.Color.Black;
            this.xuiButton3.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton3.Location = new System.Drawing.Point(3, 115);
            this.xuiButton3.Name = "xuiButton3";
            this.xuiButton3.Size = new System.Drawing.Size(134, 50);
            this.xuiButton3.TabIndex = 20;
            this.xuiButton3.TextColor = System.Drawing.Color.Black;
            this.xuiButton3.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton3.Click += new System.EventHandler(this.xuiButton3_Click);
            // 
            // xuiButton4
            // 
            this.xuiButton4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xuiButton4.ButtonImage = null;
            this.xuiButton4.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton4.ButtonText = "Действие";
            this.xuiButton4.ClickBackColor = System.Drawing.Color.Silver;
            this.xuiButton4.ClickTextColor = System.Drawing.Color.Black;
            this.xuiButton4.CornerRadius = 5;
            this.xuiButton4.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton4.HoverBackgroundColor = System.Drawing.Color.Silver;
            this.xuiButton4.HoverTextColor = System.Drawing.Color.Black;
            this.xuiButton4.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton4.Location = new System.Drawing.Point(3, 171);
            this.xuiButton4.Name = "xuiButton4";
            this.xuiButton4.Size = new System.Drawing.Size(134, 50);
            this.xuiButton4.TabIndex = 21;
            this.xuiButton4.TextColor = System.Drawing.Color.Black;
            this.xuiButton4.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton4.Click += new System.EventHandler(this.xuiButton4_Click);
            // 
            // btm7
            // 
            this.btm7.BackColor = System.Drawing.Color.Lavender;
            this.btm7.Location = new System.Drawing.Point(3, 227);
            this.btm7.Name = "btm7";
            this.btm7.Size = new System.Drawing.Size(134, 45);
            this.btm7.TabIndex = 11;
            this.btm7.Text = "Цикл с постусловием";
            this.btm7.UseVisualStyleBackColor = false;
            this.btm7.Visible = false;
            this.btm7.Click += new System.EventHandler(this.button1_Click);
            // 
            // xuiButton5
            // 
            this.xuiButton5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xuiButton5.ButtonImage = null;
            this.xuiButton5.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton5.ButtonText = "Исключение";
            this.xuiButton5.ClickBackColor = System.Drawing.Color.Silver;
            this.xuiButton5.ClickTextColor = System.Drawing.Color.Black;
            this.xuiButton5.CornerRadius = 5;
            this.xuiButton5.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton5.HoverBackgroundColor = System.Drawing.Color.Silver;
            this.xuiButton5.HoverTextColor = System.Drawing.Color.Black;
            this.xuiButton5.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton5.Location = new System.Drawing.Point(3, 278);
            this.xuiButton5.Name = "xuiButton5";
            this.xuiButton5.Size = new System.Drawing.Size(134, 50);
            this.xuiButton5.TabIndex = 22;
            this.xuiButton5.TextColor = System.Drawing.Color.Black;
            this.xuiButton5.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton5.Click += new System.EventHandler(this.xuiButton5_Click);
            // 
            // xuiButton1
            // 
            this.xuiButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.xuiButton1.ButtonImage = null;
            this.xuiButton1.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton1.ButtonText = "Развилка";
            this.xuiButton1.ClickBackColor = System.Drawing.Color.Silver;
            this.xuiButton1.ClickTextColor = System.Drawing.Color.Black;
            this.xuiButton1.CornerRadius = 5;
            this.xuiButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.HoverBackgroundColor = System.Drawing.Color.Silver;
            this.xuiButton1.HoverTextColor = System.Drawing.Color.Black;
            this.xuiButton1.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton1.Location = new System.Drawing.Point(3, 334);
            this.xuiButton1.Name = "xuiButton1";
            this.xuiButton1.Size = new System.Drawing.Size(134, 50);
            this.xuiButton1.TabIndex = 24;
            this.xuiButton1.TextColor = System.Drawing.Color.Black;
            this.xuiButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.Visible = false;
            this.xuiButton1.Click += new System.EventHandler(this.xuiButton1_Click_1);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(137, 28);
            this.splitter1.MinExtra = 5;
            this.splitter1.MinSize = 0;
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 413);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.Controls.Add(this.splitter4);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.splitter3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.splitter2);
            this.panel4.Controls.Add(this.panel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(138, 28);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(839, 413);
            this.panel4.TabIndex = 23;
            // 
            // splitter4
            // 
            this.splitter4.Location = new System.Drawing.Point(783, 0);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(3, 413);
            this.splitter4.TabIndex = 28;
            this.splitter4.TabStop = false;
            this.splitter4.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter4_SplitterMoved);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel3.Controls.Add(this.dbDiagramT);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(524, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(259, 413);
            this.panel3.TabIndex = 24;
            // 
            // dbDiagramT
            // 
            this.dbDiagramT.AutoScroll = true;
            this.dbDiagramT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dbDiagramT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbDiagramT.Diagram = null;
            this.dbDiagramT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbDiagramT.ForeColor = System.Drawing.Color.Black;
            this.dbDiagramT.Location = new System.Drawing.Point(3, 3);
            this.dbDiagramT.Margin = new System.Windows.Forms.Padding(4);
            this.dbDiagramT.Name = "dbDiagramT";
            this.dbDiagramT.SelectedFigure = null;
            this.dbDiagramT.Size = new System.Drawing.Size(253, 407);
            this.dbDiagramT.TabIndex = 12;
            this.dbDiagramT.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagramT_MouseClick);
            this.dbDiagramT.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagramT_MouseDoubleClick);
            this.dbDiagramT.Resize += new System.EventHandler(this.dbDiagramT_Resize);
            // 
            // splitter3
            // 
            this.splitter3.Location = new System.Drawing.Point(521, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 413);
            this.splitter3.TabIndex = 27;
            this.splitter3.TabStop = false;
            this.splitter3.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter3_SplitterMoved);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.dbDiagramS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(262, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(259, 413);
            this.panel2.TabIndex = 25;
            // 
            // dbDiagramS
            // 
            this.dbDiagramS.AutoScroll = true;
            this.dbDiagramS.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dbDiagramS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbDiagramS.Diagram = null;
            this.dbDiagramS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbDiagramS.ForeColor = System.Drawing.Color.Black;
            this.dbDiagramS.Location = new System.Drawing.Point(3, 3);
            this.dbDiagramS.Margin = new System.Windows.Forms.Padding(4);
            this.dbDiagramS.Name = "dbDiagramS";
            this.dbDiagramS.SelectedFigure = null;
            this.dbDiagramS.Size = new System.Drawing.Size(253, 407);
            this.dbDiagramS.TabIndex = 10;
            this.dbDiagramS.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagramS_MouseClick);
            this.dbDiagramS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagramS_MouseDoubleClick);
            this.dbDiagramS.Resize += new System.EventHandler(this.dbDiagramS_Resize);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(259, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 413);
            this.splitter2.TabIndex = 26;
            this.splitter2.TabStop = false;
            this.splitter2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter2_SplitterMoved);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.dbDiagram);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(259, 413);
            this.panel1.TabIndex = 23;
            // 
            // dbDiagram
            // 
            this.dbDiagram.AutoScroll = true;
            this.dbDiagram.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dbDiagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dbDiagram.Diagram = null;
            this.dbDiagram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbDiagram.ForeColor = System.Drawing.Color.Black;
            this.dbDiagram.Location = new System.Drawing.Point(3, 3);
            this.dbDiagram.Margin = new System.Windows.Forms.Padding(4);
            this.dbDiagram.Name = "dbDiagram";
            this.dbDiagram.SelectedFigure = null;
            this.dbDiagram.Size = new System.Drawing.Size(253, 407);
            this.dbDiagram.TabIndex = 4;
            this.dbDiagram.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagram_MouseClick);
            this.dbDiagram.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dbDiagram_MouseDoubleClick);
            this.dbDiagram.Resize += new System.EventHandler(this.dbDiagram_Resize);
            // 
            // AlgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(977, 441);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AlgForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Карандаш";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlgForm_FormClosing);
            this.Load += new System.EventHandler(this.AlgForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AlgForm_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog sfdDiagram;
        private System.Windows.Forms.OpenFileDialog ofdDiagram;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miClose;
        private System.Windows.Forms.ToolStripMenuItem miExport;
        private System.Windows.Forms.SaveFileDialog sfdImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btm7;
        private System.Windows.Forms.ToolStripMenuItem нарисоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьЗаданиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьАлгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьАлгоритмToolStripMenuItem;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьПодпрограммуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьПодпрограммуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повторитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem количествоИсполнителейToolStripMenuItem;
        private XanderUI.XUIButton xuiButton2;
        private XanderUI.XUIButton xuiButton3;
        private XanderUI.XUIButton xuiButton4;
        private XanderUI.XUIButton xuiButton5;
        private XanderUI.XUIButton xuiButton6;
        public System.Windows.Forms.ToolStripMenuItem одинToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem дваToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem триToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private XanderUI.XUIButton xuiButton1;
        private System.Windows.Forms.ToolStripMenuItem шагВперёдToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наНачалоToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem развёрткаБлоксхемToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel panel3;
        public DiagramBox dbDiagramT;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel2;
        public DiagramBox dbDiagramS;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel1;
        public DiagramBox dbDiagram;
    }
}

