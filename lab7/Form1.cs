using System.Drawing;
using System.IO;
using System.Text;
using static lab7.Shape;

namespace lab7
{
    public partial class Form1 : Form
    {
        const string filename = "data.txt";
        GroupShape shapes = new GroupShape();
        ShapeFactory shapeFactory = new ShapeFactory();
        public int objectSize = 10;
        public bool Cntrl;
        Color color = Color.Red;
        Color red = Color.Red;
        Color green = Color.Green;
        Color purple = Color.RebeccaPurple;
        Color black = Color.Chocolate;
        int colorIndex = 0;
        int selectedFigure = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            shapes.DrawShapes(e);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Cntrl)
            {
                shapes.SetConditionForAll(false);

                switch (selectedFigure)
                {
                    case 0:
                        CCircle newcircle = new CCircle(e.X, e.Y, objectSize, color);
                        newcircle.setCondition(true);
                        shapes.AddShape(newcircle);
                        break;
                    case 1:
                        CSquare newsquare = new CSquare(e.X, e.Y, objectSize, color);
                        newsquare.setCondition(true);
                        shapes.AddShape((newsquare));
                        break;
                    case 2:
                        CTriangle newtriangle = new CTriangle(e.X, e.Y, objectSize, color);
                        newtriangle.setCondition(true);
                        shapes.AddShape((newtriangle));
                        break;
                    case 3:
                        CSection newsection = new CSection(e.X, e.Y, objectSize, color);
                        newsection.setCondition(true);
                        shapes.AddShape((newsection));
                        break;
                }
                Refresh();
            }
            else if (Cntrl) // Выделение кругов, если зажат cntrl
            {
                shapes.SelectShapesCtrl(e);
                Refresh();
            }
        }

        private void odjectSize_tb_Scroll(object sender, EventArgs e)
        {
            objectSize = odjectSize_tb.Value;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrlPush_cb.Checked = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                ctrlPush_cb.Checked = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                shapes.DelShape();
                Refresh();
            }
            else if (e.KeyCode == Keys.Up)
            {
                shapes.MoveShapes('u', 0);
                Refresh();
            }
            else if (e.KeyCode == Keys.Down)
            {
                shapes.MoveShapes('d', (int)this.ClientSize.Height);
                Refresh();
            }
            else if (e.KeyCode == Keys.Left)
            {
                shapes.MoveShapes('l', 0);
                Refresh();
            }
            else if (e.KeyCode == Keys.Right)
            {
                shapes.MoveShapes('r', (int)this.ClientSize.Width);
                Refresh();
            }

            else if (e.KeyCode == Keys.Oemplus)
            {
                shapes.EditSize('+');
                Refresh();
            }
            else if (e.KeyCode == Keys.OemMinus)
            {
                shapes.EditSize('-');
                Refresh();
            }
        }

        private void ctrlPush_cb_CheckedChanged(object sender, EventArgs e)
        {
            Cntrl = ctrlPush_cb.Checked;
            shapes.PressCtrl(Cntrl);
        }

        private void plus_btn_Click(object sender, EventArgs e)
        {
            shapes.EditSize('+');
            Refresh();
        }

        private void minus_btn_Click(object sender, EventArgs e)
        {
            shapes.EditSize('-');
            Refresh();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            shapes.DelShape();
            Refresh();
        }

        private void selectAll_btn_Click(object sender, EventArgs e)
        {
            shapes.SetConditionForAll(true);
            Refresh();
        }

        private void unselectAll_btn_Click(object sender, EventArgs e)
        {
            shapes.SetConditionForAll(false);
            Refresh();
        }

        private void circle_btn_Click(object sender, EventArgs e)
        {
            selectedFigure = 0;
        }

        private void square_btn_Click(object sender, EventArgs e)
        {
            selectedFigure = 1;
        }

        private void triangle_btn_Click(object sender, EventArgs e)
        {
            selectedFigure = 2;
        }

        private void section_btn_Click(object sender, EventArgs e)
        {
            selectedFigure = 3;
        }

        private void color_btn_Click(object sender, EventArgs e)
        {
            if (colorIndex < 3)
                colorIndex++;
            else
                colorIndex = 0;
            switch (colorIndex)
            {
                case 0:
                    color = red;
                    break;
                case 1:
                    color = green;
                    break;
                case 2:
                    color = purple;
                    break;
                case 3:
                    color = black;
                    break;
            }
            color_btn.BackColor = color;
            shapes.SetColor(color);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (FileStream fs = File.Open(filename, FileMode.Open))
            {

            }
            shapes.LoadAll(filename, shapeFactory);
            using (FileStream fs = File.Create(filename))
            {

            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter streamW = new StreamWriter(filename))
            {
                shapes.SaveAll(streamW);
            }
        }
    }

    public class ShapeFactory
    {
        public Shape CreateShape(char code)
        {
            Shape shape = null;
            switch (code)
            {
                case 'c':
                    shape = new CCircle(0, 0, 0, Color.Black);
                    break;
                case 's':
                    shape = new CSquare(0, 0, 0, Color.Black);
                    break;
                case 't':
                    shape = new CTriangle(0, 0, 0, Color.Black);
                    break;
                case 'o':
                    shape = new CSection(0, 0, 0, Color.Black);
                    break;
                default:
                    break;
            }
            return shape;
        }
    }

    public class GroupShape
    {
        public List<Shape> shapes = new List<Shape>();

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public void DelShape()
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].selected == true)
                {
                    shapes.Remove(shapes[i]);
                    i--;
                }
            }
        }

        public void EditSize(char sign)
        {
            if (sign == '+')
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.selected && shape.rad < 95)
                    {
                        shape.rad += 5;
                    }
                }
            }
            else if (sign == '-')
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.selected && shape.rad > 10)
                    {
                        shape.rad -= 5;
                    }
                }
            }
        }

        public void DrawShapes(PaintEventArgs e)
        {
            foreach (Shape shape in shapes)
            {
                shape.SelfDraw(e.Graphics);
            }
        }

        public void SetConditionForAll(bool cond)
        {
            foreach (Shape shape in shapes)
            {
                shape.setCondition(cond);
            }
        }

        public void SelectShapesCtrl(MouseEventArgs e)
        {
            foreach (Shape shape in shapes)
            {
                if (shape.MouseCheck(e))
                {
                    shape.setCondition(true);
                    //break;
                }
            }
        }

        public void PressCtrl(bool ct)
        {
            foreach (Shape shape in shapes)
            {
                shape.pushCtrl = ct;
            }
        }

        public void MoveShapes(char direction, int FormSize)
        {
            if (direction == 'u')
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.selected && ((shape.coords.Y - shape.rad) > 0))
                    {
                        shape.coords.Y -= 3;
                    }
                }
            }
            else if (direction == 'd')
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.selected && ((shape.coords.Y + shape.rad) < FormSize))
                    {
                        shape.coords.Y += 3;
                    }
                }
            }
            else if (direction == 'l')
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.selected && ((shape.coords.X - shape.rad) > 0))
                    {
                        shape.coords.X -= 3;
                    }
                }
            }
            else if (direction == 'r')
            {
                foreach (Shape shape in shapes)
                {
                    if (shape.selected && ((shape.coords.X + shape.rad) < FormSize))
                    {
                        shape.coords.X += 3;
                    }
                }
            }
        }

        public void SetColor(Color color)
        {
            foreach (Shape shape in shapes)
            {
                if (shape.selected)
                {
                    shape.colorUnSelected = color;
                }
            }
        }

        public void SaveAll(StreamWriter stream)
        {
            stream.WriteLine($"{shapes.Count}");
            foreach (Shape shape in shapes)
            {
                shape.SelfSave(stream);
            }
        }

        public void LoadAll(string filename, ShapeFactory factory)
        {
            using (StreamReader stream = new StreamReader(filename))
            {
                int count;
                char code;
                Shape shape;
                count = int.Parse(stream.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    if (char.TryParse(stream.ReadLine(), out code))
                    {
                        shape = factory.CreateShape(code);
                        if (shape != null)
                        {
                            shape.SelfLoad(stream);
                            AddShape(shape);
                        }
                    }
                }

            }
        }

    }

    public class Shape
    {
        public Point coords;
        public int rad;
        public bool selected = false;
        public bool pushCtrl = false;
        public Color colorSelected = Color.Cyan;
        public Color colorUnSelected = Color.Black;

        public void setCondition(bool cond) // метод переключения выделения
        {
            selected = cond;
        }
        public virtual void SelfDraw(Graphics g) // Метод для отрисовки самого себя
        {

        }
        public virtual bool MouseCheck(MouseEventArgs e) // Проверка объекта на попадание в него курсора
        {
            return false;
        }
        public virtual void SelfSave(StreamWriter stream)
        {

        }
        public virtual void SelfLoad(StreamReader stream)
        {

        }

        public class CCircle : Shape// класс круга
        {
            public CCircle(int x, int y, int radius, Color color) // конструктор по умолчанию
            {
                coords.X = x;
                coords.Y = y;
                rad = radius;
                colorUnSelected = color;
            }
            public override void SelfDraw(Graphics g) // Метод для отрисовки самого себя
            {
                if (selected == true)
                    g.DrawEllipse(new Pen(colorSelected, 3), coords.X - rad, coords.Y - rad, rad * 2, rad * 2);
                else
                    g.DrawEllipse(new Pen(colorUnSelected, 3), coords.X - rad, coords.Y - rad, rad * 2, rad * 2);
            }
            public override bool MouseCheck(MouseEventArgs e) // Проверка объекта на попадание в него курсора
            {
                if (pushCtrl)
                {
                    if (Math.Pow(e.X - coords.X, 2) + Math.Pow(e.Y - coords.Y, 2) <= Math.Pow(rad, 2) && !selected)
                    {
                        selected = true;
                        return true;
                    }
                }
                return false;
            }
            public override void SelfSave(StreamWriter stream)
            {
                stream.WriteLine("c");
                stream.WriteLine($"{coords.X} {coords.Y} {rad}");
            }
            public override void SelfLoad(StreamReader stream)
            {
                string[] values = stream.ReadLine().Split(' ');
                coords.X = int.Parse(values[0]);
                coords.Y = int.Parse(values[1]);
                rad = int.Parse(values[2]);
            }

        }

        public class CSquare : Shape // класс квадрата
        {
            public CSquare(int x, int y, int radius, Color color) // конструктор по умолчанию
            {
                coords.X = x;
                coords.Y = y;
                rad = radius;
                colorUnSelected = color;
            }
            public override void SelfDraw(Graphics g) // Метод для отрисовки самого себя
            {
                if (selected == true)
                    g.DrawRectangle(new Pen(colorSelected, 3), coords.X - rad, coords.Y - rad, rad * 2, rad * 2);
                else
                    g.DrawRectangle(new Pen(colorUnSelected, 3), coords.X - rad, coords.Y - rad, rad * 2, rad * 2);

            }
            public override bool MouseCheck(MouseEventArgs e) // Проверка объекта на попадание в него курсора
            {
                if (pushCtrl)
                {
                    if (Math.Pow(e.X - coords.X, 2) + Math.Pow(e.Y - coords.Y, 2) <= Math.Pow(rad, 2) && !selected)
                    {
                        selected = true;
                        return true;
                    }
                }
                return false;
            }
            public override void SelfSave(StreamWriter stream)
            {
                stream.WriteLine("s");
                stream.WriteLine($"{coords.X} {coords.Y} {rad}");
            }
            public override void SelfLoad(StreamReader stream)
            {
                string[] values = stream.ReadLine().Split(' ');
                coords.X = int.Parse(values[0]);
                coords.Y = int.Parse(values[1]);
                rad = int.Parse(values[2]);
            }
        }

        public class CTriangle : Shape // класс треугольника
        {
            public CTriangle(int x, int y, int radius, Color color) // конструктор по умолчанию
            {
                coords.X = x;
                coords.Y = y;
                rad = radius;
                colorUnSelected = color;
            }
            public override void SelfDraw(Graphics g) // Метод для отрисовки самого себя
            {
                Point point1 = new Point(coords.X, coords.Y - rad);
                Point point2 = new Point(coords.X + rad, coords.Y + rad);
                Point point3 = new Point(coords.X - rad, coords.Y + rad);
                Point[] curvePoints = { point1, point2, point3 };

                if (selected == true)
                    g.DrawPolygon(new Pen(colorSelected, 3), curvePoints);
                else
                    g.DrawPolygon(new Pen(colorUnSelected, 3), curvePoints);
            }
            public override bool MouseCheck(MouseEventArgs e) // Проверка объекта на попадание в него курсора
            {
                if (pushCtrl)
                {
                    if (Math.Pow(e.X - coords.X, 2) + Math.Pow(e.Y - coords.Y, 2) <= Math.Pow(rad, 2) && !selected)
                    {
                        selected = true;
                        return true;
                    }
                }
                return false;
            }
            public override void SelfSave(StreamWriter stream)
            {
                stream.WriteLine("t");
                stream.WriteLine($"{coords.X} {coords.Y} {rad}");
            }
            public override void SelfLoad(StreamReader stream)
            {
                string[] values = stream.ReadLine().Split(' ');
                coords.X = int.Parse(values[0]);
                coords.Y = int.Parse(values[1]);
                rad = int.Parse(values[2]);
            }
        }

        public class CSection : Shape // класс отрезка
        {
            public CSection(int x, int y, int radius, Color color) // конструктор по умолчанию
            {
                coords.X = x;
                coords.Y = y;
                rad = radius;
                colorUnSelected = color;
            }
            public override void SelfDraw(Graphics g) // Метод для отрисовки самого себя
            {
                Point point1 = new Point(coords.X - rad, coords.Y);
                Point point2 = new Point(coords.X + rad, coords.Y);
                Point[] curvePoints = { point1, point2 };

                if (selected == true)
                    g.DrawPolygon(new Pen(colorSelected, 3), curvePoints);
                else
                    g.DrawPolygon(new Pen(colorUnSelected, 3), curvePoints);
            }
            public override bool MouseCheck(MouseEventArgs e) // Проверка объекта на попадание в него курсора
            {
                if (pushCtrl)
                {
                    if (Math.Pow(e.X - coords.X, 2) + Math.Pow(e.Y - coords.Y, 2) <= Math.Pow(rad, 2) && !selected)
                    {
                        selected = true;
                        return true;
                    }
                }
                return false;
            }
            public override void SelfSave(StreamWriter stream)
            {
                stream.WriteLine("o");
                stream.WriteLine($"{coords.X} {coords.Y} {rad}");
            }
            public override void SelfLoad(StreamReader stream)
            {
                string[] values = stream.ReadLine().Split(' ');
                coords.X = int.Parse(values[0]);
                coords.Y = int.Parse(values[1]);
                rad = int.Parse(values[2]);
            }
        }
    }
}