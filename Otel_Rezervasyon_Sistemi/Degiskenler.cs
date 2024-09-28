using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel_Rezervasyon_Sistemi
{
    public class Degiskenler
    {
        // Kullanıcı değişkenleri
        private static string username;
        private static string name;
        private static string surname;
        private static string mail;
        private static string tc;
        private static string gender;
        private static string password;
        private static int otelID;

        // Otel ID'sini almak için
        public static int getOtelID()
        {
            return otelID;
        }

        // Otel ID'sini ayarlamak için
        public static void setOtelID(int otelID)
        {
            Degiskenler.otelID = otelID;
        }

        // Kullanıcı adını almak için
        public static string getUsername()
        {
            return username;
        }

        // Kullanıcı adını ayarlamak için
        public static void setUsername(string username)
        {
            Degiskenler.username = username;
        }

        // İsim almak için
        public static string getName()
        {
            return name;
        }

        // İsim ayarlamak için
        public static void setName(string name)
        {
            Degiskenler.name = name;
        }

        // Soyad almak için
        public static string getSurname()
        {
            return surname;
        }

        // Soyad ayarlamak için
        public static void setSurname(string surname)
        {
            Degiskenler.surname = surname;
        }

        // E-posta almak için
        public static string getMail()
        {
            return mail;
        }

        // E-posta ayarlamak için
        public static void setMail(string mail)
        {
            Degiskenler.mail = mail;
        }

        // Cinsiyet almak için
        public static string getGender()
        {
            return gender;
        }

        // Cinsiyet ayarlamak için
        public static void setGender(string gender)
        {
            Degiskenler.gender = gender;
        }

        // Şifre almak için
        public static string getPassword()
        {
            return password;
        }

        // Şifre ayarlamak için
        public static void setPassword(string password)
        {
            Degiskenler.password = password;
        }
    }
}
