using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyBlogger.Core.Common;
using MyBlogger.Core.Repository;
using MyBlogger.Core.Service;
using MyBlogger.Infra.Common;
using MyBlogger.Infra.Repository;
using MyBlogger.Infra.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogger.API
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

            //function to allow angular project to use api 

            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("x",
                builder =>
                {
                    //builder.WithOrigins("http://127.0.0.1:4200", "http://localhost:4200", "https://localhost:4200")
                    // .AllowAnyHeader()
                    // .AllowAnyMethod();



                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            // Data Base Connection
            services.AddScoped<IDBcontext, DBcontext>();

            //Repository 
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            services.AddScoped<IConactUsRepository, ConactUsRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPostCommentRepository, PostCommentRepository>();
            services.AddScoped<IPostDetaliesRepository, PostDetaliesRepository>();
            services.AddScoped<IPostLikesRepository, PostLikesRepository>();
            services.AddScoped<IPostReviewRepository, PostReviewRepository>();
            services.AddScoped<IPostTageRepository, PostTageRepository>();
            services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IUserReviewRepository, UserReviewRepository>();
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<IWebSiteInfoRepository, WebSiteInfoRepository>();
            services.AddScoped<IDTORepository,DTORepository>();
            services.AddScoped<IJwtRepositorycs, JwtRepository>();

            //Serveic
            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<IConactUsService, ConactUsService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostReviewService, PostReviewService>();
            services.AddScoped<IPostTagService, PostTagService>();
            services.AddScoped<IPostCommentServise, PostCommentServise>();
            services.AddScoped<IPostLikesService, PostLikesService>();
            services.AddScoped<IPostDetaliesService, PostDetaliesService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<IUserReviewService, UserReviewService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IWebSiteInfoService, WebSiteInfoService>();
            services.AddScoped<IDTOService, DTOService>();
            services.AddScoped<IJwtservice, Jwtservice>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("x"); // use to allow test in Angular 

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
