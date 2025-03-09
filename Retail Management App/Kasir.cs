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
using System.Drawing.Printing;

namespace Retail_Management_App
{
    public partial class Kasir : UserControl
    {
        public Kasir()
        {
            InitializeComponent();
        }

        private void clear()
        {
            cbIDProduk.Items.Clear();
            numQty.Value = 0;
            numTotalbyr.Value = 0;
            lblharga.Text = "0";
            lblKembalian.Text = "0";
            lblsubtotal.Text = "0";
            lblTotalTransaksi.Text = "0";
            lblNamaProduk.Visible = false;
        }

        private void dgclear()
        {
            dgKeranjang.Rows.Clear();
        }

        private void btnvproduk_Click(object sender, EventArgs e)
        {
            ViewProduk vp = new ViewProduk();
            vp.ShowDialog();
        }

        private void AutoID_Transaksi()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT id_transaksi FROM tb_transaksi ORDER BY id_transaksi DESC LIMIT 1", koneksi.conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string LastID = dr["id_transaksi"].ToString();
                int urut = int.Parse(LastID.Substring(2));
                urut++;
                txtIDTransaksi.Text = "TR" + urut.ToString("D4");
            }
            else
            {
                txtIDTransaksi.Text = "TR0001";
            }
            dr.Close();
        }


        private void AutoID_Detail()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT id_detail_transaksi FROM tb_detail_transaksi ORDER BY id_detail_transaksi DESC LIMIT 1", koneksi.conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string LastID = dr["id_detail_transaksi"].ToString();
                int urut = int.Parse(LastID.Substring(2));
                urut++;
                txtIDDetail.Text = "DT" + urut.ToString("D4");
            }
            else
            {
                txtIDDetail.Text = "DT0001";
            }
            dr.Close();
        }

        private void TataLetak()
        {
            dgKeranjang.Columns[0].Width = 70;
            dgKeranjang.Columns[1].Width = 200;
            dgKeranjang.Columns[3].Width = 40;
        }

        private void vcombobox()
        {
            try
            {
                koneksi.conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT id_produk FROM tb_produk", koneksi.conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                cbIDProduk.Items.Clear();
                while (dr.Read())
                {
                    cbIDProduk.Items.Add(dr["id_produk"].ToString());
                }
                dr.Close();
                koneksi.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void Kasir_Load(object sender, EventArgs e)
        {
            numQty.Value = 0;
            vcombobox();
            TataLetak();
        }

        private void LoadProduk()
        {
            try
            {
                koneksi.conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT nama_produk, harga_produk FROM tb_produk WHERE id_produk ='" + cbIDProduk.Text + "'", koneksi.conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblNamaProduk.Visible = true;
                    lblNamaProduk.Text = dr["nama_produk"].ToString();
                    lblharga.Text = dr["harga_produk"].ToString();
                    decimal harga = Convert.ToDecimal(lblharga.Text);
                    decimal subtot = numQty.Value * harga;
                    lblsubtotal.Text = Convert.ToString(subtot);
                }
                dr.Close();
                koneksi.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void cbIDProduk_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProduk();
        }

        private void numQty_ValueChanged(object sender, EventArgs e)
        {
            LoadProduk();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear();
            vcombobox();
            dgclear();
        }

        private void btnkeranjang_Click(object sender, EventArgs e)
        {
            if(cbIDProduk.Text.Trim() != "" && lblharga.Text.Trim() != "0" && lblsubtotal.Text.Trim() != "" && lblNamaProduk.Text.Trim() != "" && numQty.Value > 0)
            {
                decimal harga = Convert.ToDecimal(lblharga.Text);
                decimal subtot = numQty.Value * harga;
                dgKeranjang.Rows.Add(cbIDProduk.Text ,lblNamaProduk.Text, harga, numQty.Value, subtot);
                clear();
                vcombobox();
                TotalTransaksi();
            }
            else
            {
                MessageBox.Show("Tidak ada inputan");
            }
        }

        private void TotalTransaksi()
        {
            decimal total = 0;
            foreach(DataGridViewRow row in dgKeranjang.Rows)
            {
                if(row.Cells[4].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells[4].Value);
                }
            }
            lblTotalTransaksi.Text = total.ToString();
        }

        private void numTotalbyr_ValueChanged(object sender, EventArgs e)
        {
            decimal kembalian = numTotalbyr.Value - Convert.ToDecimal(lblTotalTransaksi.Text);
            lblKembalian.Text = kembalian.ToString();
        }

        private void btnSimpanTransaksi_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.conn.Open();
                AutoID_Transaksi();
                decimal total_harga = Convert.ToDecimal(lblTotalTransaksi.Text);
                decimal total_bayar = Convert.ToDecimal(numTotalbyr.Value);
                decimal kembalian = Convert.ToDecimal(lblKembalian.Text);
                MySqlCommand c1 = new MySqlCommand("INSERT INTO `tb_transaksi` VALUES ('"+txtIDTransaksi.Text+"','"+DateTime.Now.ToString("yyyy-MM-dd")+"','"+total_harga+"','"+total_bayar+"','"+kembalian+"')", koneksi.conn);
                c1.ExecuteNonQuery();

                foreach(DataGridViewRow row in dgKeranjang.Rows)
                {
                    if(row.Cells[0].Value != null)
                    {
                        AutoID_Detail();
                        MySqlCommand c2 = new MySqlCommand("INSERT INTO `tb_detail_transaksi` VALUES ('" + txtIDDetail.Text + "','" + txtIDTransaksi.Text + "','" + row.Cells[0].Value.ToString() + "','" + Convert.ToInt32(row.Cells[3].Value) + "','" + Convert.ToDecimal(row.Cells[4].Value) + "')", koneksi.conn);
                        c2.ExecuteNonQuery();
                    }
                }

                koneksi.conn.Close();
                MessageBox.Show("Data Berhasil Di Simpan");
                clear();
                dgclear();
                vcombobox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void struk_PrintPage(object sender, PrintPageEventArgs e)
        {
            var g = e.Graphics;
            var font = new Font("Courier New", 12);
            float yPos = 30, leftMargin = 20;

            g.DrawString("                RETAIL", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString("            MANAGEMENT APP", font, Brushes.Black, leftMargin, yPos);
            yPos += 30;
            g.DrawString("========================================", font, Brushes.Black, leftMargin, yPos);
            yPos += 30;
            g.DrawString($"Tanggal: {DateTime.Now}", font, Brushes.Black, leftMargin, yPos);
            yPos += 40;
            g.DrawString("----------------------------------------", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString("Nama Produk      Harga   Qty   Subtotal", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;
            g.DrawString("----------------------------------------", font, Brushes.Black, leftMargin, yPos);
            yPos += 20;

            foreach (DataGridViewRow row in dgKeranjang.Rows)
            {
                if (row.Cells[1].Value == null) continue;
                var nama = row.Cells[1].Value.ToString().PadRight(10);
                var harga = Convert.ToString(row.Cells[2].Value).PadLeft(7);
                var qty = row.Cells[3].Value.ToString().PadLeft(3);
                var subtotal = Convert.ToString(row.Cells[3].Value).PadLeft(10);
                g.DrawString($"{nama} {harga} {qty} {subtotal}", font, Brushes.Black, leftMargin, yPos);
                yPos += 20;
            }

            g.DrawString("----------------------------------------", font, Brushes.Black, leftMargin, yPos);
            yPos += 40;
            g.DrawString($"Total Harga: {lblTotalTransaksi.Text}", font, Brushes.Black, leftMargin, yPos);
            yPos += 22;
            g.DrawString($"Total Bayar: {numTotalbyr.Value}", font, Brushes.Black, leftMargin, yPos);
            yPos += 22;
            g.DrawString($"Kembalian: {lblKembalian.Text}", font, Brushes.Black, leftMargin, yPos);
            yPos += 40;
            g.DrawString("Terima Kasih telah berbelanja!", font, Brushes.Black, leftMargin, yPos);
        }
    }
}