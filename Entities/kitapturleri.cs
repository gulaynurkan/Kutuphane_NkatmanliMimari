using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class kitapturleri
    {
        public int kt_id { get; set; }
        public string kt_kodu { get; set; }
        public string kt_adi { get; set; }


        public override string ToString()
        {
            return string.Format("{0}", kt_adi);
        }

        //        kt_id int identity,
        //   kt_kodu varchar(6) constraint const_kt_kodu check(kt_kodu like('KTK-[0-9][0-9]')),--KTK-00
        //kt_adi varchar(30),
        //constraint const_pkkey_kitaptürleri primary key(kt_kodu)
    }
}
