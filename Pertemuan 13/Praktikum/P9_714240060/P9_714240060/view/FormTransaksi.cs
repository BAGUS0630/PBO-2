using MySql.Data.MySqlClient;
using P9_714240060.controller;
using P9_714240060.model;
using P9_714240060.P9_714240060;
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
    public partial class FormTransaksi : Form
    {
        // Inisialisasi objek koneksi
        Koneksi koneksi = new Koneksi();
        string id_transaksi;

        public FormTransaksi()
        {
            InitializeComponent();
        }

        // Jalankan perintah saat Form pertama kali dibuka
        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            Tampil();
            GetIdBarang();
        }

        public void Tampil()
        {
            // Query JOIN untuk mengambil Nama Barang dari tabel t_barang
            string query = "SELECT t.id_transaksi, t.id_barang, b.nama_barang, t.qty, t.total " +
                           "FROM t_transaksi t " +
                           "INNER JOIN t_barang b ON t.id_barang = b.id_barang";

            dgvTransaksi.DataSource = koneksi.ShowData(query);

            // Opsional: Mengubah judul kolom agar lebih rapi
            dgvTransaksi.Columns[0].HeaderText = "ID Transaksi";
            dgvTransaksi.Columns[1].HeaderText = "ID Barang";
            dgvTransaksi.Columns[2].HeaderText = "Nama Barang";
            dgvTransaksi.Columns[3].HeaderText = "Quantity";
            dgvTransaksi.Columns[4].HeaderText = "Total Harga";

            dgvTransaksi.Columns[4].DefaultCellStyle.Format = "C2";
            dgvTransaksi.Columns[4].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("id-ID");
        }

        public void GetIdBarang()
        {
            // Perbaikan: gunakan objek 'koneksi' (huruf kecil), bukan class 'Koneksi'
            DataTable dt = koneksi.ShowData("SELECT id_barang, nama_barang, harga FROM t_barang");
            cbIdBarang.DataSource = dt;
            cbIdBarang.DisplayMember = "id_barang";
            cbIdBarang.ValueMember = "id_barang";

            // Set agar awal dibuka tidak langsung terpilih
            cbIdBarang.SelectedIndex = -1;
        }

        // Munculkan Nama & Harga otomatis saat ID dipilih
        private void cbIdBarang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIdBarang.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)cbIdBarang.SelectedItem;
                txtNamaBarang.Text = row["nama_barang"].ToString();
                txtHargaBarang.Text = row["harga"].ToString();
            }
        }


        // Kalkulasi Total otomatis: Harga x Qty
        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtHargaBarang.Text, out int harga) && int.TryParse(txtQty.Text, out int qty))
            {
                txtTotal.Text = (harga * qty).ToString();
            }
            else
            {
                txtTotal.Text = "Rp 0";
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cbIdBarang.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtQty.Text))
            {
                MessageBox.Show("Data tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                M_Transaksi m_trans = new M_Transaksi();
                m_trans.Id_barang = cbIdBarang.Text;
                m_trans.Qty = txtQty.Text;
                m_trans.Total = txtTotal.Text;

                TransaksiController tc = new TransaksiController();
                tc.Insert(m_trans);

                // Refresh data setelah simpan
                Tampil();
            }
        }

        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTransaksi.Rows[e.RowIndex];

                // 1. Ambil ID Transaksi untuk keperluan Update/Delete
                id_transaksi = row.Cells[0].Value.ToString();

                // 2. Set ComboBox ID Barang agar sesuai dengan data di tabel
                cbIdBarang.Text = row.Cells[1].Value.ToString();

                // 3. Isi TextBox lainnya secara otomatis
                // Nama Barang (Index 2) dan Harga akan terisi otomatis lewat event SelectedIndexChanged 
                // yang sudah kita buat sebelumnya, jadi kita cukup mengisi Quantity.
                txtQty.Text = row.Cells[3].Value.ToString();
                txtTotal.Text = row.Cells[4].Value.ToString();
            }
        }

        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            // Query JOIN untuk mencari berdasarkan nama barang
            string query = "SELECT t.id_transaksi, t.id_barang, b.nama_barang, t.qty, t.total " +
                           "FROM t_transaksi t " +
                           "INNER JOIN t_barang b ON t.id_barang = b.id_barang " +
                           "WHERE b.nama_barang LIKE @cari";

            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@cari", "%" + txtCari.Text + "%");

            dgvTransaksi.DataSource = koneksi.ShowDataParam(query, parameters);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cbIdBarang.SelectedIndex = -1;
            txtNamaBarang.Clear();
            txtHargaBarang.Clear();
            txtQty.Clear();
            txtTotal.Clear();
            txtCari.Clear();
            id_transaksi = null; // Reset ID agar aman
            Tampil(); // Muat ulang tabel original
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id_transaksi))
            {
                MessageBox.Show("Pilih data yang akan diubah!", "Peringatan");
            }
            else
            {
                M_Transaksi m_trans = new M_Transaksi(cbIdBarang.SelectedValue.ToString(), txtQty.Text, txtTotal.Text);
                TransaksiController tc = new TransaksiController();
                tc.Update(m_trans, id_transaksi);

                btnRefresh_Click(sender, e); // Refresh otomatis
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id_transaksi))
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan");
            }
            else
            {
                DialogResult result = MessageBox.Show("Yakin ingin menghapus transaksi ini?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    TransaksiController tc = new TransaksiController();
                    tc.Delete(id_transaksi);

                    btnRefresh_Click(sender, e);
                }
            }
        }
    }
}