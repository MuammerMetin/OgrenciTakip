using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace Ogrenci_Takip
{
    public partial class ilk : Form
    {
        public ilk()
        {
            InitializeComponent();
        }
        int kod;
        int captcha;
        private void guvenlik()
        {
            Random r = new Random();
            captcha = r.Next(0, 6);
            label49.Image = ımageList1.Images[captcha];
            Random rnd = new Random();
            kod = rnd.Next(1000, 9999);
            label49.Text = kod.ToString();
        }
        private void ort()
        {
            int a=0, b=0, c=0, d=0;
            
             
           
            
            if (comboBox1.SelectedIndex == 0)
            {
                if (textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "")
                {
                    return;
                }
                a = Convert.ToInt16(textBox13.Text);
                b = Convert.ToInt16(textBox14.Text);
                c = Convert.ToInt16(textBox15.Text);
                d = Convert.ToInt16(textBox16.Text);
           
                label36.Text=((a + b + c + d) / 4).ToString();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if (textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "")
                {
                    return;
                }
                a = Convert.ToInt16(textBox13.Text);
                b = Convert.ToInt16(textBox14.Text);
                c = Convert.ToInt16(textBox15.Text);
                d = Convert.ToInt16(textBox16.Text);
           
                label36.Text = ((a + b + c + d) / 4).ToString();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                if (textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "")
                {
                    return;
                }
                a = Convert.ToInt16(textBox13.Text);
                b = Convert.ToInt16(textBox14.Text);
                c = Convert.ToInt16(textBox15.Text);
              
           
                label36.Text = ((a + b + c ) / 3).ToString();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                if (textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "")
                {
                    return;
                }
                a = Convert.ToInt16(textBox13.Text);
                b = Convert.ToInt16(textBox14.Text);
                c = Convert.ToInt16(textBox15.Text);
                d = Convert.ToInt16(textBox16.Text);
           
                label36.Text = ((a + b + c + d) / 4).ToString();
            }
            if (comboBox1.SelectedIndex == 4)
            {
                if (textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "")
                {
                    return;
                }
                a = Convert.ToInt16(textBox13.Text);
                b = Convert.ToInt16(textBox14.Text);
                c = Convert.ToInt16(textBox15.Text);
                d = Convert.ToInt16(textBox16.Text);
           
                label36.Text = ((a + b + c + d) / 4).ToString();
            }
        }
        OleDbConnection connect = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=okul.accdb");
        OleDbCommand command = new OleDbCommand();
        OleDbDataReader read;
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Numara Seçiniz...")
            {
                MessageBox.Show("Öğrenci numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            connect.Open();
            command.Connection = connect;
            command.CommandText = ("Select*From OgrBilgiTbl Where OgrNo="+comboBox3.Text+"");
            read = command.ExecuteReader();
            while (read.Read())
            {
                comboBox3.Text = read["OgrNo"].ToString();
                textBox2.Text = read["Adi"].ToString();
                textBox3.Text = read["Soyadi"].ToString();
                textBox4.Text = read["Sinifi"].ToString();
            }
            read.Dispose();
            command.CommandText = ("Select*From VeliBilgileri Where OgrNo=" + comboBox3.Text + "");
            read = command.ExecuteReader();
            while (read.Read())
            {
                textBox8.Text = read["VeliAd"].ToString();
                textBox7.Text = read["VeliSoyad"].ToString();
                textBox6.Text = read["Telefon"].ToString();
                textBox5.Text = read["Adres"].ToString();
            }
            connect.Close();
            read.Dispose();

            if (textBox5.Text == "" && textBox6.Text == "" && textBox7.Text == "" && textBox8.Text == "")
            {
                button1.Enabled = true;
                button3.Enabled = false;
                button1.Cursor = Cursors.Default;
                button3.Cursor = Cursors.WaitCursor;
            }
            else
            {
                button3.Cursor = Cursors.Default;
                button3.Enabled = true;
                button1.Enabled = false;
                button1.Cursor = Cursors.WaitCursor;
            }
            ort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Öğrenci numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            connect.Open();
            command.Connection = connect;
            command.CommandText = ("UPDATE OgrBilgiTbl SET OgrNo=" + comboBox3.Text + ",Adi='" + textBox2.Text + "',Soyadi='" + textBox3.Text + "',Sinifi='" + textBox4.Text + "' Where OgrNo=" + comboBox3.Text + "");
            command.ExecuteNonQuery();
           
            
            command.CommandText = ("Select*From VeliBilgileri Where OgrNo=" + comboBox3.Text + "");
            command.ExecuteNonQuery();
            connect.Close();
            
            MessageBox.Show("Bilgiler Güncellendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            yenile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == ""||textBox2.Text==""||textBox3.Text==""||textBox4.Text==""||textBox5.Text==""||textBox6.Text==""||textBox7.Text==""||textBox8.Text=="")
            {
                MessageBox.Show("Tüm alanları doldurunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = ("INSERT INTO OgrBilgiTbl(OgrNo,Adi,Soyadi,Sinifi) VALUES(" + comboBox3.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')  ");
                command.ExecuteNonQuery();
                command.CommandText = ("INSERT INTO VeliBilgileri(OgrNo,VeliAd,VeliSoyad,Telefon,Adres) VALUES("+comboBox3.Text+",'"+textBox8.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + textBox4.Text + "')  ");
                command.ExecuteNonQuery();
                

             
                connect.Close();

                MessageBox.Show("Bilgiler Başarıyla Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OleDbException)
            {
                MessageBox.Show("Girdiğiniz öğrenci numarası kayıtlı veya Geçersiz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                connect.Close();
            }
            yenile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DialogResult a;
            a=MessageBox.Show(comboBox3.Text+" Numaralı öğrenciyi silme istediğinizden emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (a == DialogResult.Yes)
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = ("Delete*From OgrBilgiTbl Where=" + comboBox3.Text + "");
                command.ExecuteNonQuery();
                
            }
            connect.Close(); yenile();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            comboBox3.Text = ""; textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); textBox8.Clear();
            yenile();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            if (comboBox2.Text == "Numara Seçiniz...")
            {
                MessageBox.Show("Öğrenci numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            connect.Open();
            command.Connection = connect;
            command.CommandText = ("Select*From OgrBilgiTbl Where OgrNo=" + comboBox2.Text + "");
            read = command.ExecuteReader();
            while (read.Read())
            {
                comboBox2.Text = read["OgrNo"].ToString();
                textBox10.Text = read["Adi"].ToString();
                textBox11.Text = read["Soyadi"].ToString();
                textBox12.Text = read["Sinifi"].ToString();
            }
            read.Dispose();
            
            connect.Close();
            if (comboBox1.SelectedIndex == 0)
            {
                connect.Open();
                command.CommandText = ("Select*From NesneProgramlama Where OgrNo=" + comboBox2.Text + "");
                read = command.ExecuteReader();
                while (read.Read())
                {
                    textBox13.Text = read["Yazili1"].ToString();
                    textBox14.Text = read["Yazili2"].ToString();
                    textBox16.Text = read["Yazili3"].ToString();
                    textBox15.Text = read["Sozlu"].ToString();
                    
                }
                connect.Close(); read.Dispose();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                connect.Open();
                command.CommandText = ("Select*From Matematik Where OgrNo=" + comboBox2.Text + "");
                read = command.ExecuteReader();
                while (read.Read())
                {
                    textBox13.Text = read["Yazili1"].ToString();
                    textBox14.Text = read["Yazili2"].ToString();
                    textBox16.Text = read["Yazili3"].ToString();
                    textBox15.Text = read["Sozlu"].ToString();

                }
                connect.Close(); read.Dispose();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                connect.Open();
                command.CommandText = ("Select*From DilAnlatım Where OgrNo=" + comboBox2.Text + "");
                read = command.ExecuteReader();
                while (read.Read())
                {
                    textBox13.Text = read["Yazili1"].ToString();
                    textBox14.Text = read["Yazili2"].ToString();
                   
                    textBox15.Text = read["Sozlu"].ToString();

                }
                connect.Close(); read.Dispose();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                connect.Open();
                command.CommandText = ("Select*From Veri Where OgrNo=" + comboBox2.Text + "");
                read = command.ExecuteReader();
                while (read.Read())
                {
                    textBox13.Text = read["Yazili1"].ToString();
                    textBox14.Text = read["Yazili2"].ToString();
                    textBox16.Text = read["Yazili3"].ToString();
                    textBox15.Text = read["Sozlu"].ToString();

                }
                connect.Close(); read.Dispose();
            }
            if (comboBox1.SelectedIndex == 4)
            {
                connect.Open();
                command.CommandText = ("Select*From ingilizce Where OgrNo=" + comboBox2.Text + "");
                read = command.ExecuteReader();
                while (read.Read())
                {
                    textBox13.Text = read["Yazili1"].ToString();
                    textBox14.Text = read["Yazili2"].ToString();
                    textBox16.Text = read["Yazili3"].ToString();
                    textBox15.Text = read["Sozlu"].ToString();

                }
                connect.Close(); read.Dispose();
            }
            connect.Close();
            yenile();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == 0)
            {
                connect.Open();
                command.CommandText = ("Insert Into NesneProgramlama(OgrNo,yazili1,yazili2,yazili3,sozlu) Values(" + comboBox2.Text + "," + textBox13.Text + "," + textBox14.Text + "," + textBox16.Text + "," + textBox15.Text + ") ");
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Notlar Başarıyla Eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ort();

            }
            if (comboBox1.SelectedIndex == 1)
            {
                connect.Open();
                command.CommandText = ("Insert Into matematik(OgrNo,yazili1,yazili2,yazili3,sozlu) Values(" + comboBox2.Text + "," + textBox13.Text + "," + textBox14.Text + "," + textBox16.Text + "," + textBox15.Text + ")");
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Notlar Başarıyla Eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ort();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                connect.Open();
                command.CommandText = ("Insert Into dilanlatım(OgrNo,yazili1,yazili2,sozlu) Values(" + comboBox2.Text + "," + textBox13.Text + "," + textBox14.Text + "," + textBox15.Text + ")");
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Notlar Başarıyla Eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ort();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                connect.Open();
                command.CommandText = ("Insert Into veri(OgrNo,yazili1,yazili2,yazili3,sozlu) Values(" + comboBox2.Text + "," + textBox13.Text + "," + textBox14.Text + "," + textBox16.Text + "," + textBox15.Text + ") ");
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Notlar Başarıyla Eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ort();
            }
            if (comboBox1.SelectedIndex == 4)
            {
                connect.Open();
                command.CommandText = ("Insert Into ingilizce(OgrNo,yazili1,yazili2,yazili3,sozlu) Values(" + comboBox2.Text + "," + textBox13.Text + "," + textBox14.Text + "," + textBox16.Text + "," + textBox15.Text + ")");
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Notlar Başarıyla Eklendi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ort();
            }
            yenile();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (comboBox2.Text == "Numara Seçiniz...")
            {
                MessageBox.Show("Öğrenci numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = ("UPDATE NesneProgramlama SET Yazili1=" +textBox13.Text + ",Yazili2=" + textBox14.Text + ",Yazili3=" + textBox16.Text + ",Sozlu="+textBox15.Text+" Where OgrNo=" +comboBox2.Text + "");
                command.ExecuteNonQuery();
                MessageBox.Show("Bilgiler Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ort();

                connect.Close();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = ("UPDATE matematik SET Yazili1=" + textBox13.Text + ",Yazili2=" + textBox14.Text + ",Yazili3=" + textBox16.Text + ",Sozlu=" + textBox15.Text + " Where OgrNo=" + comboBox2.Text + "");
                command.ExecuteNonQuery();
                MessageBox.Show("Bilgiler Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ort();

                connect.Close();
            }
            if (comboBox1.SelectedIndex ==2)
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = ("UPDATE dilanlatım SET Yazili1=" + textBox13.Text + ",Yazili2=" + textBox14.Text + ",Sozlu=" + textBox15.Text + " Where OgrNo=" + comboBox2.Text + "");
                command.ExecuteNonQuery();
                MessageBox.Show("Bilgiler Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ort();

                connect.Close();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = ("UPDATE veri SET Yazili1=" + textBox13.Text + ",Yazili2=" + textBox14.Text + ",Yazili3=" + textBox16.Text + ",Sozlu=" + textBox15.Text + " Where OgrNo=" + comboBox2.Text + "");
                command.ExecuteNonQuery();
                MessageBox.Show("Bilgiler Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ort();

                connect.Close();
            }
            if (comboBox1.SelectedIndex == 4)
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = ("UPDATE ingilizce SET Yazili1=" + textBox13.Text + ",Yazili2=" + textBox14.Text + ",Yazili3=" + textBox16.Text + ",Sozlu=" + textBox15.Text + " Where OgrNo=" + comboBox2.Text + "");
                command.ExecuteNonQuery();
                MessageBox.Show("Bilgiler Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ort();

                connect.Close();
               
            }
            yenile();

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            if (comboBox2.SelectedIndex == 0)
            {
                DialogResult a;
                a = MessageBox.Show(comboBox2.Text + " Numaralı öğrencinin notlarını silmek emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (a == DialogResult.Yes)
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = ("Delete*From NesneProgramlama Where OgrNo=" + comboBox2.Text + "");
                    command.ExecuteNonQuery();

                    connect.Close();
                }
                
            }

            if (comboBox2.SelectedIndex == 1)
            {
                DialogResult a;
                a = MessageBox.Show(comboBox2.Text + " Numaralı öğrencinin notlarını silmek emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (a == DialogResult.Yes)
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = ("Delete*From matematik Where OgrNo=" + comboBox2.Text + "");
                    command.ExecuteNonQuery();

                    connect.Close();
                }
            }
            if (comboBox2.SelectedIndex == 2)
            {
                connect.Open();
                command.Connection = connect;
                command.CommandText = ("Delete*From dilanlatım Where OgrNo=" + comboBox2.Text + "");
                command.ExecuteNonQuery();

                connect.Close();
            }
            if (comboBox2.SelectedIndex == 3)
            {
                DialogResult a;
                a = MessageBox.Show(comboBox2.Text + " Numaralı öğrencinin notlarını silmek emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (a == DialogResult.Yes)
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = ("Delete*From veri Where OgrNo=" + comboBox2.Text + "");
                    command.ExecuteNonQuery();

                    connect.Close();
                }
            }
            if (comboBox2.SelectedIndex == 4)
            {
                DialogResult a;
                a = MessageBox.Show(comboBox2.Text + " Numaralı öğrencinin notlarını silmek emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (a == DialogResult.Yes)
                {
                    connect.Open();
                    command.Connection = connect;
                    command.CommandText = ("Delete*From ingilizce Where OgrNo=" + comboBox2.Text + "");
                    command.ExecuteNonQuery();

                    connect.Close();
                }
            }
            yenile();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            yenile(); 
            textBox13.Clear(); textBox14.Clear(); textBox15.Clear(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (comboBox2.Text == "Numara Seçiniz...")
                {
                    MessageBox.Show("Öğrenci numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                textBox13.Clear(); textBox14.Clear(); textBox15.Clear(); textBox16.Clear();
                label38.Visible=true;
                label37.Visible=true;
                textBox16.Visible = true;

                connect.Open();
                command.CommandText = ("Select*From NesneProgramlama Where OgrNo=" + comboBox2.Text + "");
                read = command.ExecuteReader();
                while (read.Read())
                {
                    textBox13.Text = read["Yazili1"].ToString();
                    textBox14.Text = read["Yazili2"].ToString();
                    textBox16.Text = read["Yazili3"].ToString();
                    textBox15.Text = read["Sozlu"].ToString();

                }
                connect.Close();
                if (textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "")
                {
                    button6.Enabled = false;
                    button8.Enabled = true;
                    button8.Cursor = Cursors.Default;
                    button6.Cursor = Cursors.WaitCursor;
                }
                else
                {
                    button6.Cursor = Cursors.Default;
                    button6.Enabled = true;
                    button8.Enabled = false;
                    button8.Cursor = Cursors.WaitCursor;
                }
                ort();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                textBox13.Clear(); textBox14.Clear(); textBox15.Clear(); textBox16.Clear();
                if (comboBox2.Text == "Numara Seçiniz...")
                {
                    MessageBox.Show("Öğrenci numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                label38.Visible = true;
                label37.Visible = true;
                textBox16.Visible = true;
                connect.Open();
                command.CommandText = ("Select*From Matematik Where OgrNo=" + comboBox2.Text + "");
                read = command.ExecuteReader();
                while (read.Read())
                {
                    textBox13.Text = read["Yazili1"].ToString();
                    textBox14.Text = read["Yazili2"].ToString();
                    textBox16.Text = read["Yazili3"].ToString();
                    textBox15.Text = read["Sozlu"].ToString();

                }
                connect.Close(); read.Dispose();
                if (textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "")
                {
                    button6.Enabled = false;
                    button8.Enabled = true;
                    button8.Cursor = Cursors.Default;
                    button6.Cursor = Cursors.WaitCursor;
                }
                else
                {
                    button6.Cursor = Cursors.Default;
                    button6.Enabled = true;
                    button8.Enabled = false;
                    button8.Cursor = Cursors.WaitCursor;
                } ort();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                textBox13.Clear(); textBox14.Clear(); textBox15.Clear(); textBox16.Clear();
                if (comboBox2.Text == "Numara Seçiniz...")
                {
                    MessageBox.Show("Öğrenci numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                label38.Visible = false;
                label37.Visible = false;
                textBox16.Visible = false;
                connect.Open();
                command.CommandText = ("Select*From DilAnlatım Where OgrNo=" + comboBox2.Text + "");
                read = command.ExecuteReader();
                while (read.Read())
                {
                    textBox13.Text = read["Yazili1"].ToString();
                    textBox14.Text = read["Yazili2"].ToString();

                    textBox15.Text = read["Sozlu"].ToString();

                }
                connect.Close(); read.Dispose();
                if (textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "")
                {
                    button6.Enabled = false;
                    button8.Enabled = true;
                    button8.Cursor = Cursors.Default;
                    button6.Cursor = Cursors.WaitCursor;
                }
                else
                {
                    button6.Cursor = Cursors.Default;
                    button6.Enabled = true;
                    button8.Enabled = false;
                    button8.Cursor = Cursors.WaitCursor;
                } ort();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                textBox13.Clear(); textBox14.Clear(); textBox15.Clear(); textBox16.Clear();
                if (comboBox2.Text == "Numara Seçiniz...")
                {
                    MessageBox.Show("Öğrenci numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                label38.Visible = true;
                label37.Visible = true;
                textBox16.Visible = true;
                connect.Open();
                command.CommandText = ("Select*From Veri Where OgrNo=" + comboBox2.Text + "");
                read = command.ExecuteReader();
                while (read.Read())
                {
                    textBox13.Text = read["Yazili1"].ToString();
                    textBox14.Text = read["Yazili2"].ToString();
                    textBox16.Text = read["Yazili3"].ToString();
                    textBox15.Text = read["Sozlu"].ToString();

                }
                connect.Close(); read.Dispose();
                if (textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "")
                {
                    button6.Enabled = false;
                    button8.Enabled = true;
                    button8.Cursor = Cursors.Default;
                    button6.Cursor = Cursors.WaitCursor;
                }
                else
                {
                    button6.Cursor = Cursors.Default;
                    button6.Enabled = true;
                    button8.Enabled = false;
                    button8.Cursor = Cursors.WaitCursor;
                } ort();
            }
            if (comboBox1.SelectedIndex == 4 )
            {
                textBox13.Clear(); textBox14.Clear(); textBox15.Clear(); textBox16.Clear();
                if (comboBox2.Text == "Numara Seçiniz...")
                {
                    MessageBox.Show("Öğrenci numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                label38.Visible = true;
                label37.Visible = true;
                textBox16.Visible = true;
                connect.Open();
                command.CommandText = ("Select*From ingilizce Where OgrNo=" + comboBox2.Text + "");
                read = command.ExecuteReader();
                while (read.Read())
                {
                    textBox13.Text = read["Yazili1"].ToString();
                    textBox14.Text = read["Yazili2"].ToString();
                    textBox16.Text = read["Yazili3"].ToString();
                    textBox15.Text = read["Sozlu"].ToString();

                }
                connect.Close(); read.Dispose();
                if (textBox13.Text == "" && textBox14.Text == "" && textBox15.Text == "" && textBox16.Text == "")
                {
                    button6.Enabled = false;
                    button8.Enabled = true;
                    button8.Cursor = Cursors.Default;
                    button6.Cursor = Cursors.WaitCursor;
                }
                else
                {
                    button6.Cursor = Cursors.Default;
                    button6.Enabled = true;
                    button8.Enabled = false;
                    button8.Cursor = Cursors.WaitCursor;
                }
            } ort();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label39.Text = label39.Text.Substring(1) + label39.Text.Substring(0, 1);
        }

        private void ilk_Load(object sender, EventArgs e)
        {
            guvenlik();
            yenile();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (connect.State==ConnectionState.Closed)
            {
                connect.Open();
                read.Dispose();
            }
            read.Dispose();
            command.Connection = connect;
            command.CommandText = ("Select*From OgrBilgiTbl Where OgrNo=" + comboBox2.Text + "");
            read = command.ExecuteReader();
            while (read.Read())
            {
                comboBox2.Text = read["OgrNo"].ToString();
                textBox10.Text = read["Adi"].ToString();
                textBox11.Text = read["Soyadi"].ToString();
                textBox12.Text = read["Sinifi"].ToString();
            }

            read.Dispose();
            connect.Close();
            
        }
        private void yenile()
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            connect.Open();
            command.Connection = connect;
            command.CommandText = ("Select OgrNo From OgrBilgiTbl");
            read = command.ExecuteReader();
            while (read.Read())
            {
               
                comboBox2.Items.Add(read["OgrNo"]);
                comboBox3.Items.Add(read["OgrNo"]);

            }
            timer1.Start();
            connect.Close();
            read.Dispose();
        }
        private void button11_Click(object sender, EventArgs e)
        {
           
            string kullanici="",sifre="";
           
            connect.Open();
            command.Connection = connect;
            command.CommandText = ("Select*From Giris");
            read=command.ExecuteReader();
            while(read.Read())
            {
                kullanici=read["k_adi"].ToString();
                sifre=read["sifre"].ToString();
            }
            read.Dispose();
            connect.Close();
            if (textBox9.Text == kullanici && textBox17.Text == sifre)
            {
                if (textBox20.Text == label49.Text)
                {



                    if (textBox18.Text == textBox19.Text)
                    {
                        connect.Open();
                        command.Connection = connect;
                        command.CommandText = ("Update giris set sifre='" + textBox18.Text + "'");
                        command.ExecuteNonQuery();
                        connect.Close();
                        MessageBox.Show("Şifre değiştirilmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Şifreler uyumsuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Güvenlik kodu yanlış.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            yenile();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            guvenlik();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            connect.Open();
            command.Connection = connect;
            command.CommandText = ("Select*From OgrBilgiTbl Where OgrNo=" + comboBox3.Text + "");
            read = command.ExecuteReader();
            while (read.Read())
            {
                comboBox3.Text = read["OgrNo"].ToString();
                textBox2.Text = read["Adi"].ToString();
                textBox3.Text = read["Soyadi"].ToString();
                textBox4.Text = read["Sinifi"].ToString();
            }
            read.Dispose();

            connect.Close();
        }

        private void ilk_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ilk_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            OleDbDataAdapter adptr;
            OleDbDataAdapter adptr1;
            DataSet d_set = new DataSet();
            DataSet d_set1 = new DataSet();

            if (comboBox4.SelectedIndex == 0)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                d_set.Tables.Clear();

                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                d_set1.Tables.Clear();
                adptr = new OleDbDataAdapter("Select*From NesneProgramlama Where Ortalama>50",connect);
                adptr.Fill(d_set,"NesneProgramlama");
                dataGridView1.DataSource = d_set.Tables["NesneProgramlama"];

                adptr1 = new OleDbDataAdapter("Select*From NesneProgramlama Where Ortalama<50", connect);
                adptr1.Fill(d_set1, "NesneProgramlama");
                dataGridView2.DataSource = d_set1.Tables["NesneProgramlaa"];

                
                
            }

            if (comboBox4.SelectedIndex == 1)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                d_set.Tables.Clear();

                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                d_set1.Tables.Clear();
                adptr = new OleDbDataAdapter("Select*From matematik Where Ortalama>50", connect);
                adptr.Fill(d_set, "matematik");
                dataGridView1.DataSource = d_set.Tables["matematik"];

                adptr1 = new OleDbDataAdapter("Select*From matematik Where Ortalama<50", connect);
                adptr1.Fill(d_set1, "matematik");
                dataGridView2.DataSource = d_set1.Tables["matematik"];
              
            }
            if (comboBox4.SelectedIndex == 2)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                d_set.Tables.Clear();

                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                d_set1.Tables.Clear();

                adptr = new OleDbDataAdapter("Select*From DilAnlatım Where Ortalama>50", connect);
                adptr.Fill(d_set, "DilAnlatım");
                dataGridView1.DataSource = d_set.Tables["DilAnlatım"];

                adptr1 = new OleDbDataAdapter("Select*From DilAnlatım Where Ortalama<50", connect);
                adptr1.Fill(d_set1, "DilAnlatım");
                dataGridView2.DataSource = d_set1.Tables["DilAnlatım"];
              
              

            }
            if (comboBox4.SelectedIndex == 3)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                d_set.Tables.Clear();

                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                d_set1.Tables.Clear();

                adptr = new OleDbDataAdapter("Select*From Veri Where Ortalama>50", connect);
                adptr.Fill(d_set, "veri");
                dataGridView1.DataSource = d_set.Tables["veri"];

                adptr1 = new OleDbDataAdapter("Select*From veri Where Ortalama<50", connect);
                adptr1.Fill(d_set1, "veri");
                dataGridView2.DataSource = d_set1.Tables["veri"];

                
            }
            if (comboBox4.SelectedIndex == 4)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                d_set.Tables.Clear();

                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                d_set1.Tables.Clear();

                adptr = new OleDbDataAdapter("Select*From ingilizce Where Ortalama>50", connect);
                adptr.Fill(d_set, "ingilizce");
                dataGridView1.DataSource = d_set.Tables["ingilizce"];

                adptr1 = new OleDbDataAdapter("Select*From ingilizce Where Ortalama<50", connect);
                adptr1.Fill(d_set1, "ingilizce");
                dataGridView2.DataSource = d_set1.Tables["ingilizce"];
                


            }
            
            
        }

     
       

        }


             

    }

