using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data.EF.Enums;
using WebApp.Data.EF.interfaces;

namespace WebApp.Data.EF.Entities
{
  public  class Address: IDateTracking, ISwitchable
    {
        public long Id { get; set; }
        public long CountryId { get; set; }
        public long CityId { get; set; }
        public long DistrictId { get; set; }
        public long WardId { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public Ward Ward { get; set; }
        public string Street { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set ; }
        public Product Products { set; get; }
        public long? ProductId { get; set; }
    }
}
