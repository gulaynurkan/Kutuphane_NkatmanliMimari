using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
 public   class kitapfiyatlari
    {
        public Guid ktp_kodu { get; set; }
        public int  ktp_fiyati { get; set; }
        public int ktp_gunlukkiralamafiyati { get; set; }

        //        ktp_kodu uniqueidentifier foreign key references kitaplar(ktp_kodu),
        //ktp_fiyati money,
        //ktp_gunlukkiralamafiyati money,
    }
}
