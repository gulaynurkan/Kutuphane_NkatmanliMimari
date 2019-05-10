using Entities;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataLogicLayer
{
   public class DLL
    {
        SqlConnection con;
        SqlCommand cmd;
        int donen_deger;

   
    public DLL()
    {
        con = new SqlConnection("Server=.;Database=kutuphane;USER=sa;PWD=1234");// disconnect mimari insert update delete için kullanamıyoruz 

    }
        public void BaglantiAyarla()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            else
                con.Close();
        }
 
        public DataTable KayitListeleVieww() //datagrid için
        {
            DataTable dt1 = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("Select * From uyeler", con);
                adp.Fill(dt1);
                return dt1;
            }
            catch (Exception)
            {
                return dt1;
            }
        }


        public SqlDataReader AddBookTypeList()
        {
            cmd = new SqlCommand("Select kt_kodu, kt_adi From kitaptürleri", con);
            BaglantiAyarla();

            return cmd.ExecuteReader();
        }

        public SqlDataReader AddauthorTypeList() //yazar
        {
            cmd = new SqlCommand("Select y_kodu, y_adi From yazarlar", con);
            BaglantiAyarla();

            return cmd.ExecuteReader();
        }
        public SqlDataReader AddlanguageTypeList() //dil
        {
            cmd = new SqlCommand("Select d_id, d_adi From diller", con);
            BaglantiAyarla();

            return cmd.ExecuteReader();
        }


        public DataTable KayitKitapListeleView() //datagrid için
        {
            DataTable dt2 = new DataTable();
            try
            {
                SqlDataAdapter adp = new SqlDataAdapter("Select * From kitaplar", con);
                adp.Fill(dt2);
                return dt2;
            }
            catch (Exception)
            {
                return dt2;
            }
        }

        public SqlDataReader kayitListe()  //Listbox için
        {
            cmd = new SqlCommand("Select * from uyeler", con);
            BaglantiAyarla();
            return cmd.ExecuteReader();
        }
        public SqlDataReader kayitkitapListe()  //Listbox için
        {
            cmd = new SqlCommand("Select * from kitaplar", con);
            BaglantiAyarla();
            return cmd.ExecuteReader();
        }
        public int SistemKontrol(kullanicilar k)
        {
            try
            {
                cmd = new SqlCommand("select count(*) from kullanicilar where kullanici_adi=@kullanici_adi and kullanici_sifre=@kullanici_sifre", con);
                cmd.Parameters.Add("@kullanici_adi", SqlDbType.NVarChar).Value = k.kullanici_adi;
                cmd.Parameters.Add("@kullanici_sifre", SqlDbType.NVarChar).Value = k.kullanici_sifre;
                BaglantiAyarla();
                donen_deger = (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;
        }
        public int kayitSil(string u_kodu)
        {

            try
            {
                cmd = new SqlCommand("DELETE uyeler WHERE u_kodu=@u_kodu ", con);

                cmd.Parameters.Add("@u_kodu", SqlDbType.NVarChar).Value = u_kodu;
                BaglantiAyarla();
                donen_deger = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;

        }
        public int KayitEkle(uyeler u)
        {// bunlar için connect mimari
            try
            {
                cmd = new SqlCommand("insert into uyeler (u_kodu,u_adi,u_soyadi,u_dogumtarihi,u_tel,u_email,u_adres) values (@u_kodu,@u_adi, @u_soyadi, @dogum_tarih,@u_tel, @u_email, @u_adres)", con);
               // cmd.Parameters.Add("@u_id", SqlDbType.UniqueIdentifier).Value =u.u_id;
                cmd.Parameters.Add("@u_kodu", SqlDbType.NVarChar).Value = u.u_kodu;
                cmd.Parameters.Add("@u_adi", SqlDbType.NVarChar).Value =u.u_adi;
                cmd.Parameters.Add("@u_soyadi", SqlDbType.NVarChar).Value = u.u_soyadi;
                cmd.Parameters.Add("@dogum_tarih", SqlDbType.DateTime).Value = u.u_dogumtarihi;
                cmd.Parameters.Add("@u_tel", SqlDbType.NVarChar).Value = u.u_tel;
                cmd.Parameters.Add("@u_email", SqlDbType.NVarChar).Value = u.u_email;
                cmd.Parameters.Add("@u_adres", SqlDbType.NVarChar).Value = u.u_adres;
                BaglantiAyarla();
                donen_deger = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;

        }
        public int UyeKayitDuzenle(uyeler U)
        {
            try
            {
                cmd = new SqlCommand("update uyeler set u_adi=@u_adi, u_soyadi= @u_soyadi, u_dogumtarihi= @u_dogumtarihi, u_tel= @u_tel, u_email=@u_email, u_adres=@u_adres where  u_kodu=@u_kodu", con);
                cmd.Parameters.Add("@u_kodu", SqlDbType.NVarChar).Value = U.u_kodu;
                cmd.Parameters.Add("@u_adi", SqlDbType.NVarChar).Value = U.u_adi;
                cmd.Parameters.Add("@u_soyadi", SqlDbType.NVarChar).Value = U.u_soyadi;
                cmd.Parameters.Add("@u_dogumtarihi", SqlDbType.DateTime).Value = U.u_dogumtarihi.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@u_tel", SqlDbType.NVarChar).Value = U.u_tel;
                cmd.Parameters.Add("@u_email", SqlDbType.NVarChar).Value = U.u_email;
                cmd.Parameters.Add("@u_adres", SqlDbType.NVarChar).Value = U.u_adres;
                BaglantiAyarla();
                donen_deger = cmd.ExecuteNonQuery();
            }
            catch (Exception ed)
            {
            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;

        }


        public int kitapkayitSil(string kitapIsbn)
        {

            try
            {
                cmd = new SqlCommand("DELETE kitaplar WHERE ktp_ISBN=@ktp_ISBN ", con);

                cmd.Parameters.Add("@ktp_ISBN", SqlDbType.NVarChar).Value = kitapIsbn;
                BaglantiAyarla();
                donen_deger = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;
        }
        public int KayiitEkle(kitaplar K)
        {// bunlar için connect mimari
            try
            {
                cmd = new SqlCommand("insert into kitaplar (Ktp_kodu, Ktp_ISBN, Ktp_Adi, Ktp_kt_Kodu, Ktp_y_Kodu, ktp_basimtarihi, k_dil) values (@Ktp_kodu,@Ktp_ISBN, @Ktp_Adi, @Ktp_kt_Kodu,@Ktp_y_Kodu, @DT_basimtarihi, @k_dil)", con);
                // cmd.Parameters.Add("@u_id", SqlDbType.UniqueIdentifier).Value =u.u_id;
                cmd.Parameters.Add("@Ktp_kodu", SqlDbType.UniqueIdentifier).Value = K.ktp_kodu;
                cmd.Parameters.Add("@Ktp_ISBN", SqlDbType.NVarChar).Value = K.ktp_ISBN;
                cmd.Parameters.Add("@Ktp_Adi", SqlDbType.NVarChar).Value = K.ktp_adi;
                cmd.Parameters.Add("@Ktp_kt_Kodu", SqlDbType.NVarChar).Value =K.ktp_kt_kodu;
                cmd.Parameters.Add("@Ktp_y_Kodu", SqlDbType.NVarChar).Value = K.ktp_ye_kodu;
                cmd.Parameters.Add("@k_dil", SqlDbType.NVarChar).Value = K.k_dil;
                cmd.Parameters.Add("@DT_basimtarihi", SqlDbType.DateTime).Value = K.ktp_basimtarihi;
                BaglantiAyarla();
                donen_deger = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;

        }
        public int KitapKayitDuzenle(kitaplar K)
        {
            try
            {
               cmd = new SqlCommand("update kitaplar set ktp_ISBN=@ktp_ISBN, ktp_adi= @ktp_adi, ktp_kt_kodu= @ktp_kt_kodu, ktp_y_kodu= @ktp_y_kodu, ktp_basimtarihi=@ktp_basimtarihi, k_dil=@k_dil  where ktp_ISBN=@ktp_ISBN", con);
               // cmd.Parameters.Add("@ktp_kodu", SqlDbType.UniqueIdentifier).Value = K.ktp_kodu; ;
                cmd.Parameters.Add("@ktp_ISBN", SqlDbType.NVarChar).Value = K.ktp_ISBN;
                cmd.Parameters.Add("@ktp_adi", SqlDbType.NVarChar).Value = K.ktp_adi;
                cmd.Parameters.Add("@ktp_kt_kodu", SqlDbType.NVarChar).Value = K.ktp_kt_kodu;
                cmd.Parameters.Add("@ktp_y_kodu", SqlDbType.NVarChar).Value = K.ktp_ye_kodu;
                cmd.Parameters.Add("@ktp_basimtarihi", SqlDbType.DateTime).Value = K.ktp_basimtarihi.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@k_dil", SqlDbType.NVarChar).Value = K.k_dil;
               
                BaglantiAyarla();
                donen_deger = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            finally
            {
                BaglantiAyarla();
            }
            return donen_deger;

        }


    } }
