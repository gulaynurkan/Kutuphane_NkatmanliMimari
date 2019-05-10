using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class yazarlar
    {
        public int y_id { get; set; }
        public string y_kodu { get; set; }
        public string y_adi { get; set; }
        public string y_soyadi { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", y_adi);
        }

        //        y_id int identity,
        //y_kodu varchar(8) constraint const_y_kodu check(y_kodu like('YK-[0-9][0-9][0-9][0-9][0-9]')),--YK-00000
        //y_adi varchar(50),
        //y_soyadi varchar(50),
    }
}
