using System;
using System.ComponentModel.Design;

namespace Papicalc
{
    public partial class Form1 : Form
    {
        private static List<TextBox> operandsBoxList;
        private static int[] operandsIntList;
        private static int selectedOperand;
        private static int selectedOperator;
        private static List<PictureBox> operatorsBoxList;
        private static PictureBox previousBox;
        private static bool operatorAnimationUp;

        // variables for the animation! <3
        private System.Windows.Forms.Timer operatorAnimationTimer;
        private int animationFrame = 0;
        private const int totalAnimationFrames = 20; // Total frames for one full cycle (shrink + grow)
        private float originalOperatorPictureSize; // Stores the initial font size of the operator label

        private static int previousBoxX;
        private static int previousBoxY;


        private static int previousBoxHight;
        private static int previousBoxWidth;


        private static int currentBoxX;
        private static int currentBoxY;


        private static int currentBoxHight;
        private static int currentBoxWidth;


        public Form1()
        {
            InitializeComponent();
            KeyPress += Form1_KeyPress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //operands = new List<TextBox>();
            //operands.Add(Operand1);
            //operands.Add(Operand2);

            //operands = new List<TextBox>();
            //operands.AddRange(new TextBox[] { Operand1, Operand2 });

            //operands = new List<TextBox> { Operand1, Operand2 };

            operatorsBoxList = [OperatorBoxAdd, OperatorBoxSubtract, OperatorBoxMultipy, OperatorBoxDivide];

            operandsBoxList = [Operand1, Operand2];
            operandsIntList = new int[operandsBoxList.Count];

            selectedOperator = 0;
            selectedOperand = 0;
            operatorsBoxList[selectedOperator].Visible = true;

            /*System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            // how often a tick happens (in milliseconds)
            t.Interval = 1000;

            t.Tick += T_Tick;

            t.Start();*/

            operatorAnimationTimer = new System.Windows.Forms.Timer
            {
                Interval = 25
            };
            operatorAnimationTimer.Tick += OperatorAnimationTimer_Tick;
        }

        private void OperatorAnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (animationFrame >= totalAnimationFrames) { operatorAnimationTimer.Stop(); previousBox.Visible = false; }

            /*if (animationFrame >= totalAnimationFrames)
            {
                operatorAnimationTimer.Stop();
                previousBox.Visible = false;

                operatorsBoxList[selectedOperator].Location = new Point (358, 167); 
                operatorsBoxList[selectedOperator].Size = new Size(0,0);     
                operatorsBoxList[selectedOperator].Visible = true; 

                animationFrame = 0; 
                return;
            }*/

            float t = animationFrame / (float)totalAnimationFrames;

            float easedT = (float)(0.5 - 0.5 * Math.Cos(t * Math.PI));

            if (operatorAnimationUp == true)
            {

                previousBoxX = previousBox.Location.X - (int)((previousBox.Location.X - 358) * easedT);
                previousBoxY = previousBox.Location.Y - (int)((previousBox.Location.Y - 167) * easedT);
                previousBox.Location = new Point(previousBoxX, previousBoxY);

                previousBoxHight = previousBox.Size.Height - (int)((previousBox.Size.Height - 0) * easedT);
                previousBoxWidth = previousBox.Size.Width - (int)((previousBox.Size.Width - 0) * easedT);
                previousBox.Size = new Size(previousBoxWidth, previousBoxHight);

                currentBoxX = operatorsBoxList[selectedOperator].Location.X - (int)((operatorsBoxList[selectedOperator].Location.X - 338) * easedT);
                currentBoxY = operatorsBoxList[selectedOperator].Location.Y - (int)((operatorsBoxList[selectedOperator].Location.Y - 212) * easedT); //212 mid
                operatorsBoxList[selectedOperator].Location = new Point(currentBoxX, currentBoxY);

                currentBoxHight = operatorsBoxList[selectedOperator].Size.Height - (int)((operatorsBoxList[selectedOperator].Size.Height - 40) * easedT);
                currentBoxWidth = operatorsBoxList[selectedOperator].Size.Width - (int)((operatorsBoxList[selectedOperator].Size.Width - 40) * easedT);
                operatorsBoxList[selectedOperator].Size = new Size(currentBoxHight, currentBoxHight);

                animationFrame++;
                return;

                /*previousBox.Location = new Point(previousBox.Location.X + 1, previousBox.Location.Y - 2);
                previousBox.Size = new Size(previousBox.Size.Width - 2, previousBox.Size.Height - 2);
                operatorsBoxList[selectedOperator].Location = new Point(operatorsBoxList[selectedOperator].Location.X - 1, operatorsBoxList[selectedOperator].Location.Y - 4);
                operatorsBoxList[selectedOperator].Size = new Size(operatorsBoxList[selectedOperator].Size.Width + 2, operatorsBoxList[selectedOperator].Size.Height + 2);
                animationFrame++;
                return; */
            }

            previousBoxX = previousBox.Location.X - (int)((previousBox.Location.X - 358) * easedT);
            previousBoxY = previousBox.Location.Y - (int)((previousBox.Location.Y - 297) * easedT);
            previousBox.Location = new Point(previousBoxX, previousBoxY);

