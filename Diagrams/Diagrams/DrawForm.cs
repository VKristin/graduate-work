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
        public bool draw = false;
        public bool task = false;
        public List<Coordinate> taskCoord = null;

        public List<Coordinate> coordList = new List<Coordinate>();
        
        public DrawForm(Form Parent)
        {
            Main = Parent;
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
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
            pencil1.Size = new Size(cellSize - 2, cellSize - 2);
            e.Graphics.Clear(Color.White);
            Pen pen = new Pen(Color.LightGray, 1);
            Pen penTask = new Pen(Color.YellowGreen, 3);
            float[] dashValues = { 2, 2 };
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
            if (position.X == 0 && position.Y == 0)
                pencil1.Location = startPosition;
            if (coordList.Count() != 0 && draw)
            {
                Pen pen1 = new Pen(Color.CornflowerBlue, 2);
                pencil1.Location = new Point(pbDraw.Location.X + 1 + cellSize * position.X, pbDraw.Size.Height + pbDraw.Location.Y - 1 - pencil1.Height - cellSize * position.Y);
                for (int i = 0; i < coordList.Count(); i++)
                {
                    e.Graphics.DrawLine(pen1, new Point(coordList[i].p1.X * cellSize, (-coordList[i].p1.Y + numOfCellsY) * cellSize), new Point(coordList[i].p2.X * cellSize, (-coordList[i].p2.Y + numOfCellsY) * cellSize));
                }
            }
            if (task && taskCoord.Count > 0)
            {
                penTask.DashPattern = dashValues;
                for (int i = 0; i < taskCoord.Count(); i++)
                {
                    Point point1 = new Point((int)(taskCoord[i].p1.X * cellSize), (int)((-taskCoord[i].p1.Y + numOfCellsY) * cellSize));
                    Point point2 = new Point((int)(taskCoord[i].p2.X * cellSize), (int)((-taskCoord[i].p2.Y + numOfCellsY) * cellSize));
                    e.Graphics.DrawLine(penTask, point1, point2);
                }
            }
        }

        private void trackBarSize_Scroll(object sender, EventArgs e)
        {
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
        public void DrawAgain()
        {
            if (coordList.Count() != 0)
            {
                Pen pen1 = new Pen(Color.CornflowerBlue, 3); ;
                pbDraw.Refresh();
                pencil1.Location = new Point(pbDraw.Location.X + 1 + cellSize * position.X, pbDraw.Size.Height + pbDraw.Location.Y - 1 - pencil1.Height - cellSize * position.Y);
                for (int i = 0; i < coordList.Count(); i++)
                {
                    g.DrawLine(pen1, new Point(coordList[i].p1.X * cellSize, (-coordList[i].p1.X + numOfCellsY) * cellSize), new Point(coordList[i].p2.X * cellSize, (-coordList[i].p2.X + numOfCellsY) * cellSize));
                }
            }
        }
        public void OpenTask()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.InitialDirectory = directory;
            openFileDialog.Filter = "drawer task files (*.drawertask)|*.drawertask|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            string filename = openFileDialog.FileName;
            if (filename == "")
                return;
            //directory = filename;
            //saveNewSettings(filename);
            if (taskCoord != null && taskCoord.Count != 0)
                taskCoord.Clear();
            task = false;
            pbDraw.Invalidate();
            System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(List<Coordinate>));

            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            taskCoord = (List<Coordinate>)reader.Deserialize(file);
            //numOfCellsX = Convert.ToInt32(Math.Ceiling(taskCoord.Max(x => x2))) + 1;
            //numOfCellsY = Convert.ToInt32(Math.Ceiling(taskCoord.Max(x => x.y1))) + 1;
            numOfCellsX = 20;
            numOfCellsY = 10;
            file.Close();
            task = true;
            //clear = false;
            pbDraw.Invalidate();
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
        public Coordinate() { }
    }
    
}
