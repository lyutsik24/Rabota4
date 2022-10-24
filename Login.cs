using MySql.Data.MySqlClient;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            loginBox.Clear();
            passwordBox.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //данные для входа login=admin; password=admin
            try
            {
                String loginUser = loginBox.Text;
                String loginPassword = passwordBox.Text;
                String quary = "SELECT * FROM `University`.`users` WHERE `login` = @uL AND `password` = @uP;";

                DataTable table = new DataTable();
                MySqlConnection conn = BDUtills.GetDBConnection();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand(quary, conn);
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = loginPassword;

                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    Main main = new Main();
                    this.Hide();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ShowPassBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassBox.Checked == true)
            {
                passwordBox.UseSystemPasswordChar = true;
            }
            else
            {
                passwordBox.UseSystemPasswordChar = false;
            }
        }
    }
}
