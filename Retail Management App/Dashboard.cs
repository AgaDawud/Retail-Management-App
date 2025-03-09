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
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private string FormatNumber(decimal num)
        {
            if (num >= 1000000000)
                return (num / 1000000000).ToString("0.#") + "B";
            else if (num >= 1000000)
                return (num / 1000000).ToString("0.#") + "M";
            else if (num >= 1000)
                return (num / 1000).ToString("0.#") + "K";
            else
                return num.ToString();
        }

        private void loadjml()
        {
            try
            {
                koneksi.conn.Open();
                MySqlCommand cmd1 = new MySqlCommand("select count(*) from tb_pegawai", koneksi.conn);
                MySqlCommand cmd2 = new MySqlCommand("select count(*) from tb_produk", koneksi.conn);
                MySqlCommand cmd3 = new MySqlCommand("select sum(total_harga) from tb_transaksi", koneksi.conn);

                int jmlPegawai = Convert.ToInt32(cmd1.ExecuteScalar());
                int jmlproduk = Convert.ToInt32(cmd2.ExecuteScalar());
                object r = cmd3.ExecuteScalar();

                if(r == DBNull.Value)
                {
                    lblTotalTransaksi.Text = "0";
                }
                else
                {
                    decimal totalharga = Convert.ToDecimal(r);
                    lblTotalTransaksi.Text = FormatNumber(totalharga);
                }

                lbltotalPegawai.Text = FormatNumber(jmlPegawai);
                lbltotalProduk.Text =  FormatNumber(jmlproduk);
                koneksi.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void view()
        {
            try
            {
                koneksi.conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from tb_transaksi", koneksi.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgTransaksi.DataSource = dt;
                koneksi.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadjml();
            view();
        }

    }
}
