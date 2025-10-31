using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_2_714240060
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ulang;
            do
            {
                Console.Clear();
                Console.WriteLine("--- MENGHITUNG PERSEGI PANJANG ---");
                Console.WriteLine("1. Hitung Luas");
                Console.WriteLine("2. Hitung Keliling");
                Console.WriteLine("3. Keluar");
                Console.Write("\nPilih menu (1-3): ");
                int menu = Convert.ToInt16(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        hitungLuas();
                        break;

                    case 2:
                        hitungKeliling();
                        break;

                    case 3:
                        Console.WriteLine("\nProgram Selesai, Terimakasih!");
                        return;

                    default:
                        Console.WriteLine("\nMenu Tidak Tersedia. Silahkan pilih menu yang valid!");
                        break;
                }

                Console.Write("\nIngin mengulang kembali (y/n)? ");
                ulang = Console.ReadLine();

                if (ulang != "y" && ulang != "Y" && ulang != "n" && ulang != "N")
                {
                    Console.WriteLine("\nTerima kasih!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }
            } while (ulang == "y" || ulang == "Y");
        }


        private static void hitungLuas()
        {
            Console.Write("\nMasukkan panjang: ");
            double p = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nMasukkan lebar: ");
            double l = Convert.ToDouble(Console.ReadLine());

            double luas = p * l;
            Console.WriteLine("Luas persegi panjang = " + luas);
        }

        private static void hitungKeliling()
        {
            Console.Write("\nMasukkan panjang: ");
            double p = Convert.ToDouble(Console.ReadLine());
            Console.Write("Masukkan lebar: ");
            double l = Convert.ToDouble(Console.ReadLine());

            double keliling = 2 * (p + l);
            Console.WriteLine("Keliling persegi panjang = " + keliling);
        }
    }
}
        
