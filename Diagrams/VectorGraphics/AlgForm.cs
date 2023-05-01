using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;

namespace Diagrams
{
    public partial class AlgForm : Form
    {
        Block blockFirst;
        Block blockSecond;
        Block blockThird;
        DrawForm drawForm;
        string directory;
        private int currentIdx = -1; //индекс в истории
        //списки для хранения истории для каждой диаграммы отдельно
        private List<FiguresForSave> diagrams = new List<FiguresForSave>();
        private List<BlocksForSave> blocks = new List<BlocksForSave>();
        List<Coord> coordList = new List<Coord>(); //необходимые для отрисовки балки
        public AlgForm()
        {
            if (File.Exists(Environment.CurrentDirectory + @"\history.bin"))
                File.Delete(Environment.CurrentDirectory + @"\history.bin");
            FileStream fs = new FileStream(Environment.CurrentDirectory + @"\history.bin", FileMode.Create);
            System.IO.File.SetAttributes(Environment.CurrentDirectory + @"\history.bin", System.IO.FileAttributes.Hidden);
            fs.Close();
            this.Left = 0;
            this.Top = 0;
            InitializeComponent();
            groupBox1.BackColor = Color.CornflowerBlue;
            groupBox2.BackColor = Color.ForestGreen;
            groupBox3.BackColor = Color.Orange;
            dbDiagram.markerColor = Color.CornflowerBlue;
            dbDiagramS.markerColor = Color.ForestGreen;
            dbDiagramT.markerColor = Color.Orange;
            miNewDiagram_Click(null, null);
            AddWindow();
        }
        public List<Figure> CloneFigures(List<Figure> fgrs)
        {
            List<Figure> clone = new List<Figure>();
            foreach (Figure f in fgrs)
            {
                clone.Add(f.Clone());
            }
            return clone;
        }

        public void AddWindow()
        {
            drawForm = new DrawForm(this);
            drawForm.Owner = this; //Передаём вновь созданной форме её владельца.
            drawForm.Show();
        }
        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miNewDiagram_Click(object sender, EventArgs e)
        {
            dbDiagram.Diagram = new Diagram();
            dbDiagramS.Diagram = new Diagram();
            dbDiagramT.Diagram = new Diagram();
            dbDiagramS.Diagram = dbDiagramS.Diagram;
            dbDiagramT.Diagram = dbDiagramT.Diagram;
            dbDiagram.Diagram = dbDiagram.Diagram;
            NewDiagramFirst();
            NewDiagramSecond();
            NewDiagramThird();
            if (diagrams.Count < 20) //если сохранено действий меньше 20, то просто сохраняем очередное
            {
                //AddInHistory();
                SaveHistory();
            }
        }

        private void NewDiagramFirst()
        {
            
            SolidFigure.defaultSize = 70;
            SolidFigure figure = null;
            Block figureSt = null;
            Block figureEnd = null;
            List<Block> blocks = new List<Block>();
            for (int i = 0; i < 2; i++)
            {
                figure = new EllipseFigure();
                int defaultSize = SolidFigure.defaultSize;
                figure.location = new Point(defaultSize + 20, 50 + (defaultSize + 10) * i);
                if (i == 0)
                {
                    figure.text = "НАЧАЛО";
                    figureSt = new EllipseBlock(null, figure);
                }
                else
                {
                    figure.text = "КОНЕЦ";
                    figureEnd = new EllipseBlock(null, figure);
                }
                dbDiagram.Diagram.figures.Add(figure);
            }
            figureSt.nextBlock = figureEnd;
            blockFirst = figureSt;
            LedgeLineFigure line = new LedgeLineFigure();
            line.From = dbDiagram.Diagram.figures[0] as SolidFigure;
            line.To = dbDiagram.Diagram.figures[1] as SolidFigure;
            dbDiagram.Diagram.figures.Add(line);
        }

