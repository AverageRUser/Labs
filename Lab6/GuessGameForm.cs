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
        int time;
        public GuessGameForm()
        {
            InitializeComponent();
            time = 60;
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


        private void GuessGameForm_Activated(object sender, EventArgs e)
        {
            

            if (GuessGame.Attempts == 0 || GuessGame.IsAnswerCorrect || time == 0)
            {
                GameTick.Stop();
                DialogResult = MessageBox.Show("Перезапустить?", $"Игра окончена!\nПравильный ответ - {GuessGame.Answer}", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                   
                    GuessGame._isFilled = false;

                    label4.Visible = false;
                    textBoxAnswer.Visible = false;
                    AttemptsLabel.Visible = false;
                    textBoxAttempts.Enabled = true;
                    textBoxA.Enabled = true;
                    textBoxA.Enabled = true;
                }
                else
                {
                    Close();
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
                        GuessGame._isFilled = true;
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
                        MessageBox.Show("Победа", "Правильный ответ!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
            
            time--;
            labelTime.Text = time.ToString();
        }

        private void textBoxAttempts_TextChanged(object sender, EventArgs e)
        {

        }

        private void GuessGameForm_Enter(object sender, EventArgs e)
        {
            if (GuessGame._isFilled)
            {
                MessageBox.Show("", "");
              


            }
        }
    }
}
