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
    public partial class ArraySorting : Form
    {
        ArrayProcess array;
        public ArraySorting()
        {
            InitializeComponent();
            dataGridArrays.ColumnCount = 3;
            dataGridArrays.Columns[0].HeaderText = "Id";

            dataGridArrays.Columns[1].HeaderText = "Исходный";
            dataGridArrays.Columns[2].HeaderText = "Cортированный";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int length = InputValidator.InputLengthArray(textBox1.Text);
                    array = new ArrayProcess(length);

                    SetLengthDataGrid();
                    button1.Enabled = false;
                    textBox1.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }
        public void SetLengthDataGrid()
        {
            dataGridArrays.RowCount = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                dataGridArrays.Rows[i].Cells[0].Value = i;

            }
            dataGridArrays.Columns[0].ReadOnly = true;
            button2.Enabled = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            array = new ArrayProcess();

            SetLengthDataGrid();
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            array.InitializeArray();

            for (int i = 0; i < array.Length; i++)
            {
                dataGridArrays.Rows[i].Cells[1].Value = array[i];
            }
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridArrays.Rows[array.Min()].Cells[1].Style.BackColor = Color.Red;
        }
    }
}
