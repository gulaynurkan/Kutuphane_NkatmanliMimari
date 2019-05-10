using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;


namespace BusinessLogic
{
  public class BLL
    {
        
        DataLogicLayer.DLL dll;

        public BLL()
        {
            dll = new DataLogicLayer.DLL();
        }
        public int SistemKontrol(string kullaniciadi, string sifre)
        {
            if (!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(sifre))
            {
                return dll.SistemKontrol(new Entities.kullanicilar()
                {
                    kullanici_adi = kullaniciadi,
                    kullanici_sifre = sifre
                });
            }
            else return -1;
        }


        public int KitapKayitDuzenle(/*Guid ktp_kodu,*/string Ktp_ISBNN, string Ktp_Adii, string Ktp_kt_Koduu, string Ktp_y_Koduu, string k_d_koduu, DateTime DT_basimtarihii)
        {
            if (!string.IsNullOrEmpty(Ktp_Adii) && !string.IsNullOrEmpty(Ktp_y_Koduu))
            {
                return dll.KitapKayitDuzenle(new Entities.kitaplar()
                {
                   // ktp_kodu = ktp_kodu,
                    ktp_ISBN = Ktp_ISBNN,
                    ktp_adi = Ktp_Adii,
                    ktp_kt_kodu = Ktp_kt_Koduu,
                    ktp_ye_kodu = Ktp_y_Koduu,
                    k_dil = k_d_koduu,
                    ktp_basimtarihi = DT_basimtarihii
                });
            }
            else
            {
                return -1; //hata oluştuğunda
            }

        }
        //public int u_id { get; set; }
        //public string u_kodu { get; set; }
        //public string u_adi { get; set; }
        //public string u_soyadi { get; set; }
        //public DateTime u_dogumtarihi { get; set; }
        //public string u_tel { get; set; }
        //public string u_email { get; set; }
        //public string u_adres { get; set; }
        public DataTable KayitListeleView()
        {
            DataTable dt2 = dll.KayitListeleVieww();
            return dt2;
        }

        public DataTable KayitKitapListeleVieew()
        {
            DataTable dt3 = dll.KayitKitapListeleView();
            return dt3;
        }

        public List<uyeler> KayitListele()
        {

            List<uyeler> uyelistesi = new List<uyeler>();
            try
            {
                SqlDataReader reader = dll.kayitListe();
                while (reader.Read())
                {
                    uyelistesi.Add(new uyeler()
                    {

                        u_id = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                        u_kodu = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        u_adi = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        u_soyadi = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                      //  u_dogumtarihi = reader.IsDBNull(4) ? DateTime : reader.GetDateTime(4),
                        u_tel = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        u_email = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        u_adres = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                      
                    });
                }
                reader.Close();
            }
            catch
            {
            }
            finally
            {
                dll.BaglantiAyarla();
            }
            return uyelistesi;
        }

     
        public int SistemKontrol(string u_kodu, string u_adi, string u_soyadi, string u_tel, string u_email, string u_adres)
        {
            if (!string.IsNullOrEmpty(u_kodu) && !string.IsNullOrEmpty(u_adi) && (!string.IsNullOrEmpty(u_soyadi) && !string.IsNullOrEmpty(u_tel) && !string.IsNullOrEmpty(u_email) && !string.IsNullOrEmpty(u_adres)))
            {
                return dll.SistemKontrol(new Entities.kullanicilar()
                {


                });
            }
            else return -1; }

        public int KayitSil(string kod)
        {
            if (!string.IsNullOrEmpty(kod))
            {
                return dll.kayitSil(kod);
            }
            else return -1;
        }

        public int KayitKitapSil(string ısbn)
        {
            if (!string.IsNullOrEmpty(ısbn))
            {
                return dll.kitapkayitSil(ısbn);
            }
            else return -1;
        }

        public List<kitaplar> KayitListelee()
        {

            List<kitaplar> kayıtlistesi = new List<kitaplar>();
            try
            {
                SqlDataReader reader = dll.kayitkitapListe(); 
                while (reader.Read())
                {
                    kayıtlistesi.Add(new kitaplar()
                    {

                       // ktp_kodu = reader.IsDBNull(0) ? Guid.Empty : reader.GetGuid(0),
                        ktp_ISBN = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        ktp_adi = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        ktp_kt_kodu = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        //  u_dogumtarihi = reader.IsDBNull(4) ? DateTime : reader.GetDateTime(4),
                        ktp_ye_kodu = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        k_dil= reader.IsDBNull(5) ? string.Empty : reader.GetString(6)
                        //  u_adres = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),

                    });
                }
                reader.Close();
            }
            catch
            {
            }
            finally
            {
                dll.BaglantiAyarla();
            }
            return kayıtlistesi;
        }

