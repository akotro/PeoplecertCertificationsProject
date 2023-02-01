using System.Text.Json.Serialization;
using Assignment4Final.Data;
using Assignment4Final.Data.Repositories;
using Assignment4Final.Data.Seed;
using Assignment4Final.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.DTO.Candidates;
using ModelLibrary.Models.DTO.Certificates;
using ModelLibrary.Models.DTO.Login;
using ModelLibrary.Models.DTO.Questions;
using ModelLibrary.Models.DTO.Exams;
using ModelLibrary.Models.DTO.CandidateExam;
using ModelLibrary.Models.Exams;
using ModelLibrary.Models.Questions;

namespace Assignment4Final
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
                .AddRoles<IdentityRole>() // NOTE:(akotro) Required for roles
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services
                .AddIdentityServer()
                .AddApiAuthorization<AppUser, ApplicationDbContext>();

            builder.Services.AddAuthentication().AddIdentityServerJwt();

            builder.Services
                .AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    // NOTE:(akotro) Configure JsonSerializerOptions
                    // options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            builder.Services.AddSwaggerGen(); // NOTE:(akotro) Add Swagger

            builder.Services.AddRazorPages();

            // ---------------------------------------------------------------------------------------
            //Agkiz, Add Repositories and Services

            // builder.Services.AddTransient<IExamRepository, ExamRepository>();

            builder.Services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            builder.Services.AddScoped<QuestionsService>();

            builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
            builder.Services.AddScoped<CandidateService>();

            builder.Services.AddScoped<ICertificatesRepository, CertificatesRepository>();
            builder.Services.AddScoped<CertificatesService>();

            builder.Services.AddScoped<ITopicsRepository, TopicsRepository>();
            builder.Services.AddScoped<TopicsService>();

            builder.Services.AddScoped<IDifficultyLevelsRepository, DifficultyLevelsRepository>();
            builder.Services.AddScoped<DifficultyLevelsService>();

            builder.Services.AddScoped<IGenericRepository<Country>, CountriesRepository>();
            builder.Services.AddScoped<CountriesService>();

            builder.Services.AddScoped<IGenericRepository<Gender>, GendersRepository>();
            builder.Services.AddScoped<GendersService>();

            builder.Services.AddScoped<IGenericRepository<Language>, LanguagesRepository>();
            builder.Services.AddScoped<LanguagesService>();

            builder.Services.AddScoped<ExamRepository>();
            builder.Services.AddScoped<ExamService>();
            builder.Services.AddScoped<CandidateExamRepository>();
            builder.Services.AddScoped<CandidateExamService>();
            // ---------------------------------------------------------------------------------------

            // TODO:(akotro) This should be extracted into a helper class
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<OptionDto, Option>().ReverseMap();
                mc.CreateMap<QuestionDto, Question>()
                    .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.Options))
                    .ReverseMap();
                mc.CreateMap<CertificateDto, Certificate>()
                    .ForMember(dest => dest.Topics, opt => opt.MapFrom(src => src.Topics))
                    .ReverseMap();
                mc.CreateMap<TopicDto, Topic>().ReverseMap();
                mc.CreateMap<DifficultyLevelDto, DifficultyLevel>().ReverseMap();

                mc.CreateMap<CountryDto, Country>().ReverseMap();
                mc.CreateMap<AddressDto, Address>()
                    .ForMember(c => c.Country, opt => opt.MapFrom(src => src.Country))
                    .ReverseMap();
                mc.CreateMap<LanguageDto, Language>().ReverseMap();
                mc.CreateMap<GenderDto, Gender>().ReverseMap();
                mc.CreateMap<PhotoIdTypeDto, PhotoIdType>().ReverseMap();
                mc.CreateMap<CandidatesDto, Candidate>()
                    .ForMember(c => c.Address, opt => opt.MapFrom(src => src.Address))
                    .ForMember(c => c.Language, opt => opt.MapFrom(src => src.Language))
                    .ForMember(c => c.Gender, opt => opt.MapFrom(src => src.Gender))
                    .ForMember(c => c.PhotoIdType, opt => opt.MapFrom(src => src.PhotoIdType))
                    .ReverseMap();
                mc.CreateMap<AppUser, UserDto>();

                mc.CreateMap<Exam, ExamDto>()
                    .ForPath(
                        dest => dest.CertificateTitle,
                        opt => opt.MapFrom(src => src.Certificate.Title)
                    )
                    .ReverseMap();

                mc.CreateMap<CandidateExam, CandidateExamDto>()
                    .ForPath(
                        dest => dest.ExamCertificateTitle,
                        opt => opt.MapFrom(src => src.Exam.Certificate.Title)
                    );
            });
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddCors(
                options =>
                    options.AddPolicy( // TODO:(akotro) Is this correct?
                        "FrontEndPolicy",
                        policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                    )
            ); //.WithHeaders((HeaderNames.ContentType, "application/json")));

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors("FrontEndPolicy");

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.MapFallbackToFile("index.html");

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
