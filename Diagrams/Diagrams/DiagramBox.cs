using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Printing;

namespace Diagrams
{
    public partial class DiagramBox : UserControl
    {
        Diagram diagram;
        //выделенная фигура
        public Figure selectedFigure = null;
        //фигура или маркер, который тащится мышью
        Figure draggedFigure = null;


        public List<Marker> markers = new List<Marker>();
        Pen selectRectPen;
        Pen drawPen;
        byte insertFigure = 0;
        public Block blocks;

        public Figure drawFigure = null;

        public DiagramBox()
        {
            InitializeComponent();

            AutoScroll = true;

            DoubleBuffered = true;
            ResizeRedraw = true;

            selectRectPen = new Pen(Color.Blue, 1);
            drawPen = new Pen(Color.Green, 2);
            
            selectRectPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
        }

        public event EventHandler SelectedChanged;

        public Figure SelectedFigure
        {
            get { return selectedFigure; }
            set
            {
                selectedFigure = value;
                //CreateMarkers();
                Invalidate();
                if (SelectedChanged != null)
                    SelectedChanged(this, new EventArgs());
            }
        }
        //диаграмма, отображаемая компонентом
        public Diagram Diagram
        {
            get { return diagram; }
            set
            {
                diagram = value;
                selectedFigure = null;
                draggedFigure = null;
                markers.Clear();
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Draw(Graphics gr)
        {
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

            if (diagram != null)
            {
                //сначала рисуем соединительные линии
                foreach (Figure f in diagram.figures)
                    if (f is LineFigure)
                        f.Draw(gr);
                //затем рисуем плоские фигуры
                foreach (Figure f in diagram.figures)
                    if (f is SolidFigure)
                        f.Draw(gr);
                //рисуем + и -
                foreach (Figure f in diagram.figures)
                    if (f is Plus)
                        f.Draw(gr);
            }

            //рисуем прямоугольник выделенной фигуры
            if (selectedFigure is SolidFigure)
            {
                SolidFigure figure = selectedFigure as SolidFigure;
                RectangleF bounds = figure.Bounds;
                gr.DrawRectangle(selectRectPen, bounds.Left - 2, bounds.Top - 2, bounds.Width + 4, bounds.Height + 4);
            }
            if (drawFigure is SolidFigure)
            {
                SolidFigure figure = drawFigure as SolidFigure;
                RectangleF bounds = figure.Bounds;
                gr.DrawRectangle(drawPen, bounds.Left - 2, bounds.Top - 2, bounds.Width + 4, bounds.Height + 4);
            }
            //рисуем маркеры
            foreach (Marker m in markers)
                try
                {
                    m.Draw(gr);
                }
                catch {; }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point location = e.Location;
            location.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);

            Focus();
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                draggedFigure = FindFigureByPoint(location);
                if (!(draggedFigure is Marker))
                {
                    selectedFigure = draggedFigure;
                    //CreateMarkers();
                }
                else
                {
                    Cursor.Hide();
                }
                if (draggedFigure is InsertMarker)
                {
                    InsertFigure(insertFigure, draggedFigure as InsertMarker);
                }
                startDragPoint = location;
                Invalidate();
                if (SelectedChanged != null)
                    SelectedChanged(this, new EventArgs());
                else
                    markers.Clear();
            }
        }
        private void InsertFigure(byte num, InsertMarker m)
        {
            SolidFigure figure = new RectFigure();
            int defaultSize = SolidFigure.defaultSize;
            Block block = null;
            switch (num)
            {
                //добавить цикл с постусловием
                case 1:
                    block = new ActionBlock(null, 0, ref figure);
                    break;
                case 2:
                    figure = new EllipseFigure();
                    break;
                case 3:
                    figure = new RectFigureFrame(); //действие
                    block = new ActionBlock(null, 0, ref figure);
                    break;
                case 4: //if else
                    figure = new RhombFigure();
                    block = new IfBlock(null, null, null, 0, ref figure);

                    break;
                case 5: //цикл с предусловием
                    figure = new RhombFigure();
                    block = new WhileBlock(null, 0, 0, ref figure, null);
                    break;
                case 6: //счётчик
                    figure = new SexangleFigure();
                    block = new ForBlock(null, 0, ref figure, null);
                    break;
                case 7: //if без ветви else
                    figure = new RhombFigure();
                    block = new IfWithoutElseBlock(null, 0, 0, ref figure, null);
                    break;
                case 8:
                    block = new ActionBlock(null, 0, ref figure);
                    break;

            }
            //вставка происходит между верхним и нижним блоками
            //в данном случае работам с верхним блоком
            LedgeLineFigure line = new LedgeLineFigure();
            LedgeLineFigure l = null;
            if (m.targetFigure.type == 1)
            {
                l = new LedgeLineFigure(); l = m.targetFigure as LedgeLineFigure;
                figure.location = new PointF(l.ledgePositionX, l.To.location.Y);
                line.From = l.From;
                line.To = figure;
                Diagram.figures.Add(figure);
                Diagram.figures.Add(line);
                if ((m.targetFigure as LineFigure).From is RhombFigure)
                {
                    LedgeLineFigure li =  FindLine(1, (m.targetFigure as LineFigure).To);
                    li.To = figure;
                    //////////
                    /////////
                    ///
                    ////
                    //////
                    ///////
                    /////
                }
            }
            if (m.targetFigure.type == 10)
            {
                l = new LedgeLineFigure(); l = m.targetFigure as LedgeLineFigure;
                figure.location = new PointF(l.From.location.X, l.From.location.Y);
                line.From = l.From;
                line.To = figure;
                //line.ledgePositionX = (m.targetFigure as LedgeLineFigure).ledgePositionX;
                Diagram.figures.Add(figure);
                Diagram.figures.Add(line);
            }
            if (m.targetFigure.type == 11)
            {
                DoubleLedgeLineFigureS l_ = new DoubleLedgeLineFigureS();
                DoubleLedgeLineFigureS line_ = new DoubleLedgeLineFigureS();
                l_ = m.targetFigure as DoubleLedgeLineFigureS;
                l = l_;
                figure.location = new PointF(l_.From.location.X, l_.To.location.Y);
                line_.ledgePositionX = l_.ledgePositionX;
                line_.From = l_.From;
                line_.To = figure;
                Diagram.figures.Add(figure);
                Diagram.figures.Add(line_);
            }
            //при добавлении блока после двойного цикла
            if (m.targetFigure.type == 13)
            {
                LedgeLineFigure l_ = new LedgeLineFigure();
                DoubleLedgeLineFigure line_ = new DoubleLedgeLineFigure();
                figure.location = findFigureHigher(m.location).location;
                l_.From = (m.targetFigure as TripleLedgeLineFigure).From;
                l_.To = figure;
                l_.ledgePositionX = (m.targetFigure as TripleLedgeLineFigure).ledgePositionX;
                //l_.ledgePositionY = (m.targetFigure as TripleLedgeLineFigure).ledgePositionY;
                l = l_;
                line_.ledgePositionX = (m.targetFigure as TripleLedgeLineFigure).secondLedgePosX;
                line_.From = figure;
                line_.To = (m.targetFigure as TripleLedgeLineFigure).To;
                Diagram.figures.Add(figure);
                Diagram.figures.Add(line_);
                MoveFiguresY(findFigureHigher(m.location));
            }
            Block from = findBlockWithGraphic(l.From, blocks);
            /*line.From = l.From;
            line.To = figure;

            Diagram.figures.Add(figure);
            Diagram.figures.Add(line);*/
            line = new LedgeLineFigure();
            line.From = figure;
            line.To = l.To;
            ///
            ///исправить
            ///неправильное nextBlock
            ///
            Block to = findBlockWithGraphic(l.To, blocks);
            if (to is Condition && m.targetFigure.type == 10)
                to = null;
            if (from is Condition && !(m.targetFigure.type == 11) && !(m.targetFigure.type == 13))
            {
                block.nextBlock = to;

                if (from is Condition && !(from is IfBlock))
                {
                    Block next = (from as Condition).trueBlock;
                    (from as Condition).trueBlock = block;
                    block.nextBlock = next;
                }
                if (from is IfBlock && block.figure.location.X < l.From.location.X) //то есть ветвь true
                {
                    Block next = (from as IfBlock).trueBlock;
                    (from as IfBlock).trueBlock = block;
                    block.nextBlock = next;
                }
                if (from is IfBlock && block.figure.location.X > l.From.location.X) //то есть ветвь false
                {
                    Block next = (from as IfBlock).falseBlock;
                    (from as IfBlock).falseBlock = block;
                    block.nextBlock = next;
                }
            }
            else
            {
                if (from is Condition && m.targetFigure.type == 11)
                {
                    Block next = (from as Condition).nextBlock;
                    (from as Condition).nextBlock = block;
                    block.nextBlock = next;
                }
                else
                {
                    block.nextBlock = to;
                    from.nextBlock = block;
                }
            }
            if (m.targetFigure.type == 10)
            {
                DoubleLedgeLineFigure l_ = new DoubleLedgeLineFigure();
                l_ = m.targetFigure as DoubleLedgeLineFigure;
                DoubleLedgeLineFigure line_ = new DoubleLedgeLineFigure();
                l = l_;
                line_.ledgePositionX = l_.ledgePositionX;
                line_.From = figure;
                line_.To = l_.To;
                line = line_;
                Diagram.figures.Add(line_);
            }
            else
            {
                if (m.targetFigure.type == 13)
                {
                    l = m.targetFigure as LedgeLineFigure;
                    DoubleLedgeLineFigureS line_ = new DoubleLedgeLineFigureS();
                    line_.From = (m.targetFigure as TripleLedgeLineFigure).From;
                    line_.To = figure;
                    line_.ledgePositionX = (m.targetFigure as TripleLedgeLineFigure).ledgePositionX;
                    Diagram.figures.Add(line_);
                }
                else
                {
                    l = m.targetFigure as LedgeLineFigure;
                    line.From = figure;
                    line.To = l.To;
                    Diagram.figures.Add(line);
                }
            }

            /*line.ledgePositionX = l.ledgePositionX;
            Diagram.figures.Add(line);*/
            if (figure.location.Y == l.From.location.Y && l.From.location.X == figure.location.X)
            {
                figure.location.Y += defaultSize + 10;
                if (figure.plus != null)
                    figure.plus.location.Y += defaultSize + 10;
                if (figure.minus != null)
                    figure.minus.location.Y += defaultSize + 10;
                MoveFiguresY(figure);
            }
            else
            if (figure.location.Y == l.To.location.Y && l.To.location.X == figure.location.X)
            {
                /*l.To.location.Y += defaultSize + 10;
                if (l.To.plus != null)
                    l.To.plus.location.Y += defaultSize + 10;
                if (l.To.minus != null)
                    l.To.minus.location.Y += defaultSize + 10;
                MoveFiguresY(l.To);*/
                MoveFiguresY(figure);
            }
            else if (figure.location.Y == l.To.location.Y && figure.location.X >= l.To.location.X + SolidFigure.defaultSize)
            {
                MoveFiguresY(figure);
            }

            //для конструкций выполняем ещё раз проверку, для дорисовки недостающих фигур
            switch (num)
            {
                case 4:
                    Branching(line, block);
                    Diagram.figures.Remove(line);
                    break;
                case 5:
                    Cycle(line, block, 1);
                    Diagram.figures.Remove(line);
                    break;
                case 6:
                    Cycle(line, block, 2);
                    Diagram.figures.Remove(line);
                    break;
                case 7:
                    BranchingWithoutElse(line, block as IfWithoutElseBlock);
                    Diagram.figures.Remove(line);
                    break;
                case 8:
                    CyclePostC(line, block);
                    Diagram.figures.Remove(line);
                    break;
            }
            CheckLines();
            Diagram.figures.Remove(l);
            MoveFiguresX();
            markers.Clear();
        }

