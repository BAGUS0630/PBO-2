using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P9_714240060.model
{
    public class M_Transaksi
    {
        public string Id_barang { get; set; }
        public string Qty { get; set; }
        public string Total { get; set; }

        public M_Transaksi() { }

        // Tambahkan Constructor dengan 3 argumen ini (Solusi CS1729)
        public M_Transaksi(string id_barang, string qty, string total)
        {
            this.Id_barang = id_barang;
            this.Qty = qty;
            this.Total = total;
        }
    }
}
