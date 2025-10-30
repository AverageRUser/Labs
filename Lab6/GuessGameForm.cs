using Lab2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class GuessGameForm : Form
    {
        
        public GuessGameForm()
        {
            InitializeComponent();
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    GuessGame.A = InputValidator.FillInt(textBoxA.Text);
                    if (GuessGame.A != 0)
                    {
                        textBoxA.Enabled = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка", ex.Message);
                }
            }
        }

        private void textBoxB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    GuessGame.B = InputValidator.FillInt(textBoxB.Text);
                    if (GuessGame.B != 0)
                    {
                        textBoxB.Enabled = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка", ex.Message);
                }
            }
        }




        private void textBoxAttempts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    GuessGame.Attempts = InputValidator.FillInt(textBoxAttempts.Text);
                    if (GuessGame.Attempts != 0)
                    {
                        textBoxAttempts.Enabled = false;
                        GuessGame.IsFilled = true;
                        label4.Visible = true;
                        textBoxAnswer.Visible = true;
                        AttemptsLabel.Visible = true;
                        AttemptsLabel.Text = "Попыток осталось: " + GuessGame.Attempts;
                        GuessGame.CalculateFunction();
                        GameTick.Start();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка", ex.Message);
                }
            }
        }

        private void textBoxAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    double ans = InputValidator.FillDouble(textBoxAnswer.Text);
                    if (ans == Math.Round(GuessGame.Answer, 2))
                    {
                        MessageBox.Show("Правильный ответ!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        GuessGame.IsAnswerCorrect = true;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка", "Неправильный ответ!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        GuessGame.Attempts--;
                        AttemptsLabel.Text = "Попыток осталось: " + GuessGame.Attempts;
                        textBoxAnswer.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка", ex.Message);
                }
            }
        }

        private void GameTick_Tick(object sender, EventArgs e)
        {
            EndGame();
            GuessGame.Tick();
            labelTime.Text = GuessGame.Time.ToString();
        }

        private void textBoxAttempts_TextChanged(object sender, EventArgs e)
        {

        }

     
        public void EndGame()
        {
            if (GuessGame.Attempts == 0 || GuessGame.IsAnswerCorrect || GuessGame.Time == 0)
            {
                GameTick.Stop();
                DialogResult = MessageBox.Show($"Игра окончена!\nПравильный ответ: {Math.Round(GuessGame.Answer, 2)}", "Перезапустить?", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    GuessGame.Restart();
                 
                }
                    Close();


            }
        }

    }
}
