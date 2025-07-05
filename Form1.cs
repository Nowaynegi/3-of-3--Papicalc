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

        //important positions
        private int currentOpperatorStartingCoordinate;
        private const int UpperOpperatorRestingYCoordinate = 167;
        private const int MidOpperatorRestingYCoordinate = 212;
        private const int LowerOpperatorRestingYCoordinate = 297;
        //when operatorBox is 40x40, it rests symetrically at 358
        private const int OperatorRestingXCordinate = 358;
        private const int OperatorFullSize = 40;
        private int operatorDisplacement = 85;

        // variables for the animation! <3
        private System.Windows.Forms.Timer operatorAnimationTimer;
        private int animationFrame = 0;
        private const int TotalAnimationFrames = 10;

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
            if (animationFrame >= TotalAnimationFrames) { operatorAnimationTimer.Stop(); previousBox.Visible = false; }

            float t = animationFrame / (float)TotalAnimationFrames;

            float easedT = (float)(0.5 - 0.5 * Math.Cos(t * Math.PI));
            previousSize = new Size((int)(OperatorFullSize - OperatorFullSize * easedT), (int)(OperatorFullSize - OperatorFullSize * easedT));
            previousBox.Size = previousSize;

            previousPoint = new Point(OperatorRestingXCordinate - (previousBox.Size.Width / 2), (int)(MidOpperatorRestingYCoordinate + (operatorDisplacement) * easedT));
            previousBox.Location = previousPoint;

            currentSize = new Size((int)(OperatorFullSize * easedT), (int)(OperatorFullSize * easedT));
            currentBox.Size = currentSize;

            currentPoint = new Point(OperatorRestingXCordinate - (currentBox.Size.Width / 2), (int)(currentOpperatorStartingCoordinate + (operatorDisplacement - OperatorFullSize) * easedT));
            currentBox.Location = currentPoint;

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
            switch (keyData)
            {
                case Keys.Left:
                    operandsBoxList[selectedOperand].BackColor = Color.Snow;
                    if (selectedOperand != 0) { selectedOperand--; }
                    operandsBoxList[selectedOperand].BackColor = Color.PowderBlue;
                    return true;
                case Keys.Right:
                    operandsBoxList[selectedOperand].BackColor = Color.Snow;
                    if (selectedOperand != operandsBoxList.Count - 1) { selectedOperand++; }
                    operandsBoxList[selectedOperand].BackColor = Color.PowderBlue;
                    return true;
                case Keys.Up:
                    StartOperatorAnimation(true, LowerOpperatorRestingYCoordinate); 
                    return true; ;
                case Keys.Down:
                    StartOperatorAnimation(false, UpperOpperatorRestingYCoordinate); 
                    return true; ;
                default: break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public bool StartOperatorAnimation(bool animationUp, int startlLocY)
        {
            if (operatorAnimationTimer.Enabled)
            {
                return true; //consume
            }

            previousBox = operatorsBoxList[selectedOperator];
            if (!animationUp)
            {
                operatorDisplacement = 85;
                currentOpperatorStartingCoordinate = UpperOpperatorRestingYCoordinate;
                if (selectedOperator == 0) { selectedOperator = operatorsBoxList.Count - 1; }
                else { selectedOperator--; }
            }
            else
            {
                operatorDisplacement = -85 + OperatorFullSize;
                currentOpperatorStartingCoordinate = LowerOpperatorRestingYCoordinate;
                if (selectedOperator == operatorsBoxList.Count - 1) { selectedOperator = 0; }
                else { selectedOperator++; }
            }

            OutputBox.Text = CalculateMethods.HandleCalculation(operandsIntList[0], selectedOperator, operandsIntList[1]);

            UpdateCurrentBox();
            currentBox.Size = new Size(0, 0);
            currentBox.Location = new Point(OperatorRestingXCordinate, startlLocY);
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
