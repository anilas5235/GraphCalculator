﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngouriMath;
using AngouriMath.Extensions;
using System.ComponentModel;
using System.Threading;
using Antlr4.Runtime.Atn;
using static AngouriMath.Entity;

namespace GraphCalculator
{
    public partial class Form1 : Form
    {
        // Attribute
        private float graphViewHalfWidth, graphViewHalfHeight, graphViewWidth, graphViewHeight;
        private float pixelsPerUnit = 100,UnitsPerStep = 1;        
        private double originX,originY;
        private bool drag = false;
        private int zoomStufe = 0;

        private Color[] graphColors = new Color[] 
        {Color.Red,Color.Green,Color.Gold,Color.Blue,Color.Indigo,Color.LightBlue,Color.Pink,Color.Violet,
        Color.Wheat,Color.AliceBlue,Color.Beige};


        private Point oldMousePosition;        

        private Pen penBig = new Pen(Brushes.Black, 2),
                    penNormal = new Pen(Brushes.Black, 1),
                    penSmall = new Pen(Color.FromArgb(100, 0, 0, 0), 1);

        Font AxisIndictorsFont = new Font("Arital", 12, FontStyle.Bold),
             TippFont = new Font("Arital", 8, FontStyle.Bold),
             labelFont = new Font("Arital", 20, FontStyle.Bold);        

        string[] tippFunctions = new string[]
        {
            "log","sqrt","cbrt","sqr","ln","sin","cos","tan","abs","cotan","cot","sec",
            "cosec","csc","arcsin","arccos","arctan","arccotan","arcsec","arccosec","arccsc",
            "acsc","asin","acos","atan","acotan","asec","acosec","acot","arccot","sinh",
            "sh","cosh","ch","tanh","th","cotanh","coth","cth","sech","sch","cosech",
            "csch","asinh","arsinh","arsh","acosh","arcosh","arch","atanh","artanh","arth",
            "acoth","arcoth","acotanh","arcotanh","arcth","asech","arsech","arsch",
            "acosech","arcosech","arcsch","acsch","sgn","sign",
        };

        List<TextBox> functionInputs = new List<TextBox>();

        private TextBox focusedBox = null;


        public Form1()
        {
            InitializeComponent();            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GraphViewInitializing(); 
            AddFunctionSlot();
            CreateTipps(tippFunctions);
        }

        #region EventsOnInput    
        
        private void FocusedTextBoxChanged(object sender, EventArgs e)
        {
            focusedBox = sender as TextBox;
        }

        private void palGraphView_MouseDown(object sender, MouseEventArgs e)
        {
            if (!drag && e.Button == MouseButtons.Left)
            {
                oldMousePosition = e.Location;
                drag = true;
            }
        }

