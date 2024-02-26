
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DAL;
using Microsoft.EntityFrameworkCore;
using Mono.Repository;
using Mono.Repository.Common;
using Mono.Services;
using Mono.Services.Common;
using Mono.WebAPI;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<VehicleMakeDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("VehicleMakeDbConnection"), b=>b.MigrationsAssembly("Mono"))) ;


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutoFacConfig());

});

builder.Services.AddAutoMapper(typeof(AutoMappingProfiles).Assembly);


//--------------------
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