            previousBoxHight = previousBox.Size.Height - (int)((previousBox.Size.Height - 0) * easedT);
            previousBoxWidth = previousBox.Size.Width - (int)((previousBox.Size.Width - 0) * easedT);
            previousBox.Size = new Size(previousBoxWidth, previousBoxHight);

            currentBoxX = operatorsBoxList[selectedOperator].Location.X - (int)((operatorsBoxList[selectedOperator].Location.X - 338) * easedT);
            currentBoxY = operatorsBoxList[selectedOperator].Location.Y - (int)((operatorsBoxList[selectedOperator].Location.Y - 212) * easedT); //212 mid
            operatorsBoxList[selectedOperator].Location = new Point(currentBoxX, currentBoxY);

            currentBoxHight = operatorsBoxList[selectedOperator].Size.Height - (int)((operatorsBoxList[selectedOperator].Size.Height - 40) * easedT);
            currentBoxWidth = operatorsBoxList[selectedOperator].Size.Width - (int)((operatorsBoxList[selectedOperator].Size.Width - 40) * easedT);
            operatorsBoxList[selectedOperator].Size = new Size(currentBoxHight, currentBoxHight);

            animationFrame++;
            return;
            /*
            previousBox.Location = new Point(previousBox.Location.X + 1, previousBox.Location.Y + 4);
            previousBox.Size = new Size(previousBox.Size.Width - 2, previousBox.Size.Height - 2);
            operatorsBoxList[selectedOperator].Location = new Point(operatorsBoxList[selectedOperator].Location.X - 1, operatorsBoxList[selectedOperator].Location.Y + 2);
            operatorsBoxList[selectedOperator].Size = new Size(operatorsBoxList[selectedOperator].Size.Width + 2, operatorsBoxList[selectedOperator].Size.Height + 2);
            animationFrame++;
            return;
            */

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Debug.Text = e.KeyChar.ToString();

            int i;
            if (int.TryParse(e.KeyChar.ToString(), out i))
            {
                operandsBoxList[selectedOperand].Text = i.ToString();
                operandsIntList[selectedOperand] = i;

                OutputBox.Text = HandleCalculation();
            }
            e.Handled = true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                operandsBoxList[selectedOperand].BackColor = Color.Snow;
                //selectedOperand = selectedOperand-- == -1 ? selectedOperand : selectedOperand--;
                if (selectedOperand != 0) { selectedOperand--; }
                operandsBoxList[selectedOperand].BackColor = Color.PowderBlue;
                return true;
            }
            if (keyData == Keys.Right)
            {
                operandsBoxList[selectedOperand].BackColor = Color.Snow;
                if (selectedOperand != operandsBoxList.Count - 1) { selectedOperand++; }
                operandsBoxList[selectedOperand].BackColor = Color.PowderBlue;
                return true;
            }
            if (keyData == Keys.Up)
            {
                if (operatorAnimationTimer.Enabled && animationFrame <= 13)
                {
                    
                    return true;//operatorsBoxList[selectedOperator].Visible = false;
                }
                operatorAnimationUp = true;
                previousBox = operatorsBoxList[selectedOperator];
                if (selectedOperator == operatorsBoxList.Count - 1) { selectedOperator = 0; }
                else { selectedOperator++; }
                OutputBox.Text = HandleCalculation();
                operatorsBoxList[selectedOperator].Size = new Size(0, 0);
                operatorsBoxList[selectedOperator].Location = new Point(358, 297);
                operatorsBoxList[selectedOperator].Visible = true;
                animationFrame = 0;
                operatorAnimationTimer.Start();
                return true;
            }
            if (keyData == Keys.Down)
            {
                if (operatorAnimationTimer.Enabled && animationFrame <= 13)
                {
                    
                    return true;//operatorsBoxList[selectedOperator].Visible = false;
                }
                operatorAnimationUp = false;
                previousBox = operatorsBoxList[selectedOperator];
                if (selectedOperator == 0) { selectedOperator = operatorsBoxList.Count - 1; }
                else { selectedOperator--; }
                OutputBox.Text = HandleCalculation();
                operatorsBoxList[selectedOperator].Size = new Size(0, 0);
                operatorsBoxList[selectedOperator].Location = new Point(358, 167);
                operatorsBoxList[selectedOperator].Visible = true;
                animationFrame = 0;
                
                operatorAnimationTimer.Start();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public static double Calculate(double operand1, int operatorInt, double operand2)
        {
            switch (operatorInt)
            {
                case 0:
                    return operand1 + operand2;
                case 1:
                    return operand1 - operand2;
                case 2:
                    return operand1 * operand2;
                case 3:
                    if (operand2 == 0)
                    {
                        throw new DivideByZeroException("hey silly >~< don't divide by zeroo~ i dont know that one..");
                    }
                    return operand1 / operand2;
                default:
                    throw new Exception("unsupported operator! please enter + , - , * , or /");
            }
        }

        public static string HandleCalculation()
        {
            try
            {
                return Calculate(operandsIntList[0], selectedOperator, operandsIntList[1]).ToString();
            }
            catch (DivideByZeroException)
            {
                return "?";
            }
            catch (Exception)
            {
                return "??";
            }
        }
    }
}
