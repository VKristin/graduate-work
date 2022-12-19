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
            this.btnSave = new System.Windows.Forms.Button();
            this.numActions = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nudConditions = new System.Windows.Forms.NumericUpDown();
            this.tbProcName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConditions)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAction
            // 
            this.lbAction.AutoSize = true;
            this.lbAction.Location = new System.Drawing.Point(180, 23);
            this.lbAction.Name = "lbAction";
            this.lbAction.Size = new System.Drawing.Size(57, 13);
            this.lbAction.TabIndex = 0;
            this.lbAction.Text = "Действие";
            // 
            // cbActions
            // 
            this.cbActions.FormattingEnabled = true;
            this.cbActions.Location = new System.Drawing.Point(100, 39);
            this.cbActions.Name = "cbActions";
            this.cbActions.Size = new System.Drawing.Size(226, 21);
            this.cbActions.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(46, 102);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numActions
            // 
            this.numActions.Location = new System.Drawing.Point(100, 40);
            this.numActions.Name = "numActions";
            this.numActions.Size = new System.Drawing.Size(226, 20);
            this.numActions.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(272, 102);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(146, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отменить";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // nudConditions
            // 
            this.nudConditions.Location = new System.Drawing.Point(332, 39);
            this.nudConditions.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudConditions.Name = "nudConditions";
            this.nudConditions.Size = new System.Drawing.Size(70, 20);
            this.nudConditions.TabIndex = 5;
            this.nudConditions.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbProcName
            // 
            this.tbProcName.Location = new System.Drawing.Point(100, 39);
            this.tbProcName.Name = "tbProcName";
            this.tbProcName.Size = new System.Drawing.Size(226, 20);
            this.tbProcName.TabIndex = 6;
            // 
            // EditBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 137);
            this.Controls.Add(this.tbProcName);
            this.Controls.Add(this.nudConditions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.numActions);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbActions);
            this.Controls.Add(this.lbAction);
            this.Name = "EditBlock";
            this.Text = "Редактировать блок";
            ((System.ComponentModel.ISupportInitialize)(this.numActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudConditions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbAction;
        private System.Windows.Forms.ComboBox cbActions;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numActions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nudConditions;
        private System.Windows.Forms.TextBox tbProcName;
    }
}