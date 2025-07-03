using System;
using System.ComponentModel.Design;

namespace Papicalc
{
    public partial class Form1 : Form
    {
        private static List<TextBox> operandsBoxList;
        private static int selectedOperand;
        private static int[] operandsIntList;
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

            operandsBoxList = [Operand1, Operand2];
            operandsIntList = new int[operandsBoxList.Count];

            selectedOperand = 0;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Debug.Text = e.KeyChar.ToString();

            int i;
            if (int.TryParse(e.KeyChar.ToString(), out i))
            {
                operandsBoxList[selectedOperand].Text = i.ToString();
                operandsIntList[selectedOperand] = i;
                OutputBox.Text = (operandsIntList[0] + operandsIntList[1]).ToString();


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
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
