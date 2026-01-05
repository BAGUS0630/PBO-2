using P9_714240060.controller;
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
    public partial class FormLogin : Form
    {
        CekLogin login = new CekLogin();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Mengecek apakah textbox username dan password kosong
            if (string.IsNullOrWhiteSpace(tbUsername.Text) || string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show(
                    "Username dan Password tidak boleh kosong!",
                    "Peringatan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string username = tbUsername.Text;
            string password = tbPassword.Text;

            bool status = login.cek_login(username, password);

            //mengecek hasil login
            if (status)
            {
                //jika login berhasil
                MessageBox.Show(
                    "Login Berhasil!",
                    "Informasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ParentForm pform = new ParentForm(); // membuat objek parentform
                Hide(); // menyembunyikan form login
                pform.Show(); // menampilkan parentform

            }
            else
            {
                MessageBox.Show(
                    "Username atau Password salah!",
                    "Gagal Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
            );

            }
        }
    }
}
