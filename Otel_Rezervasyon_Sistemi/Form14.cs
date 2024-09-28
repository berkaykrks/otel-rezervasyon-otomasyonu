using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class Form14 : Form
    {
        // Veritabanı bağlantı dizesi
        public static string connectionString = "Data Source=DESKTOP-5UN8A75\\SQLEXPRESS; Initial Catalog = OtelDB; Integrated Security = True;Encrypt=False;";

        // Rezervasyon iptal durumu
        public static Boolean iptalMi = false;

        public Form14()
        {
            InitializeComponent();



        }

        // İptal durumunu kontrol eden metod
        private void iptal(string t, decimal a)
        {
            if (t != null || a != 0)
            {
                iptalMi = true; // İptal durumunu belirler
            }
        }

        // Form sürükleme işlevi için gerekli Windows API mesajları
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                {
                    ReleaseCapture(); // Formu sürüklemeyi başlatır
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); // Formu sürükler
                }
            }
        }

        // Geri butonu, Form5'e geçiş yapar
        private void button12_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(); // Form5'i oluşturur
            form5.Show(); // Form5'i gösterir
            this.Hide(); // Mevcut formu gizler
        }

        // Uygulamayı kapatma butonu
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Uygulamayı kapatır
        }

        // Rezervasyonu iptal etme butonu
        private void button3_Click(object sender, EventArgs e)
        {
            DeleteReservationById();
        }
        private void DeleteReservationById()
        {
            // Kullanıcının NumericUpDown1'dan girdiği ID'yi al
            int reservationId = Convert.ToInt32(numericUpDown1.Value);

            // Eğer ID sıfırdan küçük veya eşitse silme işlemi yapma
            if (reservationId <= 0)
            {
                MessageBox.Show("Geçerli bir rezervasyon ID'si girin.");
                return;
            }

            // Veritabanı bağlantı dizesi (kendi bağlantı bilgilerinizi kullanın)
            string connectionString = "Data Source=DESKTOP-5UN8A75\\SQLEXPRESS; Initial Catalog = OtelDB; Integrated Security = True;Encrypt=False;";

            // SQL silme sorgusu - Belirtilen ID'ye göre rezervasyonu sil
            string query = "DELETE FROM Reservations WHERE ReservationId = @id";

            // Kullanıcıya gerçekten silmek istediğini sorma
            DialogResult result = MessageBox.Show($"Rezervasyon ID {reservationId} silmek istediğinize emin misiniz?", "Rezervasyon Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open(); // Veritabanı bağlantısını aç

                        // SQL sorgusunu hazırlamak için SqlCommand kullan
                        SqlCommand command = new SqlCommand(query, connection);

                        // Parametre olarak ID'yi sorguya ekle
                        command.Parameters.AddWithValue("@id", reservationId);

                        // SQL silme sorgusunu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        // Eğer bir satır etkilendiyse silme başarılı demektir
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Rezervasyon ID {reservationId} başarıyla silindi.");
                        }
                        else
                        {
                            MessageBox.Show($"Rezervasyon ID {reservationId} bulunamadı.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Hata durumunda mesaj göster
                        MessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Silme işlemi iptal edildi.");
            }
        }

        private void LoadUserReservations()
        {
            // Giriş yapan kullanıcının kullanıcı adını al
            string username = Degiskenler.getUsername(); // Kullanıcı girişinden gelen username

            // Veritabanı bağlantı dizesi (kendi bağlantı bilgilerinizi kullanın)
            string connectionString = "Data Source=DESKTOP-5UN8A75\\SQLEXPRESS; Initial Catalog = OtelDB; Integrated Security = True;Encrypt=False;";

            // SQL sorgusu - Username ile eşleşen rezervasyonları al
            string query = "SELECT * FROM Reservations WHERE Username = @username";

            // Veritabanı bağlantısını aç
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Bağlantıyı aç

                    // SQL sorgusunu hazırlamak için SqlCommand kullan
                    SqlCommand command = new SqlCommand(query, connection);

                    // Username parametresini sorguya ekle
                    command.Parameters.AddWithValue("@username", username);

                    // SQL sorgusunu çalıştır
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    // Verileri tutmak için DataTable oluştur
                    DataTable dataTable = new DataTable();

                    // Verileri DataTable'e doldur
                    dataAdapter.Fill(dataTable);

                    // DataGridView'e verileri bağla
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj göster
                    MessageBox.Show($"Veritabanına bağlanırken bir hata oluştu: {ex.Message}");
                }
            }
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            LoadUserReservations();
        }
    }
}
