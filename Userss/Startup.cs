using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Userss.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
// Espacio de nombres  agregado para el controlador de errores
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace Userss
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                // -----------------C�digo agregado-----------------
                //app.UseExceptionHandler(options => {
                //    options.Run(async context => { 
                //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //        context.Response.ContentType = "text/html";
                //        var ex = context.Features.Get<IExceptionHandlerFeature>();
                //        if (ex != null)
                //        {
                //            var error = $"<h1>Error: {ex.Error.Message}</h1> {ex.Error.StackTrace}";
                //            await context.Response.WriteAsync(error).ConfigureAwait(false);
                //        }
                //    });
                //});
                // -----------------C�digo agregado-----------------
                //app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Controlador de codigos de error
            // Muestra un error 404
            //app.UseStatusCodePages("text/plain", "Pagina de codigos de estado, codigo de estado: {0}");
            // -----------------C�digo agregado-----------------
            //app.UseStatusCodePages(async context => {
            //    await context.HttpContext.Response.WriteAsync(
            //        "Pagina de codigos de estado, codigo de estado: " + context.HttpContext.Response.StatusCode
            //        );
            //});
            // -----------------C�digo agregado-----------------

            // -------------Parte 2-------------
            //app.UseStatusCodePagesWithRedirects("/Users/Method?code={0}");
            // Es mas recomendable utilizar el siguiente metodo:

            //app.UseStatusCodePagesWithReExecute("/Users/Method", "?code={0}");
            //app.UseStatusCodePagesWithReExecute("/Home/Error", "?code={0}");
            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");
            // -------------Parte 2-------------

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
