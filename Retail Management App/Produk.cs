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
    public partial class Produk : UserControl
    {
        public Produk()
        {
            InitializeComponent();
        }

        private void AutoIDProduk()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT id_produk FROM tb_produk ORDER BY id_produk DESC LIMIT 1", koneksi.conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string LastID = dr["id_produk"].ToString();
                int urut = int.Parse(LastID.Substring(3));
                urut++;
                txtIDProduk.Text = "PR." + urut.ToString("D4");
            }
            else
            {
                txtIDProduk.Text = "PR.0001";
            }
            dr.Close();
        }

        private void clear()
        {
            txtIDProduk.Clear();
            txtNP.Clear();
            txtKP.Clear();
            hargaProduk.Value = 0;
        }

        private void view()
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

        private void Produk_Load(object sender, EventArgs e)
        {
            view();
        }


        private void dgProduk_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            if (baris >= 0)
            {
                var row = dgProduk.Rows[baris];
                txtIDProduk.Text = row.Cells[0].Value.ToString();
                txtNP.Text = row.Cells[1].Value.ToString();
                if(row.Cells[2].Value == DBNull.Value)
                {
                    MessageBox.Show("Data tidak valid");
                }
                else
                {
                    hargaProduk.Value = Convert.ToDecimal(row.Cells[2].Value);
                }
                txtKP.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(txtIDProduk.Text == "" || txtNP.Text == "" || hargaProduk.Value == 0 || txtKP.Text == "")
            {
                MessageBox.Show("Pilih Salah Satu Baris");
            }
            else
            {

                ViewProduk.Visible = false;
                lblUpdate.Visible = true;
                btnUpdate.Visible = true;
                lblTambah.Visible = false;
                btnSimpan.Visible = false;
                btnReset.Visible = false;
            }
        }

        private void btnTambahData_Click(object sender, EventArgs e)
        {

            ViewProduk.Visible = false;
            lblUpdate.Visible = false;
            btnUpdate.Visible = false;
            lblTambah.Visible = true;
            btnSimpan.Visible = true;
            btnReset.Visible = true;
            clear();
        }

        private void lblKembali_Click(object sender, EventArgs e)
        {
            ViewProduk.Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.conn.Open();
                AutoIDProduk();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `tb_produk` VALUES ('"+txtIDProduk.Text+"','"+txtNP.Text+"','"+hargaProduk.Value+"','"+txtKP.Text+"')", koneksi.conn);
                cmd.ExecuteNonQuery();

                ViewProduk.Visible = true;
                koneksi.conn.Close();
                MessageBox.Show("Data Berhasil Di Simpan");
                view();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.conn.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM `tb_produk` WHERE id_produk='" + txtIDProduk.Text + "'", koneksi.conn);
                cmd.ExecuteNonQuery();
                koneksi.conn.Close();

                MessageBox.Show("Data Berhasi di hapus");
                view();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE `tb_produk` SET `nama_produk`='"+txtNP.Text+"',`harga_produk`='"+hargaProduk.Value+"',`kategori_produk`='"+txtKP.Text+"' WHERE `id_produk`='"+txtIDProduk.Text+"'", koneksi.conn);
                cmd.ExecuteNonQuery();
                koneksi.conn.Close();

                MessageBox.Show("Data Berhasi di Update");
                view();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void txtCari_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(e.KeyChar == (char)Keys.Enter)
           {
                try
                {
                    koneksi.conn.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter("select * from tb_produk where `id_produk` LIKE '%" + txtCari.Text + "%' OR `nama_produk` LIKE '%" + txtCari.Text + "%'", koneksi.conn);
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
