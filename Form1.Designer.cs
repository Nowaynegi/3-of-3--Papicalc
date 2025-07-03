namespace Papicalc
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            OperatorLabel = new Label();
            Operand1 = new TextBox();
            textBox1 = new TextBox();
            OperatorBox = new PictureBox();
            EqualBox = new PictureBox();
            OutputBox = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)OperatorBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EqualBox).BeginInit();
            SuspendLayout();
            // 
            // OperatorLabel
            // 
            OperatorLabel.AutoSize = true;
            OperatorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OperatorLabel.Location = new Point(376, 217);
            OperatorLabel.Name = "OperatorLabel";
            OperatorLabel.RightToLeft = RightToLeft.Yes;
            OperatorLabel.Size = new Size(0, 15);
            OperatorLabel.TabIndex = 0;
            OperatorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Operand1
            // 
            Operand1.BackColor = SystemColors.GradientInactiveCaption;
            Operand1.Enabled = false;
            Operand1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Operand1.Location = new Point(327, 196);
            Operand1.Name = "Operand1";
            Operand1.Size = new Size(43, 43);
            Operand1.TabIndex = 1;
            Operand1.Text = "_";
            Operand1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Snow;
            textBox1.Enabled = false;
            textBox1.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(407, 196);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(43, 43);
            textBox1.TabIndex = 2;
            textBox1.Text = "_";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // OperatorBox
            // 
            OperatorBox.BackgroundImage = (Image)resources.GetObject("OperatorBox.BackgroundImage");
            OperatorBox.BackgroundImageLayout = ImageLayout.None;
            OperatorBox.Location = new Point(376, 207);
            OperatorBox.Name = "OperatorBox";
            OperatorBox.Size = new Size(25, 25);
            OperatorBox.TabIndex = 3;
            OperatorBox.TabStop = false;
            // 
            // EqualBox
            // 
            EqualBox.BackgroundImage = (Image)resources.GetObject("EqualBox.BackgroundImage");
            EqualBox.BackgroundImageLayout = ImageLayout.None;
            EqualBox.Location = new Point(456, 207);
            EqualBox.Name = "EqualBox";
            EqualBox.Size = new Size(25, 25);
            EqualBox.TabIndex = 4;
            EqualBox.TabStop = false;
            // 
            // OutputBox
            // 
            OutputBox.BackColor = SystemColors.ControlLight;
            OutputBox.Enabled = false;
            OutputBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OutputBox.Location = new Point(487, 196);
            OutputBox.Name = "OutputBox";
            OutputBox.Size = new Size(43, 43);
            OutputBox.TabIndex = 5;
            OutputBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(536, 127);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 6;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(OutputBox);
            Controls.Add(EqualBox);
            Controls.Add(OperatorBox);
            Controls.Add(textBox1);
            Controls.Add(Operand1);
            Controls.Add(OperatorLabel);
            KeyPreview = true;
            Name = "Form1";
            Text = "Papicalc";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)OperatorBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)EqualBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OperatorLabel;
        private TextBox Operand1;
        private TextBox textBox1;
        private PictureBox OperatorBox;
        private PictureBox EqualBox;
        private TextBox OutputBox;
        private Label label1;
    }
}
