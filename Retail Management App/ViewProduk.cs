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
    public partial class ViewProduk : Form
    {
        public ViewProduk()
        {
            InitializeComponent();
        }

        private void ViewProduk_Load(object sender, EventArgs e)
        {
            try
            {
                koneksi.conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from tb_produk", koneksi.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgProduk.DataSource = dt;
                koneksi.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void txtCari_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    koneksi.conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from tb_produk where `nama_produk` LIKE '%" + txtCari.Text + "%'", koneksi.conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgProduk.DataSource = dt;
                    koneksi.conn.Close();
                    e.Handled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    koneksi.conn.Close();
                }
            }
        }
    }
}