        //отрисовка действий для IF
        private void Branching(LedgeLineFigure line, Block bl)
        {
            SolidFigure figure = new RectFigure();
            int defaultSize = SolidFigure.defaultSize;
            figure.location = new PointF(line.To.location.X - defaultSize - 30, line.To.location.Y);
            Diagram.figures.Add(figure);
            LedgeLineFigure l = new LedgeLineFigure();
            l.From = line.From;
            l.To = figure;
            l.ledgePositionX = figure.location.X;
            Diagram.figures.Add(l);
            Plus p = new Plus(l, 1);
            line.From.plus = p;
            Diagram.figures.Add(p);

            SolidFigure figure1 = new RectFigure();
            figure1.location = new PointF(line.To.location.X + defaultSize + 30, line.To.location.Y);
            Diagram.figures.Add(figure1);
            l = new LedgeLineFigure();
            l.From = line.From;
            l.To = figure1;
            l.ledgePositionX = figure1.location.X;
            Diagram.figures.Add(l);
            Minus m = new Minus(l, 1);
            l.From.minus = m;
            Diagram.figures.Add(m);

            MoveFiguresY(figure, figure1);

            l = new DoubleLedgeLineFigure();
            l.From = figure;
            l.To = line.To;
            l.ledgePositionX = line.To.location.X;
            Diagram.figures.Add(l);

            l = new DoubleLedgeLineFigure();
            l.From = figure1;
            l.To = line.To;
            l.ledgePositionX = line.To.location.X;
            Diagram.figures.Add(l);
            ActionBlock block = new ActionBlock(null, 0, ref figure);
            ActionBlock block1 = new ActionBlock(null, 0, ref figure1);

            (bl as IfBlock).trueBlock = block;
            (bl as IfBlock).falseBlock = block1;
        }
        //циклы с предусловием и с параметром имеют одинаковую структуру, кроме первого блока)
        private void Cycle(LedgeLineFigure line, Block bl, byte type)
        {
            SolidFigure figure = new RectFigure();
            int defaultSize = SolidFigure.defaultSize;
            figure.location = new PointF(line.From.location.X, line.From.location.Y);
            Diagram.figures.Add(figure);
            LedgeLineFigure l = new DoubleLedgeLineFigure();
            l.From = figure;
            l.To = line.From;
            MoveFiguresY(line.From);
            l.ledgePositionX = figure.location.X - defaultSize - 30;
            Diagram.figures.Add(l);

            if (!(((line.To is RhombFigure)  || (line.To is SexangleFigure)) && line.To.location.Y < figure.location.Y))
            {
                l = new DoubleLedgeLineFigureS();
                l.From = line.From;
                l.To = line.To;
                l.ledgePositionX = figure.location.X + defaultSize + 30;
                Diagram.figures.Add(l);
                Minus m = new Minus(l, 1);
                l.From.minus = m;
                Diagram.figures.Add(m);
            }
            else
            {
                TripleLedgeLineFigure l_ = new TripleLedgeLineFigure();
                l_.From = line.From;
                l_.To = line.To;
                l_.ledgePositionX = figure.location.X + defaultSize + 30;
                l_.secondLedgePosX = figure.location.X - defaultSize - 60;
                Block t = findBlockWithGraphic(line.To, blocks);
                l_.ledgePositionY = (t.nextBlock.figure.location.Y + figure.location.Y) / 2 - 1;
                Diagram.figures.Add(l_);
                Minus m = new Minus(l_, 1);
                l_.From.minus = m;
                Diagram.figures.Add(m);
            }

            l = new LedgeLineFigure();
            l.From = line.From;
            l.To = figure;
            l.ledgePositionX = line.From.location.X;
            Diagram.figures.Add(l);
            Plus p = new Plus(l, 2);
            line.From.plus = p;
            Diagram.figures.Add(p);
            if (type == 1)
                (bl as WhileBlock).trueBlock = new ActionBlock(null, 0, ref figure);
            if (type == 2)
                (bl as ForBlock).trueBlock = new ActionBlock(null, 0, ref figure);

        }
        //цикл с постусловием
        private void CyclePostC(LedgeLineFigure line, Block bl)
        {
            SolidFigure figure = new RhombFigure();
            int defaultSize = SolidFigure.defaultSize;
            figure.location = new PointF(line.To.location.X, line.To.location.Y);
            Diagram.figures.Add(figure);
            LedgeLineFigure l = new DoubleLedgeLineFigure();
            l.From = figure;
            l.To = line.From;
            MoveFiguresY(figure);
            l.ledgePositionX = figure.location.X - defaultSize - 30;
            Diagram.figures.Add(l);
            Plus p = new Plus(l, 2);
            l.From.plus = p;
            Diagram.figures.Add(p);

            l = new LedgeLineFigure();
            l.From = line.From;
            l.To = figure;
            l.ledgePositionX = line.From.location.X;
            Diagram.figures.Add(l);

            l = new DoubleLedgeLineFigureS();
            l.From = figure;
            l.To = line.To;
            l.ledgePositionX = figure.location.X + defaultSize + 30;
            Diagram.figures.Add(l);
            Minus m = new Minus(l, 1);
            l.From.minus = m;
            Diagram.figures.Add(m);
            DoWhileBlock doWhile = new DoWhileBlock(bl.nextBlock, 0, 0, ref figure, bl);
            bl.nextBlock = doWhile;

            //(bl as DoWhileBlock).trueBlock = new ActionBlock(null, 0, ref figure);
        }

