using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;
using System.Reflection.Metadata;
using WebApp4a.Data;
using WebApp4a.Data.Seed;
using WebApp4a.Data.Repositories;
using WebApp4a.Services;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using ModelLibrary.Models.DTO.Questions;
using Microsoft.CodeAnalysis.Options;
using ModelLibrary.Models.Questions;

namespace WebApp4a
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString =
                builder.Configuration.GetConnectionString("localdb")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' not found."
                );
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString)
            );
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                .AddDefaultIdentity<AppUser>(
                    options => options.SignIn.RequireConfirmedAccount = false
                )
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRazorPages();
            builder.Services.AddMvc();
            builder.Services.AddControllersWithViews();
            builder.Services.AddSwaggerGen(); // NOTE:(akotro) Add Swagger
            builder.Services
                .AddControllers()
                .AddJsonOptions(
                    options =>
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve
                );

            // -----------------------------
            //Agkiz, Added Transient service repo
            builder.Services.AddTransient<IExamRepository, ExamRepository>();

            // NOTE:(akotro) Should repositories be added as Scoped since we want
            // only one DbContext for each client request?
            builder.Services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            builder.Services.AddTransient<QuestionsService>();
            // -----------------------------

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<OptionDto, Option>().ReverseMap();
                // mc.CreateMap<Option, OptionDto>();
                mc.CreateMap<QuestionDto, Question>()
                    .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                    .ReverseMap();
                // mc.CreateMap<Question, QuestionDto>()
                //     .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options));
            });
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();

                // NOTE:(akotro) Use Swagger
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapDefaultControllerRoute();

            //checks for all the latest migrations
            //also creates db ifNotExists
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
            }

            // AGkiz - Seeds dummy data to DB
            DbSeed.Seed(app);

            app.Run();
        }
    }
}
