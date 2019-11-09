using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Глобальный лист для хранения состояния поля
        List<int> begin_list = new List<int> { }; 

        //Генерируем поле
        public void Initial_PictureBox() 
        {
            begin_list.Clear();
            var rnd = new Random();
            var list = new List<int> { 1, 1, 1, 2, 2, 2, 3, 3, 3 };
            for (int i = 0; i < 9; i++)
            {
                int index = rnd.Next(list.Count);
                int temp = list[index];
                list.RemoveAt(index);
                if (temp == 1)
                {
                    begin_list.Add(1);
                    ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).BackgroundImage = Image.FromFile("../../null.png");
                }
                else if (temp == 2)
                {
                    begin_list.Add(2);
                    ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).BackgroundImage = Image.FromFile("../../rope.png");
                }
                else if (temp == 3)
                {
                    begin_list.Add(3);
                    ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).BackgroundImage = Image.FromFile("../../detector.png");
                }
            }
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        public Form1()
        {
            InitializeComponent();
            Initial_PictureBox();
        }

        //Поменять расположение ловушек
        private void button2_Click(object sender, EventArgs e)
        {
            Initial_PictureBox();
        }


        //Кошка
        private void button3_Click(object sender, EventArgs e)
        {

            var rnd = new Random();
            int in_start = 5;
            int Three = 0;
            int Two = 0;
            while (true)
            {
                //Если сработала ловушка для кошки(любая, но одна должна повторяться дважды)
                if (begin_list[in_start - 1] == 3)  //Если протоплазма
                {
                    Three++;
                    if (Three == 2)
                    {
                        Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                        Pen p = new Pen(Brushes.Red, 10);
                        g.DrawLine(p, new Point(0, 0), new Point(100, 0));
                        g.DrawLine(p, new Point(0, 100), new Point(0, 0));
                        p = new Pen(Brushes.Red, 16);
                        g.DrawLine(p, new Point(100, 0), new Point(100, 100));
                        g.DrawLine(p, new Point(100, 100), new Point(0, 100));
                        Three = 0;
                    }
                }
                else if (begin_list[in_start - 1] == 2)  //Если веревка
                {
                    Two++;
                    if (Two == 2)
                    {
                        Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                        Pen p = new Pen(Brushes.Red, 10);
                        g.DrawLine(p, new Point(0, 0), new Point(100, 0));
                        g.DrawLine(p, new Point(0, 100), new Point(0, 0));
                        p = new Pen(Brushes.Red, 16);
                        g.DrawLine(p, new Point(100, 0), new Point(100, 100));
                        g.DrawLine(p, new Point(100, 100), new Point(0, 100));
                        Two = 0;
                    }
                }

                int tmp = rnd.Next(1, 5);
                if (tmp == 1)  //Вверх
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Blue,10);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(50, 0));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();
                    in_start -= 3;
                }
                else if (tmp == 2)  //Вправо
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Blue, 10);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(100, 50));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();

                    //Проверка на выход за границы
                    if (in_start == 3 || in_start == 6)
                    {
                        in_start = 0;
                    }
                    else
                    {
                        in_start++;
                    }
                }
                else if (tmp == 3) //Влево
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Blue, 10);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(0, 50));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();

                    //Проверка на выход за границы
                    if (in_start == 4 || in_start == 7)
                    {
                        in_start = 0;
                    }
                    else
                    {
                        in_start--;
                    }
                }
                else  //Вниз
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Blue, 10);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(50, 100));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();

                    in_start += 3;
                }

                if (in_start > 9 || in_start < 1)
                {
                    break; //Выход из цикла, когда он вышел за границы
                }
            }
            button3.Enabled = false;
        }


        //Вампус
        private void button4_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            int in_start = 5;
            while (true)
            {
                int tmp = rnd.Next(1, 5);

                //Если сработала ловушка для вампуса(веревка)
                if (begin_list[in_start - 1] == 2)
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Red, 10);
                    g.DrawLine(p, new Point(0, 0), new Point(100, 0));
                    g.DrawLine(p, new Point(0, 100), new Point(0, 0));
                    p = new Pen(Brushes.Red, 16);
                    g.DrawLine(p, new Point(100, 0), new Point(100, 100));
                    g.DrawLine(p, new Point(100, 100), new Point(0, 100));
                }

                if (tmp == 1)  //Вверх
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Green, 7);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(50, 0));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();
                    in_start -= 3;
                }
                else if (tmp == 2)  //Вправо
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Green, 7);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(100, 50));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();

                    //Проверка на выход за границы
                    if (in_start == 3 || in_start == 6)
                    {
                        in_start = 0;
                    }
                    else
                    {
                        in_start++;
                    }
                }
                else if (tmp == 3) //Влево
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Green, 7);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(0, 50));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();

                    //Проверка на выход за границы
                    if (in_start == 4 || in_start == 7)
                    {
                        in_start = 0;
                    }
                    else
                    {
                        in_start--;
                    }
                }
                else  //Вниз
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Green, 7);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(50, 100));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();

                    in_start += 3;
                }

                if (in_start > 9 || in_start < 1)
                {
                    break; //Выход из цикла, когда он вышел за границы
                }
            }
            button4.Enabled = false;
        }

        //Приведение
        private void button5_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            int in_start = 5;
            while (true)
            {
                //Если сработала ловушка для приведения(протоплазма)
                if (begin_list[in_start - 1] == 3)
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Red, 10);
                    g.DrawLine(p, new Point(0, 0), new Point(100, 0));
                    g.DrawLine(p, new Point(0, 100), new Point(0, 0));
                    p = new Pen(Brushes.Red, 16);
                    g.DrawLine(p, new Point(100, 0), new Point(100, 100));
                    g.DrawLine(p, new Point(100, 100), new Point(0, 100));
                }
                int tmp = rnd.Next(1, 5);
                if (tmp == 1)  //Вверх
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Yellow, 4);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(50, 0));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();
                    in_start -= 3;
                }
                else if (tmp == 2)  //Вправо
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Yellow, 4);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(100, 50));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();

                    //Проверка на выход за границы
                    if (in_start == 3 || in_start == 6)
                    {
                        in_start = 0;
                    }
                    else
                    {
                        in_start++;
                    }
                }
                else if (tmp == 3) //Влево
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Yellow, 4);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(0, 50));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();

                    //Проверка на выход за границы
                    if (in_start == 4 || in_start == 7)
                    {
                        in_start = 0;
                    }
                    else
                    {
                        in_start--;
                    }
                }
                else  //Вниз
                {
                    Graphics g = Graphics.FromImage(((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).BackgroundImage);
                    Pen p = new Pen(Brushes.Yellow, 4);
                    p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, new Point(50, 50), new Point(50, 100));
                    ((PictureBox)this.Controls["pictureBox" + in_start.ToString()]).Refresh();

                    in_start += 3;
                }

                if (in_start > 9 || in_start < 1)
                {
                    break; //Выход из цикла, когда он вышел за границы
                }
            }
            button5.Enabled = false;
        }


        //Восстановить поле боз траекторий
        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 9; i++)
            {
                if (begin_list[i] == 1)
                {
                    ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).BackgroundImage = Image.FromFile("../../null.png");
                }
                else if (begin_list[i] == 2)
                {
                    ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).BackgroundImage = Image.FromFile("../../rope.png");
                }
                else
                {
                    ((PictureBox)this.Controls["pictureBox" + (i + 1).ToString()]).BackgroundImage = Image.FromFile("../../detector.png");
                }
            }
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }
    }
}
