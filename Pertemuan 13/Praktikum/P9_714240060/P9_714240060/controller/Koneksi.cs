using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P9_714240060
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Data;

    namespace P9_714240060
    {
        // Ubah internal menjadi public agar bisa diakses oleh folder Controller & View
        public class Koneksi
        {
            string connectionstring = "Server=localhost; Database=pemrog2ulbi; Uid=root;Pwd=";

            // Ubah menjadi public dan ganti nama menjadi 'conn' agar sesuai dengan Controller Anda
            public MySqlConnection conn;

            public void OpenConnection()
            {
                conn = new MySqlConnection(connectionstring);
                if (conn.State == ConnectionState.Closed) conn.Open();
            }

            public void CloseConnection()
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }

            // Ubah return type menjadi DataTable agar lebih spesifik (Memperbaiki CS0161)
            public DataTable ShowData(string query)
            {
                DataTable table = new DataTable();
                try
                {
                    OpenConnection();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.Fill(table);
                }
                catch (Exception) { }
                finally { CloseConnection(); }

                return table;
            }

            public void ExecuteQuery(MySqlCommand command)
            {
                try
                {
                    OpenConnection();
                    command.Connection = conn;
                    command.ExecuteNonQuery();
                }
                catch (Exception) { }
                finally { CloseConnection(); }
            }

            // Method untuk Parameterized Query di View sesuai instruksi PDF [cite: 101]
            public DataTable ShowDataParam(string query, params MySqlParameter[] parameters)
            {
                DataTable table = new DataTable();
                try
                {
                    OpenConnection();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddRange(parameters);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(table);
                }
                catch (Exception) { }
                finally { CloseConnection(); }

                return table;
            }

            public void ExecuteQuery(string query)
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }

            public MySqlDataReader reader(string query, MySqlParameter[] parameters)
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteReader();
            }
        }
    }
}