        //ветвление без else части
        private void BranchingWithoutElse(LedgeLineFigure line, Block bl)
        {
            SolidFigure figure = new RectFigure();
            int defaultSize = SolidFigure.defaultSize;
            figure.location = new PointF(line.To.location.X + 2 * defaultSize, line.To.location.Y);
            Diagram.figures.Add(figure);
            LedgeLineFigure l = new LedgeLineFigure();
            l.From = line.From;
            l.To = figure;
            l.ledgePositionX = figure.location.X;
            Diagram.figures.Add(l);
            Plus p = new Plus(l, 3);
            line.From.plus = p;
            Diagram.figures.Add(p);
            MoveFiguresY(figure);

            l = new LedgeLineFigure();
            l.From = line.From;
            l.To = line.To;
            Diagram.figures.Add(l);
            Minus m = new Minus(l, 2);
            l.From.minus = m;
            Diagram.figures.Add(m);

            l = new DoubleLedgeLineFigureS();
            l.From = figure;
            l.To = line.To;
            l.ledgePositionX = figure.location.X;
            Diagram.figures.Add(l);
            (bl as IfWithoutElseBlock).trueBlock = new ActionBlock(null, 0, ref figure);
        }

        List<LedgeLineFigure> stopListForMoving;

        //сдвигаем все фигуры, которые находятся ниже вставленной, вниз
        public void MoveFiguresY(SolidFigure a)
        {
            stopListForMoving = new List<LedgeLineFigure>();
            int defaultSize = SolidFigure.defaultSize;
            for (int i = 0; i < Diagram.figures.Count(); i++)
            {
                if (Diagram.figures[i].type != 1 && Diagram.figures[i].type != 10 && Diagram.figures[i].type != 11 && Diagram.figures[i].type != 13 && Diagram.figures[i].type != 12 &&
                    Diagram.figures[i] as SolidFigure != a && (Diagram.figures[i] as SolidFigure).location.Y >= a.location.Y)
                {
                    findLinesToMove(Diagram.figures[i] as SolidFigure, defaultSize + 10);
                    (Diagram.figures[i] as SolidFigure).location.Y += defaultSize + 10;
                    if ((Diagram.figures[i] as SolidFigure).plus != null)
                        (Diagram.figures[i] as SolidFigure).plus.location.Y += defaultSize + 10;
                    if ((Diagram.figures[i] as SolidFigure).minus != null)
                        (Diagram.figures[i] as SolidFigure).minus.location.Y += defaultSize + 10;

                }
                /*if ((Diagram.figures[i].type == 10 || Diagram.figures[i].type == 11 || Diagram.figures[i].type == 13) &&
                    ((Diagram.figures[i] as DoubleLedgeLineFigure).From != a && (Diagram.figures[i] as DoubleLedgeLineFigure).From.location.Y >= a.location.Y ||  (Diagram.figures[i] as DoubleLedgeLineFigure).To.location.Y >= a.location.Y && (Diagram.figures[i] as DoubleLedgeLineFigure).To != a 
                    || (Diagram.figures[i] as DoubleLedgeLineFigure).ledgePositionY >= a.location.Y))
                {
                    (Diagram.figures[i] as DoubleLedgeLineFigure).ledgePositionY += defaultSize + 10;
                }*/

            }
            CalcAutoScrollPosition();
        }

