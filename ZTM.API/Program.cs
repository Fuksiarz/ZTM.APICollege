using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZTM.CORE.DTO.Services;
using ZTM.Infrastructure.Context;
using ZTM.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddDbContext<MainContext>(options =>
    options.UseSqlite("DataSource=dbo.ZTM.db",
        sqlOptions => sqlOptions.MigrationsAssembly("ZTM.Infrastructure")
    )
);
// builder.Services.AddDbContext<MainContext>(options =>
//     options.UseSqlite("DataSource=dbo.ZTM.db",
//         sqlOptions => sqlOptions.MigrationsAssembly("ZTM.Infrastructure")
//     )
// );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBusRepository,BusRepository>();
builder.Services.AddScoped<IBusService,BusService>();
builder.Services.AddScoped<IDriverService,DriverService>();
builder.Services.AddScoped<IDriverRepository,DriverRepository>();

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