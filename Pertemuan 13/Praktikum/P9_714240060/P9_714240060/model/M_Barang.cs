using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P9_714240060.model
{
    namespace P9_714240060.Model
    {
        public class M_Barang
        {
            public string Id_barang { get; set; }
            public string Nama_barang { get; set; }
            public string Harga { get; set; }

            public M_Barang() { }

            public M_Barang(string nama_barang, string harga)
            {
                this.Nama_barang = nama_barang;
                this.Harga = harga;
            }
        }
    }
}