        //сдвигаем все фигуры, кроме двух указанных действий
        private void MoveFiguresY(SolidFigure a, SolidFigure b)
        {
            int defaultSize = SolidFigure.defaultSize;
            for (int i = 0; i < Diagram.figures.Count(); i++)
            {
                if (Diagram.figures[i].type != 1 && Diagram.figures[i].type != 10 && Diagram.figures[i].type != 11 && Diagram.figures[i].type != 12 && Diagram.figures[i] as SolidFigure != b &&
                    Diagram.figures[i] as SolidFigure != a && (Diagram.figures[i] as SolidFigure).location.Y >= a.location.Y)
                {
                    (Diagram.figures[i] as SolidFigure).location.Y += defaultSize + 10;
                    if ((Diagram.figures[i] as SolidFigure).plus != null)
                        (Diagram.figures[i] as SolidFigure).plus.location.Y += defaultSize + 10;
                    if ((Diagram.figures[i] as SolidFigure).minus != null)
                        (Diagram.figures[i] as SolidFigure).minus.location.Y += defaultSize + 10;
                }
                if (Diagram.figures[i].type == 10 || Diagram.figures[i].type == 11 || Diagram.figures[i].type == 13)
                {
                    (Diagram.figures[i] as DoubleLedgeLineFigure).ledgePositionY += defaultSize + 10;
                }
            }
            CalcAutoScrollPosition();
        }

