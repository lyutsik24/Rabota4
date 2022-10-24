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
    public partial class Groups : Form
    {
        int Row;

        public Groups()
        {
            InitializeComponent();
        }

        private void Groups_Load(object sender, EventArgs e)
        {
            this.courseTableAdapter.Fill(this.universityDataSet.course);
            this.groupTableAdapter.Fill(this.universityDataSet.group);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Students main = new Students();
            this.Hide();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teachers main = new Teachers();
            this.Hide();
            main.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.groupTableAdapter.Insert(textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString());
            this.groupTableAdapter.Fill(this.universityDataSet.group);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.groupTableAdapter.DeleteGroup(Row);
            this.groupTableAdapter.Fill(this.universityDataSet.group);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                Row = Convert.ToInt32(selectedRow.Cells[0].Value);
            }
        }
    }
}
