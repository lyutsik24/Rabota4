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
    public partial class Students : Form
    {
        int Row;

        public Students()
        {
            InitializeComponent();
        }

        private void Students_Load(object sender, EventArgs e)
        {
            this.groupTableAdapter.Fill(this.universityDataSet.group);
            this.genderTableAdapter.Fill(this.universityDataSet.gender);
            this.studentTableAdapter.Fill(this.universityDataSet.student);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.Insert(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(comboBox1.SelectedValue), dateTimePicker1.Value, comboBox2.SelectedValue.ToString());
            this.studentTableAdapter.Fill(this.universityDataSet.student);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.DeleteQuery(Row);
            this.studentTableAdapter.Fill(this.universityDataSet.student);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                Row = Convert.ToInt32(selectedRow.Cells[0].Value);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.ResetText();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Teachers main = new Teachers();
            this.Hide();
            main.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Groups main = new Groups();
            this.Hide();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }
    }
}
