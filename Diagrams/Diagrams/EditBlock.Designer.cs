namespace Diagrams
{
    partial class EditBlock
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
            this.lbAction = new System.Windows.Forms.Label();
            this.cbActions = new System.Windows.Forms.ComboBox();
            this.numActions = new System.Windows.Forms.NumericUpDown();
            this.nudConditions = new System.Windows.Forms.NumericUpDown();
            this.xuiButton1 = new XanderUI.XUIButton();
            this.xuiButton2 = new XanderUI.XUIButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConditions)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAction
            // 
            this.lbAction.AutoSize = true;
            this.lbAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAction.Location = new System.Drawing.Point(179, 46);
            this.lbAction.Name = "lbAction";
            this.lbAction.Size = new System.Drawing.Size(64, 15);
            this.lbAction.TabIndex = 0;
            this.lbAction.Text = "Действие";
            // 
            // cbActions
            // 
            this.cbActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbActions.FormattingEnabled = true;
            this.cbActions.Location = new System.Drawing.Point(99, 64);
            this.cbActions.Name = "cbActions";
            this.cbActions.Size = new System.Drawing.Size(226, 23);
            this.cbActions.TabIndex = 1;
            // 
            // numActions
            // 
            this.numActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numActions.Location = new System.Drawing.Point(99, 64);
            this.numActions.Name = "numActions";
            this.numActions.Size = new System.Drawing.Size(226, 21);
            this.numActions.TabIndex = 3;
            // 
            // nudConditions
            // 
            this.nudConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudConditions.Location = new System.Drawing.Point(331, 64);
            this.nudConditions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudConditions.Name = "nudConditions";
            this.nudConditions.Size = new System.Drawing.Size(70, 21);
            this.nudConditions.TabIndex = 5;
            this.nudConditions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // xuiButton1
            // 
            this.xuiButton1.BackgroundColor = System.Drawing.Color.LightGray;
            this.xuiButton1.ButtonImage = null;
            this.xuiButton1.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton1.ButtonText = "Сохранить";
            this.xuiButton1.ClickBackColor = System.Drawing.Color.LightGreen;
            this.xuiButton1.ClickTextColor = System.Drawing.Color.Black;
            this.xuiButton1.CornerRadius = 5;
            this.xuiButton1.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.HoverBackgroundColor = System.Drawing.Color.LightGreen;
            this.xuiButton1.HoverTextColor = System.Drawing.Color.Black;
            this.xuiButton1.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton1.Location = new System.Drawing.Point(41, 117);
            this.xuiButton1.Name = "xuiButton1";
            this.xuiButton1.Size = new System.Drawing.Size(146, 27);
            this.xuiButton1.TabIndex = 6;
            this.xuiButton1.TextColor = System.Drawing.Color.Black;
            this.xuiButton1.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton1.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // xuiButton2
            // 
            this.xuiButton2.BackgroundColor = System.Drawing.Color.LightGray;
            this.xuiButton2.ButtonImage = null;
            this.xuiButton2.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.xuiButton2.ButtonText = "Отменить";
            this.xuiButton2.ClickBackColor = System.Drawing.Color.IndianRed;
            this.xuiButton2.ClickTextColor = System.Drawing.Color.Black;
            this.xuiButton2.CornerRadius = 5;
            this.xuiButton2.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton2.HoverBackgroundColor = System.Drawing.Color.IndianRed;
            this.xuiButton2.HoverTextColor = System.Drawing.Color.Black;
            this.xuiButton2.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.xuiButton2.Location = new System.Drawing.Point(267, 117);
            this.xuiButton2.Name = "xuiButton2";
            this.xuiButton2.Size = new System.Drawing.Size(146, 27);
            this.xuiButton2.TabIndex = 7;
            this.xuiButton2.TextColor = System.Drawing.Color.Black;
            this.xuiButton2.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.xuiButton2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 24);
            this.panel1.TabIndex = 22;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // EditBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(462, 172);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.xuiButton2);
            this.Controls.Add(this.xuiButton1);
            this.Controls.Add(this.nudConditions);
            this.Controls.Add(this.numActions);
            this.Controls.Add(this.cbActions);
            this.Controls.Add(this.lbAction);
            this.KeyPreview = true;
            this.Name = "EditBlock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактировать блок";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditBlock_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConditions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAction;
        private System.Windows.Forms.ComboBox cbActions;
        private System.Windows.Forms.NumericUpDown numActions;
        private System.Windows.Forms.NumericUpDown nudConditions;
        private XanderUI.XUIButton xuiButton1;
        private XanderUI.XUIButton xuiButton2;
        private System.Windows.Forms.Panel panel1;
    }
}