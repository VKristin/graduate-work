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
    public partial class DrawForm : Form
    {
        public int numOfCellsX = 20;
        public int numOfCellsY = 15;
        int cellSize = 32;
        Form Main;
        public DrawForm(Form Parent)
        {
            Main = Parent;
            InitializeComponent();
            this.Left =Main.Left+Main.Width;
            this.Top= Main.Top;
            ControlBox = false;
            Size = new Size(numOfCellsX * cellSize + 40, numOfCellsY * cellSize + 140);
        }

        private void pbDraw_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Pen pen = new Pen(Color.LightGray, 1);

            cellSize = trackBarSize.Value;
            pbDraw.Width = numOfCellsX * cellSize + 1;
            pbDraw.Height = numOfCellsY * cellSize + 1;


            for (int y = 0; y <= numOfCellsY; y++)
            {
                e.Graphics.DrawLine(pen, 0, y * cellSize, numOfCellsX * cellSize, y * cellSize);
            }

            for (int x = 0; x <= numOfCellsX; x++)
            {
                e.Graphics.DrawLine(pen, x * cellSize, 0, x * cellSize, numOfCellsY * cellSize);
            }
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
            pbDraw.Invalidate();
        }
    }
}
