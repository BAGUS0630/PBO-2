using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P9_714240060.view
{
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Menambag nilai pada ProgressBar setiap 5 tick, proogressBar sebagai indikator proses loading
            progressBar2.Value += 5;

            //Mengecek apakah ProgressBar sudah mencapai nilai maksimum(100)
            if (progressBar2.Value == 100)
            {
                // Menghentikan dan membersihkan Timer agar tidak berjalan lagi
                timer1.Dispose();

                // Menutup form StartUp (Splash Screen)
                Close();
            }

        }
    }
    
}
