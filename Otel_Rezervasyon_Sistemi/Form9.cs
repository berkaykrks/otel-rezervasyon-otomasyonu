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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        // Geri butonu, Form5'e geçiş yapar
        private void button12_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        // Uygulamayı kapatma işlemi
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Formu sürüklemek için gerekli Windows API mesajları
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        // Windows API'ye mesaj göndermek için DllImport özellikleri
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        // Paneli sürüklerken formun hareket etmesini sağlar
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }       
        private void button3_Click(object sender, EventArgs e)
        {

        }

        public static void HotelButton_Click(object sender, EventArgs e)
        {
            // Tıklanan butonu al
            Button clickedButton = sender as Button;
            if (clickedButton == null) return; // Eğer buton değilse geri dön

            // Butonun Tag'inden bilgileri al
            var controls = clickedButton.Tag as Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>;
            if (controls == null) return; // Kontroller mevcut değilse geri dön

            string hotelName = controls.Item1; // Otel adını al
            NumericUpDown numericUpDown = controls.Item2;  // Kişi sayısı için
            DateTimePicker checkInPicker = controls.Item3;  // Giriş tarihi için
            DateTimePicker checkOutPicker = controls.Item4;  // Çıkış tarihi için

            // Giriş değerlerini al
            int kişiSayısı = Convert.ToInt32(numericUpDown.Value); // Kişi sayısı
            DateTime checkInDate = checkInPicker.Value;
            DateTime checkOutDate = checkOutPicker.Value;

            // Gün sayısını hesapla
            TimeSpan dateDifference = checkOutDate - checkInDate;
            int dayCount = dateDifference.Days;

            // Bugünün tarihini al
            DateTime today = DateTime.Today;

            // Giriş ve çıkış tarihlerinin bugünden sonraki tarih olması gerekmekte
            if (checkInDate <= today)
            {
                MessageBox.Show("Giriş tarihi bugünden sonraki bir tarih olmalıdır.");
                return;
            }

            if (checkOutDate <= today)
            {
                MessageBox.Show("Çıkış tarihi bugünden sonraki bir tarih olmalıdır.");
                return;
            }

            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Çıkış tarihi giriş tarihinden sonra olmalıdır.");
                return;
            }

            // Geçerli kontrol şartları
            if (kişiSayısı < 1)
            {
                MessageBox.Show("Kişi sayısı en az 1 olmalıdır.");
                return;
            }

            if (dayCount < 1)
            {
                MessageBox.Show("En az 1 günlük rezervasyon yapabilirsiniz.");
                return;
            }

            // Fiyatı hesaplamak için fonksiyonu çağır
            int totalPrice = Fonksiyonlar.CalculateTotalPrice(kişiSayısı, dayCount);

            // Kullanıcıya toplam fiyatı göster ve onay al
            DialogResult result = MessageBox.Show(
                $"Rezervasyon kişi sayısı :{kişiSayısı}\nKalınacak gün sayısı:{dayCount}\nToplam ödenecek ücret :{totalPrice} TL.\nRezervasyonunuzu onaylıyor musunuz ?",
                "Rezervasyon Onaylama",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Kullanıcı "Evet" derse rezervasyonu gerçekleştir
            if (result == DialogResult.Yes)
            {
                // Rezervasyon işlemi burada yapılabilir (veritabanına ekleme vb.)
                MessageBox.Show("Rezervasyonunuz onaylandı!");

                // Otel adını kullanarak rezervasyonu gerçekleştir
                Fonksiyonlar.ReserveHotel(hotelName, kişiSayısı, checkInDate, checkOutDate, totalPrice);
            }
            else
            {
                // Kullanıcı "Hayır" derse işlem iptal edilir
                MessageBox.Show("Rezervasyonunuz iptal edildi.");
            }
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            button3.Tag = new Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>(hotelName_31.Text, numericUpDown9, dateTimePicker18, dateTimePicker17);
            button3.Click += HotelButton_Click;

            button5.Tag = new Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>(hotelName_32.Text, numericUpDown8, dateTimePicker16, dateTimePicker15);
            button5.Click += HotelButton_Click;

            button7.Tag = new Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>(hotelName_33.Text, numericUpDown7, dateTimePicker14, dateTimePicker13);
            button7.Click += HotelButton_Click;

            button6.Tag = new Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>(hotelName_34.Text, numericUpDown6, dateTimePicker12, dateTimePicker11);
            button6.Click += HotelButton_Click;

            button9.Tag = new Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>(hotelName_35.Text, numericUpDown5, dateTimePicker10, dateTimePicker9);
            button9.Click += HotelButton_Click;

            button8.Tag = new Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>(hotelName_36.Text, numericUpDown4, dateTimePicker8, dateTimePicker7);
            button8.Click += HotelButton_Click;

            button11.Tag = new Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>(hotelName_37.Text, numericUpDown3, dateTimePicker6, dateTimePicker5);
            button11.Click += HotelButton_Click;

            button10.Tag = new Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>(hotelName_38.Text, numericUpDown2, dateTimePicker4, dateTimePicker3);
            button10.Click += HotelButton_Click;

            button4.Tag = new Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>(hotelName_39.Text, numericUpDown1, dateTimePicker2, dateTimePicker1);
            button4.Click += HotelButton_Click;

            button2.Tag = new Tuple<string, NumericUpDown, DateTimePicker, DateTimePicker>(hotelName_40.Text, numericUpDown10, dateTimePicker20, dateTimePicker19);
            button2.Click += HotelButton_Click;
        }
    }
}
