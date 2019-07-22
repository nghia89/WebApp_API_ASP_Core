using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Data.EF.Entities
{
  public  class District
    {
        public long Id { get; set; }
        public long CityId { get; internal set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public List<Ward> Wards { get; set; }
        public string OtherName { get; set; }
    }
}
