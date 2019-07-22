using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.EF.Entities
{
   public class Country
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public string OtherName { get; set; }
    }
}
