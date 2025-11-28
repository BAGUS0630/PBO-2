using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P7_1_714240060
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Size = new Size(411, 326);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonTutup_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCek_Click(object sender, EventArgs e)
        {
            StringBuilder errorMessage = new StringBuilder();

            if (string.IsNullOrWhiteSpace(textBoxNama.Text))
            {
                errorMessage.AppendLine("Nama Harus diisi.");
            }

            if (comboBoxAngkatan.SelectedIndex == -1)
            {
                errorMessage.AppendLine("Angkatan Harus diisi.");
            }

            if (string.IsNullOrWhiteSpace(textBoxKelas.Text))
            {
                errorMessage.AppendLine("Kelaas Harus diisi.");
            }

            string errorString = errorMessage.ToString();

            if (string.IsNullOrEmpty(errorString))
            {
                MessageBox.Show(
                    "Lengkap",
                    "Informasi Data Submit",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Size = new Size(411, 326);
            }
            else
            {
                MessageBox.Show(
                    errorString.Trim(),
                    "Informasi Data Submit",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void radioButtonWeekday_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeekday.Checked)
            {
                {
                    checkBoxKuliah.Enabled = true; checkBoxKuliah.Checked = false;
                    checkBoxTidur.Enabled = true;  checkBoxTidur.Checked = false;
                    checkBoxLiburan.Enabled = false; checkBoxLiburan.Checked = false;
                }
            }
        }

        private void radioButtonWeekend_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeekend.Checked)
            {
                checkBoxKuliah.Enabled = false; checkBoxKuliah.Checked = false;
                checkBoxTidur.Enabled = true; checkBoxTidur.Checked = false;
                checkBoxLiburan.Enabled = true; checkBoxLiburan.Checked = false;
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            string hari = null;
            string kegiatan = null;

            foreach(Control control in Controls)
            {
                if (control is RadioButton radioButton && radioButton.Checked)
                {
                    hari = radioButton.Text;
                    break;
                }
            }

            foreach(Control control in Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    if (!string.IsNullOrEmpty(kegiatan))
                    {
                        kegiatan += ", ";
                    }
                    kegiatan += checkBox.Text;
                }
            }

            MessageBox.Show(
                "Nama: " + textBoxNama.Text + "\n" +
                "Angkatan: " + comboBoxAngkatan.Text + "\n" +
                "Kelas: " + textBoxKelas.Text + "\n" +
                "=========================\n" +
                "Hari: " + hari + "\n" +
                "Kegiatan: " + kegiatan,
                "Informasi Data Submit",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
            }
            MessageBox.Show(
                "Form telah direset.",
                "Informasi Reset",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            Size = new Size(411, 326);
        }
    }
 }
