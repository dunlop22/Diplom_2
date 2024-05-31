using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_2
{
    public partial class LoadLogoForm2 : Form
    {
        public LoadLogoForm2()
        {
            InitializeComponent();
        }

        private void LoadLogoForm2_Load(object sender, EventArgs e)
        {
            //поместить форму в центр экрана
            var screen = Screen.FromControl(this);
            this.Top = screen.Bounds.Height / 2 - this.Height / 2;
            this.Left = screen.Bounds.Width / 2 - this.Width / 2;
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            this.BackColor = Color.AliceBlue;//цвет фона  
            this.TransparencyKey = this.BackColor;//он же будет заменен на прозрачный цвет
            
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;     //убрать оформление рамки

            //using (Graphics g = this.CreateGraphics())
            //{
            //    g.TranslateTransform(Properties.Resources.mikrotik_logo_2.Width, Properties.Resources.mikrotik_logo_2.Height);
            //    g.RotateTransform(-30);
            //    //g.DrawImage(Properties.Resources.mikrotik_logo_2, 0, 0);

            //    this.pictureBox1.Image = Properties.Resources.mikrotik_logo_2;
            //    //this.pictureBox1.Image;
            //}

            /*
            Bitmap bmp = new Bitmap(Properties.Resources.mikrotik_logo_2);
            bmp = RotateImage(bmp, 30);

            this.pictureBox1.BackgroundImage = bmp;

            */
            //загрузка изображения
            //Нужно задавать угол по дефолту
            //RotationAngle = 0;
            //Я картинку из ресурсов беру
            //img = Properties.Resources.mikrotik_logo_2;
            timer1.Enabled = true;
            //RotationAngle = 20;
            //pictureBox1.Invalidate();

        }
        private int ticker = 0;


        private static Bitmap RotateImage(Bitmap bmp, float angle)
        {
            var alpha = angle;

            //Для отрицательных углов поворота
            while (alpha < 0) alpha += 360;
            //Вспомогательные углы
            var gamma = 90;
            var beta = 180 - angle - gamma;

            var c1 = bmp.Height;
            //Коэффициент для пересчёта размера повёрнутого изображения
            var a1 = (float)(c1 * Math.Sin(alpha * Math.PI / 180) / Math.Sin(gamma * Math.PI / 180));
            var b1 = (float)(c1 * Math.Sin(beta * Math.PI / 180) / Math.Sin(gamma * Math.PI / 180));

            var c2 = bmp.Width;
            var a2 = (float)(c2 * Math.Sin(alpha * Math.PI / 180) / Math.Sin(gamma * Math.PI / 180));
            var b2 = (float)(c2 * Math.Sin(beta * Math.PI / 180) / Math.Sin(gamma * Math.PI / 180));

            //Новые размеры изображения
            var width = Convert.ToInt32(b2 + a1);
            var height = Convert.ToInt32(b1 + a2);
            //Новое изображение
            var retval = new Bitmap(width, height);
            //Рисуем повёрнутое изображение
            using (var g = Graphics.FromImage(retval))
            {
                g.TranslateTransform(retval.Width / 2, retval.Height / 2); //Перенос начала координат в центр изображения
                g.RotateTransform(angle); //Вращение
                g.TranslateTransform(-retval.Width / 2, -retval.Height / 2); //Возвращаем начало координат
                g.DrawImage(bmp, new Point((width - bmp.Width) / 2, (height - bmp.Height) / 2)); //Рисуем изображение
            }
            return retval;
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            //Перерисовываем PictureBox
            //pictureBox1.Invalidate();
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        /*
        public void Rotate(object sender, PaintEventArgs e)
        {
            //  e.Graphics.Clear(Color.Teal);
            this.Invoke(new Action(() => pictureBox1.Refresh()));
            int RotationAngle = 20; //угол вращения
            //Bitmap bitmap = new Bitmap(this.pictureBox1.Image, img.Width, img.Height); // создаем новый битмап   
            e.Graphics.TranslateTransform(this.pictureBox1.Image.Width / 2, this.pictureBox1.Image.Height + 200); // перемещение в picturebox
            e.Graphics.RotateTransform(Convert.ToInt32(RotationAngle / 1.5)); // угол вращения (Переменная RotationAngle)
            e.Graphics.TranslateTransform(-this.pictureBox1.Image.Width / 2, -this.pictureBox1.Image.Height - 200); // задаем точку вокруг которой осуществляется вращение
            e.Graphics.DrawImage(this.pictureBox1.Image, this.pictureBox1.Image.Width / 6, this.pictureBox1.Image.Height / 6);     // проецируем изображение
            this.pictureBox1.Image.Dispose();
        }
        */
        int RotationAngle;  //угол поворота
        Bitmap img;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ticker < 100)
            {
                //RotationAngle = 10;
                pictureBox1.Invalidate();
                //img = Properties.Resources.mikrotik_logo_2;
                //this.Rotate(se);
            }
            else
            {
                this.Close();
            }
            ticker++;
        }


        private void pictureBox1_Paint_2(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(Properties.Resources.mikrotik_logo_2);
            //bmp = RotateImage(bmp, 30);

            RotationAngle = 10;

            e.Graphics.TranslateTransform(bmp.Width * 5, bmp.Height + 200); // перемещение в форме
            e.Graphics.RotateTransform(Convert.ToInt32(RotationAngle / 1.5)); // угол вращения
            e.Graphics.TranslateTransform(-bmp.Width / 2, -bmp.Height - 200); // задаем точку вокруг которой осуществляется вращение
            e.Graphics.DrawImage(bmp, bmp.Width / 6, bmp.Height / 6); // проецируем изображение
            this.pictureBox1.BackgroundImage = bmp;
        }
    }
}
