using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Rezervasyon_Sistemi
{
    public class Fonksiyonlar
    {
        // SQL bağlantı dizesi
        public static string connectionString = "Data Source=DESKTOP-5UN8A75\\SQLEXPRESS; Initial Catalog = OtelDB; Integrated Security = True;Encrypt=False;";

        // Global değişkenler
        public static string loggedInUser = Degiskenler.getUsername(); // Örnek kullanıcı adı, giriş yaptıktan sonra bu değişkeni güncelleyin

        public static void ReserveHotel(string hotelName, int guestCount, DateTime checkInDate, DateTime checkOutDate, decimal totalPrice)
        {
            
            // Veritabanına rezervasyonun eklenmesi
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Reservations (Username, HotelName, GuestCount, CheckInDate, CheckOutDate, TotalPrice) " +
                               "VALUES (@Username, @HotelName, @GuestCount, @CheckInDate, @CheckOutDate, @TotalPrice)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", loggedInUser);
                    cmd.Parameters.AddWithValue("@HotelName", hotelName);
                    cmd.Parameters.AddWithValue("@GuestCount", guestCount);
                    cmd.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    cmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                    cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            MessageBox.Show("Rezervasyon Başarılı!");
        }

        public static int CalculateTotalPrice(int guestCount, int dayCount)
        {
            // Fiyat parametreleri
            int basePrice = 1000;            // Başlangıç fiyatı
            int additionalDayCost = 250;     // Her ekstra gün için eklenen fiyat
            int additionalGuestCost = 1000;  // Her ekstra kişi için eklenen fiyat

            // Toplam fiyat hesaplama
            int totalPrice = basePrice + (dayCount - 1) * additionalDayCost + (guestCount - 1) * additionalGuestCost;

            return totalPrice;
        }
    }
}
