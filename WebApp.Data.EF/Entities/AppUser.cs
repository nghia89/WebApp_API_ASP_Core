using Microsoft.AspNetCore.Identity;
using System;
using WebApp.Data.EF.Enums;
using WebApp.Data.EF.interfaces;

namespace WebApp.Data.EF.Entities
{
	public class AppUser:IdentityUser, IDateTracking, ISwitchable
	{
		public string FullName { get; set; }
		public DateTime? BirthDay { set; get; }
		public decimal Balance { get; set; }
		public string Avatar { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime? DateModified { get; set; }
		public Status Status { get; set; }
	}
}
