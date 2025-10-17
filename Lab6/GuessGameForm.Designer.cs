namespace Lab6
{
    partial class GuessGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuessGameForm));
            pictureBox1 = new PictureBox();
            GameTick = new System.Windows.Forms.Timer(components);
            labelTime = new Label();
            textBoxA = new TextBox();
            label2 = new Label();
            label3 = new Label();
            AttemptsLabel = new Label();
            textBoxB = new TextBox();
            label4 = new Label();
            textBoxAnswer = new TextBox();
            label5 = new Label();
            textBoxAttempts = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(232, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(242, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // GameTick
            // 
            GameTick.Interval = 1000;
            GameTick.Tick += GameTick_Tick;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTime.Location = new Point(307, 26);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(0, 32);
            labelTime.TabIndex = 1;
            // 
            // textBoxA
            // 
            textBoxA.Location = new Point(297, 194);
            textBoxA.Name = "textBoxA";
            textBoxA.Size = new Size(100, 23);
            textBoxA.TabIndex = 2;
            textBoxA.KeyDown += textBox1_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 197);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "Введите а:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(213, 246);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 4;
            label3.Text = "Введите b:";
            // 
            // AttemptsLabel
            // 
            AttemptsLabel.AutoSize = true;
            AttemptsLabel.Location = new Point(21, 40);
            AttemptsLabel.Name = "AttemptsLabel";
            AttemptsLabel.Size = new Size(113, 15);
            AttemptsLabel.TabIndex = 5;
            AttemptsLabel.Text = "Попыток осталось:";
            AttemptsLabel.Visible = false;
            // 
            // textBoxB
            // 
            textBoxB.Location = new Point(297, 243);
            textBoxB.Name = "textBoxB";
            textBoxB.Size = new Size(100, 23);
            textBoxB.TabIndex = 6;
            textBoxB.KeyDown += textBoxB_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(185, 341);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 7;
            label4.Text = "Угадайте ответ:";
            label4.Visible = false;
            // 
            // textBoxAnswer
            // 
            textBoxAnswer.Location = new Point(297, 341);
            textBoxAnswer.Name = "textBoxAnswer";
            textBoxAnswer.Size = new Size(100, 23);
            textBoxAnswer.TabIndex = 8;
            textBoxAnswer.Visible = false;
            textBoxAnswer.KeyDown += textBoxAnswer_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(105, 292);
            label5.Name = "label5";
            label5.Size = new Size(171, 15);
            label5.TabIndex = 9;
            label5.Text = "Введите количество попыток:";
            // 
            // textBoxAttempts
            // 
            textBoxAttempts.Location = new Point(297, 292);
            textBoxAttempts.Name = "textBoxAttempts";
            textBoxAttempts.Size = new Size(100, 23);
            textBoxAttempts.TabIndex = 10;
            textBoxAttempts.TextChanged += textBoxAttempts_TextChanged;
            textBoxAttempts.KeyDown += textBoxAttempts_KeyDown;
            // 
            // GuessGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxAttempts);
            Controls.Add(label5);
            Controls.Add(textBoxAnswer);
            Controls.Add(label4);
            Controls.Add(textBoxB);
            Controls.Add(AttemptsLabel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxA);
            Controls.Add(labelTime);
            Controls.Add(pictureBox1);
            Name = "GuessGameForm";
            Text = "Угадай число";
            Activated += GuessGameForm_Activated;
            Enter += GuessGameForm_Enter;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer GameTick;
        private Label labelTime;
        private TextBox textBoxA;
        private Label label2;
        private Label label3;
        private Label AttemptsLabel;
        private TextBox textBoxB;
        private Label label4;
        private TextBox textBoxAnswer;
        private Label label5;
        private TextBox textBoxAttempts;
    }
}