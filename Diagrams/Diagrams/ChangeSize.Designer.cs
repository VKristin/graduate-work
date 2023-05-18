namespace Diagrams
{
    partial class ChangeSize
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
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.xuiButton1 = new XanderUI.XUIButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            this.SuspendLayout();
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelY.Location = new System.Drawing.Point(75, 80);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(55, 16);
            this.labelY.TabIndex = 10;
            this.labelY.Text = "Высота";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelX.Location = new System.Drawing.Point(75, 10);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(58, 16);
            this.labelX.TabIndex = 9;
            this.labelX.Text = "Ширина";
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownY.Location = new System.Drawing.Point(46, 110);
            this.numericUpDownY.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownY.TabIndex = 7;
            this.numericUpDownY.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownX.Location = new System.Drawing.Point(46, 40);
            this.numericUpDownX.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownX.TabIndex = 6;
            this.numericUpDownX.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // xuiButton1
            // 
            this.xuiButton1.BackgroundColor = System.Drawing.Color.LightGray;
            this.xuiButton1.ButtonImage = null;
            this.xuiButton1.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton1.ButtonText = "Применить";
            this.xuiButton1.ClickBackColor = System.Drawing.Color.LightGreen;
            this.xuiButton1.ClickTextColor = System.Drawing.Color.Black;
            this.xuiButton1.CornerRadius = 5;
            this.xuiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.xuiButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.HoverBackgroundColor = System.Drawing.Color.LightGreen;
            this.xuiButton1.HoverTextColor = System.Drawing.Color.Black;
            this.xuiButton1.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton1.Location = new System.Drawing.Point(34, 168);
            this.xuiButton1.Name = "xuiButton1";
            this.xuiButton1.Size = new System.Drawing.Size(146, 32);
            this.xuiButton1.TabIndex = 11;
            this.xuiButton1.TextColor = System.Drawing.Color.Black;
            this.xuiButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.Click += new System.EventHandler(this.xuiButton1_Click);
            // 
            // ChangeSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(211, 223);
            this.Controls.Add(this.xuiButton1);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.numericUpDownY);
            this.Controls.Add(this.numericUpDownX);
            this.Name = "ChangeSize";
            this.Text = "Изменить размер поля";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private XanderUI.XUIButton xuiButton1;
    }
}