        private void palGraphView_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                float step = UnitsPerStep * pixelsPerUnit * .01f;
                originX += step * (e.X - oldMousePosition.X);
                originY += step*(e.Y - oldMousePosition.Y);
                oldMousePosition = e.Location;
                this.Refresh();
            }
        }
                
        private void palGraphView_MouseUp(object sender, MouseEventArgs e)
        {
            if(drag && e.Button == MouseButtons.Left) drag = false;
        }

        private void palGraphView_MouseLeave(object sender, EventArgs e)
        {
            if(drag) drag = false;
        }

        private void tbxFormula_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Zoom(object sender, MouseEventArgs e)
        {
            int delta = e.Delta > 0 ? 1 : -1;
            pixelsPerUnit += delta*pixelsPerUnit*.1f;
            if(pixelsPerUnit == 0) pixelsPerUnit = float.MinValue;            
            this.Refresh();
        }

        private void tbxFormula_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AddFunctionSlot();
            }
            else if(e.KeyCode == Keys.Delete)
            {
                TextBox textBox = sender as TextBox;
                textBox.Text = "";

                RemoveFormulaSlot(functionInputs.Count - 1);                
            }
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

        private void btnAddSlot_Click(object sender, EventArgs e)
        {
            AddFunctionSlot();
        }

        private void btndeleteSlot_Click(object sender, EventArgs e)
        {
            RemoveFormulaSlot(floloFunctions.Controls.Count - 1);
        }

        #endregion

        #region GraphViewDraws

        private void GraphViewInitializing()
        {
            palGraphView.BackColor = Color.LightGray;
            palGraphView.ForeColor = Color.Black;
            graphViewHeight = palGraphView.Size.Height;
            graphViewWidth = palGraphView.Size.Width;
            graphViewHalfHeight = graphViewHeight / 2f;
            graphViewHalfWidth = graphViewWidth / 2f;
            originX = graphViewHalfWidth;
            originY = graphViewHalfHeight;

            palGraphView.Paint += new PaintEventHandler(this.DrawGraphView);
        }

        public void DrawGraphView(object sender, PaintEventArgs e)
        {
            DrawAxis(e);

            int nextColorID = 0;

            foreach (var tbx in functionInputs)
            {
                DrawGraph(e, tbx.Text, graphColors[nextColorID]);
                nextColorID++;
                if(nextColorID >= graphColors.Length) nextColorID = 0;
            }
            
        }

        public void DrawGraph(PaintEventArgs e,string formulaText,Color graphColor)
        {           

            Pen pen = new Pen(graphColor,3);
            List<PointF> points = new List<PointF>();
            List<PointF[]> Draws = new List<PointF[]>();

            string text = formulaText;
            Entity expr;  

            try
            {
                 expr = text;
            }
            catch (Exception a)
            {
                System.Console.WriteLine("Function Parsing failed");
                return;
                throw;
            }

            Func<double,double> Function;

            try
            {
                Function = expr.Compile<double, double>("x");
            }
            catch (Exception a)
            {
                Console.WriteLine("Function Complie Failed");
                return;
                throw;
            }

            bool addToDraw = true;
            for (int x = 0; x < graphViewWidth; x++)
            {
                double xVal = (x - originX)/pixelsPerUnit;
                float y =  ((float)originY - (float)Function(xVal)*pixelsPerUnit);  
                if(float.IsNaN(y) || y == float.NegativeInfinity|| y== float.PositiveInfinity)
                {
                    if (addToDraw)
                    {
                        Draws.Add(points.ToArray());
                        points.Clear();
                        addToDraw = false;
                    }
                }
                else
                {
                    if (!addToDraw) addToDraw = true;                    
                    points.Add(new PointF(x, y));
                }                 
            }
            if(addToDraw) Draws.Add(points.ToArray());

            foreach (var draw in Draws)
            {
                if (draw.Length < 2) continue;
                try
                {
                    e.Graphics.DrawCurve(pen, draw);
                }
                catch (Exception a)
                {
                    System.Console.WriteLine("Draw Faied");
                    return;
                    throw;
                }

            }
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
                e.Graphics.DrawString(val, AxisIndictorsFont, penNormal.Brush, new PointF(positiveX - 5 * val.Length, (float)YDrawPosition));

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

            float drawOffset = 20;
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
                e.Graphics.DrawString(val, AxisIndictorsFont, penNormal.Brush, new PointF((float)XDrawPosition, positiveY - 15));

                for (float i = 1; i < 5; i++)
                {
                    float tempY = positiveY - i * smalStep;
                    e.Graphics.DrawLine(penSmall, 0, tempY, graphViewWidth, tempY);
                }
            }
        }
        #endregion

        #region FormulaSlots       

        private void AddFunctionSlot()
        {
            int index = functionInputs.Count+1;

            Panel slotPanel = new Panel();
            slotPanel.Name = $"plFunctionFormula{index}";
            slotPanel.Height = 60;
            slotPanel.Width = 730;
            
            Label slotlabel = new Label();
            slotlabel.Text = $"f{index}(x)=";
            slotlabel.Name = $"lbFunctionFormula{index}";
            slotlabel.Height = 32;
            slotlabel.Width = 90;
            slotlabel.Font = labelFont;
            slotlabel.Location = new Point(6, 13);

            slotPanel.Controls.Add(slotlabel);

            TextBox slotTextBox = new TextBox();
            slotTextBox.Name = $"tbxFunctionFormula{index}";
            slotTextBox.Width = 620;
            slotTextBox.Height = 30;
            slotTextBox.Location = new Point(102, 16);
            slotTextBox.TextChanged += tbxFormula_TextChanged;
            slotTextBox.KeyDown += tbxFormula_KeyDown;
            slotTextBox.GotFocus += FocusedTextBoxChanged;
            functionInputs.Add(slotTextBox);

            slotPanel.Controls.Add(slotTextBox);

            floloFunctions.Controls.Add(slotPanel); 
            
            slotTextBox.Focus();
        }

        private void RemoveFormulaSlot(int index)
        {
            Control toRemoveControl = floloFunctions.Controls[index];
            floloFunctions.Controls.Remove(toRemoveControl);
            toRemoveControl.Dispose();
            functionInputs.RemoveAt(index);
        }
        #endregion

        private void CreateTipps(string[] possibleFunctions)
        {

            foreach (var posFunction in possibleFunctions)
            {
                Button tippButton = new Button();
                tippButton.Text = posFunction;
                tippButton.Tag = posFunction+"(";
                tippButton.Name = $"btnTippButton{posFunction}";
                tippButton.BackColor = Color.Silver;
                tippButton.Height = 30;
                tippButton.Width = 70;
                tippButton.Font = TippFont;

                tippButton.Click += WriteTipp;
                
                flowLayoutPToolTipps.Controls.Add(tippButton);
            }
            
        }

        private void WriteTipp(object sender, EventArgs e)
        { 
            if(focusedBox != null)
            {
                focusedBox.Text += (sender as Button).Tag;
                focusedBox.Focus();
            }
        }
    }
}
