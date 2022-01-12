using Listy.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Listy
{
    public class Startup
    {
        private readonly string AllowReactOrigins = "_allowReactOrigins";
        private readonly string TargetHost = "https://localhost:3000";
        private readonly string AllowdAuthHost = "https://localhost:44302";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add CORS to allow React to get data from API
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowReactOrigins,
                    builder =>
                    {
                        builder.WithOrigins(TargetHost,
                                            "http://localhost:3000",
                                            "https://localhost:3000",
                                            "http://localhost:3001",
                                            "https://localhost:3001"

                                            )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddControllers();
            services.AddDbContext<ListyDbContext>();

            var TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = TargetHost,
                ValidAudience = AllowdAuthHost,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("v$JbXYFX?7RQ3krE?NJ)b$zmN{iNv+{2")),
            };

            services
                .AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(config =>
            {
                config.TokenValidationParameters = TokenValidationParameters;
            });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("Admin", policy => policy.RequireClaim("type", "Admin"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "listy_2", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                    new string[] { }
                }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "listy_2 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Add CORS
            app.UseCors(AllowReactOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}