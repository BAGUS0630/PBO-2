using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9_714240060.view
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataMahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 FormMhs = new Form1();
            FormMhs.MdiParent = this;
            FormMhs.Show();
        }

        private void dataNilaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNilai FrmNilai = new FormNilai();
            FrmNilai.MdiParent = this;
            FrmNilai.Show();
        }

        private void dataMasterBarangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // cek apakah Form_Barang sudah terbuka
            foreach (Form f in this.MdiChildren)
            {
                if (f is Form_Barang)
                {
                    f.Activate();
                    return;
                }
            }

            // jika belum terbuka
            Form_Barang frm = new Form_Barang();
            frm.MdiParent = this;
            frm.Show();
        }


        private void tugasPraktikum11ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTransaksi frmTrans = new FormTransaksi();
            frmTrans.MdiParent = this; // Menjadikan form muncul di dalam ParentForm
            frmTrans.Show();

        }

        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
