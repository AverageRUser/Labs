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
    }
}
