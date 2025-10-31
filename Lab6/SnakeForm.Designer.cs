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
            buttonStart = new Button();
            PauseButton = new Button();
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
            gameGrid.Location = new Point(12, 64);
            gameGrid.Name = "gameGrid";
            gameGrid.ReadOnly = true;
            gameGrid.RowHeadersVisible = false;
            gameGrid.ScrollBars = ScrollBars.None;
            gameGrid.Size = new Size(450, 470);
            gameGrid.TabIndex = 4;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            scoreLabel.Location = new Point(12, 29);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(78, 32);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "label1";
            // 
            // gameTimer
            // 
            gameTimer.Tick += gameTimer_Tick;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(541, 29);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(146, 57);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Старт";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // PauseButton
            // 
            PauseButton.Location = new Point(541, 107);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new Size(146, 51);
            PauseButton.TabIndex = 3;
            PauseButton.Text = "Пауза";
            PauseButton.UseVisualStyleBackColor = true;
            PauseButton.Click += PauseButton_Click;
            // 
            // SnakeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 592);
            Controls.Add(PauseButton);
            Controls.Add(buttonStart);
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
        private Button buttonStart;
        private Button PauseButton;
    }
}