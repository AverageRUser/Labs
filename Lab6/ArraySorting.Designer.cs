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
            dataGridArrays = new DataGridView();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            Avgbutton = new Button();
            GnomeSort = new Button();
            buttonInsert = new Button();
            Avglabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridArrays).BeginInit();
            SuspendLayout();
            // 
            // dataGridArrays
            // 
            dataGridArrays.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridArrays.Location = new Point(207, 45);
            dataGridArrays.Name = "dataGridArrays";
            dataGridArrays.Size = new Size(411, 380);
            dataGridArrays.TabIndex = 0;
            dataGridArrays.CellEndEdit += dataGridArrays_CellEndEdit;
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
            button3.Click += button3_Click;
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
            // Avgbutton
            // 
            Avgbutton.Enabled = false;
            Avgbutton.Location = new Point(26, 290);
            Avgbutton.Name = "Avgbutton";
            Avgbutton.Size = new Size(148, 41);
            Avgbutton.TabIndex = 7;
            Avgbutton.Text = "Найти среднее арифметическое";
            Avgbutton.UseVisualStyleBackColor = true;
            Avgbutton.Click += Avgbutton_Click;
            // 
            // GnomeSort
            // 
            GnomeSort.Enabled = false;
            GnomeSort.Location = new Point(26, 337);
            GnomeSort.Name = "GnomeSort";
            GnomeSort.Size = new Size(148, 41);
            GnomeSort.TabIndex = 9;
            GnomeSort.Text = "Гномья сортировка";
            GnomeSort.UseVisualStyleBackColor = true;
            GnomeSort.Click += GnomeSort_Click;
            // 
            // buttonInsert
            // 
            buttonInsert.Enabled = false;
            buttonInsert.Location = new Point(26, 384);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(148, 41);
            buttonInsert.TabIndex = 10;
            buttonInsert.Text = "Сортировка вставками";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += buttonInsert_Click;
            // 
            // Avglabel
            // 
            Avglabel.AutoSize = true;
            Avglabel.Location = new Point(207, 26);
            Avglabel.Name = "Avglabel";
            Avglabel.Size = new Size(38, 15);
            Avglabel.TabIndex = 11;
            Avglabel.Text = "label2";
            Avglabel.TextAlign = ContentAlignment.MiddleCenter;
            Avglabel.Visible = false;
            // 
            // ArraySorting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 450);
            Controls.Add(Avglabel);
            Controls.Add(buttonInsert);
            Controls.Add(GnomeSort);
            Controls.Add(Avgbutton);
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
        private Button Avgbutton;
        private Button GnomeSort;
        private Button buttonInsert;
        private Label Avglabel;
    }
}