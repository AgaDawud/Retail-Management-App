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
    public partial class Laporan_Transaksi : UserControl
    {
        public Laporan_Transaksi()
        {
            InitializeComponent();
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


        private void Laporan_Transaksi_Load(object sender, EventArgs e)
        {
            view();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print pr = new Print();
            pr.Show();
        }
    }
}
