using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Otel_Rezervasyon_Sistemi
{
    public partial class Form2 : Form
    {
        public Form2()
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
            Application.Exit();//uygulamayı kapatmak için kullanılır
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();//nesneyi yaratır
            form1.Show();//istenilen ekranı açar
            this.Hide();//bu ekranı kapatır
            //signup ekranına yönlendirmek için kullanıldı
        }



        private void signup_button_Click(object sender, EventArgs e)
        {
            //textboxlara girilen verilerin değişkenlere atanıp kullanılması için ayarlandı
            string username = username_textbox.Text;
            string name = name_textbox.Text;
            string surname = surname_textbox.Text;
            string mail = mail_textbox.Text;
            string tc = tc_textbox.Text;
            string gender = genderbox.Text;
            string password = password_textbox.Text;
            string confirmpassword = confirmPassword_textbox.Text;

            // Metin kutularından herhangi biri boşsa true döner ve kullanıcının sisteme kayıt olması engellenir
            bool anyTextBoxEmpty = string.IsNullOrWhiteSpace(username) ||
                                    string.IsNullOrWhiteSpace(name) ||
                                    string.IsNullOrWhiteSpace(surname) ||
                                    string.IsNullOrWhiteSpace(mail) ||
                                    string.IsNullOrWhiteSpace(tc) ||
                                    string.IsNullOrWhiteSpace(gender) ||
                                    string.IsNullOrWhiteSpace(password) ||
                                    string.IsNullOrWhiteSpace(confirmpassword);

            //veritabanına baglanabilmek için aşağıda bulunan connection komutu yazıldı
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5UN8A75\\SQLEXPRESS; Initial Catalog = OtelDB; Integrated Security = True;Encrypt=False;"))
            {
                
                con.Open();//veritabanını açtık bu komutla

                // E-posta adresinin veritabanında olup olmadığını kontrol etmek için sorgu eğer veritabanında varsa kullanıcı kayıtıını engelleyecek
                string checkQuery = "SELECT COUNT(*) FROM kullanici WHERE mail = @mail";
                SqlCommand checkCmd = new SqlCommand(checkQuery, con);
                checkCmd.Parameters.AddWithValue("@mail", mail);//mailin varlığı kontrol edildi

                // E-posta adresiyle eşleşen kayıt sayısını al
                int existingEmailCount = (int)checkCmd.ExecuteScalar();

                // Kullanıcı adı ve şifre uzunluklarını kontrol et
                bool isUsernameValid = username.Length >= 4 && username.Length <= 16;//kullanıcı adını en az 4 en fazla 16 karakter girebilmesi için kısıtlanmıştır
                bool isPasswordValid = password.Length >= 8 && password.Length <= 16;//şifreyi en az 8 en fazla 16 karakter uzunluğunda girilip kontrol sağlanabilmesi için kısıtlanmıştır
                bool isTcValid =  tc.Length == 11;//tc uzunluğu 11 karakter olduğu için 11 girilen textboxa girilen verinin 11 karakter uzunlugundan oldugunda kullanılması içindir
                bool isEqualPassword = password == confirmpassword;//girilen şifreyle doğrulama şifresi birbirine aynı ise doğrudur ve password değişkenine atanır
                bool isEqualGender = gender.ToLower() == "e" || gender.ToLower() == "k"; //kullanıcının e ve k değerlerinden başka değer girilmesini engellemek için yapıldı.
                bool isName = true;//Name textboxuna rakam girilmesini engellemek için 
                bool isEmailValid = !string.IsNullOrEmpty(mail) && mail.Contains("@");//boş değil ve @ girilmesi lazım
                foreach (char c in name)//name değişkenindeki her bir karaktere bakar 
                {
                    if (char.IsDigit(c))//herhangi bir rakam bulursa false döndürür ve programdan çıkar
                    {
                        isName = false;
                        break;
                    }
                }
                bool isSurname = true;//Surname textboxuna rakam girilmesini engellemek için 
                foreach (char c in surname)//Surname değişkenindeki her bir karaktere bakar 
                {
                    if (char.IsDigit(c))//herhangi bir rakam bulursa false döndürür ve programdan çıkar
                    {
                        isSurname= false;
                        break;
                    }
                }
                // TC kimlik numarasının sadece rakamlardan oluşup oluşmadığını kontrol etmek için kullanıldı
                bool isTc = true;
                foreach (char c in tc)
                {
                    if (!char.IsDigit(c))
                    {
                        isTc = false;
                        break;
                    }
                }

                // Kullanıcı adı, şifre uzunlukları, girilen şifre doğrulama şifresiyle aynıysa, tc kimlik numarası sadece rakamlardan oluşuyorsa, uzunlugu 11 karakterse , name değişkeninde rakam yoksa, surname değişkeninde rakam yoksa ve gender kısmı e ve k dan başka karakter girilmediyse sistem kayıt olmasına izin verir devam et
                if (isUsernameValid && isPasswordValid && isEqualPassword && isTc && isTcValid && isName && isSurname && isEqualGender && isEmailValid)
                {
                    if (anyTextBoxEmpty)
                    {
                        MessageBox.Show("Lütfen tüm bilgileri doldurunuz.");//bir kutucuk bile boşsa ekrana mesaj vermesini sağlar
                    }
                    else
                    {
                        if (existingEmailCount > 0)
                        {
                            // Eğer eşleşen bir kayıt bulunursa hata mesajı göster
                            MessageBox.Show("Bu e-posta adresiyle zaten bir hesap bulunmaktadır.");
                        }
                        else
                        {
                            // Eğer eşleşen bir kayıt yoksa yeni kullanıcıyı eklenmesi için aşağıdaki komutlar kullanılır
                            string insertQuery = "INSERT INTO kullanici(username,name,surname,mail,tc,gender,password) VALUES (@username,@name,@surname,@mail,@tc,@gender,@password)";
                            SqlCommand cmd = new SqlCommand(insertQuery, con);
                            cmd.Parameters.AddWithValue("@username", username);//veritabanına textboxdan girilen username verisi aktarılır
                            cmd.Parameters.AddWithValue("@name", name);//veritabanına textboxdan girilen name verisi aktarılır
                            cmd.Parameters.AddWithValue("@surname", surname);//veritabanına textboxdan girilen surname verisi aktarılır
                            cmd.Parameters.AddWithValue("@mail", mail);//veritabanına textboxdan girilen mail verisi aktarılır
                            cmd.Parameters.AddWithValue("@tc", tc);//veritabanına textboxdan girilen tc verisi aktarılır
                            cmd.Parameters.AddWithValue("@gender", gender);//veritabanına textboxdan girilen tc verisi aktarılır
                            cmd.Parameters.AddWithValue("@password", password);//veritabanına textboxdan girilen password verisi aktarılır
                            
                            int affectedRows = cmd.ExecuteNonQuery();//girilen işlemler 0 dan fazla ise ekrana hoşgeldiniz mesajının yazdırılması için
                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Hoşgeldiniz");//ekrana hoşgeldiniz mesajı yazdırır
                            }
                            else
                            {
                                MessageBox.Show("Hata Yapıldı");//ekrana hata yapıldı mesajı yazdırır
                            }
                        }
                    }
                }
                else
                {
                    // Kullanıcıya uygun bir kullanıcı adı ve şifre belirtmesi gerektiğini bildir
                    MessageBox.Show("Kullanıcı adı 4 ile 16 karakter arasında olmalıdır.\nŞifre en az 8 en fazla 16 karakter içermelidir.\nTc Kimlik 0 ile 11 Karakter arasında olabilir\nTc Kimlikte Harf Olamaz.\nName Surname yerine rakam girilemez.\nGender yerine belirtilenlerden farklı karakter girilemez.\nEmail'de @ işareti kullanılmalıdır.");
                    MessageBox.Show("Tekrardan Kayıt Olmayı Deneyiniz.");
                }
            }
            

        }

        // Şifre göster/gizle seçeneğinin durumunu değiştirdiğinde çalışır
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checkboxın tikli olup olmamasına göre şifreyi gösterip gizlemeye yarar
            if (checkBox1.Checked)
            {
                // Şifre kutusunun karakterini normal metin olarak ayarlar
                password_textbox.PasswordChar = '\0';
                confirmPassword_textbox.PasswordChar= '\0';
            }            
            else
            {
                // Eğer seçenek işaretli değilse, şifreyi yıldız (*) karakterleriyle gizler
                password_textbox.PasswordChar = '*';
                confirmPassword_textbox.PasswordChar='*';
            }
        }
    }
}
