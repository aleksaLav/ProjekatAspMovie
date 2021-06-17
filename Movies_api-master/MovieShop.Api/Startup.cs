using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EfDataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MovieShop.Api.Core;
using MovieShop.Application;
using MovieShop.Application.Commands;
using MovieShop.Application.Email;
using MovieShop.Application.Queries;
using MovieShop.Implementation.Commands;
using MovieShop.Implementation.Commands.Genre;
using MovieShop.Implementation.Email;
using MovieShop.Implementation.Logging;
using MovieShop.Implementation.Queries;
using MovieShop.Implementation.Validators;
using Newtonsoft.Json;

namespace MovieShop.Api
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddTransient<IEmailSender, SmtpEmailSender>();


            services.AddTransient<MovieContext>();
            services.AddTransient<UseCaseExecutor>();

            services.AddTransient<ICreateActorCommand,EfCreateActorCommand>();
            services.AddTransient<IRegistrationUserCommand, EfRegistrationUserCommand>();

            services.AddTransient<ICreateGenreCommand, EfCreateGenreCommand>();
            services.AddTransient<IDeleteGenreCommand, EfDeleteGenreCommand>();
            services.AddTransient<IUpdateGenreCommand, EfUpdateGenreCommand>();


            services.AddTransient<ICreateMovieCommand, EfCreateMovieCommand>();
            services.AddTransient<IGetMovieQuery, EfGetMovieQuery>();
            services.AddTransient<IGetOneMovieQuery, EfGetOneMovieQuery>();
            services.AddTransient<IDeleteMovieCommand, EfDeleteMovieCommand>();
            services.AddTransient<IUpdateMovieCommand, EfUpdateMovieCommand>();




            services.AddTransient<IGetOneActorQuery, EfGetOneActorQuery>();
            services.AddTransient<IDeleteActorCommand, EfDeleteActorCommand>();
            services.AddTransient<IGetActorsQuery, EfGetActorsQuery>();
            services.AddTransient<IUpdateActorCommand, EfUpdateActorCommand>();

            services.AddTransient<ICreateDirectorCommand, EfCreateDirectorCommand>();
            services.AddTransient<IGetDirectorQuery, EfGetDirectorQuery>();
            services.AddTransient<IDeleteDirectorCommand, EfDeleteDirectorCommand>();
            services.AddTransient<IUpdateDirectorCommand, EfUpdateDirectorCommand>();
            services.AddTransient<IGetOneDirectorQuery, EfGetOneDirectorQuery>();



            services.AddTransient<IGetUserQuery, EfGetUsersQuery>();
            services.AddTransient<IGetOneUserQuery, EfGetOneUserQuery>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();


            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();

            services.AddTransient<IGetLogsQuery, EfGetLogsQuery>();

            services.AddTransient<ICreateMovieReservationCommand, EfCreateMovieReservation>();
            services.AddTransient<IGetReservationQuery, EfGetReservationsQuery>();




            services.AddHttpContextAccessor();

            services.AddTransient<IActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonimusActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;
            });

            services.AddTransient<IUseCaseLogger, DataBaseUseCaseLogger>();
            services.AddTransient<JwtManager>();


            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddTransient<IGetGenresQuery, EfGetGenresQuery>();


            services.AddTransient<RegistationValidator>();


            services.AddTransient<AddMovieValidator>();
            services.AddTransient<DeleteMovieValidator>();
            services.AddTransient<UpdateMovieValidator>();



            services.AddTransient<GenreValidator>();
            services.AddTransient<DeleteGenreValidator>();
            services.AddTransient<UpdateGenreValidator>();


            services.AddTransient<DirectorValidator>();
            services.AddTransient<DeleteDirectorValidator>();
            services.AddTransient<UpdateDirectorValidator>();


            services.AddTransient<AddActorValidator>();
            services.AddTransient<UpdateActorValidator>();
            services.AddTransient<DeleteActorValidator>();


            services.AddTransient<AddReservationValidator>();






            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<GlobalExceptionHandler>();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
