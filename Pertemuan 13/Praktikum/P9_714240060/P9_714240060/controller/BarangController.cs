using MySql.Data.MySqlClient;
using P9_714240060.model.P9_714240060.Model;
using P9_714240060.P9_714240060;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9_714240060.controller
{
    public class BarangController
    {
        Koneksi koneksi = new Koneksi();

        // Insert Barang
        public void Insert(M_Barang barang)
        {
            try
            {
                koneksi.OpenConnection();
                // Menggunakan @nama dan @harga sesuai standar Parameterized Query
                MySqlCommand cmd = new MySqlCommand("INSERT INTO t_barang (nama_barang, harga) VALUES (@nama, @harga)", koneksi.conn);
                cmd.Parameters.AddWithValue("@nama", barang.Nama_barang);
                cmd.Parameters.AddWithValue("@harga", barang.Harga);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data barang berhasil disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Insert: " + ex.Message);
            }
        }

        // Update Barang
        public void Update(M_Barang barang, string id)
        {
            try
            {
                koneksi.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE t_barang SET nama_barang=@nama, harga=@harga WHERE id_barang=@id", koneksi.conn);
                cmd.Parameters.AddWithValue("@nama", barang.Nama_barang);
                cmd.Parameters.AddWithValue("@harga", barang.Harga);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data barang berhasil diubah", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update: " + ex.Message);
            }
        }

        // Delete Barang
        public void Delete(string id)
        {
            try
            {
                koneksi.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM t_barang WHERE id_barang=@id", koneksi.conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data barang berhasil dihapus", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Delete: " + ex.Message);
            }
        }
    }
}