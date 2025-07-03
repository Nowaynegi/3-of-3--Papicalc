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
            Operand2 = new TextBox();
            OperatorBoxAdd = new PictureBox();
            EqualBox = new PictureBox();
            OutputBox = new TextBox();
            OperatorBoxSubtract = new PictureBox();
            OperatorBoxDivide = new PictureBox();
            OperatorBoxMultipy = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)OperatorBoxAdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EqualBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OperatorBoxSubtract).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OperatorBoxDivide).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OperatorBoxMultipy).BeginInit();
            SuspendLayout();
            // 
            // OperatorLabel
            // 
            OperatorLabel.AutoSize = true;
            OperatorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OperatorLabel.Location = new Point(315, 217);
            OperatorLabel.Name = "OperatorLabel";
            OperatorLabel.RightToLeft = RightToLeft.Yes;
            OperatorLabel.Size = new Size(0, 15);
            OperatorLabel.TabIndex = 0;
            OperatorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Operand1
            // 
            Operand1.BackColor = Color.PowderBlue;
            Operand1.Enabled = false;
            Operand1.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Operand1.Location = new Point(261, 196);
            Operand1.Name = "Operand1";
            Operand1.Size = new Size(71, 71);
            Operand1.TabIndex = 1;
            Operand1.Text = "_";
            Operand1.TextAlign = HorizontalAlignment.Center;
            // 
            // Operand2
            // 
            Operand2.BackColor = Color.Snow;
            Operand2.Enabled = false;
            Operand2.Font = new Font("Segoe UI", 36F);
            Operand2.Location = new Point(384, 196);
            Operand2.Name = "Operand2";
            Operand2.Size = new Size(71, 71);
            Operand2.TabIndex = 2;
            Operand2.Text = "_";
            Operand2.TextAlign = HorizontalAlignment.Center;
            // 
            // OperatorBoxAdd
            // 
            OperatorBoxAdd.BackgroundImage = (Image)resources.GetObject("OperatorBoxAdd.BackgroundImage");
            OperatorBoxAdd.BackgroundImageLayout = ImageLayout.Zoom;
            OperatorBoxAdd.Location = new Point(338, 212);
            OperatorBoxAdd.Name = "OperatorBoxAdd";
            OperatorBoxAdd.Size = new Size(40, 40);
            OperatorBoxAdd.TabIndex = 3;
            OperatorBoxAdd.TabStop = false;
            OperatorBoxAdd.Visible = false;
            // 
            // EqualBox
            // 
            EqualBox.BackgroundImage = (Image)resources.GetObject("EqualBox.BackgroundImage");
            EqualBox.BackgroundImageLayout = ImageLayout.Zoom;
            EqualBox.Location = new Point(461, 212);
            EqualBox.Name = "EqualBox";
            EqualBox.Size = new Size(40, 40);
            EqualBox.TabIndex = 4;
            EqualBox.TabStop = false;
            // 
            // OutputBox
            // 
            OutputBox.BackColor = Color.Gainsboro;
            OutputBox.Enabled = false;
            OutputBox.Font = new Font("Segoe UI", 36F);
            OutputBox.Location = new Point(507, 196);
            OutputBox.Name = "OutputBox";
            OutputBox.Size = new Size(71, 71);
            OutputBox.TabIndex = 5;
            OutputBox.TextAlign = HorizontalAlignment.Center;
            // 
            // OperatorBoxSubtract
            // 
            OperatorBoxSubtract.BackgroundImage = (Image)resources.GetObject("OperatorBoxSubtract.BackgroundImage");
            OperatorBoxSubtract.BackgroundImageLayout = ImageLayout.Zoom;
            OperatorBoxSubtract.Location = new Point(338, 212);
            OperatorBoxSubtract.Name = "OperatorBoxSubtract";
            OperatorBoxSubtract.Size = new Size(40, 40);
            OperatorBoxSubtract.TabIndex = 6;
            OperatorBoxSubtract.TabStop = false;
            OperatorBoxSubtract.Visible = false;
            // 
            // OperatorBoxDivide
            // 
            OperatorBoxDivide.BackgroundImage = (Image)resources.GetObject("OperatorBoxDivide.BackgroundImage");
            OperatorBoxDivide.BackgroundImageLayout = ImageLayout.Zoom;
            OperatorBoxDivide.Location = new Point(338, 212);
            OperatorBoxDivide.Name = "OperatorBoxDivide";
            OperatorBoxDivide.Size = new Size(40, 40);
            OperatorBoxDivide.TabIndex = 7;
            OperatorBoxDivide.TabStop = false;
            OperatorBoxDivide.Visible = false;
            // 
            // OperatorBoxMultipy
            // 
            OperatorBoxMultipy.BackgroundImage = (Image)resources.GetObject("OperatorBoxMultipy.BackgroundImage");
            OperatorBoxMultipy.BackgroundImageLayout = ImageLayout.Zoom;
            OperatorBoxMultipy.Location = new Point(338, 212);
            OperatorBoxMultipy.Name = "OperatorBoxMultipy";
            OperatorBoxMultipy.Size = new Size(40, 40);
            OperatorBoxMultipy.TabIndex = 8;
            OperatorBoxMultipy.TabStop = false;
            OperatorBoxMultipy.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(OperatorBoxMultipy);
            Controls.Add(OperatorBoxDivide);
            Controls.Add(OperatorBoxSubtract);
            Controls.Add(OutputBox);
            Controls.Add(EqualBox);
            Controls.Add(OperatorBoxAdd);
            Controls.Add(Operand2);
            Controls.Add(Operand1);
            Controls.Add(OperatorLabel);
            KeyPreview = true;
            Name = "Form1";
            Text = "Papicalc";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)OperatorBoxAdd).EndInit();
            ((System.ComponentModel.ISupportInitialize)EqualBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)OperatorBoxSubtract).EndInit();
            ((System.ComponentModel.ISupportInitialize)OperatorBoxDivide).EndInit();
            ((System.ComponentModel.ISupportInitialize)OperatorBoxMultipy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label OperatorLabel;
        private TextBox Operand1;
        private TextBox Operand2;
        private PictureBox OperatorBoxAdd;
        private PictureBox EqualBox;
        private TextBox OutputBox;
        private PictureBox OperatorBoxSubtract;
        private PictureBox OperatorBoxDivide;
        private PictureBox OperatorBoxMultipy;
    }
}
