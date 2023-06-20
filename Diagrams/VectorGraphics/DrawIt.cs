using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
    public class DrawIt
    {
        public bool error;
        public List<Coord> missingCoords; //список для недостающих координат
        public List<Coord> extraCoords; //список для лишних координат
        Dictionary<string, Block> procedures; //словарь процедур, где по названию процедуры можно будет получить её первый блок
        Point locationFirst; //положение первого чертёжника
        Point locationSecond; //положение второго чертёжника
        Point locationThird; //положение третьего чертёжника
        List<Coord> coordList; //линии, которые отображены на рисунке
        List<Coord> coordListSecond; //линии, которые отображены на рисунке  (зелёные)
        List<Coord> coordListFirst; //линии, которые отображены на рисунке  (синие)
        List<Coord> coordListThird; //линии, которые отображены на рисунке (оранжевые)
        List<String> firstBlocks;
        List<String> secondBlocks;
        List<String> thirdBlocks;
        StepsOfBlockSchema blockSchema;
        Point field;
        DrawForm form;
        AlgForm parentForm;
        Graphics graph;
        bool draw;
        public List<Block> firstDrawer;
        public List<Block> secondDrawer;
        public List<Block> thirdDrawer;
        int speed = 300;
        Block blockFirst;
        Block blockSecond;
        Block blockThird;
        Pen penFirst;
        Pen penSecond;
        Pen penThird;
        int cellSize;
        public List<Block> selectedList;
        public List<Block> selectedListS;
        public List<Block> selectedListT;
        public int max;
        //добавлена переменная mode, отвечающая за режим выполнения - пошаговый или нет
        //mode = 0 при обычном выполнении алгоритма, mode = 1 при пошаговом
        public void Draw(Block blockFirst, Block blockSecond, Block blockThird, int numX, int numY, DrawForm drawForm, AlgForm parentForm, StepsOfBlockSchema blockSchema, byte mode, int step)
        {
            error = false;
            missingCoords = new List<Coord>(); //список для недостающих координат
            extraCoords = new List<Coord>(); //список для лишних координат
            procedures = new Dictionary<string, Block>(); //словарь процедур, где по названию процедуры можно будет получить её первый блок
            locationFirst = new Point(0, 0); //положение первого чертёжника
            locationSecond = new Point(0, 0); //положение второго чертёжника
            locationThird = new Point(0, 0); //положение третьего чертёжника
            coordList = new List<Coord>(); //линии, которые отображены на рисунке
            coordListSecond = new List<Coord>(); //линии, которые отображены на рисунке  (зелёные)
            coordListFirst = new List<Coord>(); //линии, которые отображены на рисунке  (синие)
            coordListThird = new List<Coord>(); //линии, которые отображены на рисунке (оранжевые)
            firstBlocks = new List<String>();
            secondBlocks = new List<String>();
            thirdBlocks = new List<String>();
            firstDrawer = new List<Block>();
            secondDrawer = new List<Block>();
            thirdDrawer = new List<Block>();
            selectedList = new List<Block>();
            selectedListS = new List<Block>();
            selectedListT = new List<Block>();
            form = drawForm;
            speed = drawForm.tbSpeed.Value;
            this.blockSchema = blockSchema;
            if (blockSchema != null)
            {
                blockSchema.dgvFirst.Rows.Clear();
                blockSchema.dgvSecond.Rows.Clear();
                blockSchema.dgvThird.Rows.Clear();
            }
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
            if (form.dr > 1)
                form.positionSecond = new Point(0, 0);
            if (form.dr > 2)
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
            if (mode == 0)
            {
                try
                {
                    DrawPicFirst(blockFirst);
                    DrawPicSecond(blockSecond);
                    DrawPicThird(blockThird);
                    locationFirst = new Point(0, 0);
                    locationSecond = new Point(0, 0);
                    locationThird = new Point(0, 0);
                    MoveBlock();
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
                    MessageBox.Show("Невозможно выполнение алгоритма!" + e.Message, "Ошибка!", MessageBoxButtons.OK);
                    parentForm.dbDiagram.drawFigure = null;
                    parentForm.dbDiagramS.drawFigure = null;
                    parentForm.dbDiagramT.drawFigure = null;
                    parentForm.dbDiagram.Invalidate();
                    parentForm.dbDiagramS.Invalidate();
                    parentForm.dbDiagramT.Invalidate();
                    error = true;
                }
            }
            else
            {
                try
                {
                    DrawPicFirst(blockFirst);
                    DrawPicSecond(blockSecond);
                    DrawPicThird(blockThird);
                    locationFirst = new Point(0, 0);
                    locationSecond = new Point(0, 0);
                    locationThird = new Point(0, 0);
                }
                catch (Exception e)
                {
                    step = 0;
                    MessageBox.Show("Невозможно выполнение алгоритма!" + e.Message, "Ошибка!", MessageBoxButtons.OK);
                    parentForm.dbDiagram.drawFigure = null;
                    parentForm.dbDiagramS.drawFigure = null;
                    parentForm.dbDiagramT.drawFigure = null;
                    parentForm.dbDiagram.Invalidate();
                    parentForm.dbDiagramS.Invalidate();
                    parentForm.dbDiagramT.Invalidate();
                    error = true;
                    missingCoords = new List<Coord>(); //список для недостающих координат
                    extraCoords = new List<Coord>(); //список для лишних координат
                    procedures = new Dictionary<string, Block>(); //словарь процедур, где по названию процедуры можно будет получить её первый блок
                    locationFirst = new Point(0, 0); //положение первого чертёжника
                    locationSecond = new Point(0, 0); //положение второго чертёжника
                    locationThird = new Point(0, 0); //положение третьего чертёжника
                    coordList = new List<Coord>(); //линии, которые отображены на рисунке
                    coordListSecond = new List<Coord>(); //линии, которые отображены на рисунке  (зелёные)
                    coordListFirst = new List<Coord>(); //линии, которые отображены на рисунке  (синие)
                    coordListThird = new List<Coord>(); //линии, которые отображены на рисунке (оранжевые)
                    firstBlocks = new List<String>();
                    secondBlocks = new List<String>();
                    thirdBlocks = new List<String>();
                    firstDrawer = new List<Block>();
                    secondDrawer = new List<Block>();
                    thirdDrawer = new List<Block>();
                    selectedList = new List<Block>();
                    selectedListS = new List<Block>();
                    selectedListT = new List<Block>();
                    form = drawForm;
                    speed = drawForm.tbSpeed.Value;
                    this.blockSchema = blockSchema;
                    if (blockSchema != null)
                    {
                        blockSchema.dgvFirst.Rows.Clear();
                        blockSchema.dgvSecond.Rows.Clear();
                        blockSchema.dgvThird.Rows.Clear();
                    }
                    form.draw = false;
                }
            }
        }

        private void checkTask()
        {
            missingCoords = new List<Coord>(); //список для недостающих координат
            extraCoords = new List<Coord>(); //список для лишних координат

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
            }
            
        }
        Block procedure = null;
        private Block DrawPicFirst(Block block)
        {
            if (block == null)
                return null;
            if (block.figure.text == null)
            {
                throw new Exception(" Был обнаружен пустой блок!");
            }

            if (block is EllipseBlock)
            {
                firstDrawer.Add(block);
                selectedList.Add(procedure == null? block: procedure);
                firstBlocks.Add(block.figure.text);

            }

            if (block is ActionBlock) //если действие
            {
                firstDrawer.Add(block);
                selectedList.Add(procedure == null ? block : procedure);
                DoAction(block, ref locationFirst);
                firstBlocks.Add(block.figure.text);
                return DrawPicFirst(block.nextBlock);
            }
            if (block is IfWithoutElseBlock)
            {
                firstDrawer.Add(block);
                firstBlocks.Add("Есть место " + block.figure.text + "?");
                switch ((block as IfWithoutElseBlock).condition)
                {
                    case 1: if (field.X - locationFirst.X >= (block as IfWithoutElseBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure);  DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += "Нет"; } selectedList.Add(procedure == null ? block : procedure); break;
                    case 2: if (locationFirst.X >= (block as IfWithoutElseBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure);  DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += "Нет"; } selectedList.Add(block);  break;
                    case 3: if (field.Y - locationFirst.Y >= (block as IfWithoutElseBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure);  DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += "Нет"; } selectedList.Add(procedure == null ? block : procedure);  break;
                    case 4: if (locationFirst.Y >= (block as IfWithoutElseBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure);  DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += "Нет"; } selectedList.Add(procedure == null ? block : procedure); break;
                    case 5: if (field.X - locationFirst.X >= (block as IfWithoutElseBlock).num_cond && locationFirst.Y >= (block as IfWithoutElseBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure);  DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += "Нет"; } selectedList.Add(procedure == null ? block : procedure);  break;
                    case 6: if (field.X - locationFirst.X >= (block as IfWithoutElseBlock).num_cond && field.Y - locationFirst.Y >= (block as IfWithoutElseBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += "Нет"; } selectedList.Add(procedure == null ? block : procedure); break;
                    case 7: if (locationFirst.X >= (block as IfWithoutElseBlock).num_cond && locationFirst.Y >= (block as IfWithoutElseBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += "Нет"; } selectedList.Add(procedure == null ? block : procedure);  break;
                    case 8: if (locationFirst.X >= (block as IfWithoutElseBlock).num_cond && (field.Y - locationFirst.Y >= (block as IfWithoutElseBlock).num_cond)) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfWithoutElseBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += "Нет"; } selectedList.Add(procedure == null ? block : procedure);  break;
                }
            }
            if (block is IfBlock)
            {
                firstDrawer.Add(block);
                firstBlocks.Add("Есть место " + block.figure.text + "?");
                switch ((block as IfBlock).condition)
                {
                    case 1: if (field.X - locationFirst.X >= (block as IfBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += " Нет"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).falseBlock); } selectedList.Add(procedure == null ? block : procedure); break;
                    case 2: if (locationFirst.X >= (block as IfBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += " Нет"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).falseBlock); } selectedList.Add(block); break;
                    case 3: if (field.Y - locationFirst.Y >= (block as IfBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += " Нет"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).falseBlock); } selectedList.Add(procedure == null ? block : procedure); break;
                    case 4: if (locationFirst.Y >= (block as IfBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += " Нет"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).falseBlock); } selectedList.Add(procedure == null ? block : procedure); break;
                    case 5: if (field.X - locationFirst.X >= (block as IfBlock).num_cond && locationFirst.Y >= (block as IfBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += " Нет"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).falseBlock); } selectedList.Add(procedure == null ? block : procedure); break;
                    case 6: if (field.X - locationFirst.X >= (block as IfBlock).num_cond && field.Y - locationFirst.Y >= (block as IfBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += " Нет"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).falseBlock); } selectedList.Add(procedure == null ? block : procedure); break;
                    case 7: if (locationFirst.X >= (block as IfBlock).num_cond && locationFirst.Y >= (block as IfBlock).num_cond) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += " Нет"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).falseBlock); } selectedList.Add(procedure == null ? block : procedure); break;
                    case 8: if (locationFirst.X >= (block as IfBlock).num_cond && (field.Y - locationFirst.Y >= (block as IfBlock).num_cond)) { firstBlocks[firstBlocks.Count - 1] += " Да"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).trueBlock); } else { firstBlocks[firstBlocks.Count - 1] += " Нет"; selectedList.Add(procedure == null ? block : procedure); DrawPicFirst((block as IfBlock).falseBlock); } selectedList.Add(procedure == null ? block : procedure); break;
                }
            }
            if (block is WhileBlock)
            {
                
                switch ((block as WhileBlock).condition)
                {
                    case 1: while (field.X - locationFirst.X >= (block as WhileBlock).num_cond) { firstBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } selectedList.Add(procedure == null ? block : procedure); firstBlocks.Add("Есть место " + block.figure.text + "? Нет"); firstDrawer.Add(block); break;
                    case 2: while (locationFirst.X >= (block as WhileBlock).num_cond) { firstBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } selectedList.Add(procedure == null ? block : procedure); firstBlocks.Add("Есть место " + block.figure.text + "? Нет"); firstDrawer.Add(block); break;
                    case 3: while (field.Y - locationFirst.Y >= (block as WhileBlock).num_cond) { firstBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } selectedList.Add(procedure == null ? block : procedure); firstBlocks.Add("Есть место " + block.figure.text + "? Нет"); firstDrawer.Add(block); break;
                    case 4: while (locationFirst.Y >= (block as WhileBlock).num_cond) { firstBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } selectedList.Add(procedure == null ? block : procedure); firstBlocks.Add("Есть место " + block.figure.text + "? Нет"); firstDrawer.Add(block); break;
                    case 5: while (field.X - locationFirst.X >= (block as WhileBlock).num_cond && locationFirst.Y >= (block as WhileBlock).num_cond) { firstBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); break;
                    case 6: while (field.X - locationFirst.X >= (block as WhileBlock).num_cond && field.Y - locationFirst.Y >= (block as WhileBlock).num_cond) { firstBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); break;
                    case 7: while (locationFirst.X >= (block as WhileBlock).num_cond && locationFirst.Y >= (block as WhileBlock).num_cond) { firstBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); break;
                    case 8: while (locationFirst.X >= (block as WhileBlock).num_cond && (field.Y - locationFirst.Y >= (block as WhileBlock).num_cond)) { firstBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); DrawPicFirst((block as WhileBlock).trueBlock); } firstBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedList.Add(procedure == null ? block : procedure); firstDrawer.Add(block); break;
                }
            }
            if (block is ForBlock)
            {
                for (int i = 0; i < (block as ForBlock).numOfRep; i++)
                {
                    firstBlocks.Add($"{i} из {(block as ForBlock).numOfRep}");
                    firstDrawer.Add(block); selectedList.Add(procedure == null ? block : procedure);
                    DrawPicFirst((block as ForBlock).trueBlock);
                }
                firstBlocks.Add($"{(block as ForBlock).numOfRep} из {(block as ForBlock).numOfRep}");
                firstDrawer.Add(block);
                selectedList.Add(procedure == null ? block : procedure);
            }
            if (block is ProcedureBlock)
            {
                if (procedure == null)
                    procedure = block;
                firstBlocks.Add($"{block.figure.text} НАЧАЛО");
                firstDrawer.Add(block); selectedList.Add(procedure == null ? block : procedure);
                if (!procedures.ContainsKey((block as ProcedureBlock).figure.text))
                    OpenProcedure((block as ProcedureBlock).figure.text);
                DrawPicFirst(procedures[(block as ProcedureBlock).figure.text].nextBlock);
                if (block == procedure)
                    procedure = null;
                firstBlocks[firstBlocks.Count - 1] = $"{block.figure.text} КОНЕЦ";

            }

            return DrawPicFirst(block.nextBlock);
        }

        private Block DrawPicSecond(Block block)
        {
            if (block == null)
                return null;
            if (block.figure.text == null)
                throw new Exception("Был обнаружен пустой блок!");

            if (procedure != null)
                block.figure = procedure.figure;
            if (block is EllipseBlock)
            {
                secondDrawer.Add(block);
                selectedListS.Add(procedure == null ? block : procedure);
                secondBlocks.Add(block.figure.text);

            }

            if (block is ActionBlock) //если действие
            {
                secondDrawer.Add(block);
                selectedListS.Add(procedure == null ? block : procedure);
                DoAction(block, ref locationSecond);
                secondBlocks.Add(block.figure.text);
                return DrawPicSecond(block.nextBlock);
            }
            if (block is IfWithoutElseBlock)
            {
                secondDrawer.Add(block);
                secondBlocks.Add("Есть место " + block.figure.text + "?");
                switch ((block as IfWithoutElseBlock).condition)
                {
                    case 1: if (field.X - locationSecond.X >= (block as IfWithoutElseBlock).num_cond) { secondBlocks[secondBlocks.Count - 1] += " Да"; selectedListS.Add(procedure == null ? block : procedure);  DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } else { secondBlocks[secondBlocks.Count - 1] += "Нет"; } selectedListS.Add(procedure == null ? block : procedure);  break;
                    case 2: if (locationSecond.X >= (block as IfWithoutElseBlock).num_cond) { secondBlocks[secondBlocks.Count - 1] += " Да"; selectedListS.Add(procedure == null ? block : procedure); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } else { secondBlocks[secondBlocks.Count - 1] += "Нет"; } selectedListS.Add(block); secondDrawer.Add(block); break;
                    case 3: if (field.Y - locationSecond.Y >= (block as IfWithoutElseBlock).num_cond) { secondBlocks[secondBlocks.Count - 1] += " Да"; selectedListS.Add(procedure == null ? block : procedure); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } else { secondBlocks[secondBlocks.Count - 1] += "Нет"; } selectedListS.Add(procedure == null ? block : procedure);break;
                    case 4: if (locationSecond.Y >= (block as IfWithoutElseBlock).num_cond) { secondBlocks[secondBlocks.Count - 1] += " Да"; selectedListS.Add(procedure == null ? block : procedure); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } else { secondBlocks[secondBlocks.Count - 1] += "Нет"; } selectedListS.Add(procedure == null ? block : procedure);break;
                    case 5: if (field.X - locationSecond.X >= (block as IfWithoutElseBlock).num_cond && locationSecond.Y >= (block as IfWithoutElseBlock).num_cond) { secondBlocks[secondBlocks.Count - 1] += " Да"; selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } else { secondBlocks[secondBlocks.Count - 1] += "Нет"; } selectedListS.Add(procedure == null ? block : procedure); break;
                    case 6: if (field.X - locationSecond.X >= (block as IfWithoutElseBlock).num_cond && field.Y - locationSecond.Y >= (block as IfWithoutElseBlock).num_cond) { secondBlocks[secondBlocks.Count - 1] += " Да"; selectedListS.Add(procedure == null ? block : procedure); DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } else { secondBlocks[secondBlocks.Count - 1] += "Нет"; } selectedListS.Add(procedure == null ? block : procedure); break;
                    case 7: if (locationSecond.X >= (block as IfWithoutElseBlock).num_cond && locationSecond.Y >= (block as IfWithoutElseBlock).num_cond) { secondBlocks[secondBlocks.Count - 1] += " Да"; selectedListS.Add(procedure == null ? block : procedure);  DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } else { secondBlocks[secondBlocks.Count - 1] += "Нет"; } selectedListS.Add(procedure == null ? block : procedure); break;
                    case 8: if (locationSecond.X >= (block as IfWithoutElseBlock).num_cond && (field.Y - locationSecond.Y >= (block as IfWithoutElseBlock).num_cond)) { secondBlocks[secondBlocks.Count - 1] += " Да"; selectedListS.Add(procedure == null ? block : procedure);  DrawPicSecond((block as IfWithoutElseBlock).trueBlock); } else { secondBlocks[secondBlocks.Count - 1] += "Нет"; } selectedListS.Add(procedure == null ? block : procedure);  break;
                }
            }
            if (block is WhileBlock)
            {

                switch ((block as WhileBlock).condition)
                {
                    case 1: while (field.X - locationSecond.X >= (block as WhileBlock).num_cond) { secondBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } selectedListS.Add(procedure == null ? block : procedure); secondBlocks.Add("Есть место " + block.figure.text + "? Нет"); secondDrawer.Add(block); break;
                    case 2: while (locationSecond.X >= (block as WhileBlock).num_cond) { secondBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } selectedListS.Add(procedure == null ? block : procedure); secondBlocks.Add("Есть место " + block.figure.text + "? Нет"); secondDrawer.Add(block); break;
                    case 3: while (field.Y - locationSecond.Y >= (block as WhileBlock).num_cond) { secondBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } selectedListS.Add(procedure == null ? block : procedure); secondBlocks.Add("Есть место " + block.figure.text + "? Нет"); secondDrawer.Add(block); break;
                    case 4: while (locationSecond.Y >= (block as WhileBlock).num_cond) { secondBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } selectedListS.Add(procedure == null ? block : procedure); secondBlocks.Add("Есть место " + block.figure.text + "? Нет"); secondDrawer.Add(block); break;
                    case 5: while (field.X - locationSecond.X >= (block as WhileBlock).num_cond && locationSecond.Y >= (block as WhileBlock).num_cond) { secondBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); break;
                    case 6: while (field.X - locationSecond.X >= (block as WhileBlock).num_cond && field.Y - locationSecond.Y >= (block as WhileBlock).num_cond) { secondBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); break;
                    case 7: while (locationSecond.X >= (block as WhileBlock).num_cond && locationSecond.Y >= (block as WhileBlock).num_cond) { secondBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); break;
                    case 8: while (locationSecond.X >= (block as WhileBlock).num_cond && (field.Y - locationSecond.Y >= (block as WhileBlock).num_cond)) { secondBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); DrawPicSecond((block as WhileBlock).trueBlock); } secondBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedListS.Add(procedure == null ? block : procedure); secondDrawer.Add(block); break;
                }
            }
            if (block is ForBlock)
            {
                for (int i = 0; i < (block as ForBlock).numOfRep; i++)
                {
                    secondBlocks.Add($"{i} из {(block as ForBlock).numOfRep}");
                    secondDrawer.Add(block); selectedListS.Add(procedure == null ? block : procedure);
                    DrawPicSecond((block as ForBlock).trueBlock);
                }
                secondBlocks.Add($"{(block as ForBlock).numOfRep} из {(block as ForBlock).numOfRep}");
                secondDrawer.Add(block);
                selectedListS.Add(procedure == null ? block : procedure);
            }
            if (block is ProcedureBlock)
            {
                if (procedure == null)
                    procedure = block;
                secondBlocks.Add($"{block.figure.text} НАЧАЛО");
                secondDrawer.Add(block); selectedListS.Add(procedure == null ? block : procedure);
                if (!procedures.ContainsKey((block as ProcedureBlock).figure.text))
                    OpenProcedure((block as ProcedureBlock).figure.text);
                DrawPicSecond(procedures[(block as ProcedureBlock).figure.text].nextBlock);
                if (block == procedure)
                    procedure = null;
                secondBlocks[secondBlocks.Count - 1] = $"{block.figure.text} КОНЕЦ";

            }
            return DrawPicSecond(block.nextBlock);
        }

        private Block DrawPicThird(Block block)
        {
            if (block == null)
                return null;
            if (block.figure.text == null)
                throw new Exception("Был обнаружен пустой блок!");

            if (procedure != null)
                block.figure = procedure.figure;
            if (procedure != null)
                block.figure = procedure.figure;
            if (block is EllipseBlock)
            {
                thirdDrawer.Add(block);
                selectedListT.Add(procedure == null ? block : procedure);
                thirdBlocks.Add(block.figure.text);

            }

            if (block is ActionBlock) //если действие
            {
                thirdDrawer.Add(block);
                selectedListT.Add(procedure == null ? block : procedure);
                DoAction(block, ref locationThird);
                thirdBlocks.Add(block.figure.text);
                return DrawPicThird(block.nextBlock);
            }
            if (block is IfWithoutElseBlock)
            {
                thirdDrawer.Add(block);
                thirdBlocks.Add("Есть место " + block.figure.text + "?");
                switch ((block as IfWithoutElseBlock).condition)
                {
                    case 1: if (field.X - locationThird.X >= (block as IfWithoutElseBlock).num_cond) { thirdBlocks[thirdBlocks.Count - 1] += " Да"; selectedListT.Add(procedure == null ? block : procedure); DrawPicThird((block as IfWithoutElseBlock).trueBlock); } else { thirdBlocks[thirdBlocks.Count - 1] += "Нет"; } selectedListT.Add(procedure == null ? block : procedure);  break;
                    case 2: if (locationThird.X >= (block as IfWithoutElseBlock).num_cond) { thirdBlocks[thirdBlocks.Count - 1] += " Да"; selectedListT.Add(procedure == null ? block : procedure);  DrawPicThird((block as IfWithoutElseBlock).trueBlock); } else { thirdBlocks[thirdBlocks.Count - 1] += "Нет"; } selectedListT.Add(block); thirdDrawer.Add(block); break;
                    case 3: if (field.Y - locationThird.Y >= (block as IfWithoutElseBlock).num_cond) { thirdBlocks[thirdBlocks.Count - 1] += " Да"; selectedListT.Add(procedure == null ? block : procedure);  DrawPicThird((block as IfWithoutElseBlock).trueBlock); } else { thirdBlocks[thirdBlocks.Count - 1] += "Нет"; } selectedListT.Add(procedure == null ? block : procedure);  break;
                    case 4: if (locationThird.Y >= (block as IfWithoutElseBlock).num_cond) { thirdBlocks[thirdBlocks.Count - 1] += " Да"; selectedListT.Add(procedure == null ? block : procedure);  DrawPicThird((block as IfWithoutElseBlock).trueBlock); } else { thirdBlocks[thirdBlocks.Count - 1] += "Нет"; } selectedListT.Add(procedure == null ? block : procedure); break;
                    case 5: if (field.X - locationThird.X >= (block as IfWithoutElseBlock).num_cond && locationThird.Y >= (block as IfWithoutElseBlock).num_cond) { thirdBlocks[thirdBlocks.Count - 1] += " Да"; selectedListT.Add(procedure == null ? block : procedure);  DrawPicThird((block as IfWithoutElseBlock).trueBlock); } else { thirdBlocks[thirdBlocks.Count - 1] += "Нет"; } selectedListT.Add(procedure == null ? block : procedure); break;
                    case 6: if (field.X - locationThird.X >= (block as IfWithoutElseBlock).num_cond && field.Y - locationThird.Y >= (block as IfWithoutElseBlock).num_cond) { thirdBlocks[thirdBlocks.Count - 1] += " Да"; selectedListT.Add(procedure == null ? block : procedure);  DrawPicThird((block as IfWithoutElseBlock).trueBlock); } else { thirdBlocks[thirdBlocks.Count - 1] += "Нет"; } selectedListT.Add(procedure == null ? block : procedure); break;
                    case 7: if (locationThird.X >= (block as IfWithoutElseBlock).num_cond && locationThird.Y >= (block as IfWithoutElseBlock).num_cond) { thirdBlocks[thirdBlocks.Count - 1] += " Да"; selectedListT.Add(procedure == null ? block : procedure);  DrawPicThird((block as IfWithoutElseBlock).trueBlock); } else { thirdBlocks[thirdBlocks.Count - 1] += "Нет"; } selectedListT.Add(procedure == null ? block : procedure); break;
                    case 8: if (locationThird.X >= (block as IfWithoutElseBlock).num_cond && (field.Y - locationThird.Y >= (block as IfWithoutElseBlock).num_cond)) { thirdBlocks[thirdBlocks.Count - 1] += " Да"; selectedListT.Add(procedure == null ? block : procedure);  DrawPicThird((block as IfWithoutElseBlock).trueBlock); } else { thirdBlocks[thirdBlocks.Count - 1] += "Нет"; } selectedListT.Add(procedure == null ? block : procedure); break;
                }
            }
            if (block is WhileBlock)
            {

                switch ((block as WhileBlock).condition)
                {
                    case 1: while (field.X - locationThird.X >= (block as WhileBlock).num_cond) { thirdBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } selectedListT.Add(procedure == null ? block : procedure); thirdBlocks.Add("Есть место " + block.figure.text + "? Нет"); thirdDrawer.Add(block); break;
                    case 2: while (locationThird.X >= (block as WhileBlock).num_cond) { thirdBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } selectedListT.Add(procedure == null ? block : procedure); thirdBlocks.Add("Есть место " + block.figure.text + "? Нет"); thirdDrawer.Add(block); break;
                    case 3: while (field.Y - locationThird.Y >= (block as WhileBlock).num_cond) { thirdBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } selectedListT.Add(procedure == null ? block : procedure); thirdBlocks.Add("Есть место " + block.figure.text + "? Нет"); thirdDrawer.Add(block); break;
                    case 4: while (locationThird.Y >= (block as WhileBlock).num_cond) { thirdBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } selectedListT.Add(procedure == null ? block : procedure); thirdBlocks.Add("Есть место " + block.figure.text + "? Нет"); thirdDrawer.Add(block); break;
                    case 5: while (field.X - locationThird.X >= (block as WhileBlock).num_cond && locationThird.Y >= (block as WhileBlock).num_cond) { thirdBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); break;
                    case 6: while (field.X - locationThird.X >= (block as WhileBlock).num_cond && field.Y - locationThird.Y >= (block as WhileBlock).num_cond) { thirdBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); break;
                    case 7: while (locationThird.X >= (block as WhileBlock).num_cond && locationThird.Y >= (block as WhileBlock).num_cond) { thirdBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); break;
                    case 8: while (locationThird.X >= (block as WhileBlock).num_cond && (field.Y - locationThird.Y >= (block as WhileBlock).num_cond)) { thirdBlocks.Add("Есть место " + block.figure.text + "? Да"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); DrawPicThird((block as WhileBlock).trueBlock); } thirdBlocks.Add("Есть место " + block.figure.text + "? Нет"); selectedListT.Add(procedure == null ? block : procedure); thirdDrawer.Add(block); break;
                }
            }
            if (block is ForBlock)
            {
                for (int i = 0; i < (block as ForBlock).numOfRep; i++)
                {
                    thirdBlocks.Add($"{i} из {(block as ForBlock).numOfRep}");
                    thirdDrawer.Add(block); selectedListT.Add(procedure == null ? block : procedure);
                    DrawPicThird((block as ForBlock).trueBlock);
                }
                thirdBlocks.Add($"{(block as ForBlock).numOfRep} из {(block as ForBlock).numOfRep}");
                thirdDrawer.Add(block);
                selectedListT.Add(procedure == null ? block : procedure);
            }
            if (block is ProcedureBlock)
            {
                if (procedure == null)
                    procedure = block;
                thirdBlocks.Add($"{block.figure.text} НАЧАЛО");
                thirdDrawer.Add(block); selectedListT.Add(procedure == null ? block : procedure);
                if (!procedures.ContainsKey((block as ProcedureBlock).figure.text))
                    OpenProcedure((block as ProcedureBlock).figure.text);
                DrawPicThird(procedures[(block as ProcedureBlock).figure.text].nextBlock);
                if (block == procedure)
                    procedure = null;
                thirdBlocks[thirdBlocks.Count - 1] = $"{block.figure.text} КОНЕЦ";

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

        
        private void MoveBlock()
        {
            //здесь посмотреть, у кого из исполнителей блоков больше
            int n = new[] { firstDrawer.Count(), secondDrawer.Count(), thirdDrawer.Count() }.Max();
            for (int i = 0; i < n; i++)
            {
                if (firstDrawer.Count() > i)
                {
                    parentForm.dbDiagram.drawFigure = selectedList[i].figure;
                    parentForm.dbDiagram.AutoScrollPosition = new Point((int)selectedList[i].figure.location.X - SolidFigure.defaultSize*2, (int)selectedList[i].figure.location.Y - 40);
                    parentForm.dbDiagram.Refresh();
                    if (firstDrawer[i] is ActionBlock)
                    {
                        DrawAction(firstDrawer[i], ref locationFirst, 0);
                    }
                    if (blockSchema != null)
                    {
                        blockSchema.dgvFirst.Rows.Add(firstBlocks[i]);
                        blockSchema.dgvFirst.FirstDisplayedScrollingRowIndex = blockSchema.dgvFirst.Rows.Count - 1;
                        blockSchema.dgvFirst.Refresh();
                    }

                    
                }
                if (secondDrawer.Count() > i)
                {
                    parentForm.dbDiagramS.drawFigure = selectedListS[i].figure;
                    parentForm.dbDiagramS.AutoScrollPosition = new Point((int)selectedListS[i].figure.location.X - SolidFigure.defaultSize * 2, (int)selectedListS[i].figure.location.Y - 40);
                    parentForm.dbDiagramS.Refresh();
                    if (secondDrawer[i] is ActionBlock)
                    {
                        DrawAction(secondDrawer[i], ref locationSecond, 1);
                    }
                    if (blockSchema != null)
                    {
                        blockSchema.dgvSecond.Rows.Add(secondBlocks[i]);
                        blockSchema.dgvSecond.FirstDisplayedScrollingRowIndex = blockSchema.dgvSecond.Rows.Count - 1;
                        blockSchema.dgvSecond.Refresh();


                    }
                }
                if (thirdDrawer.Count() > i)
                {
                    parentForm.dbDiagramT.drawFigure = selectedListT[i].figure;
                    parentForm.dbDiagramT.AutoScrollPosition = new Point((int)selectedListT[i].figure.location.X - SolidFigure.defaultSize * 2, (int)selectedListT[i].figure.location.Y - 40);
                    parentForm.dbDiagramT.Refresh();
                    if (thirdDrawer[i] is ActionBlock)
                    {
                        DrawAction(thirdDrawer[i], ref locationThird, 2);
                    }
                    if (blockSchema != null)
                    {
                        blockSchema.dgvThird.Rows.Add(thirdBlocks[i]);
                        blockSchema.dgvThird.FirstDisplayedScrollingRowIndex = blockSchema.dgvThird.Rows.Count - 1;
                        blockSchema.dgvThird.Refresh();

                    }
                }
                var t = Task.Run(async delegate
                {
                    await Task.Delay(speed);
                });
                t.Wait();
            }
        }
        public void MoveBlock(int step)
        {
            //здесь посмотреть, у кого из исполнителей блоков больше
            max = new[] { firstDrawer.Count(), secondDrawer.Count(), thirdDrawer.Count() }.Max();
            if (max > step)
            {
                if (firstDrawer.Count() > step)
                {
                    parentForm.dbDiagram.drawFigure = selectedList[step].figure;
                    parentForm.dbDiagram.AutoScrollPosition = new Point((int)selectedList[step].figure.location.X - SolidFigure.defaultSize * 2, (int)selectedList[step].figure.location.Y - 40);
                    parentForm.dbDiagram.Refresh();
                    if (firstDrawer[step] is ActionBlock)
                    {
                        DrawAction(firstDrawer[step], ref locationFirst, 0);
                    }
                    if (blockSchema != null)
                    {
                        blockSchema.dgvFirst.Rows.Add(firstBlocks[step]);
                        blockSchema.dgvFirst.FirstDisplayedScrollingRowIndex = blockSchema.dgvFirst.Rows.Count - 1;
                        blockSchema.dgvFirst.Refresh();
                    }


                }
                if (secondDrawer.Count() > step)
                {
                    parentForm.dbDiagramS.drawFigure = selectedListS[step].figure;
                    parentForm.dbDiagramS.AutoScrollPosition = new Point((int)selectedListS[step].figure.location.X - SolidFigure.defaultSize * 2, (int)selectedListS[step].figure.location.Y - 40);
                    parentForm.dbDiagramS.Refresh();
                    if (secondDrawer[step] is ActionBlock)
                    {
                        DrawAction(secondDrawer[step], ref locationSecond, 1);
                    }
                    if (blockSchema != null)
                    {
                        blockSchema.dgvSecond.Rows.Add(secondBlocks[step]);
                        blockSchema.dgvSecond.FirstDisplayedScrollingRowIndex = blockSchema.dgvSecond.Rows.Count - 1;
                        blockSchema.dgvSecond.Refresh();


                    }
                }
                if (thirdDrawer.Count() > step)
                {
                    parentForm.dbDiagramT.drawFigure = selectedListT[step].figure;
                    parentForm.dbDiagramT.AutoScrollPosition = new Point((int)selectedListT[step].figure.location.X - SolidFigure.defaultSize * 2, (int)selectedListT[step].figure.location.Y - 40);
                    parentForm.dbDiagramT.Refresh();
                    if (thirdDrawer[step] is ActionBlock)
                    {
                        DrawAction(thirdDrawer[step], ref locationThird, 2);
                    }
                    if (blockSchema != null)
                    {
                        blockSchema.dgvThird.Rows.Add(thirdBlocks[step]);
                        blockSchema.dgvThird.FirstDisplayedScrollingRowIndex = blockSchema.dgvThird.Rows.Count - 1;
                        blockSchema.dgvThird.Refresh();

                    }
                }

                Replace();
                form.g = graph;
                form.draw = true;
            }
            else
            {
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
        }
        private void DoAction(Block b, ref Point loc)
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
                        case 1:  if (form.dr > 1)
                            {
                                coordListSecond.Add(new Coord(loc, n_loc)); form.positionSecond = n_loc; graph.DrawLine(penSecond, point1, point2);
                                graph.DrawImage(form.imageList1.Images[num], form.startPosition.X + cellSize * form.positionSecond.X, form.startPosition.Y - 1 - cellSize * form.positionSecond.Y, cellSize - 2, cellSize - 2);
                            }
                            break;
                        case 2: if (form.dr > 2)
                            {
                                coordListThird.Add(new Coord(loc, n_loc)); form.positionThird = n_loc; graph.DrawLine(penThird, point1, point2);
                                graph.DrawImage(form.imageList1.Images[num], form.startPosition.X + cellSize * form.positionThird.X, form.startPosition.Y - 1 - cellSize * form.positionThird.Y, cellSize - 2, cellSize - 2);
                            }
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
                    case 1: if (form.dr > 1) form.positionSecond = loc; break;
                    case 2: if (form.dr > 2) form.positionThird = loc; break;
                }
                form.Invalidate();
                RefreshField();

            }
            else
            {
                throw new Exception(" Чертёжник вышел за пределы поля!");
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
            if (form.dr > 1) graph.DrawImage(form.imageList1.Images[1], form.startPosition.X + cellSize * form.positionSecond.X, form.startPosition.Y - 1 - cellSize * form.positionSecond.Y, cellSize - 2, cellSize - 2);
            if (form.dr > 2) graph.DrawImage(form.imageList1.Images[2], form.startPosition.X + cellSize * form.positionThird.X, form.startPosition.Y - 1 - cellSize * form.positionThird.Y, cellSize - 2, cellSize - 2);

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
        private void OpenProcedure(string filename)
        {
            string filenamePath = Directory.GetCurrentDirectory() + "\\" + filename + ".drawerprocedure";
            ForSaveProcedure forsave = LoadFileP(filenamePath);
            procedures[filename] = forsave.block;
        }
        private ForSaveProcedure LoadFileP(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
                return (ForSaveProcedure)new BinaryFormatter().Deserialize(fs);
        }
    }
}
