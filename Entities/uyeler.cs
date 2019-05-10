using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class uyeler
    {
        public Guid u_id { get; set; }
        public string u_kodu { get; set; }
        public string u_adi { get; set; }
        public string u_soyadi { get; set; }
        public DateTime u_dogumtarihi { get; set; }
        public string u_tel { get; set; }
        public string u_email { get; set; }
        public string u_adres { get; set; }
        //        u_id int identity,
        //   u_kodu varchar(8) constraint const_u_kodu check(u_kodu like('UK-[0-9][0-9][0-9][0-9][0-9]')),--UK-00000
        //u_adi varchar(30),
        //u_soyadi varchar(30), 
        //u_dogumtarihi date,
        //u_tel varchar(16),
        //u_email varchar(50), 
        //u_adres varchar(500),
    }
}
