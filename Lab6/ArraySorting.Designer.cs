namespace Lab6
{
    partial class ArraySorting
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
            dataGridArrays = new DataGridView();
            arrayProcessBindingSource = new BindingSource(components);
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button7 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridArrays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)arrayProcessBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridArrays
            // 
            dataGridArrays.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridArrays.Location = new Point(389, 12);
            dataGridArrays.Name = "dataGridArrays";
            dataGridArrays.Size = new Size(399, 426);
            dataGridArrays.TabIndex = 0;
            // 
            // arrayProcessBindingSource
            // 
            arrayProcessBindingSource.DataSource = typeof(Lab2.ArrayProcess);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(26, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(148, 23);
            textBox1.TabIndex = 1;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Location = new Point(26, 26);
            label1.Name = "label1";
            label1.Size = new Size(148, 15);
            label1.TabIndex = 2;
            label1.Text = "Введите размер массива: ";
            // 
            // button1
            // 
            button1.Location = new Point(26, 74);
            button1.Name = "button1";
            button1.Size = new Size(148, 65);
            button1.TabIndex = 3;
            button1.Text = "Создать массив с длиной по умолчанию";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(26, 145);
            button2.Name = "button2";
            button2.Size = new Size(148, 45);
            button2.TabIndex = 4;
            button2.Text = "Генерация массива";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(26, 196);
            button3.Name = "button3";
            button3.Size = new Size(148, 41);
            button3.TabIndex = 5;
            button3.Text = "Найти максимальное значение";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(26, 243);
            button4.Name = "button4";
            button4.Size = new Size(148, 41);
            button4.TabIndex = 6;
            button4.Text = "Найти минимальное значение";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Enabled = false;
            button5.Location = new Point(26, 290);
            button5.Name = "button5";
            button5.Size = new Size(148, 41);
            button5.TabIndex = 7;
            button5.Text = "Найти среднее арифметическое";
            button5.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Enabled = false;
            button7.Location = new Point(26, 337);
            button7.Name = "button7";
            button7.Size = new Size(148, 41);
            button7.TabIndex = 9;
            button7.Text = "Гномья сортировка";
            button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Enabled = false;
            button8.Location = new Point(26, 384);
            button8.Name = "button8";
            button8.Size = new Size(148, 41);
            button8.TabIndex = 10;
            button8.Text = "Сортировка вставками";
            button8.UseVisualStyleBackColor = true;
            // 
            // ArraySorting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridArrays);
            Name = "ArraySorting";
            Text = "ArraySorting";
            ((System.ComponentModel.ISupportInitialize)dataGridArrays).EndInit();
            ((System.ComponentModel.ISupportInitialize)arrayProcessBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridArrays;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button7;
        private Button button8;
        private BindingSource arrayProcessBindingSource;
    }
}