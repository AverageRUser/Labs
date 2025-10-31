namespace Lab6
{
    partial class SnakeForm
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
            gameGrid = new DataGridView();
            scoreLabel = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            StartLabel = new Label();
            Plabel = new Label();
            ((System.ComponentModel.ISupportInitialize)gameGrid).BeginInit();
            SuspendLayout();
            // 
            // gameGrid
            // 
            gameGrid.AllowUserToAddRows = false;
            gameGrid.AllowUserToDeleteRows = false;
            gameGrid.AllowUserToResizeColumns = false;
            gameGrid.AllowUserToResizeRows = false;
            gameGrid.BackgroundColor = Color.White;
            gameGrid.ColumnHeadersVisible = false;
            gameGrid.Enabled = false;
            gameGrid.Location = new Point(12, 54);
            gameGrid.Name = "gameGrid";
            gameGrid.ReadOnly = true;
            gameGrid.RowHeadersVisible = false;
            gameGrid.ScrollBars = ScrollBars.None;
            gameGrid.Size = new Size(400, 400);
            gameGrid.TabIndex = 4;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            scoreLabel.Location = new Point(12, 9);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(78, 32);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "label1";
            // 
            // gameTimer
            // 
            gameTimer.Tick += gameTimer_Tick;
            // 
            // StartLabel
            // 
            StartLabel.AutoSize = true;
            StartLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            StartLabel.Location = new Point(43, 229);
            StartLabel.Name = "StartLabel";
            StartLabel.Size = new Size(354, 30);
            StartLabel.TabIndex = 5;
            StartLabel.Text = "Нажмите ПРОБЕЛ для начала игры";
            // 
            // Plabel
            // 
            Plabel.AutoSize = true;
            Plabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Plabel.Location = new Point(183, 229);
            Plabel.Name = "Plabel";
            Plabel.Size = new Size(69, 30);
            Plabel.TabIndex = 6;
            Plabel.Text = "Пауза";
            Plabel.Visible = false;
            // 
            // SnakeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 459);
            Controls.Add(Plabel);
            Controls.Add(StartLabel);
            Controls.Add(scoreLabel);
            Controls.Add(gameGrid);
            Name = "SnakeForm";
            Text = "SnakeForm";
            KeyDown += SnakeForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gameGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gameGrid;
        private Label scoreLabel;
        private System.Windows.Forms.Timer gameTimer;
        private Label StartLabel;
        private Label Plabel;
    }
}