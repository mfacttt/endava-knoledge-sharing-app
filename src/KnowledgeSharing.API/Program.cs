using KnowledgeSharing.APP;
using KnowledgeSharing.DAL.UnitOfWork;
using KnowledgeSharing.CORE.Interfaces.Persistence;
using KnowledgeSharing.DAL.Repositories;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AssemblyMarker>());

// Add AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(AssemblyMarker).Assembly);

// Add FluentValidation
builder.Services.AddValidatorsFromAssembly(typeof(AssemblyMarker).Assembly);



builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<ICourseContributorRepository, ContributorRepository>();
builder.Services.AddScoped<ICourseEnrollmentRepository, EnrollmentRepository>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapOpenApi();

// Подключаем Swagger UI (в dev)
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(opt =>
    {
        // говорим UI, где лежит документ
        opt.SwaggerEndpoint("/openapi/v1.json", "KnowledgeSharing API v1");
        opt.RoutePrefix = "swagger"; // UI будет по /swagger
    });
}

app.MapControllers();
app.Run();
