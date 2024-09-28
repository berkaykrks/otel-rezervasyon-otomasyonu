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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
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
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();//uygulamadan çıkmak için
        }

        private void resetPassword_button_Click(object sender, EventArgs e)
        {
            //veritabanına bağlanmak için kullanılır
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5UN8A75\\SQLEXPRESS; Initial Catalog = OtelDB; Integrated Security = True;Encrypt=False;"))
            {
                if (resetPassword_textbox.Text == verifyPassword_textbox.Text)//girilen şifreler birbirlerine eşitse 
                {
                    // textboxdan yeni şifreyi alır
                    string newPassword = verifyPassword_textbox.Text;
                    
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Kullanici] SET [password] = @pass WHERE [mail] = @mail", con);//veritabanında veriyi güncellemek için sql sorgusu oluşturuluyor
                    cmd.Parameters.AddWithValue("@pass", newPassword);// Yeni şifreyi parametre olarak ekler
                    cmd.Parameters.AddWithValue("@mail", Degiskenler.getMail());// Kullanıcının e-posta adresini parametre olarak ekler
                    MessageBox.Show(Degiskenler.getMail());//değiştirilen mailin gmailini ekranda görebilemek için yapıldı
                    con.Open();//veritabanı baglantısı açılır
                    cmd.ExecuteNonQuery();//şifre güncelleme sorgusu veritabanında çalıştırmak için yazıldı.
                    con.Close();//ve ardından da veritabanı baglantısı kapatılır
                    MessageBox.Show("Şifreniz başarıyla yenilendi");//şifrenin yenilendigini dogrulamak için ekrana mesaj gösterilir
                }
                else
                {
                    MessageBox.Show("Yeni şifrneiz birbiriyle eşleşmiyor");// iki textboxda girilen şifreler birbirlerine eşleşmediyse ekrana mesaj yazdırılır
                }
            }
        }
        //şifreyi gizlemek ve göstermek için checkbox kullanılıyor
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)//eğer tikliyse çalıştır
            {
                //eğer seçenek tikliyse şifreyi gösterir
                resetPassword_textbox.PasswordChar = '\0';
                verifyPassword_textbox.PasswordChar = '\0';
            }
            else //değilse burayı çalıştır
            {
                // Eğer seçenek tikli değilse, şifreyi yıldız (*) karakterleriyle gizler
                resetPassword_textbox.PasswordChar = '*';
                verifyPassword_textbox.PasswordChar = '*';
            }
        }
    }
}
