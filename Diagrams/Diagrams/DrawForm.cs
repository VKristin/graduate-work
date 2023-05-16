using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Runtime.Serialization;

namespace Diagrams
{
    public partial class DrawForm : Form
    {
        public int numOfCellsX = 20;
        public int numOfCellsY = 15;
        public Point startPosition;
        int cellSize = 32;
        public Point positionFirst;
        public Point positionSecond;
        public Point positionThird;
        public byte dr = 3;
        Form Main;
        public Graphics g;
        public bool draw = false;
        public bool task = false;
        public List<Coordinate> taskCoord = new List<Coordinate>();

        public List<Coordinate> coordListFirst = new List<Coordinate>();
        public List<Coordinate> coordListSecond = new List<Coordinate>();
        public List<Coordinate> coordListThird = new List<Coordinate>();


        public DrawForm(Form Parent)
        {
            Main = Parent;
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.Left = Main.Left+Main.Width;
            this.Top = Main.Top;
            //pencil1.Size = new Size(cellSize - 2, cellSize - 2);
            ControlBox = false;
            Size = new Size(numOfCellsX * cellSize + 25, numOfCellsY * cellSize + 160);
            startPosition = new Point(1, numOfCellsY * cellSize + 2);
            //pencil1.BackColor = Color.Transparent;
            //pencil1.Location = startPosition;
            positionFirst = new Point(0, 0);
        }

        public void pbDraw_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Pen pen = new Pen(Color.LightGray, 1);
            Pen penTask = new Pen(Color.YellowGreen, 3);
            float[] dashValues = { 2, 2 };
            cellSize = trackBarSize.Value;
            pbDraw.Width = numOfCellsX * cellSize + 1 + cellSize;
            pbDraw.Height = numOfCellsY * cellSize + 1 + cellSize;
            //startPosition = new Point(pbDraw.Location.X + 1, pbDraw.Size.Height + pbDraw.Location.Y - 1 - cellSize - 2);
            startPosition = new Point(1, numOfCellsY * cellSize + 2);
            Pen pen1 = new Pen(Color.CornflowerBlue, 2);
            Pen pen2 = new Pen(Color.ForestGreen, 2);
            Pen pen3 = new Pen(Color.Orange, 2);

            for (int y = 1; y <= numOfCellsY + 1; y++)
            {
                e.Graphics.DrawLine(pen, 0, y * cellSize, numOfCellsX * cellSize, y * cellSize);
            }

            for (int x = 0; x <= numOfCellsX; x++)
            {
                e.Graphics.DrawLine(pen, x * cellSize, cellSize, x * cellSize, (numOfCellsY + 1) * cellSize);
            }
            
            if (task && taskCoord.Count > 0)
            {
                penTask.DashPattern = dashValues;
                for (int i = 0; i < taskCoord.Count(); i++)
                {
                    Point point1 = new Point((int)(taskCoord[i].p1.X * cellSize), (int)((-taskCoord[i].p1.Y + numOfCellsY + 1) * cellSize));
                    Point point2 = new Point((int)(taskCoord[i].p2.X * cellSize), (int)((-taskCoord[i].p2.Y + numOfCellsY + 1) * cellSize));
                    e.Graphics.DrawLine(penTask, point1, point2);
                }
            }
            if (positionFirst.X == 0 && positionFirst.Y == 0)
                e.Graphics.DrawImage(imageList1.Images[0], startPosition.X, startPosition.Y, cellSize - 2, cellSize - 2);

            if (positionSecond.X == 0 && positionSecond.Y == 0 && dr > 1)
                e.Graphics.DrawImage(imageList1.Images[1], startPosition.X, startPosition.Y, cellSize - 2, cellSize - 2);

            if (positionThird.X == 0 && positionThird.Y == 0 && dr > 2)
                e.Graphics.DrawImage(imageList1.Images[2], startPosition.X, startPosition.Y, cellSize - 2, cellSize - 2);