        private void MoveFiguresYUp(SolidFigure a)
        {
            int defaultSize = SolidFigure.defaultSize;
            for (int i = 0; i < Diagram.figures.Count(); i++)
            {
                if (Diagram.figures[i].type != 1 && Diagram.figures[i].type != 10 && Diagram.figures[i].type != 11 && Diagram.figures[i].type != 13 && Diagram.figures[i].type != 12 && 
                    Diagram.figures[i] as SolidFigure != a && (Diagram.figures[i] as SolidFigure).location.Y >= (a.location.Y + defaultSize + 10))
                {
                    (Diagram.figures[i] as SolidFigure).location.Y -= defaultSize + 10;
                    if ((Diagram.figures[i] as SolidFigure).plus != null)
                        (Diagram.figures[i] as SolidFigure).plus.location.Y -= defaultSize + 10;
                    if ((Diagram.figures[i] as SolidFigure).minus != null)
                        (Diagram.figures[i] as SolidFigure).minus.location.Y -= defaultSize + 10;
                }
                if ((Diagram.figures[i].type == 10 || Diagram.figures[i].type == 11 || Diagram.figures[i].type == 13) &&
                    ((Diagram.figures[i] as DoubleLedgeLineFigure).ledgePositionY >= a.location.Y))
                {
                    (Diagram.figures[i] as DoubleLedgeLineFigure).ledgePositionY -= defaultSize + 10;
                }
            }
            CalcAutoScrollPosition();
        }

        //Используем для сдвига по х, чтобы не выходить за "поля"
        private void MoveFiguresX()
        {
            int defaultSize = SolidFigure.defaultSize;
            float b = -1;
            for (int i = 0; i < Diagram.figures.Count(); i++)
            {
                if (Diagram.figures[i].type != 1 && Diagram.figures[i].type != 10 && Diagram.figures[i].type != 11 && Diagram.figures[i].type != 13 && Diagram.figures[i].type != 12
                    && (Diagram.figures[i] as SolidFigure).location.X - defaultSize - 20 <= 0)
                    if ((Diagram.figures[i] as SolidFigure).location.X - defaultSize - 20 < b)
                        b = (Diagram.figures[i] as SolidFigure).location.X - defaultSize - 20;
                if ((Diagram.figures[i].type == 1 || Diagram.figures[i].type == 10 || Diagram.figures[i].type == 11 || Diagram.figures[i].type == 13)
                    && (Diagram.figures[i] as LedgeLineFigure).ledgePositionX < 0 && (Diagram.figures[i] as LedgeLineFigure).ledgePositionX != -1)
                    b = (Diagram.figures[i] as LedgeLineFigure).ledgePositionX - defaultSize - 20;
            }
            if (b != -1)
            {
                for (int i = 0; i < Diagram.figures.Count(); i++)
                {
                    if (Diagram.figures[i].type != 1 && Diagram.figures[i].type != 10 && Diagram.figures[i].type != 11)
                        (Diagram.figures[i] as SolidFigure).location.X -= b;
                    else (Diagram.figures[i] as LedgeLineFigure).ledgePositionX -= b;
                }
            }
            CalcAutoScrollPosition();
        }
        //сдвигаем линии

        private void findLinesToMove(SolidFigure figure, int b)
        {
            List<LedgeLineFigure> lines = new List<LedgeLineFigure>();
            for (int i = 0; i < Diagram.figures.Count(); i++)
            {
                if (Diagram.figures[i] is LineFigure && Diagram.figures[i].type != 1 )
                {
                    /*if ((Diagram.figures[i] as DoubleLedgeLineFigure).ledgePositionY >= figure.location.Y || (Diagram.figures[i] as DoubleLedgeLineFigure).To.location.Y >= figure.location.Y)
                        lines.Add(Diagram.figures[i] as LedgeLineFigure);*/
                    if (((Diagram.figures[i] as DoubleLedgeLineFigure).To == figure || (Diagram.figures[i] as DoubleLedgeLineFigure).From == figure) && stopListForMoving.FindAll(x => x == Diagram.figures[i] as DoubleLedgeLineFigure).Count() == 0)
                    { 
                        lines.Add(Diagram.figures[i] as LedgeLineFigure);
                        stopListForMoving.Add(Diagram.figures[i] as LedgeLineFigure);
                    }
                }
            }
            moveLines(lines, b);
        }

        private void moveLines(List<LedgeLineFigure> lines, int b)
        {
            for (int i = 0; i < lines.Count(); i++)
            {
                (lines[i] as DoubleLedgeLineFigure).ledgePositionY += b;
            }
        }
        private void MoveFiguresX(int dist)
        {
            for (int i = 0; i < Diagram.figures.Count(); i++)
            {
                if (Diagram.figures[i].type != 1 && Diagram.figures[i].type != 10 && Diagram.figures[i].type != 11)
                    (Diagram.figures[i] as SolidFigure).location.X += dist;
                else
                {
                    (Diagram.figures[i] as LedgeLineFigure).ledgePositionX += dist;
                }
            }
            CalcAutoScrollPosition();
        }

