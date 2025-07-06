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
        private int currentOperatorStartingCoordinate;
        private const int UpperOperatorRestingYCoordinate = 167;
        private const int MidOperatorRestingYCoordinate = 212;
        private const int LowerOperatorRestingYCoordinate = 297;
        //when operatorBox is 40x40, it rests symetrically at 358
        private const int OperatorRestingCenterXCoordinate = 358;
        private const int OperatorRestingXCoordinate = OperatorRestingCenterXCoordinate - OperatorFullSize / 2;  // top left x = center x - half the width
        private const int OperatorFullSize = 40;
        private int operatorDisplacement = 85;

        // variables for the animation! <3
        private System.Windows.Forms.Timer operatorAnimationTimer;
        private int animationFrame = 0;
        private const int TotalAnimationFrames = 10;

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

            foreach (var opBox in operatorsBoxList)
            {
                opBox.Visible = false;
            }
            operatorsBoxList[selectedOperator].Visible = true;
            operatorsBoxList[selectedOperator].Size = new Size(OperatorFullSize, OperatorFullSize);
            operatorsBoxList[selectedOperator].Location = new Point(OperatorRestingXCoordinate, MidOperatorRestingYCoordinate);

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
            float inverseEasedT = 1 - easedT;
            previousBox.Size = new Size((int)(OperatorFullSize * inverseEasedT), (int)(OperatorFullSize * inverseEasedT));

            previousBox.Location = new Point(OperatorRestingCenterXCoordinate - ((int)(OperatorFullSize * inverseEasedT) / 2), (int)(MidOperatorRestingYCoordinate + (operatorDisplacement) * easedT));

            currentBox.Size = new Size((int)(OperatorFullSize * easedT), (int)(OperatorFullSize * easedT));

            currentBox.Location = new Point(OperatorRestingCenterXCoordinate - (int)(OperatorFullSize * easedT / 2), (int)(currentOperatorStartingCoordinate + (operatorDisplacement - OperatorFullSize) * easedT));

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
                    selectedOperand = (selectedOperand - 1 + operandsBoxList.Count) % operandsBoxList.Count; // the modulo allows you to cycle nya~ //if (selectedOperand > 0) { selectedOperand--; }
                    operandsBoxList[selectedOperand].BackColor = Color.PowderBlue;
                    return true;
                case Keys.Right:
                    operandsBoxList[selectedOperand].BackColor = Color.Snow;
                    selectedOperand = (selectedOperand + 1) % operandsBoxList.Count; // if (selectedOperand != operandsBoxList.Count - 1) { selectedOperand++; }
                    operandsBoxList[selectedOperand].BackColor = Color.PowderBlue;
                    return true;
                case Keys.Up:
                    StartOperatorAnimation(true);
                    return true; ;
                case Keys.Down:
                    StartOperatorAnimation(false);
                    return true; ;
                default: break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //in the future, the generic startanimation method might need to take a starting coordinate, although it might be better for it to simply just take an object/control that way it can pass
        //it on to the animationhandler, which deals with control properties
        public bool StartOperatorAnimation(bool animationUp)
        {
            if (operatorAnimationTimer.Enabled)
            {
                return true; //consume
            }

            previousBox = operatorsBoxList[selectedOperator];
            if (!animationUp)
            {
                operatorDisplacement = 85;
                currentOperatorStartingCoordinate = UpperOperatorRestingYCoordinate;
                if (selectedOperator == 0) { selectedOperator = operatorsBoxList.Count - 1; }
                else { selectedOperator--; }
            }
            else
            {
                operatorDisplacement = -85 + OperatorFullSize;
                currentOperatorStartingCoordinate = LowerOperatorRestingYCoordinate;
                if (selectedOperator == operatorsBoxList.Count - 1) { selectedOperator = 0; }
                else { selectedOperator++; }
            }

            OutputBox.Text = CalculateMethods.HandleCalculation(operandsIntList[0], selectedOperator, operandsIntList[1]);

            UpdateCurrentBox();
            currentBox.Size = new Size(0, 0);
            currentBox.Location = new Point(OperatorRestingCenterXCoordinate, currentOperatorStartingCoordinate);
            currentBox.Visible = true;
            animationFrame = 0;
            operatorAnimationTimer.Start();

            return true;
        }

        public void UpdateCurrentBox()
        {
            currentBox = operatorsBoxList[selectedOperator];
        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            AnimationType[] requestedAnimations = { AnimationType.SizeTransform };
            Size startSize = DebugBox.Size;
            Size endSize = new Size(0,0);
            UIAnimator animator = new UIAnimator(requestedAnimations, AnimationStyle.Ease, 0, 20, DebugBox, DebugBox.Location, DebugBox.Location, startSize, endSize);
            animator.UIAnimatorTimer.Start();
        }
    }
}
