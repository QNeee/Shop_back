using Microsoft.EntityFrameworkCore;
using Shop_back.Core.Abstractions.Items.Smarts;
using Shop_back.DataAccess;
using Shop_back.DataAccess.Repositories.Items;
using Shop_back.Services.Items;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShopBackDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(ShopBackDbContext)));
    }
);
builder.Services.AddScoped<ISmartsService, SmartsService>();
builder.Services.AddScoped<ISmartsRepository, SmartsRepository>(); 
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
