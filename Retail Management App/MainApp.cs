using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retail_Management_App
{
    public partial class MainApp : Form
    {
        private string lvlakses;
        private string name;
        public MainApp(string level, string np)
        {
            lvlakses = level;
            name = np;
            InitializeComponent();
            Dashboard dash = new Dashboard();
            addUC(dash);
        }

        private void addUC(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            PanelUC.Controls.Clear();
            PanelUC.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            if(pMaster.Visible == true)
            {
                pMaster.Visible = false;
            }
            else
            {
                pMaster.Visible = true;
                PanelMenu.Width = 228;
                btnLogout.Visible = true;
            }
        }

        private void btnSide_Click(object sender, EventArgs e)
        {
            if (PanelMenu.Width == 70)
            {
                PanelMenu.Width = 228;
                btnLogout.Visible = true;
            }
            else
            {
                PanelMenu.Width = 70;
                btnLogout.Visible = false;
                pMaster.Visible = false;
            }
        }

        private void btnDash_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            addUC(dash);
        }

        private void btnPegawai_Click(object sender, EventArgs e)
        {
            Pegawai pg = new Pegawai();
            addUC(pg);
        }

        private void btnProduk_Click(object sender, EventArgs e)
        {
            Produk pr = new Produk();
            addUC(pr);
        }

        private void btnKasir_Click(object sender, EventArgs e)
        {
            Kasir ks = new Kasir();
            addUC(ks);
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            if(lvlakses == "admin")
            {
                btnLaporan.Visible = true;
                btnMaster.Visible = true;
                btnKasir.Visible = false;
            }
            else if (lvlakses == "kasir")
            {
                btnLaporan.Visible = true;
                btnMaster.Visible = false;
                btnKasir.Visible = true;
            }
            lblUser.Text = name;
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            Laporan_Transaksi lt = new Laporan_Transaksi();
            addUC(lt);
        }
    }
}
