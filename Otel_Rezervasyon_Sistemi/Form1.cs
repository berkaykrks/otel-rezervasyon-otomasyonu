using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();//formu açar
            form3.Show();//bu ekraný açar
            this.Hide();//bu ekraný gizler
            //kayýt ol ekranýna yölendirir
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2(); //formu açar
            form2.Show();//bu ekraný açar
            this.Hide();//bu ekraný gizler
            //forgot password ekranýna yönlendirir
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string username = username_textbox.Text;//textboxdan girilen username'i deðiþkene atar
            string password = password_textbox.Text;//textboxdan girilen passwordu deðiþkene atar
            Degiskenler.setUsername(username_textbox.Text);
            
            string query = "SELECT COUNT(*) FROM Kullanici WHERE username = @username AND password = @password";//veritabanýnda bulunan username ve password ile eþleþip eþleþmediðini kontrol eder
            //veritabanýna baðlanmak için veritabaný yolunu aþaðýda belirtip veritabanýna eriþiriz
            
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5UN8A75\\SQLEXPRESS; Initial Catalog = OtelDB; Integrated Security = True;Encrypt=False;"))
            {
                // SqlCommand nesnesi oluþturur ve sorguyu ve baðlantýyý belirtir
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Kullanýcý adý ve þifreyi parametre olarak ekler
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    // Baðlantýyý açar
                    con.Open();

                    // Sorgudan dönen sonucu alýr (kullanýcý adý ve þifreye sahip kullanýcý sayýsý)
                    int count = (int)cmd.ExecuteScalar();

                    // Eðer veritabanýnda böyle bir kullanýcý varsa giriþ yapmasýna izin veririz
                    if (count > 0)
                    {
                        MessageBox.Show("Hoþgeldiniz " + username);// ekrana hoþgeldiniz yanýnada kullanýcýnýn adý yazýlýr
                        Form5 form5 = new Form5();
                        form5.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalý kullanýcý adý veya þifre");// ekrana hatalý giriþ yaptýgýný belirtmek için mesaj yazdýrýrýz.
                    }
                }


            }
        }

        // Þifre göster/gizle seçeneðinin durumunu deðiþtirdiðinde çalýþýr
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Eðer þifre göster/gizle seçeneði iþaretlenmiþse
            if (checkBox1.Checked)
            {
                // Þifre kutusunun karakterini normal metin olarak ayarlar
                password_textbox.PasswordChar = '\0';                
            }            
            else
            {
                // Eðer seçenek iþaretli deðilse, þifreyi yýldýz (*) karakterleriyle gizler
                password_textbox.PasswordChar = '*';           
            }
        }
    }
}
