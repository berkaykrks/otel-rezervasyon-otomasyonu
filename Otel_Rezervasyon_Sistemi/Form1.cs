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
            Form3 form3 = new Form3();//formu a�ar
            form3.Show();//bu ekran� a�ar
            this.Hide();//bu ekran� gizler
            //kay�t ol ekran�na y�lendirir
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2(); //formu a�ar
            form2.Show();//bu ekran� a�ar
            this.Hide();//bu ekran� gizler
            //forgot password ekran�na y�nlendirir
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string username = username_textbox.Text;//textboxdan girilen username'i de�i�kene atar
            string password = password_textbox.Text;//textboxdan girilen passwordu de�i�kene atar
            Degiskenler.setUsername(username_textbox.Text);
            
            string query = "SELECT COUNT(*) FROM Kullanici WHERE username = @username AND password = @password";//veritaban�nda bulunan username ve password ile e�le�ip e�le�medi�ini kontrol eder
            //veritaban�na ba�lanmak i�in veritaban� yolunu a�a��da belirtip veritaban�na eri�iriz
            
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-5UN8A75\\SQLEXPRESS; Initial Catalog = OtelDB; Integrated Security = True;Encrypt=False;"))
            {
                // SqlCommand nesnesi olu�turur ve sorguyu ve ba�lant�y� belirtir
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Kullan�c� ad� ve �ifreyi parametre olarak ekler
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    // Ba�lant�y� a�ar
                    con.Open();

                    // Sorgudan d�nen sonucu al�r (kullan�c� ad� ve �ifreye sahip kullan�c� say�s�)
                    int count = (int)cmd.ExecuteScalar();

                    // E�er veritaban�nda b�yle bir kullan�c� varsa giri� yapmas�na izin veririz
                    if (count > 0)
                    {
                        MessageBox.Show("Ho�geldiniz " + username);// ekrana ho�geldiniz yan�nada kullan�c�n�n ad� yaz�l�r
                        Form5 form5 = new Form5();
                        form5.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatal� kullan�c� ad� veya �ifre");// ekrana hatal� giri� yapt�g�n� belirtmek i�in mesaj yazd�r�r�z.
                    }
                }


            }
        }

        // �ifre g�ster/gizle se�ene�inin durumunu de�i�tirdi�inde �al���r
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // E�er �ifre g�ster/gizle se�ene�i i�aretlenmi�se
            if (checkBox1.Checked)
            {
                // �ifre kutusunun karakterini normal metin olarak ayarlar
                password_textbox.PasswordChar = '\0';                
            }            
            else
            {
                // E�er se�enek i�aretli de�ilse, �ifreyi y�ld�z (*) karakterleriyle gizler
                password_textbox.PasswordChar = '*';           
            }
        }
    }
}
