using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.EF.Entities
{
    public class City
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long CountryId { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<District> Districts { get; set; }
        public string OtherName { get; set; }
    }
}
