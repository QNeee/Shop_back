using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shop_back.Contracts.Request.Product;
using Shop_back.Core.Abstractions;
using Shop_back.Core.Abstractions.Product;
using Shop_back.DataAccess;
using Shop_back.DataAccess.Repositories.Product;
using Shop_back.Middlewares;
using Shop_back.Services;
using Shop_back.Services.Product;
using Shop_back.Validation.Product;
var builder = WebApplication.CreateBuilder(args);
var alowFront = "AllowFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(alowFront, policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",
                "http://localhost:5174",
                "https://qneee.github.io"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// VAlidators
builder.Services.AddScoped<IValidator<CreateProductRequest>, CreateProductRequestValidation>();
builder.Services.AddScoped<IValidator<UpdateProductImagesRequest>, UpdateProductImagesRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateProductMainInfoRequest>, UpdateProductMainInfoRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateProductVariantsRequest>, UpdateProductVariantsRequestValidator>();
//=======
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var dbUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

//var uri = new Uri(dbUrl ?? "");

//var userInfo = uri.UserInfo.Split(':');

//var connStr =
//    $"Host={uri.Host};" +
//    $"Port=5432;" +
//    $"Database={uri.AbsolutePath.TrimStart('/')};" +
//    $"Username={userInfo[0]};" +
//    $"Password={userInfo[1]};" +
//    $"SSL Mode=Require;" +
//    $"Trust Server Certificate=true";
builder.Services.AddDbContext<ShopBackDbContext>(
    options =>
    {
       // options.UseNpgsql(connStr);
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(ShopBackDbContext))); //development

    }
);
builder.Services.AddScoped<ISharesService, SharesService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<ShopBackDbContext>();
//    db.Database.Migrate();
//}
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
