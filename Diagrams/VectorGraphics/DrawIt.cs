using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

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
        Point locationFirst = new Point(0, 0); //положение первого чертёжника
        Point locationSecond = new Point(0, 0); //положение второго чертёжника
        Point locationThird = new Point(0, 0); //положение третьего чертёжника
        List<Coord> coordList = new List<Coord>(); //линии, которые отображены на рисунке
        List<Coord> coordListSecond = new List<Coord>(); //линии, которые отображены на рисунке  (зелёные)
        List<Coord> coordListFirst = new List<Coord>(); //линии, которые отображены на рисунке  (синие)
        List<Coord> coordListThird = new List<Coord>(); //линии, которые отображены на рисунке (оранжевые)
        Point field;
        DrawForm form;
        AlgForm parentForm;
        Graphics graph;
        bool draw;
        List<Block> firstDrawer = new List<Block>();
        List<Block> secondDrawer = new List<Block>();
        List<Block> thirdDrawer = new List<Block>();
        int speed = 300;
        Block blockFirst;
        Block blockSecond;
        Block blockThird;
        Pen penFirst;
        Pen penSecond;
        Pen penThird;
        int cellSize;
        public void Draw(Block blockFirst, Block blockSecond, Block blockThird, int numX, int numY, DrawForm drawForm, AlgForm parentForm)
        {
            form = drawForm;
            speed = drawForm.tbSpeed.Value;
            form.draw = false;
            form.pbDraw.Refresh();
            field = new Point(numX, numY); //размер поля
            draw = true;
            penFirst = new Pen(Color.CornflowerBlue, 2);
            penSecond = new Pen(Color.ForestGreen, 2);
            penThird = new Pen(Color.Orange, 2);
            graph = form.pbDraw.CreateGraphics();
            //form.pencil1.Location = form.startPosition;
            //form.pencil1.Location = form.startPosition;
            form.positionFirst = new Point(0, 0);
            form.positionSecond = new Point(0, 0);
            form.positionThird = new Point(0, 0);
            RefreshField();
            //Thread.Sleep(speed);
            var t = Task.Run(async delegate
            {
                await Task.Delay(speed);
            });
            t.Wait();
            this.blockFirst = blockFirst;
            this.blockSecond = blockSecond;
            this.blockThird = blockThird;
            this.parentForm = parentForm;
            cellSize = form.trackBarSize.Value;
            form.coordListFirst.Clear();
            form.coordListSecond.Clear();
            form.coordListThird.Clear();
            try
            {
                DrawPicFirst(blockFirst);
                DrawPicSecond(blockSecond);
                DrawPicThird(blockThird);
                locationFirst = new Point(0, 0);
                locationSecond = new Point(0, 0);
                locationThird= new Point(0, 0);
                moveBlock();
                Replace();
                form.g = graph;
                form.draw = true;
                parentForm.dbDiagram.drawFigure = null;
                parentForm.dbDiagram.Refresh();
                parentForm.dbDiagramS.drawFigure = null;
                parentForm.dbDiagramS.Refresh();
                parentForm.dbDiagramT.drawFigure = null;
                parentForm.dbDiagramT.Refresh();
                checkTask();
            }
            catch (Exception e)
            {
                MessageBox.Show("Невозможно выполнение алгоритма!" + e.Message, "Ошибка!", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.ServiceNotification);
            }
        }

        private void checkTask()
        {
            List <Coord> missingCoords = new List<Coord>(); //список для недостающих координат
            List <Coord> extraCoords = new List<Coord>(); //список для лишних координат

            if (form.task)
            {
                for (int i = 0; i < coordList.Count(); i++)
                {
                    if (form.taskCoord.Find(x => x.p1 == coordList[i].p1 && x.p2 == coordList[i].p2 || x.p2 == coordList[i].p1 && x.p1 == coordList[i].p2) == null)
                    {
                        extraCoords.Add(coordList[i]);
                    }
                }
                for (int i = 0; i < form.taskCoord.Count(); i++)
                {
                    if (coordList.Find(x => x.p1 == form.taskCoord[i].p1 && x.p2 == form.taskCoord[i].p2 || x.p2 == form.taskCoord[i].p1 && x.p1 == form.taskCoord[i].p2) == null)
                    {
                        Coord b = new Coord(new Point(form.taskCoord[i].p1.X, form.taskCoord[i].p1.Y), new Point(form.taskCoord[i].p2.X, form.taskCoord[i].p2.Y));
                        missingCoords.Add(b);
                    }
                }
                if (missingCoords.Count() != 0 || extraCoords.Count() != 0)
                    MessageBox.Show("Задание было выполнено некорретно!", "Алгоритм выполнен", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.ServiceNotification);
                else
                    MessageBox.Show("Задание было выполнено успешно!", "Алгоритм выполнен", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information,
                                    MessageBoxDefaultButton.Button1,
                                    MessageBoxOptions.ServiceNotification);
            }
            
        }
        private Block DrawPicFirst(Block block)
        {
            if (block == null)
                return null;
            if (block.figure.text == null)
                throw new Exception("Был обнаружен пустой блок!");

            if (block is EllipseBlock)
                firstDrawer.Add(block);

            if (block is ActionBlock) //если действие
            {
                firstDrawer.Add(block);
                DoAction(block, locationFirst);
                return DrawPicFirst(block.nextBlock);
            }
            if (block is IfWithoutElseBlock)
            {
                firstDrawer.Add(block);
                switch ((block as IfWithoutElseBlock).condition)
                {
                    case 1: if (field.X - locationFirst.X >= (block as IfWithoutElseBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 2: if (locationFirst.X >= (block as IfWithoutElseBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 3: if (field.Y - locationFirst.Y >= (block as IfWithoutElseBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 4: if (locationFirst.Y >= (block as IfWithoutElseBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 5: if (field.X - locationFirst.X >= (block as IfWithoutElseBlock).num_cond && locationFirst.Y >= (block as IfWithoutElseBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 6: if (field.X - locationFirst.X >= (block as IfWithoutElseBlock).num_cond && field.Y - locationFirst.Y >= (block as IfWithoutElseBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 7: if (locationFirst.X >= (block as IfWithoutElseBlock).num_cond && locationFirst.Y >= (block as IfWithoutElseBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 8: if (locationFirst.X >= (block as IfWithoutElseBlock).num_cond && (field.Y - locationFirst.Y >= (block as IfWithoutElseBlock).num_cond)) { firstDrawer.Add(block); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } firstDrawer.Add(block); break;
                }
            }
            if (block is WhileBlock)
            {
                switch ((block as WhileBlock).condition)
                {
                    case 1: while (field.X - locationFirst.X >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 2: while (locationFirst.X >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 3: while (field.Y - locationFirst.Y >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 4: while (locationFirst.Y >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 5: while (field.X - locationFirst.X >= (block as WhileBlock).num_cond && locationFirst.Y >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 6: while (field.X - locationFirst.X >= (block as WhileBlock).num_cond && field.Y - locationFirst.Y >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 7: while (locationFirst.X >= (block as WhileBlock).num_cond && locationFirst.Y >= (block as WhileBlock).num_cond) { firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                    case 8: while (locationFirst.X >= (block as WhileBlock).num_cond && (field.Y - locationFirst.Y >= (block as WhileBlock).num_cond)) { firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstDrawer.Add(block); break;
                }
            }
            if (block is ForBlock)
            {
                for (int i = 0; i < (block as ForBlock).numOfRep; i++)
                {
                    firstDrawer.Add(block);
                    DrawPicFirst((block as ForBlock).trueBlock);
                }
                firstDrawer.Add(block);
            }
            return DrawPicFirst(block.nextBlock);
        }

        private Block DrawPicSecond(Block block)
        {
            if (block == null)
                return null;
            if (block.figure.text == null)
                throw new Exception("Был обнаружен пустой блок!");

            if (block is EllipseBlock)
                secondDrawer.Add(block);

            if (block is ActionBlock) //если действие
            {
                secondDrawer.Add(block);
                DoAction(block, locationSecond);
                return DrawPicSecond(block.nextBlock);
            }
            if (block is IfWithoutElseBlock)
            {
                secondDrawer.Add(block);
                switch ((block as IfWithoutElseBlock).condition)
                {
                    case 1: if (field.X - locationSecond.X >= (block as IfWithoutElseBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 2: if (locationSecond.X >= (block as IfWithoutElseBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 3: if (field.Y - locationSecond.Y >= (block as IfWithoutElseBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 4: if (locationSecond.Y >= (block as IfWithoutElseBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 5: if (field.X - locationSecond.X >= (block as IfWithoutElseBlock).num_cond && locationSecond.Y >= (block as IfWithoutElseBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 6: if (field.X - locationSecond.X >= (block as IfWithoutElseBlock).num_cond && field.Y - locationSecond.Y >= (block as IfWithoutElseBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 7: if (locationSecond.X >= (block as IfWithoutElseBlock).num_cond && locationSecond.Y >= (block as IfWithoutElseBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 8: if (locationSecond.X >= (block as IfWithoutElseBlock).num_cond && (field.Y - locationSecond.Y >= (block as IfWithoutElseBlock).num_cond)) { secondDrawer.Add(block); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } secondDrawer.Add(block); break;
                }
            }
            if (block is WhileBlock)
            {
                switch ((block as WhileBlock).condition)
                {
                    case 1: while (field.X - locationSecond.X >= (block as WhileBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 2: while (locationSecond.X >= (block as WhileBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 3: while (field.Y - locationSecond.Y >= (block as WhileBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 4: while (locationSecond.Y >= (block as WhileBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 5: while (field.X - locationSecond.X >= (block as WhileBlock).num_cond && locationSecond.Y >= (block as WhileBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 6: while (field.X - locationSecond.X >= (block as WhileBlock).num_cond && field.Y - locationSecond.Y >= (block as WhileBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 7: while (locationSecond.X >= (block as WhileBlock).num_cond && locationSecond.Y >= (block as WhileBlock).num_cond) { secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondDrawer.Add(block); break;
                    case 8: while (locationSecond.X >= (block as WhileBlock).num_cond && (field.Y - locationSecond.Y >= (block as WhileBlock).num_cond)) { secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondDrawer.Add(block); break;
                }
            }
            if (block is ForBlock)
            {
                for (int i = 0; i < (block as ForBlock).numOfRep; i++)
                {
                    secondDrawer.Add(block);
                    DrawPicSecond((block as ForBlock).trueBlock);
                }
                secondDrawer.Add(block);
            }
            return DrawPicSecond(block.nextBlock);
        }

        private Block DrawPicThird(Block block)
        {
            if (block == null)
                return null;
            if (block.figure.text == null)
                throw new Exception("Был обнаружен пустой блок!");

            if (block is EllipseBlock)
                thirdDrawer.Add(block);

            if (block is ActionBlock) //если действие
            {
                thirdDrawer.Add(block);
                DoAction(block, locationThird);
                return DrawPicThird(block.nextBlock);
            }
            if (block is IfWithoutElseBlock)
            {
                thirdDrawer.Add(block);
                switch ((block as IfWithoutElseBlock).condition)
                {
                    case 1: if (field.X - locationThird.X >= (block as IfWithoutElseBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as IfWithoutElseBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 2: if (locationThird.X >= (block as IfWithoutElseBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as IfWithoutElseBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 3: if (field.Y - locationThird.Y >= (block as IfWithoutElseBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as IfWithoutElseBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 4: if (locationThird.Y >= (block as IfWithoutElseBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as IfWithoutElseBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 5: if (field.X - locationThird.X >= (block as IfWithoutElseBlock).num_cond && locationThird.Y >= (block as IfWithoutElseBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as IfWithoutElseBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 6: if (field.X - locationThird.X >= (block as IfWithoutElseBlock).num_cond && field.Y - locationThird.Y >= (block as IfWithoutElseBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as IfWithoutElseBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 7: if (locationThird.X >= (block as IfWithoutElseBlock).num_cond && locationThird.Y >= (block as IfWithoutElseBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as IfWithoutElseBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 8: if (locationThird.X >= (block as IfWithoutElseBlock).num_cond && (field.Y - locationThird.Y >= (block as IfWithoutElseBlock).num_cond)) { thirdDrawer.Add(block); DrawPicThird((block as IfWithoutElseBlock).trueBlock); } thirdDrawer.Add(block); break;
                }
            }
            if (block is WhileBlock)
            {
                switch ((block as WhileBlock).condition)
                {
                    case 1: while (field.X - locationThird.X >= (block as WhileBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 2: while (locationThird.X >= (block as WhileBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 3: while (field.Y - locationThird.Y >= (block as WhileBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 4: while (locationThird.Y >= (block as WhileBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 5: while (field.X - locationThird.X >= (block as WhileBlock).num_cond && locationThird.Y >= (block as WhileBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 6: while (field.X - locationThird.X >= (block as WhileBlock).num_cond && field.Y - locationThird.Y >= (block as WhileBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 7: while (locationThird.X >= (block as WhileBlock).num_cond && locationThird.Y >= (block as WhileBlock).num_cond) { thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdDrawer.Add(block); break;
                    case 8: while (locationThird.X >= (block as WhileBlock).num_cond && (field.Y - locationThird.Y >= (block as WhileBlock).num_cond)) { thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdDrawer.Add(block); break;
                }
            }
            if (block is ForBlock)
            {
                for (int i = 0; i < (block as ForBlock).numOfRep; i++)
                {
                    thirdDrawer.Add(block);
                    DrawPicThird((block as ForBlock).trueBlock);
                }
                thirdDrawer.Add(block);
            }
            return DrawPicThird(block.nextBlock);
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
            int n = new[] { firstDrawer.Count(), secondDrawer.Count(), thirdDrawer.Count() }.Max();
            for (int i = 0; i < n; i++)
            {
                if (firstDrawer.Count() > i)
                {
                    parentForm.dbDiagram.drawFigure = firstDrawer[i].figure;
                    parentForm.dbDiagram.Refresh();
                    if (firstDrawer[i] is ActionBlock)
                    {
                        DrawAction(firstDrawer[i], ref locationFirst, 0);
                    }
                }
                if (secondDrawer.Count() > i)
                {
                    parentForm.dbDiagramS.drawFigure = secondDrawer[i].figure;
                    parentForm.dbDiagramS.Refresh();
                    if (secondDrawer[i] is ActionBlock)
                    {
                        DrawAction(secondDrawer[i], ref locationSecond, 1);
                    }
                }
                if (thirdDrawer.Count() > i)
                {
                    parentForm.dbDiagramT.drawFigure = thirdDrawer[i].figure;
                    parentForm.dbDiagramT.Refresh();
                    if (thirdDrawer[i] is ActionBlock)
                    {
                        DrawAction(thirdDrawer[i], ref locationThird, 2);
                    }
                }
                var t = Task.Run(async delegate
                {
                    await Task.Delay(speed);
                });
                t.Wait();
            }
        }
        private void DoAction(Block b, Point loc)
        {
            Point n_loc = new Point(0, 0);
            switch ((b as ActionBlock).action)
            {
                case 0: break; //если пустой блок
                case 1: loc = new Point(0, 0); break;
                case 2: loc = new Point(loc.X + 1, loc.Y); break;
                case 3: loc = new Point(loc.X - 1, loc.Y); break;
                case 4: loc = new Point(loc.X, loc.Y + 1); break;
                case 5: loc = new Point(loc.X, loc.Y - 1); break;
                case 6: loc = new Point(loc.X + 1, loc.Y + 1); break;
                case 7: loc = new Point(loc.X + 1, loc.Y - 1); break;
                case 8: loc = new Point(loc.X - 1, loc.Y + 1); break;
                case 9: loc = new Point(loc.X - 1, loc.Y - 1); break;
                case 10: loc = new Point(loc.X + 1, loc.Y); break;
                case 11: loc = new Point(loc.X - 1, loc.Y); break;
                case 12: loc = new Point(loc.X, loc.Y + 1); break;
                case 13: loc = new Point(loc.X, loc.Y - 1); break;
                case 14: loc = new Point(loc.X + 1, loc.Y + 1); break;
                case 15: loc = new Point(loc.X + 1, loc.Y - 1); break;
                case 16: loc = new Point(loc.X - 1, loc.Y + 1); break;
                case 17: loc = new Point(loc.X - 1, loc.Y - 1); break;

            }
        }
        private void DrawAction(Block block, ref Point loc, byte num)
        {
            Point n_loc = new Point(0, 0);
            switch ((block as ActionBlock).action)
            {
                case 0: break; //если пустой блок
                case 1: n_loc = new Point(0, 0); break;
                case 2: n_loc = new Point(loc.X + 1, loc.Y); break;
                case 3: n_loc = new Point(loc.X - 1, loc.Y); break;
                case 4: n_loc = new Point(loc.X, loc.Y + 1); break;
                case 5: n_loc = new Point(loc.X, loc.Y - 1); break;
                case 6: n_loc = new Point(loc.X + 1, loc.Y + 1); break;
                case 7: n_loc = new Point(loc.X + 1, loc.Y - 1); break;
                case 8: n_loc = new Point(loc.X - 1, loc.Y + 1); break;
                case 9: n_loc = new Point(loc.X - 1, loc.Y - 1); break;
                case 10: n_loc = new Point(loc.X + 1, loc.Y); break;
                case 11: n_loc = new Point(loc.X - 1, loc.Y); break;
                case 12: n_loc = new Point(loc.X, loc.Y + 1); break;
                case 13: n_loc = new Point(loc.X, loc.Y - 1); break;
                case 14: n_loc = new Point(loc.X + 1, loc.Y + 1); break;
                case 15: n_loc = new Point(loc.X + 1, loc.Y - 1); break;
                case 16: n_loc = new Point(loc.X - 1, loc.Y + 1); break;
                case 17: n_loc = new Point(loc.X - 1, loc.Y - 1); break;

            }
            if (n_loc.X >= 0 && n_loc.X <= form.numOfCellsX && n_loc.Y >= 0 && n_loc.Y <= form.numOfCellsY)
            {
                Point d = new Point(n_loc.X - loc.X, n_loc.Y - loc.Y);
                if (0 < (block as ActionBlock).action && (block as ActionBlock).action < 10)
                {
                    Point point1 = new Point((loc.X * cellSize), ((-loc.Y + field.Y + 1) * cellSize));
                    Point point2 = new Point((n_loc.X * cellSize), ((-n_loc.Y + field.Y) * cellSize));
                    coordList.Add(new Coord(loc, n_loc));
                    
                    switch (num ){
                        case 0: coordListFirst.Add(new Coord(loc, n_loc)); form.positionFirst = n_loc; graph.DrawLine(penFirst, point1, point2);
                            graph.DrawImage(form.imageList1.Images[num], form.startPosition.X + cellSize * form.positionFirst.X, form.startPosition.Y - 1 - cellSize * form.positionFirst.Y, cellSize - 2, cellSize - 2);
                            break;
                        case 1: coordListSecond.Add(new Coord(loc, n_loc)); form.positionSecond = n_loc; graph.DrawLine(penSecond, point1, point2);
                            graph.DrawImage(form.imageList1.Images[num], form.startPosition.X + cellSize * form.positionSecond.X, form.startPosition.Y - 1 - cellSize * form.positionSecond.Y, cellSize - 2, cellSize - 2);
                            break;
                        case 2: coordListThird.Add(new Coord(loc, n_loc)); form.positionThird = n_loc; graph.DrawLine(penThird, point1, point2);
                            graph.DrawImage(form.imageList1.Images[num], form.startPosition.X + cellSize * form.positionThird.X, form.startPosition.Y - 1 - cellSize * form.positionThird.Y, cellSize - 2, cellSize - 2);
                            break;
                    }
                }
                //form.pencil1.Location = new Point(form.pencil1.Location.X + d.X * cellSize, form.pencil1.Location.Y - d.Y * cellSize);
                //form.pencil1.Update();
                
                RefreshField();
                loc = n_loc;
                switch (num)
                {
                    case 0: form.positionFirst = loc; break;
                    case 1: form.positionSecond = loc; break;
                    case 2: form.positionThird = loc; break;
                }
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
            for (int i = 0; i < coordListFirst.Count(); i++)
            {
                graph.DrawLine(penFirst, new Point(coordListFirst[i].p1.X * cellSize, (-coordListFirst[i].p1.Y + field.Y + 1) * cellSize), new Point(coordListFirst[i].p2.X * cellSize, (-coordListFirst[i].p2.Y + field.Y + 1) * cellSize));
            }

            for (int i = 0; i < coordListSecond.Count(); i++)
            {
                graph.DrawLine(penSecond, new Point(coordListSecond[i].p1.X * cellSize, (-coordListSecond[i].p1.Y + field.Y + 1) * cellSize), new Point(coordListSecond[i].p2.X * cellSize, (-coordListSecond[i].p2.Y + field.Y + 1) * cellSize));
            }

            for (int i = 0; i < coordListThird.Count(); i++)
            {
                graph.DrawLine(penThird, new Point(coordListThird[i].p1.X * cellSize, (-coordListThird[i].p1.Y + field.Y + 1) * cellSize), new Point(coordListThird[i].p2.X * cellSize, (-coordListThird[i].p2.Y + field.Y + 1) * cellSize));
            }

            graph.DrawImage(form.imageList1.Images[0], form.startPosition.X + cellSize * form.positionFirst.X, form.startPosition.Y - 1 - cellSize * form.positionFirst.Y, cellSize - 2, cellSize - 2);
            graph.DrawImage(form.imageList1.Images[1], form.startPosition.X + cellSize * form.positionSecond.X, form.startPosition.Y - 1 - cellSize * form.positionSecond.Y, cellSize - 2, cellSize - 2);
            graph.DrawImage(form.imageList1.Images[2], form.startPosition.X + cellSize * form.positionThird.X, form.startPosition.Y - 1 - cellSize * form.positionThird.Y, cellSize - 2, cellSize - 2);

        }
        public void DrawAgain(List<Coord> coord, Point pencilCoord)
        {
            form.pbDraw.Refresh();
            graph.DrawImage(form.imageList1.Images[0], form.startPosition.X + cellSize * form.positionFirst.X, form.startPosition.Y - 1 - cellSize * form.positionFirst.Y, cellSize - 2, cellSize - 2);

            //graph.DrawImage(form.imageList1.Images[0], new Point(1 + cellSize * form.position.X, pbDraw.Location.Y - 1 - cellSize - 2 - cellSize * position.Y));
            //form.pencil1.Location = new Point(form.pbDraw.Location.X + 1 + cellSize * pencilCoord.X, form.pbDraw.Size.Height + form.pbDraw.Location.Y - 1 - form.pencil1.Height - cellSize * pencilCoord.Y);
            for (int i = 0; i < coord.Count(); i++)
            {
                graph.DrawLine(penFirst, new Point(coordList[i].p1.X * cellSize, (-coordList[i].p1.Y + field.Y + 1) * cellSize), new Point(coordList[i].p2.X * cellSize, (-coordList[i].p2.Y + field.Y + 1) * cellSize));
            }
            graph.DrawImage(form.imageList1.Images[0], form.startPosition.X + cellSize * form.positionFirst.X, form.startPosition.Y - 1 - cellSize * form.positionFirst.Y, cellSize - 2, cellSize - 2);
        }
        public void Replace()
        {
            foreach (Coord coord in coordListFirst)
            {
                form.coordListFirst.Add(new Diagrams.Coordinate(coord.p1, coord.p2));
            }
            foreach (Coord coord in coordListSecond)
            {
                form.coordListSecond.Add(new Diagrams.Coordinate(coord.p1, coord.p2));
            }
            foreach (Coord coord in coordListThird)
            {
                form.coordListThird.Add(new Diagrams.Coordinate(coord.p1, coord.p2));
            }
        }
    }
}