        /*public void CreateMarkers()
        {
            markers = new List<Marker>();
            if (selectedFigure != null)
            {
                foreach (Marker m in selectedFigure.GetMarkers(diagram))
                    markers.Add(m);
                UpdateMarkers();
            }
        }*/
        public void CreateMarkers(byte a, Block block)
        {
            this.blocks = block;
            markers = new List<Marker>();
            insertFigure = a;
            markers = new List<Marker>();
            for (int i = 0; i < Diagram.figures.Count; i++)
            {
                if (Diagram.figures[i].type == 1 || Diagram.figures[i].type == 10 || Diagram.figures[i].type == 11 || Diagram.figures[i].type == 13)
                //if (Diagram.figures[i].type == 1)
                    {
                    InsertMarker marker = new InsertMarker();
                    marker.targetFigure = Diagram.figures[i];
                    markers.Add(marker);
                    markers.Add(marker);
                }
            }
            UpdateMarkers();
        }

        public void UpdateMarkers()
        {
            foreach (Marker m in markers)
                if (draggedFigure != m)//маркер который тащится, обновляется сам
                    m.UpdateLocation();
        }

        Point startDragPoint;

        /*protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point location = e.Location;
            location.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (draggedFigure != null && (draggedFigure is SolidFigure))
                {
                    (draggedFigure as SolidFigure).Offset(location.X - startDragPoint.X, location.Y - startDragPoint.Y);
                    UpdateMarkers();
                    Invalidate();
                    CalcAutoScrollPosition();
                }
            }
            else
            {
                Figure figure = FindFigureByPoint(location);
                if (figure is Marker)
                {
                    Cursor = (figure as Marker).Cursor;
                    if (toolTip1.GetToolTip(this) != (figure as Marker).ToolTip)
                        toolTip1.SetToolTip(this, (figure as Marker).ToolTip);
                }
                else
                {
                    if (figure != null)
                        Cursor = Cursors.Hand;
                    else
                        Cursor = Cursors.Default;

                    if (toolTip1.GetToolTip(this) != null)
                        toolTip1.SetToolTip(this, null);
                }
            }

            startDragPoint = location;
        }*/

        public void CalcAutoScrollPosition()
        {
            RectangleF r = new RectangleF(0, 0, 0, 0);
            //перебираем все фигуры, ищем максимальные координаты
            foreach (Figure f in diagram.figures)
                if (f != null && f is SolidFigure)
                    r = RectangleF.Union(r, (f as SolidFigure).Bounds);

            Size size = new Size((int)r.Width, (int)r.Height + 10);
            if (size != AutoScrollMinSize)
                AutoScrollMinSize = size;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Cursor.Show();
            draggedFigure = null;
            UpdateMarkers();
            Invalidate();
        }

