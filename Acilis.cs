using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ogrenci_Takip
{
    public partial class Acilis : Form
    {
        public Acilis()
        {
            InitializeComponent();
        }
        
        byte bekle=0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (this.Opacity != 0)
            {
                this.Opacity -= 0.05;
                this.Top += 10;
            }
            else
            {
                giris giris= new giris();
                giris.Show();
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                this.Hide();
                
            }
          
        }

        private void Acilis_Load(object sender, EventArgs e)
        {
            
           
            timer2.Start();
            timer3.Start();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bekle++;
            if (bekle == 2)
            {
                timer1.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0,1);
        }

      
       
    }
}
