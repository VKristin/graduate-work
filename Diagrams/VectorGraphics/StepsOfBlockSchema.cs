using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diagrams
{
    public partial class StepsOfBlockSchema : Form
    {
        public StepsOfBlockSchema()
        {
            InitializeComponent();
            ControlBox = false;
            dgvFirst.Columns[0].Width = panel1.Width - dgvFirst.RowHeadersWidth - 10;
            dgvSecond.Columns[0].Width = panel2.Width - dgvSecond.RowHeadersWidth - 10;
            dgvThird.Columns[0].Width = panel3.Width - dgvThird.RowHeadersWidth - 10;

        }


        private void dgvFirst_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dgvFirst.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dgvFirst.Rows[index].HeaderCell.Value = indexStr;
        }

        private void dgvSecond_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dgvSecond.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dgvSecond.Rows[index].HeaderCell.Value = indexStr;
        }

        private void dgvThird_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dgvThird.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.dgvThird.Rows[index].HeaderCell.Value = indexStr;
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            dgvFirst.Columns[0].Width = panel1.Width - dgvFirst.RowHeadersWidth - 10;
        }

        private void panel2_Resize(object sender, EventArgs e)
        {
            dgvSecond.Columns[0].Width = panel2.Width - dgvSecond.RowHeadersWidth - 10;

        }

        private void panel3_Resize(object sender, EventArgs e)
        {
            dgvThird.Columns[0].Width = panel3.Width - dgvThird.RowHeadersWidth - 10;

        }
    }
}