        private void NewDiagramSecond()
        {

            SolidFigure.defaultSize = 70;
            SolidFigure figure = null;
            Block figureSt = null;
            Block figureEnd = null;
            List<Block> blocks = new List<Block>();
            for (int i = 0; i < 2; i++)
            {
                figure = new EllipseFigure();
                int defaultSize = SolidFigure.defaultSize;
                figure.location = new Point(defaultSize + 20, 50 + (defaultSize + 10) * i);
                if (i == 0)
                {
                    figure.text = "НАЧАЛО";
                    figureSt = new EllipseBlock(null, figure);
                }
                else
                {
                    figure.text = "КОНЕЦ";
                    figureEnd = new EllipseBlock(null, figure);
                }
                dbDiagramS.Diagram.figures.Add(figure);
            }
            figureSt.nextBlock = figureEnd;
            blockSecond = figureSt;
            LedgeLineFigure line = new LedgeLineFigure();
            line.From = dbDiagramS.Diagram.figures[0] as SolidFigure;
            line.To = dbDiagramS.Diagram.figures[1] as SolidFigure;
            dbDiagramS.Diagram.figures.Add(line);
        }

        private void NewDiagramThird()
        {

            SolidFigure.defaultSize = 70;
            SolidFigure figure = null;
            Block figureSt = null;
            Block figureEnd = null;
            List<Block> blocks = new List<Block>();
            for (int i = 0; i < 2; i++)
            {
                figure = new EllipseFigure();
                int defaultSize = SolidFigure.defaultSize;
                figure.location = new Point(defaultSize + 20, 50 + (defaultSize + 10) * i);
                if (i == 0)
                {
                    figure.text = "НАЧАЛО";
                    figureSt = new EllipseBlock(null, figure);
                }
                else
                {
                    figure.text = "КОНЕЦ";
                    figureEnd = new EllipseBlock(null, figure);
                }
                dbDiagramT.Diagram.figures.Add(figure);
            }
            figureSt.nextBlock = figureEnd;
            blockThird = figureSt;
            LedgeLineFigure line = new LedgeLineFigure();
            line.From = dbDiagramT.Diagram.figures[0] as SolidFigure;
            line.To = dbDiagramT.Diagram.figures[1] as SolidFigure;
            dbDiagramT.Diagram.figures.Add(line);
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (sfdDiagram.ShowDialog() == DialogResult.OK)
                dbDiagram.Diagram.Save(sfdDiagram.FileName);
        }

        private void miLoad_Click(object sender, EventArgs e)
        {
            if (ofdDiagram.ShowDialog() == DialogResult.OK)
                dbDiagram.Diagram = Diagram.Load(ofdDiagram.FileName);
        }

