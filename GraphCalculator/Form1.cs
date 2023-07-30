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
        private float pixelsPerUnit = 100,UnitsPerStep = 1;        
        private double originX,originY;
        private PaintEventHandler painter;
        private Point oldMousePosition;
        private bool drag = false;
        private int zoomStufe = 0;

        private Pen penBig = new Pen(Brushes.Black, 2),
                    penNormal = new Pen(Brushes.Black, 1),
                    penSmall = new Pen(Color.FromArgb(100, 0, 0, 0), 1);
        Font font = new Font("Arital", 12, FontStyle.Bold);
        public Form1()
        {
            InitializeComponent();
        }

        private float graphViewHalfWidth, graphViewHalfHeight, graphViewWidth, graphViewHeight;

        private void Zoom(object sender, MouseEventArgs e)
        {
            int delta = e.Delta > 0 ? 1 : -1;
            pixelsPerUnit += delta*pixelsPerUnit*.1f;
            if(pixelsPerUnit == 0) pixelsPerUnit = float.MinValue;
            System.Diagnostics.Debug.WriteLine($"pixelsPerUnit {pixelsPerUnit}");
            this.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            float step = UnitsPerStep * pixelsPerUnit*.1f;

            if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.W) originY += step; 
            else if(e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.S) originY -= step;
            if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D) originX -= step;
            else if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.A) originX += step;

            this.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            picbGraphView.BackColor = Color.LightGray;
            picbGraphView.ForeColor = Color.Black;
            graphViewHeight = picbGraphView.Size.Height;
            graphViewWidth = picbGraphView.Size.Width;
            graphViewHalfHeight = graphViewHeight / 2f;
            graphViewHalfWidth  = graphViewWidth / 2f;
            originX = graphViewHalfWidth;
            originY = graphViewHalfHeight;

            painter =new PaintEventHandler(this.DrawGraph);
            picbGraphView.Paint += painter;        
        }
        public void DrawGraph(object sender,PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red,3);
            List<PointF> points = new List<PointF>();            
            
            for (int x = 0; x < graphViewWidth; x++)
            {
                double xVal = (x - originX)/pixelsPerUnit;
                float y =  ((float)originY - (float)GraphFunction(xVal)*pixelsPerUnit);                  
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

            float steps = graphViewHalfWidth / (pixelsPerUnit * UnitsPerStep);
            if (steps > 6) { UnitsPerStep *= 2f; zoomStufe--; }
            else if (steps < 3) { UnitsPerStep *= .5f;zoomStufe++; }
            steps = graphViewHalfWidth / (pixelsPerUnit * UnitsPerStep);

            DrawXAxis(e);
            DrawYAxis(e);
        }

        private void DrawXAxis(PaintEventArgs e) 
        { 
            float step = UnitsPerStep*pixelsPerUnit;
            float smalStep = step / 5;

            float drawOffset = 20;
            double YDrawPosition = originY-drawOffset;
            if (YDrawPosition < -1) YDrawPosition = -1;
            else if(YDrawPosition > graphViewHeight-drawOffset) YDrawPosition = graphViewHeight -drawOffset;

            e.Graphics.DrawLine(penBig, 0, (float)originY, graphViewWidth, (float)originY);


            double offset = (originX / step) -(int) (originX / step);

            for (float j = -1; j < (graphViewWidth/step)+2; j++)
            {
                float positiveX = (float)((j + offset) * step);
                e.Graphics.DrawLine(penNormal, positiveX, 0, positiveX, graphViewHeight);
                string val = Math.Round((positiveX - originX) / pixelsPerUnit, zoomStufe<=0? 0 : zoomStufe).ToString();
                if (val == "0") val = "";
                e.Graphics.DrawString(val, font, penNormal.Brush, new PointF(positiveX - 5 * val.Length, (float)YDrawPosition));

                for (float i = 1; i < 5; i++)
                {
                    float tempX = i * smalStep + positiveX;
                    e.Graphics.DrawLine(penSmall, tempX, 0, tempX, graphViewHeight);
                }
            }        

        }

        private void DrawYAxis(PaintEventArgs e)
        {
            float step = UnitsPerStep * pixelsPerUnit;
            float smalStep = step / 5;

            float drawOffset = -5;
            double XDrawPosition = originX - drawOffset;
            if (XDrawPosition < -1) XDrawPosition = -1;
            else if (XDrawPosition > graphViewWidth - drawOffset) XDrawPosition = graphViewWidth - drawOffset;

            double offset = (originY /step) - (int)(originY / step);

            e.Graphics.DrawLine(penBig, (float)originX, 0, (float)originX, graphViewHeight);

            
            for (float j = -1; j < (graphViewHeight/step)+2; j++)
            {
                float positiveY = (float)((j+offset) * step);

                e.Graphics.DrawLine(penNormal, 0, positiveY, graphViewWidth, positiveY);
                
                string val = Math.Round(-1 * (positiveY - originY) / pixelsPerUnit, zoomStufe <= 0 ? 0 : zoomStufe).ToString();
                if (val == "0") val = ""; 
                e.Graphics.DrawString(val, font, penNormal.Brush, new PointF((float)XDrawPosition, positiveY - 15));

                for (float i = 1; i < 5; i++)
                {
                    float tempY = positiveY - i * smalStep;
                    e.Graphics.DrawLine(penSmall, 0, tempY, graphViewWidth, tempY);
                }
            }
        }  
    }
}