            if (coordListFirst.Count() != 0 && draw)
            {
                e.Graphics.DrawImage(imageList1.Images[0], startPosition.X + cellSize * positionFirst.X, startPosition.Y - 1 - cellSize * positionFirst.Y, cellSize - 2, cellSize - 2);

                for (int i = 0; i < coordListFirst.Count(); i++)
                {
                    e.Graphics.DrawLine(pen1, new Point(coordListFirst[i].p1.X * cellSize, (-coordListFirst[i].p1.Y + numOfCellsY + 1) * cellSize), new Point(coordListFirst[i].p2.X * cellSize, (-coordListFirst[i].p2.Y + numOfCellsY + 1) * cellSize));
                }
            }
            if (coordListSecond.Count() != 0 && draw)
            {
                if (dr > 1)
                e.Graphics.DrawImage(imageList1.Images[1], startPosition.X + cellSize * positionSecond.X, startPosition.Y - 1 - cellSize * positionSecond.Y, cellSize - 2, cellSize - 2);

                for (int i = 0; i < coordListSecond.Count(); i++)
                {
                    e.Graphics.DrawLine(pen2, new Point(coordListSecond[i].p1.X * cellSize, (-coordListSecond[i].p1.Y + numOfCellsY + 1) * cellSize), new Point(coordListSecond[i].p2.X * cellSize, (-coordListSecond[i].p2.Y + numOfCellsY + 1) * cellSize));
                }
            }
            if (coordListThird.Count() != 0 && draw)
            {
                if (dr > 2)
                e.Graphics.DrawImage(imageList1.Images[2], startPosition.X + cellSize * positionThird.X, startPosition.Y - 1 - cellSize * positionThird.Y, cellSize - 2, cellSize - 2);

                for (int i = 0; i < coordListThird.Count(); i++)
                {
                    e.Graphics.DrawLine(pen3, new Point(coordListThird[i].p1.X * cellSize, (-coordListThird[i].p1.Y + numOfCellsY + 1) * cellSize), new Point(coordListThird[i].p2.X * cellSize, (-coordListThird[i].p2.Y + numOfCellsY + 1) * cellSize));
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

            Pen pen1 = new Pen(Color.CornflowerBlue, 2);
            Pen pen2 = new Pen(Color.ForestGreen, 2);
            Pen pen3 = new Pen(Color.Orange, 2);
            if (coordListFirst.Count() != 0)
            {
                pbDraw.Refresh();
                //pencil1.Location = new Point(pbDraw.Location.X + 1 + cellSize * position.X, pbDraw.Size.Height + pbDraw.Location.Y - 1 - pencil1.Height - cellSize * position.Y);
                for (int i = 0; i < coordListFirst.Count(); i++)
                {
                    g.DrawLine(pen1, new Point(coordListFirst[i].p1.X * cellSize, (-coordListFirst[i].p1.X + numOfCellsY) * cellSize), new Point(coordListFirst[i].p2.X * cellSize, (-coordListFirst[i].p2.X + numOfCellsY) * cellSize));
                }
            }
            if (coordListSecond.Count() != 0)
            {
                pbDraw.Refresh();
                //pencil1.Location = new Point(pbDraw.Location.X + 1 + cellSize * position.X, pbDraw.Size.Height + pbDraw.Location.Y - 1 - pencil1.Height - cellSize * position.Y);
                for (int i = 0; i < coordListSecond.Count(); i++)
                {
                    g.DrawLine(pen2, new Point(coordListSecond[i].p1.X * cellSize, (-coordListSecond[i].p1.X + numOfCellsY) * cellSize), new Point(coordListSecond[i].p2.X * cellSize, (-coordListSecond[i].p2.X + numOfCellsY) * cellSize));
                }
            }
            if (coordListThird.Count() != 0)
            {
                pbDraw.Refresh();
                //pencil1.Location = new Point(pbDraw.Location.X + 1 + cellSize * position.X, pbDraw.Size.Height + pbDraw.Location.Y - 1 - pencil1.Height - cellSize * position.Y);
                for (int i = 0; i < coordListThird.Count(); i++)
                {
                    g.DrawLine(pen3, new Point(coordListThird[i].p1.X * cellSize, (-coordListThird[i].p1.X + numOfCellsY) * cellSize), new Point(coordListThird[i].p2.X * cellSize, (-coordListThird[i].p2.X + numOfCellsY) * cellSize));
                }
            }
        }
        public void OpenTask()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "drawer task files (*.drawertask)|*.drawertask|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            string filename = openFileDialog.FileName;
            if (filename == "")
                return;
            taskCoord.Clear();
            draw = false;
            using (StreamReader reader = new StreamReader(filename))
            {
                numOfCellsX = Convert.ToInt32(reader.ReadLine());
                numOfCellsY = Convert.ToInt32(reader.ReadLine());
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    int[] c = Array.ConvertAll(line.Split(' '), int.Parse);
                    taskCoord.Add(new Coordinate(new Point(c[0], c[1]), new Point(c[2], c[3])));
                }
                task = true;
            }
            pbDraw.Invalidate();
        }
        private Field LoadFile(string filename)
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Binder = new CustomBinder();
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                return(formatter.Deserialize(fs) as Field);
            }
        }

        private void очиститьПолеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            coordListFirst.Clear();
            coordListSecond.Clear();
            coordListThird.Clear();
            pbDraw.Invalidate();
        }

        private void удалитьЗаданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskCoord.Clear();
            task = false;
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
    [Serializable]
    class Field
    {
        public int n; //количество строк
        public int m; //количество столбцов
        public List<Coordinate> task;

        public Field(int n, int m, List<Coordinate> task)
        {
            this.n = n;
            this.m = m;
            this.task = task;
        }
    }

    public class CustomBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Assembly currentasm = Assembly.GetExecutingAssembly();

            return Type.GetType($"{currentasm.GetName().Name}.{typeName.Split('.')[1]}");
        }
    }
}
