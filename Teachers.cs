using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabota4
{
    public partial class Teachers : Form
    {
        int Row;

        public Teachers()
        {
            InitializeComponent();
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            this.ranksTableAdapter.Fill(this.universityDataSet.ranks);
            this.teachersTableAdapter.Fill(this.universityDataSet.teachers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Groups main = new Groups();
            this.Hide();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Students main = new Students();
            this.Hide();
            main.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.teachersTableAdapter.Insert(textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString());
            this.teachersTableAdapter.Fill(this.universityDataSet.teachers);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.teachersTableAdapter.DeleteTeachers(Row);
            this.teachersTableAdapter.Fill(this.universityDataSet.teachers);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                Row = Convert.ToInt32(selectedRow.Cells[0].Value);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