        public List<kitapturleri> AddBookTypeList()
        {
            List<kitapturleri> BookList = new List<kitapturleri>();
            try
            {
                SqlDataReader reader = dll.AddBookTypeList();
                while (reader.Read())
                {
                    BookList.Add(new kitapturleri()
                    {
                        kt_kodu = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                        kt_adi = reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
                    });
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                dll.BaglantiAyarla();
            }

            return BookList;
        }

        public List<yazarlar> AddauthorTypeList()
        {
            List<yazarlar> authorList = new List<yazarlar>();
            try
            {
                SqlDataReader reader = dll.AddauthorTypeList();
                while (reader.Read())
                {
                    authorList.Add(new yazarlar()
                    {
                        y_kodu = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                        y_adi = reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
                    });
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                dll.BaglantiAyarla();
            }

            return authorList;
        }
        public List<diller> AddlanguageTypeList()
        {
            List<diller> languageList = new List<diller>();
            try
            {
                SqlDataReader reader = dll.AddlanguageTypeList();
                while (reader.Read())
                {
                    languageList.Add(new diller()
                    {
                       d_id  = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                        ad = reader.IsDBNull(1) ? string.Empty : reader.GetString(1)
                    });
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                dll.BaglantiAyarla();
            }

            return languageList;
        }
        public int KayıtEkleU(string u_koduu, string u_adii, string u_soyadii, DateTime dogum_tarihi, string u_tell, string u_emaill, string u_adress)
        {

            if (!string.IsNullOrEmpty(u_koduu) && !string.IsNullOrEmpty(u_adii) && (!string.IsNullOrEmpty(u_soyadii) && !string.IsNullOrEmpty(u_adress)))
            {

                return dll.KayitEkle(new Entities.uyeler()
                {
                    // u_id = Guid.NewGuid(),
                    u_kodu = u_koduu,
                    u_adi = u_adii,
                    u_soyadi = u_soyadii,
                    u_dogumtarihi = dogum_tarihi,
                    u_tel = u_tell,
                    u_email = u_emaill,
                    u_adres = u_adress


                });
            }
            else
            {
                return -1; //hata oluştuğunda
            }
        }
        public int UyeKayitDuzenle(string u_koduu, string u_adii, string u_soyadii, DateTime dogum_tarihi, string u_tell, string u_emaill, string u_adress)
        {
            if (!string.IsNullOrEmpty(u_koduu) && !string.IsNullOrEmpty(u_adii) && (!string.IsNullOrEmpty(u_soyadii) && !string.IsNullOrEmpty(u_adress)))
            {
                return dll.UyeKayitDuzenle(new Entities.uyeler()
                 {
                    u_kodu=u_koduu,
                    u_adi = u_adii,
                    u_soyadi = u_soyadii,
                    u_dogumtarihi = dogum_tarihi,
                    u_tel = u_tell,
                    u_email = u_emaill,
                    u_adres = u_adress,
                
                });
            }
            else
            {
                return -1; //hata oluştuğunda
            }

        }

        public int KayıtEkleK(string Ktp_ISBNN, string Ktp_Adii,string Ktp_kt_Koduu ,string Ktp_y_Koduu,string k_d_koduu,DateTime DT_basimtarihii)
        {

            if (!string.IsNullOrEmpty(Ktp_ISBNN))
            {

                return dll.KayiitEkle(new Entities.kitaplar()
                {
                    // u_id = Guid.NewGuid(),
                    ktp_kodu=Guid.NewGuid(),
                    ktp_ISBN=  Ktp_ISBNN,
                    ktp_adi = Ktp_Adii,
                    ktp_kt_kodu = Ktp_kt_Koduu,
                    ktp_ye_kodu = Ktp_y_Koduu,
                    k_dil=k_d_koduu,
                    ktp_basimtarihi = DT_basimtarihii

                });
            }
            else
            {
                return -1; //hata oluştuğunda
            }
        }

    }
    }
    


