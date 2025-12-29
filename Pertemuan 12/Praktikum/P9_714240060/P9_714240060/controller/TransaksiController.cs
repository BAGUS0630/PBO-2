using MySql.Data.MySqlClient;
using P9_714240060.model;
using P9_714240060.P9_714240060;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9_714240060.controller
{
    public class TransaksiController
    {
        Koneksi koneksi = new Koneksi();

        // Fungsi untuk mengecek duplikasi ID Barang
        public bool Update(M_Transaksi trans, string id)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                // Gunakan ExecuteQuery yang menerima parameter STRING
                string query = "UPDATE t_transaksi SET id_barang='" + trans.Id_barang +
                               "', qty='" + trans.Qty + "', total='" + trans.Total +
                               "' WHERE id_transaksi='" + id + "'";

                koneksi.ExecuteQuery(query); // Baris ini yang sebelumnya eror

                status = true;
                MessageBox.Show("Data transaksi berhasil diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        public bool Delete(string id)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                string query = "DELETE FROM t_transaksi WHERE id_transaksi='" + id + "'";

                // Pastikan memanggil ExecuteQuery(query), bukan memasukkannya ke objek Command
                koneksi.ExecuteQuery(query);

                status = true;
                MessageBox.Show("Data transaksi berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Gagal Hapus", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                koneksi.CloseConnection();
            }
            return status;
        }

        public bool CekIdBarang(string id)
        {
            bool status = false;
            try
            {
                koneksi.OpenConnection();
                // Menggunakan Parameterized Query untuk keamanan
                MySqlCommand cmd = new MySqlCommand("SELECT id_barang FROM t_transaksi WHERE id_barang = @id", koneksi.conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows) status = true;
                }
                koneksi.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Cek ID: " + ex.Message);
            }
            return status;
        }

        public void Insert(M_Transaksi trans)
        {
            // Validasi duplikasi ID sebelum menyimpan data baru
            if (CekIdBarang(trans.Id_barang))
            {
                MessageBox.Show("Id Barang sudah ada dalam data transaksi! Silakan gunakan tombol Update/Ubah.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                koneksi.OpenConnection();
                // Query Insert sesuai struktur tabel t_transaksi
                MySqlCommand cmd = new MySqlCommand("INSERT INTO t_transaksi (id_barang, qty, total) VALUES (@id, @qty, @total)", koneksi.conn);
                cmd.Parameters.AddWithValue("@id", trans.Id_barang);
                cmd.Parameters.AddWithValue("@qty", trans.Qty);
                cmd.Parameters.AddWithValue("@total", trans.Total);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Transaksi Berhasil Disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Insert Transaksi: " + ex.Message);
            }
        }

        // Tambahkan fungsi Update agar sejalan dengan peringatan validasi Anda
        public void Update(M_Transaksi trans)
        {
            try
            {
                koneksi.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE t_transaksi SET qty=@qty, total=@total WHERE id_barang=@id", koneksi.conn);
                cmd.Parameters.AddWithValue("@id", trans.Id_barang);
                cmd.Parameters.AddWithValue("@qty", trans.Qty);
                cmd.Parameters.AddWithValue("@total", trans.Total);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Transaksi Berhasil Diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update Transaksi: " + ex.Message);
            }
        }
    }
}