        private void miExport_Click(object sender, EventArgs e)
        {
            if (sfdImage.ShowDialog() == DialogResult.OK)
            {

                using (Bitmap bmp = new Bitmap(dbDiagram.GetImage().Width+ dbDiagramS.GetImage().Width+ dbDiagramT.GetImage().Width,
                    dbDiagram.GetImage().Height))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        using (Image img1 = dbDiagram.GetImage())
                            g.DrawImage(img1, new Point(0, 0));

                        using (Image img2 = dbDiagramS.GetImage())
                            g.DrawImage(img2, new Point(dbDiagram.GetImage().Width));

                        using (Image img3 = dbDiagramT.GetImage())
                            g.DrawImage(img3, new Point(dbDiagram.GetImage().Width+dbDiagramS.Width));
                    }
                    bmp.Save(sfdImage.FileName);
                }
            }
        }

        private void dbDiagram_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dbDiagram.SelectedBeginEditText(this, blockFirst);
            /*EditBlock editBlock = new EditBlock(blocks);
            editBlock.Owner = this; //Передаём вновь созданной форме её владельца.
            editBlock.Show();*/
        }
        private void dbDiagramS_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dbDiagramS.SelectedBeginEditText(this, blockFirst);
            /*EditBlock editBlock = new EditBlock(blocks);
            editBlock.Owner = this; //Передаём вновь созданной форме её владельца.
            editBlock.Show();*/
        }

        private void dbDiagramT_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dbDiagramT.SelectedBeginEditText(this, blockFirst);
            /*EditBlock editBlock = new EditBlock(blocks);
            editBlock.Owner = this; //Передаём вновь созданной форме её владельца.
            editBlock.Show();*/
        }


        Point startDragPoint;

        private void miAddRect_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<RectFigure>(startDragPoint);
        }

        private void addRoundRectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<RoundRectFigure>(startDragPoint);
        }

        private void addRhombToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<RhombFigure>(startDragPoint);
        }

        private void addParalelogrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<ParalelogrammFigure>(startDragPoint);
        }

        private void addEllipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<EllipseFigure>(startDragPoint);
        }

        private void addStackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<StackFigure>(startDragPoint);
        }

        private void addFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<FrameFigure>(startDragPoint);
        }

        private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedBringToFront();
        }

        private void miAddLedgeLine_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedAddLedgeLine();
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedDelete();
            SaveHistory();
        }

        private void miAddLine_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedAddLine();
        }

        private void editTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedBeginEditText(this, blockFirst);
        }

        private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedSendToBack();
        }

        /*private void dbDiagram_MouseUp(object sender, MouseEventArgs e)
        {
            startDragPoint = e.Location;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (dbDiagram.SelectedFigure == null)
                    cmMain.Show(dbDiagram.PointToScreen(e.Location));
                else
                    cmSelectedFigure.Show(dbDiagram.PointToScreen(e.Location));
            }
        }*/

        private void dbDiagram_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                dbDiagram.SelectedDelete();
                SaveHistory();
            }
        }
        private void dbDiagramS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                dbDiagramS.SelectedDelete();
            }
        }
        private void btm1_Click(object sender, EventArgs e)
        {
            dbDiagram.CreateMarkers(3, blockFirst);
            dbDiagram.Invalidate();
            dbDiagramS.CreateMarkers(3, blockSecond);
            dbDiagramS.Invalidate();
            dbDiagramT.CreateMarkers(3, blockThird);
            dbDiagramT.Invalidate();
        }

        private void btm2_Click(object sender, EventArgs e)
        {
            dbDiagram.CreateMarkers(4, blockFirst);
            dbDiagram.Invalidate();
            dbDiagramS.CreateMarkers(4, blockSecond);
            dbDiagramS.Invalidate();
            dbDiagramT.CreateMarkers(4, blockThird);
            dbDiagramT.Invalidate();


        }

        private void прямоугольникСРамкойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<RectFigureFrame>(startDragPoint);
        }

        private void шестиугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.AddFigure<SexangleFigure>(startDragPoint);
        }

        private void btm5_Click(object sender, EventArgs e)
        {
            dbDiagram.CreateMarkers(1, blockFirst);
            dbDiagram.Invalidate();
            dbDiagramS.CreateMarkers(1, blockSecond);
            dbDiagramS.Invalidate();
            dbDiagramT.CreateMarkers(1, blockThird);
            dbDiagramT.Invalidate();

        }

        private void двойнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbDiagram.SelectedAddDoubleLedgeLine();
        }

        private void btm3_Click(object sender, EventArgs e)
        {
            dbDiagram.CreateMarkers(5, blockFirst);
            dbDiagram.Invalidate();
            dbDiagramS.CreateMarkers(5, blockSecond);
            dbDiagramS.Invalidate();
            dbDiagramT.CreateMarkers(5, blockThird);
            dbDiagramT.Invalidate();

        }

        private void btm4_Click(object sender, EventArgs e)
        {
            dbDiagram.CreateMarkers(6, blockFirst);
            dbDiagram.Invalidate();
            dbDiagramS.CreateMarkers(6, blockSecond);
            dbDiagramS.Invalidate();
            dbDiagramT.CreateMarkers(6, blockThird);
            dbDiagramT.Invalidate();

        }

        private void btm6_Click(object sender, EventArgs e)
        {
            dbDiagram.CreateMarkers(7, blockFirst);
            dbDiagram.Invalidate();
            dbDiagramS.CreateMarkers(7, blockSecond);
            dbDiagramS.Invalidate();
            dbDiagramT.CreateMarkers(7, blockThird);
            dbDiagramT.Invalidate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbDiagram.CreateMarkers(8, blockFirst);
            dbDiagram.Invalidate();
            dbDiagramS.CreateMarkers(8, blockSecond);
            dbDiagramS.Invalidate();
            dbDiagramT.CreateMarkers(8, blockThird);
            dbDiagramT.Invalidate();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //SolidFigure.defaultSize = trackBar1.Value;
            //ChangeSize();
        }

        private void AlgForm_Load(object sender, EventArgs e)
        {
            //SolidFigure.defaultSize = trackBar1.Value;
            //dbDiagram.Invalidate();
        }
        /*private void ChangeSize()
        {
            //dbDiagram.zoom = trackBar1.Value / 100.0f;
            SolidFigure.defaultSize = (int)(dbDiagram.Diagram.figures[0].defaultS.Width / 2 * trackBar1.Value / 100.0f);
            //List<int> list = new List<int>();
            //list = NumDouble();
            float value = SolidFigure.defaultSize + 10;
            float delta = trackBar1.Value / 100.0f;
            //проходимся по всем фигурам и меняем их масштаб
            for (int i = 0; i < dbDiagram.Diagram.figures.Count; i++)
            {
                switch (dbDiagram.Diagram.figures[i].type)
                {
                    case 2: case 3: case 4: case 5: case 6: case 7: case 8:
                        (dbDiagram.Diagram.figures[i] as SolidFigure).Size = new SizeF(dbDiagram.Diagram.figures[i].defaultS.Width * delta, dbDiagram.Diagram.figures[i].defaultS.Height * delta);
                        break;
                }
                
                dbDiagram.Invalidate();
            }
            //Проходимся по всем линиям и меняем координаты по у тех фигур, размер которых изменился
            List<LedgeLineFigure> lines = ListOfLines();
            List<Distance> list = NumDouble(lines);

            for (int i = 0; i < lines.Count; i++)
            {
                float d = 0;
                if (lines[i].To.location.Y > lines[i].From.location.Y)
                {
                    value = (SolidFigure.defaultSize + 10) * list[i].dist;
                    d = lines[i].From.location.Y + value - lines[i].To.location.Y;
                    lines[i].To.location.Y = lines[i].From.location.Y + value;
                    
                }
                if (lines[i].To.plus != null || lines[i].To.minus != null)
                {
                    lines[i].To.plus.location.Y += d;
                    lines[i].To.minus.location.Y += d;
                }
                if (lines[i].type == 10)
                        (lines[i] as DoubleLedgeLineFigure).ledgePositionY = lines[i].From.location.Y + SolidFigure.defaultSize / 2;
                    if (lines[i].type == 11)
                        (lines[i] as DoubleLedgeLineFigure).ledgePositionY = lines[i].To.location.Y - SolidFigure.defaultSize + SolidFigure.defaultSize / 2.2f;
                    if (lines[i].type == 11)
                        (lines[i] as DoubleLedgeLineFigureS).CreateArrow();
                    else
                        lines[i].CreateArrows();
                
                dbDiagram.Invalidate();
            }
            dbDiagram.CalcAutoScrollPosition();
        }*/

        //метод для составления списка всех линий и их сортировки
        public List<LedgeLineFigure> ListOfLines()
        {
            List<LedgeLineFigure> list = new List<LedgeLineFigure>();
            for (int i = 0; i < dbDiagram.Diagram.figures.Count; i++)
            {
                switch (dbDiagram.Diagram.figures[i].type) 
                {
                    case 1: case 10: case 11:
                        list.Add(dbDiagram.Diagram.figures[i] as LedgeLineFigure);
                        break;
                }
            }
            list.Sort((a,b) => a.From.location.Y.CompareTo(b.From.location.Y));
            return list;
        }


        private float MinDist(List<LedgeLineFigure> lines)
        {
            float d = float.MaxValue;
            for (int i = 0; i < lines.Count; i++)
            {
                        if (lines[i].To.location.Y - lines[i].From.location.Y > 0 &&
                            lines[i].To.location.Y - lines[i].From.location.Y < d)
                            d = lines[i].To.location.Y - lines[i].From.location.Y;
            }
            return d;
        }
        private List<Distance> NumDouble(List<LedgeLineFigure> lines)
        {
            float oneD = MinDist(lines);
            List <Distance> list = new List<Distance>();
            for (int i = 0; i < lines.Count; i++)
            {
                Distance dist = new Distance(i, (int)(Math.Abs(lines[i].To.location.Y - lines[i].From.location.Y) / oneD));
                list.Add(dist);
            }
            return list;
        }
        private void MoveY()
        {

        }

        private void ChangePosition(float ds)
        {
            
        }

        private void нарисоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawIt draw = new DrawIt();
            draw.Draw(blockFirst, blockSecond, blockThird, drawForm.numOfCellsX, drawForm.numOfCellsY, drawForm, this);
        }
        public void Repaint(Point location)
        {
            DrawIt draw = new DrawIt();
            draw.DrawAgain(coordList, location);
        }

        private void открытьЗаданиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawForm.OpenTask();
        }

        private void сохранитьАлгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = directory;
            saveFileDialog.Filter = "drawer algorithm files (*.draweralgorithm)|*.draweralgorithm|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                ForSave forsave = new ForSave(blockFirst, blockSecond, blockThird, dbDiagram.Diagram.figures, dbDiagramS.Diagram.figures, dbDiagramT.Diagram.figures);
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                    new BinaryFormatter().Serialize(fs, forsave);
            }
        }

        private void открытьАлгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = directory;
            openFileDialog.Filter = "drawer algorithm files (*.draweralgorithm)|*.draweralgorithm|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                dbDiagram.Diagram.figures.Clear();
                dbDiagramS.Diagram.figures.Clear();
                dbDiagramT.Diagram.figures.Clear();
                ForSave forsave = LoadFile(filename);
                blockFirst = forsave.blockFirst; 
                blockSecond = forsave.blockSecond;
                blockThird = forsave.blockThird;
                dbDiagram.blocks = blockFirst;
                dbDiagramS.blocks = blockSecond;
                dbDiagramT.blocks = blockThird;
                dbDiagram.Diagram.figures = forsave.figuresFirst;
                dbDiagramS.Diagram.figures = forsave.figuresSecond;
                dbDiagramT.Diagram.figures = forsave.figuresThird;
                dbDiagramS.Invalidate();
                dbDiagram.Invalidate();
                dbDiagramT.Invalidate();
            }
        }

        private ForSave LoadFile(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
                return (ForSave)new BinaryFormatter().Deserialize(fs);
        }

        private InfoForSave LoadFile()
        {
            try
            {
                using (FileStream fs = new FileStream(Environment.CurrentDirectory + @"\history.bin", FileMode.Open))
                    return (InfoForSave)new BinaryFormatter().Deserialize(fs);
            }
            catch
            {
                return null;
            }
        }

        private ForSaveProcedure LoadFileP(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
                return (ForSaveProcedure)new BinaryFormatter().Deserialize(fs);
        }

        private void dbDiagramS_DoubleClick(object sender, EventArgs e)
        {
            dbDiagramS.SelectedBeginEditText(this, blockSecond);
        }

        private void dbDiagramT_DoubleClick(object sender, EventArgs e)
        {
            dbDiagramT.SelectedBeginEditText(this, blockThird);
        }

        private void dbDiagramS_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                dbDiagramS.SelectedDelete();
                SaveHistory();
            }
        }

        private void dbDiagramT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                dbDiagramT.SelectedDelete();
                SaveHistory();

            }
        }

        private void dbDiagram_MouseClick(object sender, MouseEventArgs e)
        {
            dbDiagramS.SelectedFigure = null;
            dbDiagramS.markers.Clear();
            dbDiagramT.SelectedFigure = null;
            dbDiagramT.markers.Clear();
            //AddInHistory();
            SaveHistory();

        }
        private void dbDiagramS_MouseClick(object sender, MouseEventArgs e)
        {
            dbDiagram.SelectedFigure = null;
            dbDiagram.markers.Clear();
            dbDiagramT.SelectedFigure = null;
            dbDiagramT.markers.Clear();
            //AddInHistory();
            SaveHistory();

        }
        private void dbDiagramT_MouseClick(object sender, MouseEventArgs e)
        {
            dbDiagramS.SelectedFigure = null;
            dbDiagramS.markers.Clear();
            dbDiagram.SelectedFigure = null;
            dbDiagram.markers.Clear();
            //AddInHistory();
            SaveHistory();
        }

        private void сохранитьПодпрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.Filter = "drawer algorithm files (*.drawerprocedure)|*.drawerprocedure|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog.FileName;
                ForSaveProcedure forsave = new ForSaveProcedure(blockFirst, dbDiagram.Diagram.figures);
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                    new BinaryFormatter().Serialize(fs, forsave);
            }
        }

        private bool Different(InfoForSave fs)
        {
            //если добавились какие-либо фигуры
            if (fs.figuresForSave[currentIdx].figureFirst.Count != dbDiagram.Diagram.figures.Count ||
                fs.figuresForSave[currentIdx].figureSecond.Count != dbDiagramS.Diagram.figures.Count ||
                fs.figuresForSave[currentIdx].figureThird.Count != dbDiagramT.Diagram.figures.Count)
                return true;
            //посмотрим, изменились ли фигуры и их надписи
            for (int i = 0; i < fs.figuresForSave[currentIdx].figureFirst.Count; i++)
            {
                if (fs.figuresForSave[currentIdx].figureFirst[i] is SolidFigure && (fs.figuresForSave[currentIdx].figureFirst[i] as SolidFigure).text != (dbDiagram.Diagram.figures[i] as SolidFigure).text)
                    return true;
            }
            for (int i = 0; i < fs.figuresForSave[currentIdx].figureSecond.Count; i++)
            {
                if (fs.figuresForSave[currentIdx].figureSecond[i] is SolidFigure && (fs.figuresForSave[currentIdx].figureSecond[i] as SolidFigure).text != (dbDiagramS.Diagram.figures[i] as SolidFigure).text)
                    return true;
            }
            for (int i = 0; i < fs.figuresForSave[currentIdx].figureThird.Count; i++)
            {
                if (fs.figuresForSave[currentIdx].figureThird[i] is SolidFigure && (fs.figuresForSave[currentIdx].figureThird[i] as SolidFigure).text != (dbDiagramT.Diagram.figures[i] as SolidFigure).text)
                    return true;
            }

            return false;
        }

        private void SaveHistory()
        {
            InfoForSave forsave = LoadFile();
            //если что-то поменялось - добавляем в историю
            Figure figure1 = dbDiagram.selectedFigure;
            Figure figure2 = dbDiagramS.selectedFigure;
            Figure figure3 = dbDiagramT.selectedFigure;
            dbDiagram.selectedFigure = null;
            dbDiagramS.selectedFigure = null;
            dbDiagramT.selectedFigure = null;

            if (forsave != null && forsave.blocksForSave.Count != 0 && Different(forsave))
            {
                if (currentIdx == forsave.figuresForSave.Count() - 1)
                {
                    forsave.figuresForSave.Add(new FiguresForSave(dbDiagram.Diagram.figures, dbDiagramS.Diagram.figures, dbDiagramT.Diagram.figures));
                    forsave.blocksForSave.Add(new BlocksForSave(blockFirst, blockSecond, blockThird));
                    using (FileStream fs = new FileStream("history.bin", FileMode.Open))
                        new BinaryFormatter().Serialize(fs, forsave);
                    currentIdx += 1;
                }
                else
                {
                    forsave.blocksForSave.RemoveRange(currentIdx + 1, forsave.blocksForSave.Count - currentIdx - 1);
                    forsave.figuresForSave.RemoveRange(currentIdx + 1, forsave.figuresForSave.Count - currentIdx - 1);
                    forsave.figuresForSave.Add(new FiguresForSave(dbDiagram.Diagram.figures, dbDiagramS.Diagram.figures, dbDiagramT.Diagram.figures));
                    forsave.blocksForSave.Add(new BlocksForSave(blockFirst, blockSecond, blockThird));
                    using (FileStream fs = new FileStream("history.bin", FileMode.Open))
                        new BinaryFormatter().Serialize(fs, forsave);
                    currentIdx += 1;
                }
            }
            if (forsave == null)
            {
                forsave = new InfoForSave(new List<FiguresForSave>(), new List<BlocksForSave>());
                forsave.figuresForSave.Add(new FiguresForSave(dbDiagram.Diagram.figures, dbDiagramS.Diagram.figures, dbDiagramT.Diagram.figures));
                forsave.blocksForSave.Add(new BlocksForSave(blockFirst, blockSecond, blockThird));
                using (FileStream fs = new FileStream("history.bin", FileMode.Open))
                    new BinaryFormatter().Serialize(fs, forsave);
                currentIdx += 1;
            }

            dbDiagram.selectedFigure = figure1;
            dbDiagramS.selectedFigure = figure2;
            dbDiagramT.selectedFigure = figure3;
        }

        private void ReturnHistory()
        {
            InfoForSave forsave = LoadFile();
            blocks = forsave.blocksForSave;
            diagrams = forsave.figuresForSave;
        }

        private void открытьПодпрограммуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Filter = "drawer algorithm files (*.drawerprocedure)|*.drawerprocedure|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                dbDiagram.Diagram.figures.Clear();
                dbDiagramS.Diagram.figures.Clear();
                dbDiagramT.Diagram.figures.Clear();
                NewDiagramSecond();
                NewDiagramThird();
                ForSaveProcedure forsave = LoadFileP(filename);
                blockFirst = forsave.block;
                dbDiagram.blocks = blockFirst;
                dbDiagram.Diagram.figures = forsave.figures;
                dbDiagramS.Invalidate();
                dbDiagram.Invalidate();
                dbDiagramT.Invalidate();
            }
        }

        private void Cancel()
        {
            if (currentIdx > 0)
            {
                dbDiagram.selectedFigure = null;
                dbDiagramS.selectedFigure = null;
                dbDiagramT.selectedFigure = null;
                currentIdx -= 1;
                ReturnHistory();
                dbDiagram.Diagram.figures.Clear();
                dbDiagramS.Diagram.figures.Clear();
                dbDiagramT.Diagram.figures.Clear();
                dbDiagram.Diagram.figures = diagrams[currentIdx].figureFirst;
                dbDiagram.Invalidate();
                dbDiagramS.Diagram.figures = diagrams[currentIdx].figureSecond;
                dbDiagramS.Invalidate();
                dbDiagramT.Diagram.figures = diagrams[currentIdx].figureThird;
                dbDiagramT.Invalidate();
                blockFirst = blocks[currentIdx].blockFirst;
                blockSecond = blocks[currentIdx].blockSecond;
                blockThird = blocks[currentIdx].blockThird;
                dbDiagram.blocks = blockFirst;
                dbDiagramS.blocks = blockSecond;
                dbDiagramT.blocks = blockThird;
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void одинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            дваToolStripMenuItem.Checked = false;
            триToolStripMenuItem.Checked = false;
            groupBox1.Width = this.Width - flowLayoutPanel1.Width - 50;
            groupBox2.Width = 10;
            groupBox2.Visible = false;
            groupBox3.Width = 10;
            groupBox3.Visible = false;
            splitter2.Visible = false;
            splitter3.Visible = false;
        }

        private void дваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            одинToolStripMenuItem.Checked = false;
            триToolStripMenuItem.Checked = false;
            groupBox2.Visible = true;
            groupBox3.Width = 10;
            groupBox3.Visible = false;
            splitter2.Visible = true;
            splitter3.Visible = false;
            groupBox1.Width = (this.Width - flowLayoutPanel1.Width - 50)/2;
            groupBox2.Width = (this.Width - flowLayoutPanel1.Width - 50) / 2;

        }

        private void триToolStripMenuItem_Click(object sender, EventArgs e)
        {
            одинToolStripMenuItem.Checked = false;
            дваToolStripMenuItem.Checked = false;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
            splitter2.Visible = true;
            splitter3.Visible = true;
            groupBox1.Width = (this.Width - flowLayoutPanel1.Width - 50) / 3;
            groupBox2.Width = (this.Width - flowLayoutPanel1.Width - 50) / 3;
            groupBox3.Width = (this.Width - flowLayoutPanel1.Width - 50) / 3;
        }

        private void AlgForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists("history.bin"))
            {
                File.Delete("history.bin");
            }
        }

        private void повторитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return();
        }

        private void Return()
        {
            ReturnHistory();
            if (currentIdx < diagrams.Count() - 1)
            {
                dbDiagram.selectedFigure = null;
                dbDiagramS.selectedFigure = null;
                dbDiagramT.selectedFigure = null;
                currentIdx += 1;
                dbDiagram.Diagram.figures.Clear();
                dbDiagramS.Diagram.figures.Clear();
                dbDiagramT.Diagram.figures.Clear();
                dbDiagram.Diagram.figures = diagrams[currentIdx].figureFirst;
                dbDiagram.Invalidate();
                dbDiagramS.Diagram.figures = diagrams[currentIdx].figureSecond;
                dbDiagramS.Invalidate();
                dbDiagramT.Diagram.figures = diagrams[currentIdx].figureThird;
                dbDiagramT.Invalidate();
                blockFirst = blocks[currentIdx].blockFirst;
                blockSecond = blocks[currentIdx].blockSecond;
                blockThird = blocks[currentIdx].blockThird;
                dbDiagram.blocks = blockFirst;
                dbDiagramS.blocks = blockSecond;
                dbDiagramT.blocks = blockThird;
            }
        }

        private void AlgForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Alt && e.KeyCode == Keys.Z)
            {
                Cancel();
            }
            if (e.KeyCode == Keys.Alt && e.KeyCode == Keys.X)
            {
                Return();
            }
        }
    }

    [Serializable]
    public class ForSave 
    {
        public Block blockFirst;
        public Block blockSecond;
        public Block blockThird;
        public List<Figure> figuresFirst;
        public List<Figure> figuresSecond;
        public List<Figure> figuresThird;

        public ForSave(Block blockFirst, Block blockSecond, Block blockThird, List<Figure> figuresFirst, List<Figure> figuresSecond, List<Figure> figuresThird)
        {
            this.blockFirst = blockFirst;
            this.blockSecond = blockSecond;
            this.blockThird = blockThird;
            this.figuresFirst = figuresFirst;
            this.figuresSecond = figuresSecond;
            this.figuresThird = figuresThird;
        }
    }

    [Serializable]
    public class ForSaveProcedure
    {
        public Block block;
        public List<Figure> figures;
        public ForSaveProcedure(Block block, List<Figure> figures)
        {
            this.block = block;
            this.figures = figures;
        }
    }
    [Serializable]

    public class FiguresForSave
    {
        public List<Figure> figureFirst;
        public List<Figure> figureSecond;
        public List<Figure> figureThird;

        public FiguresForSave(List<Figure> figureFirts, List<Figure> figureSecond, List<Figure> figureThird)
        {
            this.figureFirst = figureFirts;
            this.figureSecond = figureSecond;
            this.figureThird = figureThird;

        }
        public FiguresForSave()
        {
            figureFirst= new List<Figure>();
            figureSecond= new List<Figure>();
            figureThird= new List<Figure>();
        }
    }
    [Serializable]

    public class BlocksForSave
    {
        public Block blockFirst;
        public Block blockSecond;
        public Block blockThird;
        public BlocksForSave(Block blockFirst, Block blockSecond, Block blockThird)
        {
            this.blockFirst = blockFirst;
            this.blockSecond = blockSecond;
            this.blockThird = blockThird;
        }
    }

    [Serializable]
    public class InfoForSave
    {
        public List<FiguresForSave> figuresForSave;
        public List<BlocksForSave> blocksForSave;

        public InfoForSave(List<FiguresForSave> figuresForSaves, List<BlocksForSave> blocksForSaves)
        {
            blocksForSave = blocksForSaves;
            figuresForSave= figuresForSaves;
        }
    }

}
