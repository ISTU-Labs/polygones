using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Main
{
    public partial class Form1 : Form
    {

        private List<Figure> list;
        private bool CircleChecked = false, RectChecked = false, PolygonChecked = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (CircleChecked || RectChecked || PolygonChecked)
            {
                if (isFull())
                {
                    Figure Figure;
                    if (CircleChecked)
                    {
                        Figure = new Circle(Int32.Parse(textBox1.Text), Int32.Parse(textBox4.Text),
                            Int32.Parse(textBox2.Text), Double.Parse(textBox3.Text));
                        list.Add(Figure);
                        listBox1.Items.Add(String.Format("Добавлена фигура:  Круг"));

                    }
                    else if (RectChecked)
                    {
                        Figure = new Rectangle(Int32.Parse(textBox1.Text), Int32.Parse(textBox4.Text),
                            Int32.Parse(textBox2.Text), Double.Parse(textBox3.Text), Double.Parse(textBox5.Text));

                        list.Add(Figure);
                        listBox1.Items.Add(String.Format("Добавлена фигура:  Прямоугольник"));

                    }
                    else
                    {
                        Figure = new Polygon(Int32.Parse(textBox1.Text), Int32.Parse(textBox4.Text),
                            Int32.Parse(textBox2.Text), Double.Parse(textBox3.Text), Int32.Parse(textBox5.Text));

                        list.Add(Figure);
                        listBox1.Items.Add(String.Format("Добавлена фигура:  Правильный многоугольник"));

                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";

                }
                else
                    MessageBox.Show("Заполните все поля!", "Ошибка");
            }
            else
                MessageBox.Show("Выберите тип фигуры!", "Ошибка");
        }

        private void FigureCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FigureCombo.Text.Equals("Круг"))
            {
                CircleChecked = true;
                RectChecked = false;
                PolygonChecked = false;
                label8.Visible = false;
                label9.Visible = false;
                textBox5.Visible = false;
                label4.Text = "Радиус";

            }
            else if (FigureCombo.Text.Equals("Прямоугольник"))
            {
                CircleChecked = false;
                RectChecked = true;
                PolygonChecked = false;
                label8.Visible = true;
                label9.Visible = true;
                textBox5.Visible = true;
                label4.Text = "Сторона";
                label9.Text = "Отношение сторон:";

            }
            else if (FigureCombo.Text.Equals("Правильный многоугольник"))
            {
                CircleChecked = false;
                RectChecked = false;
                PolygonChecked = true;
                label8.Visible = true;
                label9.Visible = true;
                textBox5.Visible = true;
                label4.Text = "Радиус";
                label9.Text = "Число сторон:";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list = new List<Figure>();
        }

        private bool isFull()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                return false;
            if ((RectChecked || PolygonChecked) && textBox5.Text == "")
                return false;
            return true;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (comboBox1.Text.Equals("Круги"))
            {
                var query = from elem in list where elem.GetType() == typeof(Circle) select elem;

                if (query.Count() != 0)
                    foreach (Circle x in query)
                        listBox1.Items.Add(x.ToString());
                else
                    listBox1.Items.Add("В коллекции нет фигур данного типа");
            }
            else if (comboBox1.Text.Equals("Прямоугольники"))
            {
                var query = from elem in list where elem.GetType() == typeof(Rectangle) select elem;

                if (query.Count() != 0)
                    foreach (Rectangle x in query)
                        listBox1.Items.Add(x.ToString());
                else
                    listBox1.Items.Add("В коллекции нет фигур данного типа");
            }
            else if (comboBox1.Text.Equals("Многоугольники"))
            {

                var query = from elem in list where elem.GetType() == typeof(Polygon) select elem;

                if (query.Count() != 0)
                    foreach (Polygon x in query)
                        listBox1.Items.Add(x.ToString());
                else
                    listBox1.Items.Add("В коллекции нет фигур данного типа");
            }
            else if (comboBox1.Text.Equals("Все фигуры"))
            {
                if (list.Count != 0)
                    foreach (Figure x in list)
                        listBox1.Items.Add(x.ToString());
                else
                    listBox1.Items.Add("В коллекции нет фигур");
            }
            else
                MessageBox.Show("Выберите тип фигуры!", "Ошибка");
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            list.RemoveAt(list.Count - 1);
            listBox1.Items.Add(String.Format("Удалена последняя добавленная фигура"));
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {

            if (CircleChecked || RectChecked || PolygonChecked)
            {
                if (isFull())
                {
                    Figure Figure;
                    if (CircleChecked)
                    {
                        Figure = new Circle(Int32.Parse(textBox1.Text), Int32.Parse(textBox4.Text),
                            Int32.Parse(textBox2.Text), Double.Parse(textBox3.Text));
                        list[0] = Figure;
                        listBox1.Items.Add(String.Format("На первое место добавлена фигура:  Круг"));
                    }
                    else if (RectChecked)
                    {
                        Figure = new Rectangle(Int32.Parse(textBox1.Text), Int32.Parse(textBox4.Text),
                            Int32.Parse(textBox2.Text), Double.Parse(textBox3.Text), Double.Parse(textBox5.Text));
                        list[0] = Figure;
                        listBox1.Items.Add(String.Format("На первое место добавлена фигура:  Прямоугольник"));
                    }
                    else
                    {
                        Figure = new Polygon(Int32.Parse(textBox1.Text), Int32.Parse(textBox4.Text),
                            Int32.Parse(textBox2.Text), Double.Parse(textBox3.Text), Int32.Parse(textBox5.Text));
                        list[0] = Figure;
                        listBox1.Items.Add(String.Format("На первое место добавлена фигура:  Правильный многоугольник"));
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                }
                else
                    MessageBox.Show("Заполните все поля!", "Ошибка");
            }
            else
                MessageBox.Show("Выберите тип фигуры!", "Ошибка");
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            int x = Int32.Parse(transX.Text);
            int y = Int32.Parse(transY.Text);
            foreach (var elem in list.Where(el => el.Size != 0))
            {
                elem.X += x;
                elem.Y += y;
            }
            listBox1.Items.Add(String.Format("[{0}] Выполненен параллельный перенос на {1} по оси OX" +
                                             " и {2} по оси OY", DateTime.Now, x, y));

        }

        private void SButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var elem in list.Where(el => el.Size != 0))
                listBox1.Items.Add(String.Format("Площадь фигуры №{0:f3} = {1}",
                    list.IndexOf(elem) + 1, elem.S()));
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BaseContext DB = new BaseContext();
            var Cquery = from elem in list where elem.GetType() == typeof(Circle) select elem;
            foreach (Circle x in Cquery)
                DB.Circle.Add(x);
            var Pquery = from elem in list where elem.GetType() == typeof(Polygon) select elem;
            foreach (Polygon x in Pquery)
                DB.Polygon.Add(x);
            var Rquery = from elem in list where elem.GetType() == typeof(Rectangle) select elem;
            foreach (Rectangle x in Rquery)
                DB.Rectangle.Add(x);
            DB.SaveChanges();
        }
    }
}
