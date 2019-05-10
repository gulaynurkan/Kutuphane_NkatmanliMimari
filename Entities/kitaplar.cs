using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class kitaplar
    {
        public int ktp_id { get; set; }
        public Guid ktp_kodu { get; set; }
        public string ktp_ISBN { get; set; }
        public string ktp_adi { get; set; }
        public string ktp_kt_kodu { get; set; }
        public string  ktp_ye_kodu {get; set;}
        public string k_dil { get; set; }
        public DateTime ktp_basimtarihi { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", k_dil);
        }
        //        ktp_id int identity,
        //   ktp_kodu uniqueidentifier,
        //ktp_ISBN varchar(13) unique not null,
        //ktp_adi varchar(150),
        //ktp_kt_kodu varchar(6) foreign key references kitaptürleri(kt_kodu),
        //ktp_y_kodu varchar(8) foreign key references yazarlar(y_kodu),
        //ktp_sayfasayisi int,
        //ktp_ye_firmakodu varchar(9) foreign key references yayinevi(ye_firmakodu),
        //ktp_basimtarihi date,
    }
}
