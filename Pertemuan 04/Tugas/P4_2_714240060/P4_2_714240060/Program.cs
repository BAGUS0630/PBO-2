using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_2_714240060
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Membuat array Kendaraan untuk Polymorphism
            Kendaraan[] daftarKendaraan = new Kendaraan[2];

            daftarKendaraan[0] = new Mobil("Toyota", 2023, "Avanza", 1500);
            daftarKendaraan[1] = new Motor("Yamaha", 2021, "T - Max", 500);

            Console.WriteLine(" DATA KENDARAAN \n");

            // POLYMORPHISM → panggil method yang sama tapi hasil beda
            foreach (Kendaraan k in daftarKendaraan)
            {
                k.InfoKendaraan();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
