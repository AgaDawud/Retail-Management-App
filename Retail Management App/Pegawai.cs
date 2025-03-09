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
    public partial class Pegawai : UserControl
    {
        public MySqlDataReader dr;
        public MySqlCommand cmd;

        public Pegawai()
        {
            InitializeComponent();
        }

        private void view()
        {

            try
            {
                koneksi.conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select * from tb_pegawai", koneksi.conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgPegawai.DataSource = dt;
                koneksi.conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void clear()
        {
            txtIDPegawai.Text = "";
            txtNP.Text = "";
            cbJK.Text = "-- Select --";
            tgl_lahir.Value = DateTime.Now;
            txtTL.Text = "";
            txtUser.Text = "";
            txtPass.Text = "";
            cbLevel.Text = "-- Select --";
        }

        private void AutoID()
        {
            cmd = new MySqlCommand("SELECT id_pegawai FROM tb_pegawai ORDER BY id_pegawai DESC LIMIT 1", koneksi.conn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string LastID = dr["id_pegawai"].ToString();
                int urut = int.Parse(LastID.Substring(3));
                urut++;
                txtIDPegawai.Text = "PG." + urut.ToString("D3");
            }
            else
            {
                txtIDPegawai.Text = "PG.001";
            }
            dr.Close();
        }

        private void btnTambahData_Click(object sender, EventArgs e)
        {
            Viewpegawai.Visible = false;
            lblUpdate.Visible = false;
            btnUpdate.Visible = false;
            lblTambah.Visible = true;
            btnSimpan.Visible = true;
            btnReset.Visible = true;
            clear();
        }

        private void lblKembali_Click(object sender, EventArgs e)
        {
            Viewpegawai.Visible = true;
        }

        private void Pegawai_Load(object sender, EventArgs e)
        {
            view();
            clear();
        }

        private void dgPegawai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = e.RowIndex;
            if(baris >= 0)
            {
                var row = dgPegawai.Rows[baris];
                txtIDPegawai.Text = row.Cells[0].Value.ToString();
                txtNP.Text = row.Cells[1].Value.ToString();
                cbJK.Text = row.Cells[2].Value.ToString();
                if(row.Cells[3].Value == DBNull.Value)
                {
                    MessageBox.Show("Data Tidak Valid");
                }
                else
                {
                    tgl_lahir.Value = Convert.ToDateTime(row.Cells[3].Value);

                }
                txtTL.Text = row.Cells[4].Value.ToString();
                txtUser.Text = row.Cells[5].Value.ToString();
                if (row.Cells[6].Value == DBNull.Value)
                {
                    txtPass.Text = "";
                }
                else
                {
                    txtPass.PasswordChar = '*';
                    txtPass.Text = row.Cells[6].Value.ToString();
                }
                cbLevel.Text = row.Cells[7].Value.ToString();
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.conn.Open();
                AutoID();
                cmd = new MySqlCommand("INSERT INTO `tb_pegawai` VALUES ('"+txtIDPegawai.Text+"','"+txtNP.Text+"','"+cbJK.Text+"','"+tgl_lahir.Value.ToString("yyyy-MM-dd")+"','"+ txtTL.Text + "','"+txtUser.Text+"','"+txtPass.Text+"','"+cbLevel.Text+"')", koneksi.conn);
                cmd.ExecuteNonQuery();
                
                Viewpegawai.Visible = true;
                koneksi.conn.Close();
                MessageBox.Show("Data Berhasil Di Simpan");
                view();
                clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                koneksi.conn.Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clear();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(txtIDPegawai.Text == "" || txtNP.Text == "" || cbJK.Text == "-- Select --" || txtTL.Text == "" || txtUser.Text == "" || cbLevel.Text == "")
            {
                MessageBox.Show("Pilih Salah Satu Baris");
            }
            else
            {
                Viewpegawai.Visible = false;
                lblUpdate.Visible = true;
                btnUpdate.Visible = true;
                lblTambah.Visible = false;
                btnSimpan.Visible = false;
                btnReset.Visible = false;

            }
        }


        private void btnHapus_Click(object sender, EventArgs e)
        {
            try
            {
                koneksi.conn.Open();
                cmd = new MySqlCommand("DELETE FROM `tb_pegawai` WHERE id_pegawai='"+txtIDPegawai.Text+"'", koneksi.conn);
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
                cmd = new MySqlCommand("UPDATE `tb_pegawai` SET `nama_pegawai`='"+txtNP.Text+"',`jenis_kelamin`='"+cbJK.Text+"',`tgl_lahir`='"+tgl_lahir.Value.ToString("yyyy-MM-dd")+"',`tempat_lahir`='"+txtTL.Text+"',`username`='"+txtUser.Text+"',`password`='"+txtPass.Text+"',`level`='"+cbLevel.Text+"' WHERE `id_pegawai`='"+txtIDPegawai.Text+"'", koneksi.conn);
                cmd.ExecuteNonQuery();
                koneksi.conn.Close();

                Viewpegawai.Visible = true;
                MessageBox.Show("Data Berhasil Di Update");
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
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT `id_pegawai`, `nama_pegawai`, `jenis_kelamin`, `tgl_lahir`, `tempat_lahir`, `username`, `level` FROM `tb_pegawai` WHERE `id_pegawai` LIKE '%" + txtCari.Text+"%' OR `nama_pegawai` LIKE '%"+txtCari.Text+"%'", koneksi.conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgPegawai.DataSource = dt;
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

        private void dgPegawai_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length); 
                e.FormattingApplied = true;
            }
        }
    }
}