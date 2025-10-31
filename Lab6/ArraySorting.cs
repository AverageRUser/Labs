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
            dataGridArrays.ColumnCount = 4;
            dataGridArrays.Columns[0].HeaderText = "Id";

            dataGridArrays.Columns[1].HeaderText = "Исходный";
            dataGridArrays.Columns[2].HeaderText = "Гномья";
            dataGridArrays.Columns[3].HeaderText = "Вставками";
            dataGridArrays.Columns[0].Width = 40;

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
        public bool CheckCells()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(dataGridArrays.Rows[i].Cells[1].Value == null)
                {
                    return false;
                }
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            ResetColors(dataGridArrays);
            array.InitializeArray();

            for (int i = 0; i < array.Length; i++)
            {
                dataGridArrays.Rows[i].Cells[1].Value = array[i];
            }
            button3.Enabled = true;
            button4.Enabled = true;
            Avgbutton.Enabled = true;
            GnomeSort.Enabled = true;
            buttonInsert.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetColors(dataGridArrays);
            dataGridArrays.Rows[array.Min()].Cells[1].Style.BackColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ResetColors(dataGridArrays);
            dataGridArrays.Rows[array.Max()].Cells[1].Style.BackColor = Color.Green;
        }

        public static void ResetColors(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }
        }
        private void dataGridArrays_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(dataGridArrays.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out int num))
            {
                array[e.RowIndex] = num;
              
                if(CheckCells())
                {
                    button3.Enabled = true;
                    button4.Enabled = true;
                    Avgbutton.Enabled = true;
                    GnomeSort.Enabled = true;
                    buttonInsert.Enabled = true;
                }
                
            }
        }

        private void Avgbutton_Click(object sender, EventArgs e)
        {
            Avglabel.Visible = true;
            Avglabel.Text = $"Среднее арифметическое: {array.Avg()}";
        }

        private void GnomeSort_Click(object sender, EventArgs e)
        {
            ArrayProcess arrayClone = array.CloneArray();
            arrayClone.GnomeSort();
            for (int i = 0; i < array.Length; i++)
            {
                dataGridArrays.Rows[i].Cells[2].Value = arrayClone[i];

            }
          
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            ArrayProcess arrayClone = array.CloneArray();
            arrayClone.InsertionSort();
            for (int i = 0; i < array.Length; i++)
            {
                dataGridArrays.Rows[i].Cells[3].Value = arrayClone[i];

            }
       
        }
    }
}
