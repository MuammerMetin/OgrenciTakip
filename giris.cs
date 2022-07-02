using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Ogrenci_Takip
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        int kod;
        int captcha;
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=okul.accdb");
        OleDbCommand command = new OleDbCommand();
        OleDbDataReader read;
        private void giris_Load(object sender, EventArgs e)
        {
            guvenlik();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            connect.Open();
            command.Connection = connect;
            command.CommandText=("SELECT*FROM giris");
            read=command.ExecuteReader();
            while (read.Read())
            {
                if (textBox3.Text != kod.ToString())
                {
                    MessageBox.Show("Güvenlik Kodu Hatalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    connect.Close();
                    return;
                }
                if (textBox1.Text != read["k_adi"].ToString() || textBox2.Text != read["sifre"].ToString())
                {
                   // MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    connect.Close();
                    return;
                }
                if (textBox1.Text == read["k_adi"].ToString() && textBox2.Text == read["sifre"].ToString() && textBox3.Text == kod.ToString())
                {
                    ilk ilk_1 = new ilk();
                    ilk_1.Show();
                    this.Hide();
                }

            }
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult a;
            a = MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            guvenlik();
        }
        private void guvenlik()
        {
            Random r = new Random();
            captcha = r.Next(0, 6);
            label5.Image = ımageList1.Images[captcha];
            Random rnd = new Random();
            kod = rnd.Next(1000, 9999);
            label5.Text = kod.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.technoprogram.com");
        }
       
     
       

    

    }
}
