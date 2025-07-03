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
                operatorsBoxList[selectedOperator].Visible = false;
                if (selectedOperator == operatorsBoxList.Count - 1) { selectedOperator = 0; operatorsBoxList[selectedOperator].Visible = true; OutputBox.Text = HandleCalculation(); return true; }
                selectedOperator ++ ;
                operatorsBoxList[selectedOperator].Visible = true;
                OutputBox.Text = HandleCalculation();
                return true;
            }
            if (keyData == Keys.Down)
            {
                operatorsBoxList[selectedOperator].Visible = false;
                if (selectedOperator == 0) { selectedOperator = operatorsBoxList.Count - 1; operatorsBoxList[selectedOperator].Visible = true; OutputBox.Text = HandleCalculation(); return true; }
                selectedOperator -- ;
                operatorsBoxList[selectedOperator].Visible = true;
                OutputBox.Text = HandleCalculation();
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
