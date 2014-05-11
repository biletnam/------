using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace kursach
{
    public partial class OtchetForm : Form
    {
        public OtchetForm()
        {
            InitializeComponent();
        }

        private void OtchetForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Graph = CreateGraphics();
            Graphics graph = panel1.CreateGraphics();
            ////Это карандашы от тонкого до толстого для сетки и фигур
            Pen bold_pen = new Pen(Brushes.Black, 3);
            Pen middle_pen = new Pen(Brushes.Black, 2);
            Pen think_pen = new Pen(Brushes.Black, 1);  
            Font _textfont = new Font("Arial", 10);          
            ////Масштаб
            int scale = panel1.Width / 12;
            int scale2 = panel1.Height / 6;
            Point X0Y0 = new Point(panel1.Width / 2, panel1.Height / 2);
            //Строим ось Х
            graph.DrawLine(middle_pen, new Point(0, panel1.Height / 2), new Point(panel1.Width, panel1.Height / 2));
            //Строим ось Y
            graph.DrawLine(middle_pen, new Point(1, 0), new Point(1, panel1.Height));
            //Строим координатную сетку вдоль Х
            for (int i = 0; i <= panel1.Height; i++)
            {
                
                graph.DrawLine(think_pen, new Point(0, i * scale2), new Point(panel1.Width, i * scale2));
                graph.DrawString(i.ToString(), _textfont, Brushes.DarkMagenta, 0, i * scale2);
            }
            //Строим координатную сетку вдоль Y
            for (int i = 0; i <= panel1.Width; i++)
            {
                graph.DrawLine(think_pen, new Point(i * scale, 0), new Point(i * scale, panel1.Height));
                graph.DrawString((i + 1).ToString(), _textfont, Brushes.DarkMagenta, i * scale, panel1.Height / 2);
                }
        }
    }
}
