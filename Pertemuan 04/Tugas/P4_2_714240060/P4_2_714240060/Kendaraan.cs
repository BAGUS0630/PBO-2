using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_714240060
{
    internal class Kendaraan
    {
        // Encapsulation (field private)
        private string merk;
        private int tahun;

        // Property untuk akses aman
        public string Merk
        {
            get { return merk; }
            set { merk = value; }
        }

        public int Tahun
        {
            get { return tahun; }
            set { tahun = value; }
        }

        // Constructor
        public Kendaraan(string merk, int tahun)
        {
            Merk = merk;
            Tahun = tahun;
        }

        // Method umum
        public virtual void InfoKendaraan()
        {
            Console.WriteLine($"Merk: {Merk}, Tahun: {Tahun}");
        }
    }
}
