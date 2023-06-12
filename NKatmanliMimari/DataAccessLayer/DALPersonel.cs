using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;
namespace DataAccessLayer
{
   public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("Select*From TBLBILGI", Baglanti.bgl);
            if (komut1.Connection.State != System.Data.ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())// burdaki while kullanma nedeni verileri okuyup yazdırmaa.
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Sehir = dr["SEHİR"].ToString();
                ent.Gorev = dr["GOREV"].ToString();
                ent.Maas = short.Parse(dr["MAAS"].ToString());
                degerler.Add(ent);

            }
            dr.Close();
            return degerler;
        }
        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBLBILGI (AD,SOYAD,SEHİR,GOREV,MAAS) VALUES(@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);

            if (komut2.Connection.State != System.Data.ConnectionState.Open)
            {
                komut2.Connection.Open();
            }

            komut2.Parameters.AddWithValue("@p1", p.Ad);
            komut2.Parameters.AddWithValue("@p2", p.Soyad);
            komut2.Parameters.AddWithValue("@p3", p.Sehir);
            komut2.Parameters.AddWithValue("@p4", p.Gorev);
            komut2.Parameters.AddWithValue("@p5", p.Maas);
            var ekle= komut2.ExecuteNonQuery();
            return ekle;
        }
        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("Delete From TBLBILGI WHERE ID=@p1", Baglanti.bgl);
            if (komut3.Connection.State != System.Data.ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", p);
            var deger=komut3.ExecuteNonQuery() > 0;
            return deger;


        }
        public static bool PersonelGuncelle(EntityPersonel  per)
        {
            SqlCommand komut4 = new SqlCommand("Update TBLBILGI set Ad=@p2,Soyad=@p3,Sehir=@p4,Gorev=@p5,Maas=@p6 WHERE ID=@p1", Baglanti.bgl);
            if (komut4.Connection.State != System.Data.ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p2",per.Ad);
            komut4.Parameters.AddWithValue("@p3", per.Soyad);
            komut4.Parameters.AddWithValue("@p4", per.Sehir);
            komut4.Parameters.AddWithValue("@p5", per.Gorev);
            komut4.Parameters.AddWithValue("@p6", per.Maas);
            komut4.Parameters.AddWithValue("@p1", per.Id);

            return komut4.ExecuteNonQuery() > 0;
        }
    }
}
