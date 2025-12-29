using MySql.Data.MySqlClient;
using P9_714240060.controller;
using P9_714240060.model.P9_714240060.Model;
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
    public partial class Form_Barang : Form
    {
        Koneksi koneksi = new Koneksi();
        string id_barang;
        public Form_Barang()
        {
            InitializeComponent();
        }

        // Dipanggil saat Form pertama kali muncul
        private void Form_Barang_Load(object sender, EventArgs e)
        {
            Tampil();
        }

        public void Tampil()
        {
            // Menampilkan data ke DataGridView
            dgvBarang.DataSource = koneksi.ShowData("SELECT * FROM t_barang");
            if (dgvBarang.Columns.Count > 0)
            {
                dgvBarang.Columns[0].HeaderText = "ID Barang";
                dgvBarang.Columns[1].HeaderText = "Nama Barang";
                dgvBarang.Columns[2].HeaderText = "Harga";

                dgvBarang.Columns[2].DefaultCellStyle.Format = "C2";
                dgvBarang.Columns[2].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("id-ID");
            }
        }

        // Tombol Simpan
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaBarang.Text) || string.IsNullOrWhiteSpace(txtHarga.Text))
            {
                MessageBox.Show("Data tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                M_Barang m_brg = new M_Barang(txtNamaBarang.Text, txtHarga.Text);
                BarangController bc = new BarangController();
                bc.Insert(m_brg);

                // Bersihkan field dan perbarui tabel
                txtNamaBarang.Clear();
                txtHarga.Clear();
                Tampil();
            }
        }

        // Tombol Ubah (Update)
        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (dgvBarang.SelectedRows.Count > 0)
            {
               if (string.IsNullOrWhiteSpace(txtNamaBarang.Text) || string.IsNullOrWhiteSpace(txtHarga.Text) || id_barang == null)
    {
        MessageBox.Show("Pilih data yang akan diubah terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    else
    {
        // Gunakan variabel m_brg dan controller untuk melakukan update berdasarkan id_barang
        M_Barang m_brg = new M_Barang(txtNamaBarang.Text, txtHarga.Text);
        BarangController bc = new BarangController();
        bc.Update(m_brg, id_barang);

        Tampil(); // Segarkan tabel setelah update
        btnRefresh_Click(sender, e); // Bersihkan field
    }
            }
            else
            {
                MessageBox.Show("Silakan pilih baris data yang ingin diubah terlebih dahulu", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Fitur Pencarian dengan Parameterized Query (Sesuai instruksi PDF)
        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM t_barang WHERE nama_barang LIKE @cari OR id_barang LIKE @cari";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@cari", "%" + txtCari.Text + "%");

            // Menggunakan method ShowDataParam yang sudah kita buat di Koneksi.cs
            dgvBarang.DataSource = koneksi.ShowDataParam(query, parameters);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // isi sesuai kebutuhan
            MessageBox.Show("Button diklik");
        }

        private void dgvBarang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBarang.Rows[e.RowIndex];

                // Mengambil data dari baris yang diklik
                id_barang = row.Cells[0].Value.ToString();
                txtNamaBarang.Text = row.Cells[1].Value.ToString();
                txtHarga.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtNamaBarang.Clear();
            txtHarga.Clear();
            txtCari.Clear();
            Tampil();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(id_barang))
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Konfirmasi sebelum menghapus agar tidak terjadi kesalahan tidak sengaja
                DialogResult result = MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    BarangController bc = new BarangController();
                    bc.Delete(id_barang); // Memanggil fungsi delete di controller

                    Tampil(); // Refresh tabel
                    btnRefresh_Click(sender, e); // Kosongkan form
                }
            }
        }
    }
}