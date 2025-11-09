using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_714240060

    {
        // INHERITANCE + POLYMORPHISM
        internal class Motor : Kendaraan
        {
            public string JenisMotor { get; set; }

            public int CC { get; set; }

        public Motor(string merk, int tahun, string jenisMotor, int cc)
                : base(merk, tahun)
            {
                JenisMotor = jenisMotor;
                CC = cc;    
        }

        // POLYMORPHISM → implementasi berbeda dari class Mobil
        public override void InfoKendaraan()
        {
            Console.WriteLine($"MOTOR");
            Console.WriteLine($"Merk: {Merk}");
            Console.WriteLine($"Tahun: {Tahun}");
            Console.WriteLine($"Nama Motor: {JenisMotor}");
            Console.WriteLine($"Kapasitas Mesin: {CC} cc");

        }
    }
}
