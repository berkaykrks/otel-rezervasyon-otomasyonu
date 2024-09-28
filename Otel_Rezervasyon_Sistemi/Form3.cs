using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;


namespace Otel_Rezervasyon_Sistemi
{
    public partial class Form3 : Form
    {
        public Form3()
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
            Application.Exit();//uygulamadan çıkmaya yarar
        }

        //kayıt olma ekranına yönlendirir
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();//nesne oluşturur
            form1.Show();//kayıt ol ekranını gösterir
            this.Hide();//bu ekranı gizler
            

        }
        //giriş yap ekranına yönlendirir
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();//nesne oluşturur
            form2.Show();//giriş yap ekranını gösterir
            this.Hide();//bu ekranı gizler
        }
        string randomCode; // Rastgele oluşturulan kodu saklamak  ve sonradan kullanbilmek için değişken tanımladım
        public  string to; // E-posta gönderilecek adresi saklamak ve sonradan kullanbilmek için değişken tanımlladım
        private void send_button_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği e-posta adresini alıp başka bir sınıfta saklar 
            // bu girilen eposta ile hesap şifresi değiştireceğim için bir sonraki kullanacağım formda işime yarayacak o yüzden saklamak için değişken atadım.
            Degiskenler.setMail(email_textbox.Text);
            string from, pass, messageBody; // Gerekli değişkenler tanımlanır.
            Random rand = new Random();// Rastgele kod oluşturulur.
            randomCode = (rand.Next(999999)).ToString();
            // MailMessage nesnesi oluşturulur ve gerekli alanlar doldurulur.
            MailMessage message = new MailMessage();
            to = email_textbox.Text.ToString();// E-posta adresi alınır.
            from = "karakusataberkay@gmail.com";//gönderen eposta alınır
            pass = "zzvr wtal anoj kgzl";//gönderen eposta adresinin şifresi googledan alındı bu.
            messageBody = "your reset code is " + randomCode; // Gönderilecek e-posta içeriği oluşturulur.

            message.To.Add(to);// Alıcı e-posta adresi eklenir.
            message.From = new MailAddress(from); // Gönderen e-posta adresi atanır.
            message.Body = messageBody; // Mesaj içeriği atanır.
            message.Subject = "password reseting code";// kullanıcının göreceği mesaj konusu atanır.
            // SMTP client oluşturulur ve ayarları yapılır.
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true; // güvenlik için SSL etkinleştirilir.
            smtp.Port = 587; // Gmail SMTP portu otomatiktir.
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // Teslimat yöntemi belirlenir.
            smtp.Credentials = new NetworkCredential(from, pass); // Gönderen e-posta ve şifre atanır.

            // Veritabanına bağlanılır
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5UN8A75\\SQLEXPRESS; Initial Catalog = OtelDB; Integrated Security = True;Encrypt=False;"))
            {
                string query = "SELECT COUNT(*) FROM kullanici WHERE mail = @Email";//kullanıcı e-posta adresi kontrol edilir
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email_textbox.Text);
                try
                {
                    con.Open(); // Veritabanı bağlantısı açılır.
                    int count = (int)command.ExecuteScalar(); // E-posta adresine sahip kullanıcı sayısı alınır.
                    if (count > 0)//eğer kullanıcı varsa eposta gönderilir
                    {
                        try
                        {
                            smtp.Send(message);//eposta gönderildi
                            MessageBox.Show("Code sende successfuly");//başarıyla gönderildiğini kullanıcı görsün diye
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);//eğer bi hata olursa kullanıcı görsün diye
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hesap bulunamadı");//girilen hesabın bulunamadıgını kullancıı görsün diye
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//hata olursa ekrana gösterilsin
                }
            }

                
        }

        //kullanıcının girdği kodu kontrol edilir
        private void verify_button_Click(object sender, EventArgs e)
        {
            // Kullanıcının girdiği kod doğruysa
            if (randomCode == (verifycode_textbox.Text))
            {
                to = email_textbox.Text;// Kullanıcının e-posta adresi kaydedilir.
                Form4 form4=new Form4();//şifresiini yenilemek için şifre yenile ekranına yönlendirilir
                this.Hide();//şuanki form gizlenir
                form4.Show();//şifre yenileme ekranı açılır
            }
            else
            {
                MessageBox.Show("Wrong Code");//kodu yanlış girdiğinde ekrana mesaj gelir
            }
        }
    }
}
