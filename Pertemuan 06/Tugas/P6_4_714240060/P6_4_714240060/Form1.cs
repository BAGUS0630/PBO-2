using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P6_4_714240060
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ------------------------------------------------------------------
        // A. CHAR TEXTBOX & NUMERIC TEXTBOX (MENGGUNAKAN KeyPress EVENT)
        // ------------------------------------------------------------------

        // Numeric Textbox (txtNoHP): Hanya mengizinkan digit
        private void txtNoHP_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Izinkan digit (0-9) dan tombol kontrol (seperti Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Abaikan input non-digit
            }
        }

        // Char Textbox (txtNamaLengkap): Hanya mengizinkan huruf dan spasi
        private void txtNamaLengkap_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Izinkan huruf, spasi, dan tombol kontrol
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Abaikan input non-huruf/spasi
            }
        }

        // ------------------------------------------------------------------
        // B. UPPER CASE TEXTBOX & LOWER CASE TEXTBOX (MENGGUNAKAN TextChanged EVENT)
        // ------------------------------------------------------------------

        // Upper Case Textbox (txtIDPemesanan)
        private void txtIDPemesanan_TextChanged(object sender, EventArgs e)
        {
            // Simpan posisi kursor
            int cursor = txtIDPemesanan.SelectionStart;
            txtIDPemesanan.Text = txtIDPemesanan.Text.ToUpper();
            txtIDPemesanan.SelectionStart = cursor;
        }

        // Lower Case Textbox (txtNamaLengkap)
        private void txtNamaLengkap_TextChanged(object sender, EventArgs e)
        {
            // Simpan posisi kursor
            int cursor = txtNamaLengkap.SelectionStart;
            txtNamaLengkap.Text = txtNamaLengkap.Text.ToLower();
            txtNamaLengkap.SelectionStart = cursor;
        }

        // ------------------------------------------------------------------
        // C. SEMUA VALIDASI PADA TOMBOL SUBMIT (Click EVENT)
        // ------------------------------------------------------------------

        private void btnPesan_Click(object sender, EventArgs e)
        {
            // 1. REQUIRED VALIDATOR
            if (string.IsNullOrWhiteSpace(txtIDPemesanan.Text) ||
                string.IsNullOrWhiteSpace(txtNamaLengkap.Text) ||
                string.IsNullOrWhiteSpace(txtNoHp.Text) ||
                string.IsNullOrWhiteSpace(txtKodeVoucher.Text) ||
                string.IsNullOrWhiteSpace(txtJumlahTiket.Text) ||
                string.IsNullOrWhiteSpace(txtUlangJumlah.Text))
            {
                MessageBox.Show("Semua kolom wajib diisi.", "Validasi Gagal - Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. LENGTH VALIDATOR (ID Pemesanan harus 5 karakter)
            if (txtIDPemesanan.Text.Length != 5)
            {
                MessageBox.Show("ID Pemesanan harus tepat 5 karakter.", "Validasi Gagal - Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDPemesanan.Focus();
                return;
            }

            // 3. REGEX VALIDATOR (Kode Voucher: Pola DISKON diikuti 3 Angka)
            string regexVoucher = @"^DISKON\d{3}$";
            if (!Regex.IsMatch(txtKodeVoucher.Text, regexVoucher))
            {
                MessageBox.Show("Kode Voucher tidak valid. Gunakan format DISKONxxx (contoh: DISKON123).", "Validasi Gagal - Regex", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKodeVoucher.Focus();
                return;
            }

            // 4. Pengecekan Numeric dan Comparison (Min/Max)
            if (!int.TryParse(txtJumlahTiket.Text, out int jumlahTiket) || jumlahTiket < 1 || jumlahTiket > 10)
            {
                MessageBox.Show("Jumlah Tiket harus angka antara 1 sampai 10.", "Validasi Gagal - Comparison", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJumlahTiket.Focus();
                return;
            }

            // 5. COMPARISON VALIDATOR (Konfirmasi Jumlah Tiket harus sama)
            if (txtJumlahTiket.Text != txtUlangJumlah.Text)
            {
                MessageBox.Show("Konfirmasi Jumlah Tiket tidak cocok.", "Validasi Gagal - Comparison", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUlangJumlah.Focus();
                return;
            }


            // ------------------------------------------------------------------
            // D. TAMPILKAN ISIAN FORM DALAM MESSAGE BOX
            // ------------------------------------------------------------------
            string hasilPemesanan = $"--- Data Pemesanan Tiket Konser ---\n\n" +
                                    $"ID Pemesanan: {txtIDPemesanan.Text}\n" +
                                    $"Nama Pembeli: {txtNamaLengkap.Text}\n" +
                                    $"Nomor HP: {txtNoHp.Text}\n" +
                                    $"Kode Voucher: {txtKodeVoucher.Text}\n" +
                                    $"Jumlah Tiket: {txtJumlahTiket.Text} buah\n\n" +
                                    $"Status: Pemesanan Tiket Berhasil!";

            MessageBox.Show(hasilPemesanan, "Sukses Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
