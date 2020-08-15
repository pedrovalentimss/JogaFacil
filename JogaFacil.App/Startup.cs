using JogaFacil.App.Auth;
using JogaFacil.App.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace JogaFacil.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPlacesService, PlacesService>();
            services.AddSingleton<IReservationService, ReservationService>();
            services.AddSingleton<IArenasService, ArenasService>();
            services.AddAuthorizationCore();
            services.AddScoped<JWTAuthProvider>();
            services.AddScoped<AuthenticationStateProvider, JWTAuthProvider>(p => p.GetRequiredService<JWTAuthProvider>());
            services.AddScoped<ILoginService, JWTAuthProvider>(p => p.GetRequiredService<JWTAuthProvider>());
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
