using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }

        public static int LLPersonelEkle(EntityPersonel p)
        {
            if(p.Ad!=""&& p.Soyad!="" && p.Maas>=3500 && p.Ad.Length >= 3)
            {
                return DALPersonel.PersonelEkle(p);
            }
            else
            {
                return -1;
            }


        }

        public static bool LLPersonelSil(int per)
        {
            if (per >= 1)
            {
                return DALPersonel.PersonelSil(per);
            }
            else
            {
                return false;
            }
        }

        public static bool LLPersonelGuncelle(EntityPersonel per)
        {
            if (per.Ad.Length>=3 && per.Ad!="" && per.Maas>=4500)
            {
                return DALPersonel.PersonelGuncelle(per);
            }
            else
            {
                return false;
            }
        }
    }
}
