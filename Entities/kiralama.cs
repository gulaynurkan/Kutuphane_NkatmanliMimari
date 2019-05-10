using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class kiralama
    { public string k_id { get; set; }
        public string k_kodu { get; set; }
        public Guid k_ktp_kodu { get; set; }
        public DateTime k_baslangictarihi { get; set; }
        public DateTime k_bitistarihi { get; set; }
        public DateTime k_veristarihi { get; set; }
        public string k_u_kodu { get; set; }
        public int k_fiyat { get; set; }
      
        public string k_notu { get; set; }
        public string k_bitisdurumu { get; set; }
        //        k_id int identity,
        //   k_kodu varchar(10) constraint const_k_kodu check(k_kodu like('KK-[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')),--KK-0000000
        //k_ktp_kodu uniqueidentifier foreign key references kitaplar(ktp_kodu),
        //k_baslangictarihi date,
        //k_bitistarihi date,
        //k_veristarihi date,
        //k_u_kodu varchar(8) foreign key references uyeler(u_kodu),
        //k_fiyati money,
        //k_d_kodu int foreign key references diller(d_id),
        //k_notu varchar(500),
        //k_bitisdurumu bit,

    }
}
