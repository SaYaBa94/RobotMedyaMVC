using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace PresentationLayer
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
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true; options.Providers.Add<BrotliCompressionProvider>();
            });

            

            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddMvc();
            services.AddSingleton<IArticleService, ArticleManager>();
            services.AddSingleton<IArticleDAL, EFArticleDAL>();

            services.AddSingleton<IArticleTagService, ArticleTagManager>();
            services.AddSingleton<IArticleTagDAL, EFArticleTagDAL>();

            services.AddSingleton<IAuthorService, AuthorManager>();
            services.AddSingleton<IAuthorDAL, EFAuthorDAL>();

            services.AddSingleton<ICategoryService, CategoryManager>();
            services.AddSingleton<ICategoryDAL, EFCategoryDAL>();

            services.AddSingleton<ICategoryTypeService, CategoryTypeManager>();
            services.AddSingleton<ICategoryTypeDAL, EFCategoryTypeDAL>();

            services.AddSingleton<ITagService, TagManager>();
            services.AddSingleton<ITagDAL, EFTagDAL>();


            services.AddResponseCaching();
            services.AddControllersWithViews();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option => {
                option.LoginPath = "/Author/AdminLogin";
                option.Cookie.Name = "CredentialCookie";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Tag/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseSession();

            app.UseCookiePolicy();
            app.UseResponseCompression();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24 * 30;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Article}/{action=Index}/{id?}"                    
                    );
                endpoints.MapControllerRoute(
                  name: "admin",
                  pattern: "admin/{controller=Article}/{action=AdminIndex}/{id?}");
            });
        }
    }
}
