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
        });

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("TaskManagement"));

        services.AddAutoMapper(
            typeof(UserProfile),
            typeof(UserTaskProfile),
            typeof(SubTaskProfile));

        services.AddValidatorsFromAssemblyContaining<CreateSubTaskValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateSubTaskValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateTaskValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateTaskValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginUserValidator>();

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

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}