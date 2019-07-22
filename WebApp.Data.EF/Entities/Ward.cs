using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.EF.Entities
{
   public class Ward
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long DistrictId { get; internal set; }
        public string Name { get; set; }
        public District District { get; set; }
        public string OtherName { get; set; }
    }
}
