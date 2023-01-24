using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Diagrams
{
    public class Coord
    {
        public Point p1;
        public Point p2;
        public Coord(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
    }
    internal class DrawIt
    {
        Point location = new Point(0, 0); //положение нашего чертёжника
        List<Coord> coordList = new List<Coord>(); //линии, которые отображены на рисунке
        Point field;
        DrawForm form;
        AlgForm parentForm;
        Graphics graph;
        bool draw;
        List<Block> firstDrawer = new List<Block>();
        int speed = 300;
        Block block;
        Pen pen;
        int cellSize;
        public void Draw(Block block, int numX, int numY, DrawForm drawForm, AlgForm parentForm)
        {
            form = drawForm;
            speed = drawForm.tbSpeed.Value;
            form.draw = false;
            form.pbDraw.Refresh();
            field = new Point(numX, numY); //размер поля
            draw = true;
            pen = new Pen(Color.CornflowerBlue, 2);
            graph = form.pbDraw.CreateGraphics();
            form.pencil1.Location = form.startPosition;
            RefreshField();
            Thread.Sleep(speed);
            this.block = block;
            this.parentForm = parentForm;
            cellSize = form.trackBarSize.Value;
            form.coordList.Clear();
            drawPic(block);
            moveBlock();
            Replace();
            form.g = graph;
            form.draw =  true;
            parentForm.dbDiagram.drawFigure = null;
            parentForm.dbDiagram.Refresh();
        }
        private Block drawPic(Block block)
        {

            if (block is EllipseBlock)
                firstDrawer.Add(block);

            if (block == null)
                return null;
            if (block is ActionBlock) //если действие
            {
                firstDrawer.Add(block);
                //drawAction(block);
                return drawPic(block.nextBlock);
            }
            if (block is WhileBlock)
            {
                switch ((block as WhileBlock).condition)
                {
                    case 1: while (field.X - location.X >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); drawPic((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 2: while (location.X >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); drawPic((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 3: while (field.Y - location.Y >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); drawPic((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 4: while (location.Y >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); drawPic((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 5: while (field.X - location.X >= (block as WhileBlock).num_cond && location.Y >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); drawPic((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 6: while (field.X - location.X >= (block as WhileBlock).num_cond && field.Y - location.Y >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); drawPic((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 7: while (location.X >= (block as WhileBlock).num_cond && location.Y >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); drawPic((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 8: while (location.X >= (block as WhileBlock).num_cond && (field.Y - location.Y >= (block as WhileBlock).num_cond)) { firstDrawer.Add(block); drawPic((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                }
            }
            if (block is ForBlock)
            {
                for (int i = 0; i < (block as ForBlock).numOfRep; i++)
                {
                    firstDrawer.Add(block);
                    drawPic((block as ForBlock).trueBlock);
                }
                firstDrawer.Add(block);
            }
            return drawPic(block.nextBlock);
        }

        /*          case 0: figure.text = "→ " + nudConditions.Value.ToString(); break;
                    case 1: figure.text = "← " + nudConditions.Value.ToString(); break;
                    case 2: figure.text = "↑ " + nudConditions.Value.ToString(); break;
                    case 3: figure.text = "↓ " + nudConditions.Value.ToString(); break;
                    case 4: figure.text = "↘ " + nudConditions.Value.ToString(); break;
                    case 5: figure.text = "↗ " + nudConditions.Value.ToString(); break;
                    case 6: figure.text = "↙ " + nudConditions.Value.ToString(); break;
                    case 7: figure.text = "↖ " + nudConditions.Value.ToString(); break;*/
        
        private void moveBlock()
        {
            //здесь посмотреть, у кого из исполнителей блоков больше
            for (int i = 0; i < firstDrawer.Count(); i++)
            {
                parentForm.dbDiagram.drawFigure = firstDrawer[i].figure;
                parentForm.dbDiagram.Refresh();
                if (firstDrawer[i] is ActionBlock)
                {
                    drawAction(firstDrawer[i]);
                }
                Thread.Sleep(speed);
            }
        }

        private void drawAction(Block block)
        {
            Point n_loc = new Point(-1, -1);
            switch ((block as ActionBlock).action)
            {
                case 1: n_loc = new Point(0, 0); break;
                case 2: n_loc = new Point(location.X + 1, location.Y); break;
                case 3: n_loc = new Point(location.X - 1, location.Y); break;
                case 4: n_loc = new Point(location.X, location.Y + 1); break;
                case 5: n_loc = new Point(location.X, location.Y - 1); break;
                case 6: n_loc = new Point(location.X + 1, location.Y + 1); break;
                case 7: n_loc = new Point(location.X + 1, location.Y - 1); break;
                case 8: n_loc = new Point(location.X - 1, location.Y + 1); break;
                case 9: n_loc = new Point(location.X - 1, location.Y - 1); break;
                case 10: n_loc = new Point(location.X + 1, location.Y); break;
                case 11: n_loc = new Point(location.X - 1, location.Y); break;
                case 12: n_loc = new Point(location.X, location.Y + 1); break;
                case 13: n_loc = new Point(location.X, location.Y - 1); break;
                case 14: n_loc = new Point(location.X + 1, location.Y + 1); break;
                case 15: n_loc = new Point(location.X + 1, location.Y - 1); break;
                case 16: n_loc = new Point(location.X - 1, location.Y + 1); break;
                case 17: n_loc = new Point(location.X - 1, location.Y - 1); break;

            }
            if (n_loc.X >= 0 && n_loc.X <= form.numOfCellsX && n_loc.Y >= 0 && n_loc.Y <= form.numOfCellsY)
            {
                Point d = new Point(n_loc.X - location.X, n_loc.Y - location.Y);
                if (0 < (block as ActionBlock).action && (block as ActionBlock).action < 10)
                {
                    Point point1 = new Point((location.X * cellSize), ((-location.Y + field.Y) * cellSize));
                    Point point2 = new Point((n_loc.X * cellSize), ((-n_loc.Y + field.Y) * cellSize));
                    coordList.Add(new Coord(location, n_loc));
                    form.position = n_loc;
                    graph.DrawLine(pen, point1, point2);
                }
                form.pencil1.Location = new Point(form.pencil1.Location.X + d.X * cellSize, form.pencil1.Location.Y - d.Y * cellSize);
                form.pencil1.Update();
                RefreshField();
                location = n_loc;
                form.position = location;
                form.Invalidate();
                RefreshField();

            }
            else
            {
                MessageBox.Show("Чертёжник вышел за пределы поля", "Обнаружена ошибка", MessageBoxButtons.OK,
                                MessageBoxIcon.Error,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.ServiceNotification);
                return;
            }
        }
        public void RefreshField()
        {
            form.pbDraw.Refresh();
            for (int i = 0; i < coordList.Count(); i++)
            {
                graph.DrawLine(pen, new Point(coordList[i].p1.X * cellSize, (-coordList[i].p1.Y + field.Y) * cellSize), new Point(coordList[i].p2.X * cellSize, (-coordList[i].p2.Y + field.Y) * cellSize));
            }
        }
        public void DrawAgain(List<Coord> coord, Point pencilCoord)
        {
            form.pbDraw.Refresh();
            form.pencil1.Location = new Point(form.pbDraw.Location.X + 1 + cellSize * pencilCoord.X, form.pbDraw.Size.Height + form.pbDraw.Location.Y - 1 - form.pencil1.Height - cellSize * pencilCoord.Y);
            for (int i = 0; i < coord.Count(); i++)
            {
                graph.DrawLine(pen, new Point(coordList[i].p1.X * cellSize, (-coordList[i].p1.Y + field.Y) * cellSize), new Point(coordList[i].p2.X * cellSize, (-coordList[i].p2.Y + field.Y) * cellSize));
            }
        }
        public void Replace()
        {
            foreach (Coord coord in coordList)
            {
                form.coordList.Add(new Diagrams.Coordinate(coord.p1, coord.p2));
            }
        }
    }
}
