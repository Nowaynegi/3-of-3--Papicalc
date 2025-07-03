namespace Papicalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPress += Form1_KeyPress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label1.Text = e.KeyChar.ToString();
            e.Handled = true;
        }
    }
}
