using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace P6_3_714240060
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SetErrorMessages(TextBox textBox, string warningMessage, string wrongMessage, string correctMessage)
        {
            epWarning.SetError(textBox, warningMessage);
            epWrong.SetError(textBox, wrongMessage);
            epCorrect.SetError(textBox, correctMessage);
        }

        private void label1_Leave(object sender, EventArgs e)
        {

        }

        private void txtHuruf_Leave(object sender, EventArgs e)
        {
            if (txtHuruf.Text == "")
            {
                SetErrorMessages(txtHuruf, "Textbox Huruf tidak boleh kosong!", "", "");
            }
            else if (txtHuruf.Text.All(Char.IsLetter))
            {
                SetErrorMessages(txtHuruf, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(txtHuruf, "", "Inputan hanya boleh huruf!", "");
            }
        }
        private void txtAngka_Leave(object sender, EventArgs e)
        {
            if (txtAngka.Text == "")
            {
                SetErrorMessages(txtAngka, "Textbox Angka tidak boleh kosong!", "", "");
            }
            else if (txtAngka.Text.All(Char.IsNumber))
            {
                SetErrorMessages(txtAngka, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(txtAngka, "", "Inputan hanya boleh angka!", "");
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                SetErrorMessages(txtEmail, "Textbox Email tidak boleh kosong!", "", "");
            }
            else if (Regex.IsMatch(txtEmail.Text, @"^^[^@\s]+@[^@\s]+(\.[^@\s]+)+$"))
            {
                SetErrorMessages(txtEmail, "", "", "Betul!");
            }
            else
            {
                SetErrorMessages(txtEmail, "", "Format email salah!\nContoh: a@b.c", "");
            }
        }

        private void txtAngka1_TextChanged(object sender, EventArgs e)
        {
            // Menggunakan string.IsNullOrEmpty untuk cek kekosongan
            if (string.IsNullOrEmpty(txtAngka1.Text))
            {
                // Error: Tidak boleh kosong
                SetErrorMessages(txtAngka1, "Textbox Angka1 tidak boleh kosong!", "", "");
            }
            // Menggunakan int.TryParse untuk memastikan input adalah angka
            else if (int.TryParse(txtAngka1.Text, out _))
            {
                // Sukses: Input adalah angka
                SetErrorMessages(txtAngka1, "", "", "Betul!");
            }
            else
            {
                // Error: Bukan angka
                SetErrorMessages(txtAngka1, "", "Inputan hanya boleh angka!", "");
            }
        }

        private void txtAngka2_TextChanged(object sender, EventArgs e)
        {
            // Menggunakan string.IsNullOrEmpty untuk cek kekosongan
            if (string.IsNullOrEmpty(txtAngka2.Text))
            {
                // Error: Tidak boleh kosong
                SetErrorMessages(txtAngka2, "Textbox Angka1 tidak boleh kosong!", "", "");
            }
            // Menggunakan int.TryParse untuk memastikan input adalah angka
            else if (int.TryParse(txtAngka2.Text, out _))
            {
                // Sukses: Input adalah angka
                SetErrorMessages(txtAngka2, "", "", "Betul!");
            }
            else
            {
                // Error: Bukan angka
                SetErrorMessages(txtAngka2, "", "Inputan hanya boleh angka!", "");
            }
        }
    }
}