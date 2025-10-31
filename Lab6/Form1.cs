using Lab2;

namespace Lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuessGameForm guessGameForm = new GuessGameForm();
            guessGameForm.Show();
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (GuessGame.IsRestart)
            {
                GuessGame.IsRestart = false;
                GuessGameForm guessGameForm = new GuessGameForm();
                guessGameForm.Show();
            }
        }

        private void SortingButton_Click(object sender, EventArgs e)
        {
            ArraySorting sortingForm = new ArraySorting();
            sortingForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SnakeForm snakeForm = new SnakeForm();
            snakeForm.Show();
        }
    }
}
