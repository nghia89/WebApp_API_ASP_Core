using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_API_ASP_Core.Extensions
{
	public class LocalizationPipeline
	{
		public void Configure(IApplicationBuilder app,RequestLocalizationOptions options)
		{
			app.UseRequestLocalization(options);
		}
	}
}
