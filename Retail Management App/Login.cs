using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Retail_Management_App
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }



        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showpass_CheckedChanged(object sender, EventArgs e)
        {

            if (showpass.Checked == true)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void validate()
        {
            try
            {
                koneksi.conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM `tb_pegawai` WHERE username='" + txtUser.Text + "' AND password='" + txtPass.Text + "'", koneksi.conn);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string level = dr["level"].ToString();
                    string np = dr["nama_pegawai"].ToString();
                    MainApp ma = new MainApp(level, np);
                    koneksi.conn.Close();
                    ma.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Username atau Password Salah !!!");
                    txtUser.Clear();
                    txtPass.Clear();
                }
                koneksi.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Isi Username dan Password Terlebih Dulu !!!");
                koneksi.conn.Close();
            }
            else
            {
                validate();
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                validate();
                e.Handled = true;
            }
        }
    }
}
