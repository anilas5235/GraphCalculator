using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphCalculator
{
    public partial class Form1 : Form
    {
        private double zoomFactor = 1d;
        private PaintEventHandler painter;
        public Form1()
        {
            InitializeComponent();
        }

        private float graphViewHalfWidth, graphViewHalfHeight, graphViewWidth, graphViewHeight;

        private void Zoom(object sender, MouseEventArgs e)
        {
            zoomFactor += e.Delta*0.001*zoomFactor;
            if (zoomFactor < .01d) zoomFactor = 0.01d;
            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            picbGraphView.BackColor = Color.LightGray;
            picbGraphView.ForeColor = Color.Black;
            graphViewHalfHeight = picbGraphView.Size.Height / 2;
            graphViewHalfWidth = picbGraphView.Size.Width / 2;
            graphViewHeight = picbGraphView.Size.Height;
            graphViewWidth = picbGraphView.Size.Width;

            painter =new PaintEventHandler(this.DrawGraph);
            picbGraphView.Paint += painter;        
        }
        public void DrawGraph(object sender,PaintEventArgs e)
        {
            Pen pen = new Pen(Brushes.Black);
            List<PointF> points = new List<PointF>();
            
            for (int x = 0; x < picbGraphView.Size.Width; x++)
            {
                float y = (float)(graphViewHalfHeight - GraphFunction((x - graphViewHalfWidth) * zoomFactor));
                if (y > graphViewHalfHeight) y = graphViewHalfHeight + 1;
                else if (y < -graphViewHalfHeight) y = -graphViewHalfHeight - 1;
                points.Add(new PointF(x,y));
            }
            double GraphFunction(double x)
            {
                return Math.Pow(x,2);
            }
            e.Graphics.DrawCurve(pen, points.ToArray());

            DrawAxis(e);
        }

        private void DrawAxis(PaintEventArgs e)
        {
            Pen pen = new Pen(Brushes.Black);

            e.Graphics.DrawCurve(pen, new PointF[] {
                new PointF(0,graphViewHalfHeight),
                new PointF(graphViewWidth,graphViewHalfHeight) });
            e.Graphics.DrawCurve(pen, new PointF[] {
                new PointF(graphViewHalfWidth,0),
                new PointF(graphViewHalfWidth,graphViewHeight) });
        }
    }
}
