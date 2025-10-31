using Lab2.SnakeGame.Snake;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Lab6
{
    public partial class SnakeForm : Form
    {
    

        private Game game;
        private Keys currentDirection;
        private Keys nextDirection;


        public SnakeForm()
        {
            InitializeComponent();
            for (int i = 0; i < Game.GRID_SIZE; i++)
            {
                gameGrid.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Width = Game.CELL_SIZE,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });
            }

            gameGrid.Rows.Add(Game.GRID_SIZE);
            foreach (DataGridViewRow row in gameGrid.Rows)
            {
                row.Height = Game.CELL_SIZE;
            }
            InitializeGame();
        }

        private void InitializeGame()
        {
            gameTimer.Interval = Game.GAME_SPEED;
            ClearGrid();

            game = new Game(gameGrid);
            currentDirection = Keys.Right;
            nextDirection = Keys.Right;

            Game.IsPlaying = false;
            Game.IsPaused = false;
            Game.CountFeed = 0;
        }
        private void TogglePause()
        {
            if (Game.IsPlaying && !Game.IsPaused)
            {
                gameTimer.Stop();
                Game.IsPaused = true;
               Plabel.Visible = true;
            }
            else if (Game.IsPlaying && Game.IsPaused)
            {
                gameTimer.Start();
                Game.IsPaused = false;
                Plabel.Visible = false;
            }
        }
        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
          

            switch (e.KeyCode)
            {
                case Keys.W:
                    if (currentDirection != Keys.Down)
                        nextDirection = Keys.Up;
                    break;

                case Keys.S:
                    if (currentDirection != Keys.Up)
                        nextDirection = Keys.Down;
                    break;
                case Keys.A:
                    if (currentDirection != Keys.Right)
                        nextDirection = Keys.Left;
                    break;
                case Keys.D:
                    if (currentDirection != Keys.Left)
                        nextDirection = Keys.Right;
                    break;

                case Keys.Space:
                    if (!Game.IsPlaying)
                    {
                        StartGame();
                    }
                    else 
                        TogglePause();
                    break;
            }

            e.Handled = true;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (Game.IsPlaying && !Game.IsPaused)
            {
                game.StateUpdate(nextDirection);
                currentDirection = nextDirection;
                UpdateScore();

                if (!Game.IsPlaying)
                {
                    GameOver();
                }
            }
        }
        private void ClearGrid()
        {
            for (int i = 0; i < Game.GRID_SIZE; i++)
            {
                for (int j = 0; j < Game.GRID_SIZE; j++)
                {
                    gameGrid.Rows[i].Cells[j].Value = "";
                    gameGrid.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }
        private void UpdateScore()
        {
            scoreLabel.Text = $"Счет: {Game.CountFeed}";
        }

        private void StartGame()
        {
            ClearGrid();
            game.Start(); 
            Game.IsPlaying = true;
            Game.IsPaused = false;
            gameTimer.Start();
            StartLabel.Visible = false;


            Game.Restart();
            UpdateScore();
        }
        private void GameOver()
        {
            gameTimer.Stop();
            Game.IsPlaying = false;
            StartLabel.Visible= true;


            MessageBox.Show($"Ваш счет: {Game.CountFeed}", "Игра окончена!");
        }
     
   
    }
}
