using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_714240060
{

    // INHERITANCE → Mobil mewarisi Kendaraan
    internal class Mobil : Kendaraan
    {
        public string NamaMobil { get; set; }
        public int CC { get; set; }

        // CONSTRUCTOR (memanggil constructor induk)
        public Mobil(string merk, int tahun, string namaMobil, int cc)
            : base(merk, tahun)
        {
            NamaMobil = namaMobil;
            CC = cc;
        }

        // POLYMORPHISM → override method abstract dari induk
        public override void InfoKendaraan()
        {
            Console.WriteLine($"MOBIL");
            Console.WriteLine($"Merk: {Merk}");
            Console.WriteLine($"Tahun: {Tahun}");
            Console.WriteLine($"Nama Mobil: {NamaMobil}");
            Console.WriteLine($"Kapasitas Mesin: {CC} cc");
        }
	}
}

