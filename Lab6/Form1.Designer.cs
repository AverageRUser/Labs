namespace Lab6
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
            LabelMenu = new Label();
            AboutButton = new Button();
            GuessButton = new Button();
            SortingButton = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // LabelMenu
            // 
            LabelMenu.AutoSize = true;
            LabelMenu.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 204);
            LabelMenu.Location = new Point(302, 47);
            LabelMenu.Name = "LabelMenu";
            LabelMenu.Size = new Size(163, 65);
            LabelMenu.TabIndex = 0;
            LabelMenu.Text = "Меню";
            // 
            // AboutButton
            // 
            AboutButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AboutButton.Location = new Point(290, 200);
            AboutButton.Name = "AboutButton";
            AboutButton.Size = new Size(186, 45);
            AboutButton.TabIndex = 1;
            AboutButton.Text = "Об авторе";
            AboutButton.UseVisualStyleBackColor = true;
            AboutButton.Click += AboutButton_Click;
            // 
            // GuessButton
            // 
            GuessButton.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GuessButton.ForeColor = SystemColors.ControlText;
            GuessButton.Location = new Point(290, 143);
            GuessButton.Name = "GuessButton";
            GuessButton.Size = new Size(186, 51);
            GuessButton.TabIndex = 2;
            GuessButton.Text = "Игра \"Угадай число\"";
            GuessButton.UseVisualStyleBackColor = true;
            GuessButton.Click += button2_Click;
            // 
            // SortingButton
            // 
            SortingButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            SortingButton.Location = new Point(290, 251);
            SortingButton.Name = "SortingButton";
            SortingButton.Size = new Size(186, 45);
            SortingButton.TabIndex = 3;
            SortingButton.Text = "Сортировка массива";
            SortingButton.UseVisualStyleBackColor = true;
            SortingButton.Click += SortingButton_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button1.Location = new Point(290, 302);
            button1.Name = "button1";
            button1.Size = new Size(186, 45);
            button1.TabIndex = 4;
            button1.Text = "Игра \"Змейка с препятствиями\"";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(SortingButton);
            Controls.Add(GuessButton);
            Controls.Add(AboutButton);
            Controls.Add(LabelMenu);
            Name = "Form1";
            Text = "Лабораторная №6";
            Activated += Form1_Activated;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LabelMenu;
        private Button AboutButton;
        private Button GuessButton;
        private Button SortingButton;
        private Button button1;
    }
}
