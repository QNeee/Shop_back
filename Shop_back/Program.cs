using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop_back.Contracts.Request.items.Smart;
using Shop_back.Core.Abstractions.Items;
using Shop_back.Core.Abstractions.Items.Smarts;
using Shop_back.DataAccess;
using Shop_back.DataAccess.Repositories.Items;
using Shop_back.Middlewares;
using Shop_back.Services;
using Shop_back.Services.Items;
using Shop_back.Validation.Items.Smart;
var builder = WebApplication.CreateBuilder(args);
var alowFront = "AllowFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(alowFront, policy =>
    {
        policy
            .SetIsOriginAllowed(origin =>
            {
                return new Uri(origin).Host == "localhost";
            })
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// VAlidators

builder.Services.AddScoped<IValidator<CreateSmartRequest>, CreateSmartRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateSmartImagesRequest>, UpdateSmartImagesRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateSmartMainInfoRequest>, UpdateSmartMainInfoRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateSmartVariantsRequest>, UpdateSmartVariantsRequestValidator>();

//=======
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

var uri = new Uri(dbUrl ?? "");

var userInfo = uri.UserInfo.Split(':');

var connStr =
    $"Host={uri.Host};" +
    $"Port=5432;" +
    $"Database={uri.AbsolutePath.TrimStart('/')};" +
    $"Username={userInfo[0]};" +
    $"Password={userInfo[1]};" +
    $"SSL Mode=Require;" +
    $"Trust Server Certificate=true";
builder.Services.AddDbContext<ShopBackDbContext>(
    options =>
    {
        options.UseNpgsql(connStr);
        //options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(ShopBackDbContext))); development

    }
);
builder.Services.AddScoped<ISmartsService, SmartServices>();
builder.Services.AddScoped<ISmartsRepository, SmartsRepository>();
builder.Services.AddScoped<ISharesService, SharesService>();
var app = builder.Build();
app.UseCors(alowFront);
app.UseMiddleware<ExceptionHandlingMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
