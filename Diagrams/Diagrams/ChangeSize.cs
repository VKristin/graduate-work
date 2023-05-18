using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diagrams
{
    public partial class ChangeSize : Form
    {
        DrawForm frm;
        public ChangeSize(int numOfCellsX, int numOfCellsY)
        {
            InitializeComponent();
            numericUpDownX.Value = numOfCellsX;
            numericUpDownY.Value = numOfCellsY;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            frm = (DrawForm)this.Owner;
            frm.gridSize((int)numericUpDownX.Value, (int)numericUpDownY.Value);
            this.Close();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            frm = (DrawForm)this.Owner;
            frm.gridSize((int)numericUpDownX.Value, (int)numericUpDownY.Value);
            this.Close();
        }
    }
}
