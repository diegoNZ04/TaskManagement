using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskManagement.API.Middlewares;
using TaskManagement.Application.Mappings;
using TaskManagement.Application.Services;
using TaskManagement.Application.Services.Interfaces;
using TaskManagement.Infra.Data;
using TaskManagement.Infra.Repositories;
using TaskManagement.Infra.Repositories.Interfaces;
using TaskManagement.Application.Validators.SubTaskValidators;
using FluentValidation;
using TaskManagement.Application.Validators.TaskValidators;
using TaskManagement.Application.Validators.UserValidators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskManagement.Application.Dtos.Requests.UserResquests;
using TaskManagement.Application.Dtos.Requests.SubTasksRequests;
using TaskManagement.Application.Dtos.Requests;
using TaskManagement.Application.Dtos.Requests.UserTasksRequests;
using FluentValidation.AspNetCore;

namespace TaskManagement.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "TaskManagement.API",
                Version = "v1",
                Description = "A simple API to manage tasks",
                Contact = new OpenApiContact
                {
                    Name = "Diego Amorim",
                    Email = "diegoamorim03152004@gmail.com"
                },
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter the JWT token in the field below."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new string[] { }
                }
            });
        });

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("TaskManagement"));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtSettings:Issuer"],
                    ValidAudience = Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"]))
                };
            });

        services.AddAuthorization();

        services.AddAutoMapper(
            typeof(UserProfile),
            typeof(UserTaskProfile),
            typeof(SubTaskProfile));

        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginUserValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateTaskValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateTaskValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateSubTaskValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateSubTaskValidator>();

        services.AddScoped<IValidator<CreateSubTaskRequest>, CreateSubTaskValidator>();
        services.AddScoped<IValidator<UpdateSubTaskRequest>, UpdateSubTaskValidator>();
        services.AddScoped<IValidator<CreateTaskRequest>, CreateTaskValidator>();
        services.AddScoped<IValidator<UpdateTaskRequest>, UpdateTaskValidator>();
        services.AddScoped<IValidator<CreateUserRequest>, CreateUserValidator>();
        services.AddScoped<IValidator<LoginUserRequest>, LoginUserValidator>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserTaskRepository, UserTaskRepository>();
        services.AddScoped<ISubTaskRepository, SubTaskRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserTaskService, UserTaskService>();
        services.AddScoped<ISubTaskService, SubTaskService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IHasherService, HasherService>();

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskManagement.API v1");
                options.RoutePrefix = string.Empty;
            });
        }
        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}