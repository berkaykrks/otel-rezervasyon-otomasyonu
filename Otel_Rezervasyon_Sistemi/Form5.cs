using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();

            // Kullanıcı adını kullanarak hoşgeldin mesajını ayarla
            kullanici_ad.Text = Degiskenler.getUsername() + " Hoşgeldiniz";
        }

        // Formun başlığını sürüklemek için Windows API'ye mesaj gönderir
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            // Formu sürüklemek için Windows API'ye mesaj gönderir
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        // Diğer formlara geçiş yapmak için buton tıklama olayları
        private void button14_Click(object sender, EventArgs e)
        {
            // Form7'yi göster, bu formu gizle
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Uygulamayı kapat
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Form6'yı göster, bu formu gizle
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Form8'i göster, bu formu gizle
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Form9'u göster, bu formu gizle
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Form10'u göster, bu formu gizle
            Form10 form10 = new Form10();
            form10.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Form11'i göster, bu formu gizle
            Form11 form11 = new Form11();
            form11.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Form12'yi göster, bu formu gizle
            Form12 form12 = new Form12();
            form12.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Form13'ü göster, bu formu gizle
            Form13 form13 = new Form13();
            form13.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Form14'ü göster, bu formu gizle
            Form14 form14 = new Form14();
            form14.Show();
            this.Hide();
        }
    }
}
