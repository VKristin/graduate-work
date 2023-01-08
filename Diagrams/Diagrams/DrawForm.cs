using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Diagrams
{
    public partial class DrawForm : Form
    {
        public int numOfCellsX = 20;
        public int numOfCellsY = 15;
        public Point startPosition;
        int cellSize = 32;
        public Point position;
        Form Main;
        public Graphics g;

        public List<Coordinate> coordList = new List<Coordinate>();
        
        public DrawForm(Form Parent)
        {
            Main = Parent;
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.Left = Main.Left+Main.Width;
            this.Top = Main.Top;
            pencil1.Size = new Size(cellSize - 2, cellSize - 2);
            ControlBox = false;
            Size = new Size(numOfCellsX * cellSize + 25, numOfCellsY * cellSize + 160);
            startPosition = new Point(pbDraw.Location.X + 1, pbDraw.Size.Height + pbDraw.Location.Y - 4);
            pencil1.BackColor = Color.Transparent;
            pencil1.Location = startPosition;
            position = new Point(0, 0);
        }

        private void pbDraw_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Pen pen = new Pen(Color.LightGray, 1);
            cellSize = trackBarSize.Value;
            pbDraw.Width = numOfCellsX * cellSize + 1;
            pbDraw.Height = numOfCellsY * cellSize + 1;
            startPosition = new Point(pbDraw.Location.X + 1, pbDraw.Size.Height + pbDraw.Location.Y - 1 - pencil1.Height);

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
            pencil1.Size = new Size(cellSize - 2, cellSize - 2);
            pbDraw.Invalidate();
        }

        private void изменитьРазмерПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
                ChangeSize window = new ChangeSize(numOfCellsX, numOfCellsY);
                window.Owner = this; //Передаём вновь созданной форме её владельца.
                window.Show();
        }

        public void gridSize(int x, int y)
        {
            numOfCellsX = x;
            numOfCellsY = y;
            Invalidate();
        }

    }
    public class Coordinate
    {
        public Point p1;
        public Point p2;
        public Coordinate(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
    }
}