        //поиск фигуры, по данной точке
        public Figure FindFigureByPoint(Point p)
        {
            //ищем среди маркеров
            for (int i = markers.Count - 1; i >= 0; i--)
                if (markers[i].IsInsidePoint(p))
                    return markers[i];
            //затем ищем среди плоских фигур
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is SolidFigure && diagram.figures[i].IsInsidePoint(p))
                    return diagram.figures[i];
            //затем ищем среди линий
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is LineFigure && diagram.figures[i].IsInsidePoint(p))
                    return diagram.figures[i];
            return null;
        }

        public void AddFigure<FigureType>(PointF location) where FigureType : SolidFigure, new()
        {
            FigureType figure = new FigureType();
            figure.location = location;
            if (diagram != null)
                diagram.figures.Add(figure);
            Invalidate();
        }

        public void SelectedBringToFront()
        {
            if (selectedFigure != null)
            {
                diagram.figures.Remove(selectedFigure);
                diagram.figures.Add(selectedFigure);
                Invalidate();
            }
        }
        public void SelectedSendToBack()
        {
            if (selectedFigure != null)
            {
                diagram.figures.Remove(selectedFigure);
                diagram.figures.Insert(0, selectedFigure);
                Invalidate();
            }
        }

        public void SelectedBeginEditText(Form form, Block blocks)
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                SolidFigure figure = (selectedFigure as SolidFigure);
                if (figure.type != 6 || figure.type == 6 && Diagram.figures[0] == figure)
                {
                    Block block = findBlockWithGraphic(figure, blocks);
                    EditBlock editBlock = new EditBlock(this, block);
                    editBlock.Owner = form; //Передаём вновь созданной форме её владельца.
                    editBlock.Show();
                }
                /*TextBox textBox = new TextBox();
                textBox.Parent = this;
                textBox.SetBounds(figure.TextBounds.Left, figure.TextBounds.Top, figure.TextBounds.Width, figure.TextBounds.Height);
                textBox.Text = figure.text;
                textBox.Multiline = true;
                textBox.TextAlign = HorizontalAlignment.Center;
                textBox.Focus();
                textBox.LostFocus += new EventHandler(textBox_LostFocus);*/
            }
        }

        public void textBox_LostFocus(object sender, EventArgs e)
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                (selectedFigure as SolidFigure).text = (sender as TextBox).Text;
            }
            Controls.Remove((Control)sender);
        }

        public void SelectedAddLine()
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                LineFigure line = new LineFigure();
                line.From = (selectedFigure as SolidFigure);
                EndLineMarker marker = new EndLineMarker(diagram, 1);
                marker.location = line.From.location;
                marker.location = marker.location.Offset(0, line.From.Size.Height / 2 + 10);
                line.To = marker;
                diagram.figures.Add(line);
                selectedFigure = line;
                //CreateMarkers();

                Invalidate();
            }
        }

        public void SelectedAddLedgeLine()
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                LedgeLineFigure line = new LedgeLineFigure();
                line.From = (selectedFigure as SolidFigure);
                EndLineMarker marker = new EndLineMarker(diagram, 1);
                marker.location = line.From.location;
                marker.location = marker.location.Offset(0, line.From.Size.Height / 2 + 10);
                line.To = marker;
                diagram.figures.Add(line);
                selectedFigure = line;
                //CreateMarkers();

                Invalidate();
            }
        }

        public void SelectedAddDoubleLedgeLine()
        {
            if (selectedFigure != null && (selectedFigure is SolidFigure))
            {
                DoubleLedgeLineFigure line = new DoubleLedgeLineFigure();
                line.From = (selectedFigure as SolidFigure);
                EndLineMarker marker = new EndLineMarker(diagram, 1);
                marker.location = line.From.location;
                marker.location = marker.location.Offset(0, line.From.Size.Height / 2 + 10);
                line.To = marker;
                diagram.figures.Add(line);
                selectedFigure = line;
                //CreateMarkers();

                Invalidate();
            }
        }
        SolidFigure f_to = null;

        public void SelectedDelete()
        {
            if (selectedFigure != null)
            {
                //удалем фигуру
                Block del = findBlockWithGraphic(selectedFigure, blocks);
                Block from = findBlockFromBlock(del, blocks);
                //если удалить все блоки из цикла, то у самого цикла не остаётся nextBlock, из-за чего всё ломается
                //нужно посмотреть, в чём ошибка
                Block to = del.nextBlock;
                if (!(from is Condition))
                    from.nextBlock = to;
                else
                {
                    if ((from is Condition) && (from as Condition).nextBlock == del)
                    {
                        from.nextBlock = to;
                    }
                    else
                        (from as Condition).trueBlock = to;
                }
                DeleteFromBlock(del, from);
                selectedFigure = null;
                draggedFigure = null;
                LedgeLineFigure li = new LedgeLineFigure();
                if (from != null && to != null)
                {
                    if (from is Condition && (from as Condition).trueBlock != to) 
                    {
                        LedgeLineFigure l = new DoubleLedgeLineFigureS();
                        l.From = from.figure;
                        l.To = f_to;
                        l.ledgePositionX = from.figure.location.X + SolidFigure.defaultSize + 30;
                        Diagram.figures.Add(l);
                    }
                    else
                    {
                        li.From = from.figure;
                        li.To = to.figure;
                        diagram.figures.Add(li);
                    }
                }
                if (to == null && !(from is EllipseBlock))
                {
                    LedgeLineFigure l = new DoubleLedgeLineFigure();
                    l.From = from.figure;
                    l.To = f_to;
                    l.ledgePositionX = from.figure.location.X - SolidFigure.defaultSize - 30;
                    Diagram.figures.Add(l);
                }
                //CreateMarkers();
                Invalidate();
            }
        }
        //удялаем также все линии, ведущие к данной фигуре
        public void DeleteLinesFromDiagam(Figure figure)
        {
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is LineFigure)
                {
                    LineFigure line = (diagram.figures[i] as LineFigure);
                    if (line.To == figure || line.From == figure)
                    {
                        if (line.From == figure)
                            f_to = line.To;
                        diagram.figures.RemoveAt(i);
                    }
                }
        }

        //удаление
        bool b = false;
        public void DeleteFromBlock(Block bl, Block from)
        {
            MoveFiguresYUp(bl.figure);
            diagram.figures.Remove(bl.figure);
            DeleteLinesFromDiagam(bl.figure);
            if (b && bl.nextBlock != null)
                DeleteFromBlock(bl.nextBlock, bl);
            if (bl is WhileBlock || bl is DoWhileBlock || bl is ForBlock || bl is IfWithoutElseBlock || bl is IfBlock)
            {
                b = true;
                diagram.figures.Remove((bl.figure as SolidFigure).minus);
                diagram.figures.Remove((bl.figure as SolidFigure).plus);
                if (bl is Condition && (bl as Condition).trueBlock != null)
                    DeleteFromBlock((bl as Condition).trueBlock, from);
                if (bl is IfBlock)
                    DeleteFromBlock((bl as IfBlock).falseBlock, from);
            }
            b = false;
        }
        //преобразуем в картинку
        public Bitmap GetImage()
        {
            selectedFigure = null;
            draggedFigure = null;
            //CreateMarkers();

            Bitmap bmp = new Bitmap(Bounds.Width, Bounds.Height);
            DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            return bmp;
        }


        //сохраняем как метафайл
        public void SaveAsMetafile(string fileName)
        {
            selectedFigure = null;
            draggedFigure = null;
            //CreateMarkers();

            Metafile curMetafile = null;
            Graphics g = this.CreateGraphics();
            IntPtr hdc = g.GetHdc();
            Rectangle rect = new Rectangle(0, 0, 200, 200);
            try
            {
                curMetafile =
                    new Metafile(fileName, hdc, System.Drawing.Imaging.EmfType.EmfOnly);
            }
            catch
            {
                g.ReleaseHdc(hdc);
                g.Dispose();
                throw;
            }

            Graphics gr = Graphics.FromImage(curMetafile);
            //отрисовываем диаграмму
            Draw(gr);

            g.ReleaseHdc(hdc);
            gr.Dispose();
            g.Dispose();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }
        /*
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (SelectedFigure == null || !(SelectedFigure is SolidFigure))
                return;
            int dx = 0;
            int dy = 0;
            if (e.KeyData == Keys.Right)
                dx = +1;
            if (e.KeyData == Keys.Left)
                dx = -1;
            if (e.KeyData == Keys.Up)
                dy = -1;
            if (e.KeyData == Keys.Down)
                dy = +1;

            if (e.KeyData == (Keys.Right | Keys.Shift))
                dx = +15;
            if (e.KeyData == (Keys.Left | Keys.Shift))
                dx = -15;
            if (e.KeyData == (Keys.Up | Keys.Shift))
                dy = -15;
            if (e.KeyData == (Keys.Down | Keys.Shift))
                dy = +15;

            if (dx != 0 || dy != 0)
            {
                (SelectedFigure as SolidFigure).Offset(dx, dy);
                UpdateMarkers();
                CalcAutoScrollPosition();
                Invalidate();
            }
        }*/

        public List<LedgeLineFigure> ListOfLines()
        {
            List<LedgeLineFigure> list = new List<LedgeLineFigure>();
            for (int i = 0; i < Diagram.figures.Count; i++)
            {
                switch (Diagram.figures[i].type)
                {
                    case 1: list.Add(Diagram.figures[i] as LedgeLineFigure); break;
                    case 10: list.Add(Diagram.figures[i] as DoubleLedgeLineFigure); break;
                    case 11: list.Add(Diagram.figures[i] as DoubleLedgeLineFigureS); break;
                    case 13: list.Add(Diagram.figures[i] as TripleLedgeLineFigure); break;
                }
            }
            list.Sort((a, b) => a.From.location.Y.CompareTo(b.From.location.Y));
            return list;
        }

        private void CheckLines()
        {
            bool move = false;
            List<LedgeLineFigure> list = ListOfLines();
            foreach (LedgeLineFigure line in list)
            {
                foreach (LedgeLineFigure item in list)
                {
                    if ((item.ledgePositionX == line.ledgePositionX || item.type == 13 &&(item as TripleLedgeLineFigure).secondLedgePosX == line.ledgePositionX)
                        && (item.From.location.Y > line.From.location.Y && (item as LedgeLineFigure).To.location.Y < line.To.location.Y) ||
                        ((item as LedgeLineFigure).To.location.Y > line.To.location.Y && (item as LedgeLineFigure).From.location.Y < line.From.location.Y))
                    {
                        if (item.ledgePositionX < item.From.location.X)
                        {
                            while ((item as LedgeLineFigure).ledgePositionX == line.ledgePositionX)
                            {
                                item.ledgePositionX -= 30;
                                move = true;
                            }
                        }
                        else
                        {
                            if (item.ledgePositionX > item.From.location.X)
                            {
                                while (item.ledgePositionX == line.ledgePositionX)
                                {
                                    line.ledgePositionX += 30;
                                }
                            }
                        }
                        if (item.type == 13 && (item as TripleLedgeLineFigure).secondLedgePosX < item.From.location.X)
                        {
                            while ((item as TripleLedgeLineFigure).secondLedgePosX == line.ledgePositionX)
                            {
                                item.ledgePositionX -= 30;
                                move = true;
                            }
                        }
                    }

                }
            }
            if (move)
                MoveFiguresX(30);
        }

        public SolidFigure findFigureHigher(PointF p)
        {
            SolidFigure f = new RectFigure();
            f.location = new PointF(0, 0);
            for (int i = 0; i < Diagram.figures.Count; i++)
            {
                if (Diagram.figures[i] is SolidFigure)
                {
                    SolidFigure fig = Diagram.figures[i] as SolidFigure;
                    if (fig.location.Y < p.Y && Math.Abs(fig.location.Y - p.Y) < Math.Abs(f.location.Y - p.Y))
                    {
                        f = fig;
                    }
                }
            }
            return f;
        }
        public Block findBlockWithGraphic(Figure figure, Block block)        
        {
            if (block == null)
                return null;
            if (block.figure == figure)
                return block;
            
            if (block is Condition)
            {
                Block b = null;
                b = findBlockWithGraphic(figure, (block as Condition).trueBlock);
                if (block is IfBlock)
                    b = findBlockWithGraphic(figure, (block as IfBlock).falseBlock);
                if (b == null)
                    return findBlockWithGraphic(figure, block.nextBlock);
                else
                    return b;
            }
            return findBlockWithGraphic(figure, block.nextBlock);
        }
        public Block findBlockFromBlock(Block bl, Block block)
        {
            if (block.nextBlock == bl)
            {
                return block;
            }
            if (block is Condition && (block as Condition).trueBlock == bl)
                return block;
            if (block is Condition)
            {
                Block b = null;
                if (block is Condition)
                {
                    b = findBlockFromBlock(bl, (block as Condition).trueBlock);
                }
                if (block is IfBlock)
                {
                    b = findBlockFromBlock(bl, (block as IfBlock).falseBlock);
                }
                if (b == null)
                    return findBlockFromBlock(bl, block.nextBlock);
                else
                    return b;
            }
            if (block.nextBlock == null)
                return null;
            return findBlockFromBlock(bl, block.nextBlock);
        }
        public LedgeLineFigure FindLine(byte type, SolidFigure figure)
        {
            for (int i = 0; i < Diagram.figures.Count(); i++)
            {
                if (Diagram.figures[i] is LedgeLineFigure && (Diagram.figures[i] as LedgeLineFigure).To != null && (Diagram.figures[i] as LedgeLineFigure).To == figure)
                {
                    return (Diagram.figures[i] as LedgeLineFigure);
                }
            }
            return null;
        }
    }
}
