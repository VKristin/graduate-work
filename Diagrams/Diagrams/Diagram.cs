using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Diagrams
{
    //диаграмма
    [Serializable]
    public class Diagram
    {
        //список фигур диаграммы
        public List<Figure> figures = new List<Figure>();

        //сохранение диаграммы в файл
        public void Save(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
                new BinaryFormatter().Serialize(fs, this);
        }

        //чтение диаграммы из файла
        public static Diagram Load(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
                return (Diagram)new BinaryFormatter().Deserialize(fs);
        }
    }

    //фигура
    [Serializable]
    public abstract class Figure
    {
        //линии фигуры
        readonly SerializableGraphicsPath serializablePath = new SerializableGraphicsPath();
        protected GraphicsPath Path { get { return serializablePath.path; } }
        //карандаш отрисовки линий
        Color _penColor = System.Drawing.ColorTranslator.FromHtml("#262626");

        public float _penWidth = 2;
        [NonSerialized]
        protected Pen _pen;
        public byte type = 0;
        public SizeF defaultS = new SizeF(0, 0);
        public virtual Pen pen
        {
            get {
                if (_pen == null)
                    _pen = new Pen(_penColor, _penWidth);
                return _pen;
            }
        }

        public Color penColor
        {
            get { return _penColor; }
            set { _penColor = value; _pen = null; }
        }

        public float penWidth
        {
            get { return _penWidth; }
            set { _penWidth = value; _pen = null; }
        }


        //точка находится внутри фигуры?
        public abstract bool IsInsidePoint(PointF p);

        //отрисовка фигуры
        public abstract void Draw(Graphics gr);

        //получение маркеров
        //public abstract IEnumerable<Marker> GetMarkers(Diagram diagram);

        public virtual Figure Clone()
        {
            return (Figure)MemberwiseClone();
        }
    }
    //многоугольник с текстом внутри
    [Serializable]
    public abstract class SolidFigure: Figure
    {
        public Block block;
        //размер новой фигуры, по умолчанию
        public static int defaultSize;
        //заливка фигуры
        Color _color = Color.White;
        //местоположение центра фигуры
        public PointF location;
        //прямоугольник, в котором расположен текст
        protected RectangleF textRect;
        //текст
        public string text = null;
        //
        public Plus plus = null;
        public Minus minus = null;
        
        [NonSerialized]
        public Brush _brush;

        public Color color
        {
            get { return _color; }
            set { _color = value; _brush = null; }
        }

        public virtual Brush brush
        {
            get {
                if (_brush == null)
                    _brush = new SolidBrush(_color);
                return _brush;
            }
        }
        

        //настройки вывода текста
        protected virtual StringFormat StringFormat
        {
            get {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                return stringFormat;
            }
        }

        //находится ли точка внутри контура?
        public override bool IsInsidePoint(PointF p)
        {
            return Path.IsVisible(p.X - location.X, p.Y - location.Y);
        }
        
        //прямоугольник вокруг фигуры (в абсолютных координатах)
        public virtual RectangleF Bounds
        {
            get
            {
                RectangleF bounds = Path.GetBounds();
                return new RectangleF(bounds.Left + location.X, bounds.Top + location.Y, bounds.Width, bounds.Height);
            }
        }

        //прямоугольник текста (в абсолютных координатах)
        public Rectangle TextBounds
        {
            get
            {
                return new Rectangle((int)(textRect.Left + location.X), (int)(textRect.Top + location.Y), (int)textRect.Width, (int)textRect.Height);
            }
        }

        //размер прямоугольника вокруг фигуры
        public SizeF Size
        {
            get { return Path.GetBounds().Size; }
            set
            {
                SizeF oldSize = Path.GetBounds().Size;
                SizeF newSize = new SizeF(Math.Max(1, value.Width), Math.Max(1, value.Height));
                //коэффициент шкалировани по x
                float kx = newSize.Width / oldSize.Width;
                //коэффициент шкалировани по y
                float ky = newSize.Height / oldSize.Height;
                Scale(kx, ky);
            }
        }

        public void DefaultS()
        {
            if (defaultS == new SizeF(0, 0))
                defaultS = Path.GetBounds().Size;
        }

        //изменение масштаба фигуры
        public virtual void Scale(float scaleX, float scaleY)
        {
            //масштабируем линии
            Matrix m = new Matrix();
            m.Scale(scaleX, scaleY);
            Path.Transform(m);
            //масштабируем прямоугльник текста
            textRect = new RectangleF(textRect.Left * scaleX, textRect.Top * scaleY, textRect.Width * scaleX, textRect.Height * scaleY);
        }

        //сдвиг местоположения фигуры
        public virtual void Offset(float dx, float dy)
        {
            location = location.Offset(dx, dy);
            if(location.X < 0)
                location.X = 0;
            if (location.Y < 0)
                location.Y = 0;
        }

        //отрисовка фигуры
        public override void Draw(Graphics gr)
        {
            GraphicsState transState = gr.Save();
            gr.TranslateTransform(location.X, location.Y);
            gr.FillPath(brush, Path);
            gr.DrawPath(pen, Path);
            Font font = new Font("Arial", 10);

            if (!string.IsNullOrEmpty(text))
                gr.DrawString(text, font, Brushes.Black, textRect, StringFormat);
            gr.Restore(transState);
        }

        //создание маркера для изменения размера
        /*public override IEnumerable<Marker> GetMarkers(Diagram diagram)
        {
            Marker m = new SizeMarker();
            m.targetFigure = this;
            yield return m;
        }*/
    }

    //прямоугольник
    [Serializable]
    public class RectFigure : SolidFigure
    {
        public RectFigure()
        {
            type = 2;
            Path.AddRectangle(new RectangleF(-defaultSize, -defaultSize/ 2 / 1.5f, 2*defaultSize, defaultSize / 1.5f));
            textRect = new RectangleF(-defaultSize + 3, -defaultSize / 2 / 1.5f + 2, 2 * defaultSize - 6, defaultSize / 1.5f - 4);
            DefaultS();
        }
    }

    //скругленный прямоугольник
    [Serializable]
    public class RoundRectFigure : SolidFigure
    {
        public RoundRectFigure()
        {
            type = 3;
            float diameter = 16f; 
            SizeF sizeF = new SizeF( diameter, diameter );
            RectangleF arc = new RectangleF( -defaultSize, -defaultSize/2, sizeF.Width, sizeF.Height );
            Path.AddArc( arc, 180, 90 );
            arc.X = defaultSize-diameter;
            arc.X = defaultSize-diameter;
            Path.AddArc( arc, 270, 90 );
            arc.Y = defaultSize/2-diameter;
            Path.AddArc( arc, 0, 90 );
            arc.X = -defaultSize;
            Path.AddArc( arc, 90, 90 );
            Path.CloseFigure(); 

            textRect = new RectangleF(-defaultSize + 3, -defaultSize / 2 + 2, 2 * defaultSize - 6, defaultSize / 1.5f - 4);
            DefaultS();
        }
    }

    //прямоугольник с рамкой
    [Serializable]
    public class RectFigureFrame : SolidFigure
    {
        public RectFigureFrame()
        {
            type = 7;
            Path.AddRectangle(new RectangleF(-defaultSize, -defaultSize / 2 / 1.5f, 2 * defaultSize, defaultSize / 1.5f));
            Path.AddLines(new PointF[]{
                new PointF(-defaultSize + 20, defaultSize / 2/ 1.5f),
                new PointF(-defaultSize + 20, -defaultSize / 2 / 1.5f),
                new PointF(defaultSize - 20, -defaultSize / 2 / 1.5f),
                new PointF(defaultSize - 20, defaultSize / 2/ 1.5f)
            });
            Path.AddRectangle(new RectangleF(-defaultSize + 20, -defaultSize / 2 / 1.5f, 2 * defaultSize - 40, defaultSize / 1.5f));
            textRect = new RectangleF(-defaultSize + 3 + 20, -defaultSize / 2 / 1.5f + 2, 2 * defaultSize - 6 - 40, defaultSize / 1.5f - 4);
            DefaultS();
        }
    }

    //шестиугольник
    [Serializable]
    public class SexangleFigure : SolidFigure
    {
        public SexangleFigure()
        {
            type = 8;
            Path.AddPolygon(new PointF[]{
                new PointF(-defaultSize, 0),
                new PointF(-defaultSize + 40, defaultSize / 2 / 1.5f),
                new PointF(defaultSize - 40, defaultSize / 2 / 1.5f),
                new PointF(defaultSize, 0),
                new PointF(defaultSize - 40, -defaultSize / 2 / 1.5f),
                new PointF(-defaultSize + 40, -defaultSize / 2 / 1.5f)
            });
            textRect = new RectangleF(-defaultSize + 3 + 20, -defaultSize / 2 / 1.5f + 2, 2 * defaultSize - 6 - 40, defaultSize / 1.5f - 4);
            DefaultS();
        }
    }

    //ромб
    [Serializable]
    public class RhombFigure : SolidFigure
    {
        public RhombFigure()
        {
            type = 4;
            Path.AddPolygon(new PointF[]{
                new PointF(-defaultSize, 0),
                new PointF(0, -defaultSize / 2 / 1.5f),
                new PointF(defaultSize, 0),
                new PointF(0, defaultSize / 2 / 1.5f)
            });
            textRect = new RectangleF(-defaultSize/2, -defaultSize / 4 / 1.5f, defaultSize, defaultSize /2 / 1.5f);
            DefaultS();
        }
    }

    //паралелограмм
    [Serializable]
    public class ParalelogrammFigure : SolidFigure
    {
        public ParalelogrammFigure()
        {
            type = 5;
            float shift = 8f;
            Path.AddPolygon(new PointF[]{
                new PointF(-defaultSize + shift/2, -defaultSize/2),
                new PointF(defaultSize + shift/2, -defaultSize/2),
                new PointF(defaultSize - shift/2, defaultSize/2),
                new PointF(-defaultSize - shift/2, defaultSize/2),
            });
            textRect = new RectangleF(-defaultSize + shift / 2, -defaultSize / 2 + 2, 2 * defaultSize - shift, defaultSize - 4);
            DefaultS();
        }
    }

    //эллипс
    [Serializable]
    public class EllipseFigure : SolidFigure
    {
        public EllipseFigure()
        {
            type = 6;
            Path.AddEllipse(new RectangleF(-defaultSize, -defaultSize/ 2 / 1.5f, defaultSize*2, defaultSize / 1.5f));
            textRect = new RectangleF(-defaultSize / 1.4f, -defaultSize / 2 / 1.4f / 1.5f, 2 * defaultSize / 1.4f, defaultSize / 2.1f);
            DefaultS();
        }
    }

    //стопка прямоугольников
    [Serializable]
    public class StackFigure : SolidFigure
    {
        public StackFigure()
        {
            float shift = 4f;
            Path.AddRectangle(new RectangleF(-defaultSize, -defaultSize / 2, defaultSize * 2, defaultSize));
            Path.AddLines(new PointF[]{
                new PointF(-defaultSize + shift, defaultSize / 2),
                new PointF(-defaultSize + shift, defaultSize / 2 + shift),
                new PointF(defaultSize + shift, defaultSize / 2 + shift),
                new PointF(defaultSize + shift, -defaultSize / 2 + shift),
                new PointF(defaultSize, -defaultSize / 2 + shift),
                new PointF(defaultSize, defaultSize / 2)
            });

            textRect = new RectangleF(-defaultSize + 3, -defaultSize / 2 + 2, 2 * defaultSize - 6, defaultSize - 4);
        }
    }

    //рамка
    [Serializable]
    public class FrameFigure : SolidFigure
    {
        static Pen clickPen = new Pen(Color.Transparent, 3);

        protected override StringFormat StringFormat
        {
            get
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;
                return stringFormat;
            }
        }

        public FrameFigure()
        {
            Path.AddRectangle(new RectangleF(0, -defaultSize, defaultSize * 4, defaultSize*2));
            textRect = new RectangleF(0, -defaultSize, defaultSize * 4, defaultSize * 2);
        }

        public override bool IsInsidePoint(PointF p)
        {
            return Path.IsOutlineVisible(p.X - location.X, p.Y - location.Y, clickPen);
        }

        public override void Draw(Graphics gr)
        {
            GraphicsState transState = gr.Save();
            gr.TranslateTransform(location.X, location.Y);
            gr.DrawPath(pen, Path);
            if (!string.IsNullOrEmpty(text))
                gr.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, textRect, StringFormat.GenericDefault);
            gr.Restore(transState);
        }
    }

    //картинка
    [Serializable]
    public class PictureFigure : SolidFigure
    {
        string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; image = null; }
        }

        [NonSerialized]
        Image image;

        public PictureFigure():this("")
        {
        }

        public PictureFigure(string fileName)
        {
            this.fileName = fileName;
            Path.AddRectangle(new RectangleF(-defaultSize * 2, -defaultSize, 4 * defaultSize, 2 * defaultSize));
        }

        public override void Draw(Graphics gr)
        {
            if (image == null)
                if (File.Exists(fileName))
                    image = Image.FromFile(fileName);
                else
                    image = new Bitmap(1, 1);
            gr.DrawImage(image, this.Bounds);
        }

        public override void Offset(float dx, float dy)
        {
            location = location.Offset(dx, dy);
        }
    }

    [Serializable]
    public class Plus : SolidFigure
    {
        public LineFigure line;
        //Типы расположения плюса
        //Плюс слева сверху - 1
        //Плюс снизу справа - 2
        public byte plusType;
        public Plus()
        {

        }
        public Plus(LineFigure line, byte plusType)
        {
            type = 12;
            this.line = line;
            this.plusType = plusType;

            PointF pt1, pt2, pt3, pt4, pt5;
            pt1 = pt2 = pt3 = pt4 = pt5 = new PointF(0, 0);

            if (plusType == 3)
            {
                pt1 = new PointF(line.From.location.X + defaultSize + 10, line.From.location.Y - defaultSize / 8 - 5);
                pt2 = new PointF(line.From.location.X + defaultSize + 10, line.From.location.Y - defaultSize / 8 + 5);
                pt3 = new PointF(line.From.location.X + defaultSize + 5, line.From.location.Y - defaultSize / 8);
                pt4 = new PointF(line.From.location.X + defaultSize + 15, line.From.location.Y - defaultSize / 8);
                pt5 = new PointF(line.From.location.X + defaultSize + 10, line.From.location.Y - defaultSize / 8);
            }

            if (plusType == 2)
            {
                pt1 = new PointF(line.From.location.X + defaultSize / 8, line.From.location.Y + defaultSize / 3 + 15);
                pt2 = new PointF(line.From.location.X + defaultSize / 8, line.From.location.Y + defaultSize / 3 + 5);
                pt3 = new PointF(line.From.location.X + defaultSize / 8 - 5, line.From.location.Y + defaultSize / 3 + 10);
                pt4 = new PointF(line.From.location.X + defaultSize / 8 + 5, line.From.location.Y + defaultSize / 3 + 10);
                pt5 = new PointF(line.From.location.X + defaultSize / 8, line.From.location.Y + defaultSize / 3 + 10);
            }
            if (plusType == 1)
            {
                pt1 = new PointF(line.From.location.X - defaultSize - 10, line.From.location.Y - defaultSize / 8 - 5);
                pt2 = new PointF(line.From.location.X - defaultSize - 10, line.From.location.Y - defaultSize / 8 + 5);
                pt3 = new PointF(line.From.location.X - defaultSize - 5, line.From.location.Y - defaultSize / 8);
                pt4 = new PointF(line.From.location.X - defaultSize - 15, line.From.location.Y - defaultSize / 8);
                pt5 = new PointF(line.From.location.X - defaultSize - 10, line.From.location.Y - defaultSize / 8);
            }
            Path.AddLine(pt1, pt5);
            Path.AddLine(pt2, pt5);
            Path.AddLine(pt3, pt5);
            Path.AddLine(pt4, pt5);

        }
        public void RecalcPath()
        {
            PointF pt1, pt2, pt3, pt4, pt5;
            pt1 = pt2 = pt3 = pt4 = pt5 = new PointF(0, 0);


            if (plusType == 2)
            {
                pt1 = new PointF(line.From.location.X + defaultSize / 8, line.From.location.Y + defaultSize / 3 + 15);
                pt2 = new PointF(line.From.location.X + defaultSize / 8, line.From.location.Y + defaultSize / 3 + 5);
                pt3 = new PointF(line.From.location.X + defaultSize / 8 - 5, line.From.location.Y + defaultSize / 3 + 10);
                pt4 = new PointF(line.From.location.X + defaultSize / 8 + 5, line.From.location.Y + defaultSize / 3 + 10);
                pt5 = new PointF(line.From.location.X + defaultSize / 8, line.From.location.Y + defaultSize / 3 + 10);
            }
            if (plusType == 1)
            {
                pt1 = new PointF(line.From.location.X - defaultSize - 10, line.From.location.Y - defaultSize / 8 - 5);
                pt2 = new PointF(line.From.location.X - defaultSize - 10, line.From.location.Y - defaultSize / 8 + 5);
                pt3 = new PointF(line.From.location.X - defaultSize - 5, line.From.location.Y - defaultSize / 8);
                pt4 = new PointF(line.From.location.X - defaultSize - 15, line.From.location.Y - defaultSize / 8);
                pt5 = new PointF(line.From.location.X - defaultSize - 10, line.From.location.Y - defaultSize / 8);
            }
            Path.AddLine(pt1, pt5);
            Path.AddLine(pt2, pt5);
            Path.AddLine(pt3, pt5);
            Path.AddLine(pt4, pt5);
        }
    }
    [Serializable]
    public class Minus : SolidFigure
    {
        public LineFigure line;
        static Pen clickPen = new Pen(Color.Transparent, 2);

        public Minus()
        {

        }
        public Minus(LineFigure line, byte minusType)
        {
            type = 12;
            this.line = line;
            PointF pt1, pt2;
            pt1 = pt2 = new PointF(0, 0);

            if (minusType == 1)
            {
                pt1 = new PointF(line.From.location.X + defaultSize + 5, line.From.location.Y - defaultSize / 8);
                pt2 = new PointF(line.From.location.X + defaultSize + 15, line.From.location.Y - defaultSize / 8);
            }
            if (minusType == 2)
            {
                pt1 = new PointF(line.From.location.X + defaultSize / 8 + 5, line.From.location.Y + defaultSize / 3 + 10);
                pt2 = new PointF(line.From.location.X + defaultSize / 8 + 15, line.From.location.Y + defaultSize / 3 + 10);
            }

            Path.AddLine(pt1, pt2);
        }
        public void RecalcPath()
        {
            PointF pt3, pt4;
            pt3 = new PointF(line.From.location.X + defaultSize + 5, line.From.location.Y - defaultSize / 8);
            pt4 = new PointF(line.From.location.X + defaultSize + 15, line.From.location.Y - defaultSize / 8);
            Path.AddLine(pt3, pt4);
        }
    }
    //соединительная линия
    [Serializable]
    public class LineFigure : Figure
    {
        public SolidFigure From;
        public SolidFigure To;
        static Pen clickPen = new Pen(Color.Transparent, 2);
        public override void Draw(Graphics gr)
        {
            if (From == null || To == null)
                return;

            RecalcPath();
            gr.DrawPath(pen, Path);
        }
        public LineFigure()
        {
            type = 1;
        }

        public override bool IsInsidePoint(PointF p)
        {
            if (From == null || To == null)
                return false;

            RecalcPath();
            return Path.IsOutlineVisible(p, clickPen);
        }

        public virtual void RecalcPath()
        {
            PointF[] points = null;
            if(Path.PointCount>0)
                points = Path.PathPoints;
            if(Path.PointCount!=2 || points[0]!=From.location || points[1]!=To.location)
            {
                Path.Reset();
                Path.AddLine(From.location, To.location);
            }
        }

        /*public override IEnumerable<Marker> GetMarkers(Diagram diagram)
        {
            EndLineMarker m1 = new EndLineMarker(diagram, 0);
            m1.targetFigure = this;
            yield return m1;

            EndLineMarker m2 = new EndLineMarker(diagram, 1);
            m2.targetFigure = this;
            yield return m2;

        }*/
    }

    //линия с "переломом"
    [Serializable]
    public class LedgeLineFigure : LineFigure
    {
        //координата X точки "перелома"
        public float ledgePositionX = -1;

        public LedgeLineFigure()
        {
            type = 1;
        }
        public override void RecalcPath()
        {
            
            PointF[] points = null;

            if (ledgePositionX < 0)
                ledgePositionX = (From.location.X + To.location.X) / 2;
            if (Math.Abs(From.location.X - To.location.X) < 1)
                ledgePositionX = From.location.X;

            if (Path.PointCount > 0)
                points = Path.PathPoints;
            if (Path.PointCount != 4 || points[0] != From.location || points[3] != To.location ||
                points[1].X!=ledgePositionX)
            {
                Path.Reset();
                Path.AddLines(new PointF[]{
                    From.location,
                    new PointF(ledgePositionX, From.location.Y),
                    new PointF(ledgePositionX, To.location.Y),
                    To.location
                    });
                CreateArrows();
            }
        }
        public void CreateArrows()
        {
            //добавляем дополнительные линии для стрелочки в зависимости от конечной координаты
            PointF p = new PointF();
            if (ledgePositionX == To.location.X)
                p = new PointF(To.location.X, To.location.Y - SolidFigure.defaultSize / 2 / 1.5f);
            if (ledgePositionX > To.location.X)
                p = new PointF(To.location.X + SolidFigure.defaultSize, To.location.Y);
            if (ledgePositionX < To.location.X)
                p = new PointF(To.location.X - SolidFigure.defaultSize, To.location.Y);
            PointF pt = new PointF(p.X + 8, To.location.Y + 7);
            if (ledgePositionX > To.location.X)
            {
                Path.AddLine(p, pt);
                pt = new PointF(p.X + 4, p.Y - 9);
                Path.AddLine(p, pt);
            }
            if (ledgePositionX < To.location.X)
            {
                pt = new PointF(p.X - 9, p.Y + 4);
                Path.AddLine(p, pt);
                pt = new PointF(p.X - 9, p.Y - 4);
                Path.AddLine(p, pt);
            }
            if (ledgePositionX == To.location.X && From.location.Y < To.location.Y)
            {
                pt = new PointF(p.X - 4, p.Y - 9);
                Path.AddLine(p, pt);
                pt = new PointF(p.X + 4, p.Y - 9);
                Path.AddLine(p, pt);
            }
            if (ledgePositionX == To.location.X && From.location.Y > To.location.Y)
            {
                p = new PointF(To.location.X, To.location.Y + SolidFigure.defaultSize / 2);
                pt = new PointF(p.X - 4, p.Y + 9);
                Path.AddLine(p, pt);
                pt = new PointF(p.X + 4, p.Y + 9);
                Path.AddLine(p, pt);
            }
        }

        /*public override IEnumerable<Marker> GetMarkers(Diagram diagram)
        {
            RecalcPath();
            EndLineMarker m1 = new EndLineMarker(diagram, 0);
            m1.targetFigure = this;
            yield return m1;

            EndLineMarker m2 = new EndLineMarker(diagram, 1);
            m2.targetFigure = this;
            yield return m2;

            LedgeMarker m3 = new LedgeMarker();
            m3.targetFigure = this;
            m3.UpdateLocation();
            yield return m3;
        }*/
    }

    //линия с двойным "переломом"
    [Serializable]
    public class DoubleLedgeLineFigure : LedgeLineFigure
    {
        public float ledgePositionY = -1;
        public override void RecalcPath()
        {
            type = 10;
            PointF[] points = null;

            if (ledgePositionX < 0)
                ledgePositionX = (From.location.X + To.location.X) / 2.2f;
            if (ledgePositionY < 0)
                ledgePositionY = From.location.Y + SolidFigure.defaultSize / 2.2f;

            if (Path.PointCount > 0)
                points = Path.PathPoints;
            if (Path.PointCount != 4 || points[0] != From.location || points[3] != To.location ||
                points[1].X != ledgePositionX)
            {
                Path.Reset();
                Path.AddLines(new PointF[]{
                    From.location,
                    new PointF(From.location.X, ledgePositionY),
                    new PointF(ledgePositionX, ledgePositionY),
                    new PointF(ledgePositionX, To.location.Y),
                    To.location
                    });
                CreateArrows();
            }
        }
    }

    //линия с двойным "переломом" для выхода из цикла
    [Serializable]

    public class DoubleLedgeLineFigureS : DoubleLedgeLineFigure
    {
        public override void RecalcPath()
        {
            type = 11;
            PointF[] points = null;

            if (Path.PointCount > 0)
                points = Path.PathPoints;
            if (ledgePositionY < 0)
                ledgePositionY = To.location.Y - SolidFigure.defaultSize + SolidFigure.defaultSize / 2;
            if (Path.PointCount != 4 || points[0] != From.location || points[3] != To.location ||
                points[1].X != ledgePositionX)
            {
                Path.Reset();
                Path.AddLines(new PointF[]{
                    From.location,
                    new PointF(ledgePositionX, From.location.Y),
                    new PointF(ledgePositionX, ledgePositionY),
                    new PointF(To.location.X, ledgePositionY),
                    To.location
                    });
                CreateArrow();
            }
        }
        public void CreateArrow()
        {
            PointF p = new PointF(To.location.X, To.location.Y - SolidFigure.defaultSize/ 2 / 1.5f);
            PointF pt = new PointF(p.X - 4, p.Y - 9);
            Path.AddLine(p, pt);
            pt = new PointF(p.X + 4, p.Y - 9);
            Path.AddLine(p, pt);
        }
    }
    [Serializable]

    public class TripleLedgeLineFigure: DoubleLedgeLineFigure
    {
        public float secondLedgePosX = -1;
        public override void RecalcPath()
        {
            type = 13;
            PointF[] points = null;

            if (ledgePositionX < 0)
                ledgePositionX = (From.location.X + To.location.X) / 2.2f;
            if (ledgePositionY < 0)
                ledgePositionY = From.location.Y + SolidFigure.defaultSize / 2f;
            if (secondLedgePosX < 0)
                secondLedgePosX = (From.location.X + To.location.X) / 2;

            if (Path.PointCount > 0)
                points = Path.PathPoints;
            if (ledgePositionY < 0)
                ledgePositionY = To.location.Y - SolidFigure.defaultSize + SolidFigure.defaultSize / 2;
            if (Path.PointCount != 4 || points[0] != From.location || points[3] != To.location ||
                points[1].X != ledgePositionX)
            {
                Path.Reset();
                Path.AddLines(new PointF[]{
                    From.location,
                    new PointF(ledgePositionX, From.location.Y),
                    new PointF(ledgePositionX, ledgePositionY),
                    new PointF(secondLedgePosX, ledgePositionY),
                    new PointF(secondLedgePosX, To.location.Y),
                    To.location
                    });
                CreateArrow();
            }
        }
        public void CreateArrow()
        {
            PointF p = new PointF(To.location.X - SolidFigure.defaultSize, To.location.Y);
            PointF pt = new PointF(p.X - 9, p.Y + 4);
            Path.AddLine(p, pt);
            pt = new PointF(p.X - 9, p.Y - 4);
            Path.AddLine(p, pt);
        }
    }

    //сериализуемая обертка над GraphicsPath
    [Serializable]
    public class SerializableGraphicsPath: ISerializable
    {
        public GraphicsPath path = new GraphicsPath();

        public SerializableGraphicsPath()
        {
        }

        private SerializableGraphicsPath(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount > 0)
            {
                PointF[] points = (PointF[])info.GetValue("p", typeof(PointF[]));
                byte[] types = (byte[])info.GetValue("t", typeof(byte[]));
                path = new GraphicsPath(points, types);
            }
            else
                path = new GraphicsPath();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (path.PointCount > 0)
            {
                info.AddValue("p", path.PathPoints);
                info.AddValue("t", path.PathTypes);
            }
        }
    }


    [Serializable]
    public abstract class Marker : SolidFigure
    {
        protected static new int defaultSize = 3;
        public Figure targetFigure;
         

        public Marker()
        {
            color = Color.Black;
        }

        public virtual string ToolTip
        {
            get { return "Добавить блок"; }
        }
        public virtual System.Windows.Forms.Cursor Cursor
        {
            get {
                return System.Windows.Forms.Cursors.SizeNWSE;
            }
        }

        public override bool IsInsidePoint(PointF p)
        {
            if (p.X < location.X - defaultSize || p.X > location.X + defaultSize)
                return false;
            if (p.Y < location.Y - defaultSize || p.Y > location.Y + defaultSize)
                return false;

            return true;
        }

        public override void Draw(Graphics gr)
        {
            //обычные маркеры - эллипсы
            gr.DrawEllipse(Pens.Black, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
            gr.FillEllipse(brush, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
        }

        public abstract void UpdateLocation();
    }

    //маркер для вставки элемента
    public class InsertMarker: Marker 
    {
        public Color markerColor;

        public InsertMarker(Color color)
        {
            markerColor = color;
        }
        public override void UpdateLocation()
        {
            LedgeLineFigure line = (targetFigure as LedgeLineFigure);
            if (line.To is SexangleFigure || line.To is RhombFigure)
                location = new PointF(line.To.location.X, line.From.location.Y + SolidFigure.defaultSize / 2 - 5);
            else
                location = new PointF(line.ledgePositionX, (line.From.location.Y + line.To.location.Y) / 2);
            //if (line.ledgePositionX == (line.From.location.X + line.To.location.X) / 2) //добавить, когда условия в целом смогут быть другими
            if (line.type == 11 && (line.From is SexangleFigure || line.From is RhombFigure))
                location = new PointF(line.To.location.X, line.To.location.Y - SolidFigure.defaultSize / 2 + 5);
            if (line.type == 13)
                location = new PointF(((line as TripleLedgeLineFigure).secondLedgePosX + (line as TripleLedgeLineFigure).ledgePositionX) / 2, (line as TripleLedgeLineFigure).ledgePositionY);
            if (line.type == 1 && line.From is RhombFigure && line.ledgePositionX == line.From.location.X)
                location = new PointF(line.From.location.X, line.To.location.Y - SolidFigure.defaultSize/2);
        }
        public override void Draw(Graphics gr)
        {
            //обычные маркеры - эллипсы
            Brush br = new SolidBrush(markerColor);
            gr.DrawEllipse(Pens.Black, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
            gr.FillEllipse(br, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
        }
        public override Cursor Cursor
        {
            get
            {
                return Cursors.Hand;
            }
        }
    }
    public class SizeMarker : Marker
    {
        public override void UpdateLocation()
        {
            RectangleF bounds = (targetFigure as SolidFigure).Bounds;
            location = new PointF(bounds.Right + defaultSize / 2, bounds.Bottom + defaultSize / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);
            (targetFigure as SolidFigure).Size =
                SizeF.Add((targetFigure as SolidFigure).Size, new SizeF(dx * 2, dy * 2));
        }
        public override void Draw(Graphics gr)
        {
            //маркеры размера - квадраты
            gr.DrawRectangle(Pens.Black, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
            gr.FillRectangle(brush, location.X - defaultSize, location.Y - defaultSize, defaultSize * 2, defaultSize * 2);
        }
    }

    /// <summary>
    /// Есть вероятность, что это где-то здесь
    /// </summary>
    [Serializable]
    public class EndLineMarker : Marker
    {
        int pointIndex;
        Diagram diagram;

        public EndLineMarker(Diagram diagram, int pointIndex)
        {
            this.diagram = diagram;
            this.pointIndex = pointIndex;
        }

        public override void UpdateLocation()
        {
            LineFigure line = (targetFigure as LineFigure);
            if (line.From == null || line.To == null)
                return;//не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            SolidFigure figure = pointIndex == 0 ? line.From : line.To;
            location = figure.location;
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, dy);

            //ищем фигуру под маркером
            SolidFigure figure = null;
            for (int i = diagram.figures.Count - 1; i >= 0; i--)
                if (diagram.figures[i] is SolidFigure && diagram.figures[i].IsInsidePoint(location))
                {
                    figure = (SolidFigure)diagram.figures[i];
                    break;
                }

            LineFigure line = (targetFigure as LineFigure);
            if (figure == null)
                figure = this;//если под маркером нет фигуры, то просто коннектим линию к самому маркеру

            //не позволяем конектится самому к себе
            if (line.From == figure || line.To == figure)
                return;
            //обновляем конекторы линии
            if (pointIndex == 0)
                line.From = figure;
            else
                line.To = figure;

        }
    }

    [Serializable]
    public class LedgeMarker : Marker
    {
        public override void UpdateLocation()
        {
            LedgeLineFigure line = (targetFigure as LedgeLineFigure);
            if (line.From == null || line.To == null)
                return;//не обновляем маркеры оторванных концов
            //фигура, с которой связана линия
            location = new PointF(line.ledgePositionX, (line.From.location.Y + line.To.location.Y) / 2);
        }

        public override void Offset(float dx, float dy)
        {
            base.Offset(dx, 0);
            (targetFigure as LedgeLineFigure).ledgePositionX += dx;
        }
    }

    public static class GraphicsPathHelper
    {
        public static void Transform(this GraphicsPath path, Func<PointF, PointF> func, bool accuracy)
        {
            //для более точных рассчетов, можно сделать Flatten
            if (accuracy)
                path.Flatten();
            //получаем точки изображения
            var data = path.PathData;
            //выполняем преобразование над каждой точкой
            for (int i = 0; i < data.Points.Length; i++)
                data.Points[i] = func.Invoke(data.Points[i]);
            //очищаем исходный контур
            path.Reset();
            //создаем новый конутр и присоединяем к исходному
            path.AddPath(new GraphicsPath(data.Points, data.Types), false);
        }

        public static void Transform(this GraphicsPath path, Func<PointF, PointF> func)
        {
            Transform(path, func, false);
        }
    }

    public static class PointHelper
    {
        public static PointF Offset(this PointF p, float x, float y)
        {
            p.X = p.X + x;
            p.Y = p.Y + y;
            return p;
        }

        public static float Length(this PointF p)
        {
            return (float)Math.Sqrt(p.X * p.X + p.Y * p.Y);
        }

        public static PointF Sub(this PointF p, PointF p1)
        {
            return new PointF(p.X-p1.X, p.Y - p1.Y);
        }

        public static PointF Mult(this PointF p, float k)
        {
            return new PointF(k*p.X, k*p.Y);
        }

        public static PointF Mult(this PointF p, float kx, float ky)
        {
            return new PointF(kx * p.X, ky * p.Y);
        }

        public static PointF Add(this PointF p, PointF p1)
        {
            return new PointF(p.X + p1.X, p.Y + p1.Y);
        }

        public static float FromTo(this float k, float a, float b)
        {
            return (a * (1 - k) + b * k);
        }

        public static PointF FromTo(this float k, PointF a, PointF b)
        {
            return new PointF(k.FromTo(a.X, b.X), k.FromTo(a.Y, b.Y));
        }

        public static string FirstCharUpper(this string s)
        {
            if(string.IsNullOrEmpty(s))
                return s;
            if(s.Length==1)
                return s.ToUpper();

            return char.ToUpper(s[0]) + s.Substring(1);
        }


        public static float Angle(this PointF A, PointF B)
        {
            return (float)(180f * (Math.Atan2(A.Y, A.X) - Math.Atan2(B.Y, B.X)) / Math.PI);
        }

        public static PointF[] FlipByX(this PointF[] points)
        {
            Array.Reverse(points);
            for (int i = 0; i < points.Length; i++)
                points[i].X *= -1f;
            return points;
        }

        
    }
}
