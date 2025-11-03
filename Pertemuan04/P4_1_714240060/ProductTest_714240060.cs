using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_1_714240060
{
     class ProductTest_714240060
    {
        static void Main(string[] args)
        {
            Book_714240060 product1 = new Book_714240060("Book", "c# Object Oriented Solution", "300");
            DVD_714240060 product2 = new DVD_714240060("Ethernal Sunshine of the Spotless Mind", "145");

            product1.DisplayInfo();
            product2.DisplayInfo();
        }
    }
}
