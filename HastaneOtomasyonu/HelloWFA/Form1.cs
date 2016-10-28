using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWFA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text;
            string sifre = txtSifre.Text;

            if (kullaniciAdi == "Admin" && sifre == "1234")
                MessageBox.Show("Hoşgeldin admin");
            else
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Form yüklendi");
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Form kapanıyor", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.No)
                e.Cancel = true;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Form kapandı. Gemiş olsun");
        }
    }
}
