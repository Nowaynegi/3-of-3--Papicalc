using System;
using System.ComponentModel.Design;

namespace Papicalc
{
    public partial class Form1 : Form
    {
        private List<TextBox> operandsBoxList;
        public int[] operandsIntList;
        private int selectedOperand;
        public int selectedOperator;
        private List<PictureBox> operatorsBoxList;
        private PictureBox previousBox;
        private PictureBox currentBox;
        private bool operatorAnimationUp;

        //important positions
        private int OpperatorEndpointYCoordinate;
        private int UpperOpperatorEndpointYCoordinate = 167;
        private int MidOpperatorEndpointYCoordinate = 212;
        private int LowerOpperatorEndpointYCoordinate = 297;
        //when operatorBox is 40x40, it rests symetrically at 358
        private int Operator4040XCordinate = 358;

        // variables for the animation! <3
        private System.Windows.Forms.Timer operatorAnimationTimer;
        private int animationFrame = 0;
        private const int totalAnimationFrames = 20;

        private Point previousPoint;
        private Size previousSize;

        private Point currentPoint;
        private Size currentSize;

        public Form1()
        {
            InitializeComponent();
            KeyPress += Form1_KeyPress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            operatorsBoxList = [OperatorBoxAdd, OperatorBoxSubtract, OperatorBoxMultipy, OperatorBoxDivide];

            operandsBoxList = [Operand1, Operand2];
            operandsIntList = new int[operandsBoxList.Count];

            selectedOperator = 0;
            selectedOperand = 0;
            operatorsBoxList[selectedOperator].Visible = true;

            operatorAnimationTimer = new System.Windows.Forms.Timer
            {
                Interval = 25
            };
            operatorAnimationTimer.Tick += OperatorAnimationTimer_Tick;
        }

        private void OperatorAnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (animationFrame >= totalAnimationFrames) { operatorAnimationTimer.Stop(); previousBox.Visible = false; }

            float t = animationFrame / (float)totalAnimationFrames;

            float easedT = (float)(0.5 - 0.5 * Math.Cos(t * Math.PI));

            if (operatorAnimationUp == true)
            {
                OpperatorEndpointYCoordinate = UpperOpperatorEndpointYCoordinate;
            }
            else { OpperatorEndpointYCoordinate = LowerOpperatorEndpointYCoordinate; }

                previousPoint = new Point(previousBox.Location.X - (int)((previousBox.Location.X - Operator4040XCordinate) * easedT), previousBox.Location.Y - (int)((previousBox.Location.Y - OpperatorEndpointYCoordinate) * easedT));
                previousBox.Location = previousPoint;

                previousSize = new Size(previousBox.Size.Height - (int)((previousBox.Size.Height - 0) * easedT), previousBox.Size.Width - (int)((previousBox.Size.Width - 0) * easedT));
                previousBox.Size = previousSize;

                currentPoint = new Point(currentBox.Location.X - (int)((currentBox.Location.X - Operator4040XCordinate + 20) * easedT), currentBox.Location.Y - (int)((currentBox.Location.Y - MidOpperatorEndpointYCoordinate) * easedT));
                currentBox.Location = currentPoint;

                currentSize = new Size(currentBox.Size.Height - (int)((currentBox.Size.Height - 40) * easedT), currentBox.Size.Width - (int)((currentBox.Size.Width - 40) * easedT));
                currentBox.Size = currentSize;

                animationFrame++;
                return;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Debug.Text = e.KeyChar.ToString();

            int i;
            if (int.TryParse(e.KeyChar.ToString(), out i))
            {
                operandsBoxList[selectedOperand].Text = i.ToString();
                operandsIntList[selectedOperand] = i;

                OutputBox.Text = CalculateMethods.HandleCalculation(operandsIntList[0], selectedOperator, operandsIntList[1]);
            }
            e.Handled = true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left)
            {
                operandsBoxList[selectedOperand].BackColor = Color.Snow;
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
                return StartOperatorAnimation(true, LowerOpperatorEndpointYCoordinate);
            }
            if (keyData == Keys.Down)
            {
                return StartOperatorAnimation(false, UpperOpperatorEndpointYCoordinate);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public bool StartOperatorAnimation(bool animationUp, int startlLocY)
        {
            if (operatorAnimationTimer.Enabled && animationFrame <= 13)
            {
                return true;
            }

            previousBox = operatorsBoxList[selectedOperator];
            if (!animationUp)
            {
                if (selectedOperator == 0) { selectedOperator = operatorsBoxList.Count - 1; }
                else { selectedOperator--; }
            }
            else
            {
                if (selectedOperator == operatorsBoxList.Count - 1) { selectedOperator = 0; }
                else { selectedOperator++; }
            }
            OutputBox.Text = CalculateMethods.HandleCalculation(operandsIntList[0], selectedOperator, operandsIntList[1]);

            operatorAnimationUp = animationUp;
            UpdateCurrentBox();
            currentBox.Size = new Size(0, 0);
            currentBox.Location = new Point(358, startlLocY);
            currentBox.Visible = true;
            animationFrame = 0;
            operatorAnimationTimer.Start();

            return true;
        }

        public void UpdateCurrentBox()
        {
            currentBox = operatorsBoxList[selectedOperator];
        }
    }
}
