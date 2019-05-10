using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class yayinevi
    { public int ye_id {get;set;}
        public string ye_firmakodu {get;set;}
        public string ye_firmaadi {get;set;}
        public string ye_firmatelI {get;set;}
    public string ye_firmatelII { get; set; }
        public string ye_firmatelIII {get;set;}

    //        ye_id int identity,
    //ye_firmakodu varchar(9) constraint const_ye_firmakodu check(ye_firmakodu like('YEFK-[0-9][0-9][0-9][0-9]')),--YEFK-0000
    //ye_firmaadi varchar(50),
    //ye_firmatelI varchar(16),
    //ye_firmatelII varchar(16),
    //ye_firmafaxno varchar(16),
    //ye_firmaemail varchar(60),
    //ye_firmawebadresi varchar(100),
    //ye_firmaadresi varchar(500),
}
}
