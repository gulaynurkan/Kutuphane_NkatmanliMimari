﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class diller
    {
        public string d_id { get; set; }
        public string ad { get; set; }


        public override string ToString()
        {
            return string.Format("{0}",ad);
        }
        //     d_id int identity,
        //d_adi varchar(20),
    }
}
