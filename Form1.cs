using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen1 = new Pen(Color.Blue, 1);
            Pen pen2 = new Pen(Color.Black, 1);

            double x1 = 10;
            double y1 = 1000;
            double x2 = 1500;
            double y2 = 100;
            double h = 0.1;
            int n = 14;
            double trashhold = 20;

            g.DrawEllipse(pen2, (int)x1, (int)y1, 3, 3);
            g.DrawEllipse(pen2, (int)x2, (int)y2, 3, 3);

            double x = Math.Abs(x1 - x2);
            double y = Math.Abs(y1 - y2);
            
            double angle = aTan(n, y / x);
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            double s = sinOur(n, angle);
            double c = cosOur(n, angle);
            while (true)
            {                             
                y1 += h * s;
                x1 += h * c;
                g.DrawEllipse(pen1, (int)x1, (int)y1, 1, 1);
                x = Math.Abs(x1 - x2);
                y = Math.Abs(y1 - y2);
                double distance1 = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                
                if (distance1 > distance)
                    break;
                distance = distance1;               
            }
            distance = (double)distance;
            label1.Text = distance.ToString();
        }
        int factorial(int n)
        {
            if (n <= 1)
                return 1;
            else
                return n * factorial(n - 1);
        }
        double sinOur(int n, double x)
        {
            double sin = 0.0d;
            for (int i = 1; i < n + 1; i++)
                sin =sin + Math.Pow(-1, i) * Math.Pow(x, 2 * i - 1) / factorial(2 * i - 1);
            return sin;
        }
        double cosOur(int n, double x)
        {
            double cos = 0.0d;
            for (int i = 1; i < n + 1; i++)
                cos += Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 2) / factorial(2 * i - 2);
            return cos;
        }

        double aTan(int n, double x)
        {
            double atan = 0.0d;
            
            for (int i = 1; i < n + 1; i++)
                atan = atan + Math.Pow(-1, i - 1) * Math.Pow(x, 2 * i - 1) / (2 * i - 1);
            return atan;
        }

        double aCTan(int n, double x)
        {
            return Math.PI / 2 - aTan(n, x);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
