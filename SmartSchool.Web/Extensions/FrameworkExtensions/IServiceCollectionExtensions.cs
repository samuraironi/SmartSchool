using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using SmartSchool.Web.Services;

namespace SmartSchool.Web.Extensions.FrameworkExtensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection ConfigureAuthentication(this IServiceCollection services) 
		{
			services.AddCascadingAuthenticationState();

			//adding revalidation for user each x minutes
			services.AddScoped<AuthenticationStateProvider, AuthStateRevalidation>();

			services.AddAuthentication(options =>
			{
				//use cookies because it's simple username and password auth
				options.DefaultScheme = IdentityConstants.ApplicationScheme;
				// default signIn with cookies
				options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
				options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
			})
				.AddIdentityCookies();


			//configuration where to go on redirect to login
			services.AddScoped<CookieEvents>();
			services.ConfigureApplicationCookie(options =>
			{
				options.EventsType = typeof(CookieEvents);
			});

			return services;
		}
	}
}
