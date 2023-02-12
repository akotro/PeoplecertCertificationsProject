using Assignment4Final.Data;
using Assignment4Final.Data.Repositories;
using Assignment4Final.Data.Seed;
using Assignment4Final.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ModelLibrary.Models;
using ModelLibrary.Models.Candidates;
using ModelLibrary.Models.Certificates;
using ModelLibrary.Models.DTO.Candidates;
using ModelLibrary.Models.DTO.Certificates;
using ModelLibrary.Models.DTO.Questions;
using ModelLibrary.Models.DTO.Exams;
using ModelLibrary.Models.DTO.CandidateExam;
using ModelLibrary.Models.Exams;
using ModelLibrary.Models.Questions;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using ModelLibrary.Models.DTO.Accounts;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Assignment4Final
{
    public class Program
    {
        private static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString =
                builder.Configuration.GetConnectionString("localhost")
                ?? throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' not found."
                );
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString)
            );
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                .AddIdentity<AppUser, IdentityRole>(
                    // NOTE:(akotro) Users must have unique emails so that we can get the user by their email
                    opt => opt.User.RequireUniqueEmail = true
                )
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    JwtBearerDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration["keyjwt"])
                            ),
                            ClockSkew = TimeSpan.Zero
                        };
                    }
                );

            builder.Services.AddAuthorization(options =>
            {
                // NOTE:(akotro) Admin has full rights to all data
                options.AddPolicy("IsAdmin", policy => policy.RequireClaim("role", "admin"));

                // NOTE:(akotro) Marker has right to mark assigned exams at a specific time
                options.AddPolicy("IsMarker", policy => policy.RequireClaim("role", "marker"));

                // NOTE:(akotro) Quality Control has new rights to all data
                options.AddPolicy(
                    "IsQualityControl",
                    policy => policy.RequireClaim("role", "qualitycontrol")
                );
                // NOTE:(akotro) Candidate can see and buy certificates and take exams
                options.AddPolicy(
                    "IsCandidate",
                    policy => policy.RequireClaim("role", "candidate")
                );
                options.AddPolicy(
                    "IsAdminOrMarker",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement("role", new[] { "admin", "marker" })
                        )
                );
                options.AddPolicy(
                    "IsAdminOrQualityControl",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement(
                                "role",
                                new[] { "admin", "qualitycontrol" }
                            )
                        )
                );
                options.AddPolicy(
                    "IsAdminOrCandidate",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement(
                                "role",
                                new[] { "admin", "candidate" }
                            )
                        )
                );
                options.AddPolicy(
                    "IsMarkerOrQualityControl",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement(
                                "role",
                                new[] { "marker", "qualitycontrol" }
                            )
                        )
                );
                options.AddPolicy(
                    "IsMarkerOrCandidate",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement(
                                "role",
                                new[] { "marker", "candidate" }
                            )
                        )
                );
                options.AddPolicy(
                    "IsQualityControlOrCandidate",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement(
                                "role",
                                new[] { "qualitycontrol", "candidate" }
                            )
                        )
                );
                options.AddPolicy(
                    "IsAdminOrMarkerOrQualityControl",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement(
                                "role",
                                new[] { "admin", "marker", "qualitycontrol" }
                            )
                        )
                );
                options.AddPolicy(
                    "IsAdminOrMarkerOrCandidate",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement(
                                "role",
                                new[] { "admin", "marker", "candidate" }
                            )
                        )
                );
                options.AddPolicy(
                    "IsAdminOrQualityControlOrCandidate",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement(
                                "role",
                                new[] { "admin", "qualitycontrol", "candidate" }
                            )
                        )
                );
                options.AddPolicy(
                    "IsMarkerOrQualityControlOrCandidate",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement(
                                "role",
                                new[] { "marker", "qualitycontrol", "candidate" }
                            )
                        )
                );
                options.AddPolicy(
                    "IsAny",
                    policy =>
                        policy.Requirements.Add(
                            new ClaimsAuthorizationRequirement(
                                "role",
                                new[] { "admin", "marker", "qualitycontrol", "candidate" }
                            )
                        )
                );
            });

            builder.Services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            // NOTE:(akotro) Add Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer",
                        BearerFormat = "JWT",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Description =
                            "Add the JWT bearer token obtained from authentication to the header."
                    }
                );

                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    }
                );
            });

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

            builder.Services.AddScoped<IGenericRepository<PhotoIdType>, PhotoIdTypesRepository>();
            builder.Services.AddScoped<PhotoIdTypesService>();

            builder.Services.AddScoped<ExamRepository>();
            builder.Services.AddScoped<ExamService>();
            builder.Services.AddScoped<CandidateExamRepository>();
            builder.Services.AddScoped<CandidateExamService>();

            builder.Services.AddScoped<
                IGenericRepository<CandidateExamAnswers>,
                CandidateExamAnswersRepository
            >();
            builder.Services.AddScoped<CandidateExamAnswersService>();

            builder.Services.AddScoped<IMarkersRepository, MarkersRepository>();
            builder.Services.AddScoped<MarkersService>();

            builder.Services.AddScoped<IAccountsRepository, AccountsRepository>();
            builder.Services.AddScoped<AccountsService>();

            builder.Services.AddScoped<PaypalService>();
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
                mc.CreateMap<AppUser, UserDto>().ReverseMap();

                mc.CreateMap<Exam, ExamDto>().ReverseMap();

                mc.CreateMap<CandidateExam, CandidateExamDto>().ReverseMap();
                mc.CreateMap<CandidateExamAnswers, CandidateExamAnswersDto>().ReverseMap();

                mc.CreateMap<Marker, MarkerDto>().ReverseMap();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddCors(
                options =>
                    options.AddPolicy(
                        "FrontEndPolicy",
                        policy =>
                            policy
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials()
                                .WithOrigins("https://localhost:44473")
                    )
            );

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
            // app.UseIdentityServer();
            app.UseAuthorization();

            app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.MapFallbackToFile("index.html");

            // AGkiz - Seeds dummy data to DB
            DbSeed.Seed(app).Wait();

            app.Run();
        }
    }
}
