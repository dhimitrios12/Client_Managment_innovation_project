using ClientManagement.Core.Entities;
using ClientManagement.Core.Helpers;
using ClientManagement.Core.Services;
using ClientManagment.PersistanceV2.Contexts;
using ClientManagment.Services.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using AutoMapper;
using ClientManagement.Core.Validators;
using ClientManagment.API.Helpers;
using ClientManagment.Services.AutomapperProfiles;

namespace ClientManagment.API
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
			services.AddControllers(options =>
				{
					options.Filters.Add(new HttpResponseExceptionFilter());
				})
				.AddFluentValidation(options =>
				{
					options.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(RegisterModelValidator)));
				});

			// Add EF core configuration
			services.AddDbContext<ApplicationDBContext>(options =>
				{
					options.UseSqlServer(Configuration.GetConnectionString("LocalConnection"));
				});

			// Taking app settings configurations
			var tokenAppSettingsSection = Configuration.GetSection("TokenOptions");
			services.Configure<TokenOptionsModel>(tokenAppSettingsSection);
			var tokenOptions = tokenAppSettingsSection.Get<TokenOptionsModel>();

			// Configuring identity
			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
			}).AddEntityFrameworkStores<ApplicationDBContext>()
				.AddDefaultTokenProviders();

			// Adding authentication JWT
			services.AddAuthentication(auth =>
				{
					auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				}).AddJwtBearer(options =>
				{
					options.RequireHttpsMetadata = false;
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidIssuer = tokenOptions.Issuer,
						ValidateAudience = true,
						ValidAudience = tokenOptions.Audience,
						RequireExpirationTime = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.
							UTF8.GetBytes(tokenOptions.Key)),
						ValidateIssuerSigningKey = true,
						ValidateLifetime = true,
						ClockSkew = TimeSpan.Zero
					};
				});

			// Register Swagger generator
			services.AddSwaggerGen(conf =>
			{
				conf.SwaggerDoc("v1", new OpenApiInfo { Title = "Client managment API", Version = "v1" });
				// Set the comments path for the Swagger JSON and UI.
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				conf.IncludeXmlComments(xmlPath);

				conf.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					Scheme = "bearer", // Must be lowercase
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT authorization header using Bearer Token scheme."
				});

				conf.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme()
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						}, 
						new string[] {}
					}
				});
			});

			// Register AutoMapper
			services.AddAutoMapper(typeof(EntityToModel));

			// Register used dependencies
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IBusinessTypeService, BusinessTypeService>();
			services.AddScoped<IBusinessService, BusinessService>();
			services.AddScoped<IBService, BServiceService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			// Configure Swagger
			app.UseSwagger();

			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "Client managment API v1");
			});

			app.UseHttpsRedirection();

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
