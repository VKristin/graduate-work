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
        AlgForm parent;
        public StepsOfBlockSchema(AlgForm parent)
        {
            InitializeComponent();
            ControlBox = false;
            dgvFirst.Columns[0].Width = panel1.Width - dgvFirst.RowHeadersWidth - 10;
            dgvSecond.Columns[0].Width = panel2.Width - dgvSecond.RowHeadersWidth - 10;
            dgvThird.Columns[0].Width = panel3.Width - dgvThird.RowHeadersWidth - 10;
            this.parent = parent;
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

        private void dgvFirst_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvFirst.SelectedRows.Count != 0 && dgvFirst.Rows.Count > 1 && parent.развёрткаБлоксхемToolStripMenuItem.Checked && dgvFirst.SelectedRows[0].Index <= parent.draw.selectedList.Count)
            {
                parent.dbDiagram.selectedFigure = parent.draw.selectedList[dgvFirst.SelectedRows[0].Index].figure;
                parent.dbDiagram.Invalidate();
            }
        }

        private void dgvSecond_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvSecond.SelectedRows.Count != 0 && dgvSecond.Rows.Count > 1 && parent.развёрткаБлоксхемToolStripMenuItem.Checked && dgvSecond.SelectedRows[0].Index <= parent.draw.selectedListS.Count)
            {
                parent.dbDiagramS.selectedFigure = parent.draw.selectedListS[dgvSecond.SelectedRows[0].Index].figure;
                parent.dbDiagramS.Invalidate();
            }
        }

        private void dgvThird_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvThird.SelectedRows.Count != 0 && dgvThird.Rows.Count > 1 && parent.развёрткаБлоксхемToolStripMenuItem.Checked && dgvThird.SelectedRows[0].Index <= parent.draw.selectedListT.Count)
            {
                parent.dbDiagramT.selectedFigure = parent.draw.selectedListT[dgvThird.SelectedRows[0].Index].figure;
                parent.dbDiagramT.Invalidate();
            }
        }
    }
}
