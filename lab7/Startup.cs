using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SchoolGradesAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Здесь регистрируем необходимые сервисы, например, добавление поддержки контроллеров
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Указываем маршрутизацию для контроллеров
                endpoints.MapControllers();
            });
        }
    }
}
