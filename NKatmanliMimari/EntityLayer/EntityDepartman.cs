using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityDepartman //diğer katmanlar ulaşabilmesi için  public tanımladık.
    {
        private int Id;
        private string Ad;
        private string Acıklama;

        //OOP  özelliklerinden kapsüllemeyi kullandık kapsülleme
        //class içinde dışarıya kullanıma
        //izin vermek istediğimiz propertyleri public yaptık ve set değer atadık
        // dışarıya kullanım izin vermediklerimizide private yapabiliriz.
        public int Id1 { get => Id; set => Id = value; }
        public string Ad1 { get => Ad; set => Ad = value; }
        public string Acıklama1 { get => Acıklama; set => Acıklama = value; }
    }
}
