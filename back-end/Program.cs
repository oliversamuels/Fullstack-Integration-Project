using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Register the memory cache service
builder.Services.AddMemoryCache();

var app = builder.Build();

app.UseCors();

app.MapGet("/api/productlist", (IMemoryCache cache) =>
{
    const string cacheKey = "productList";
    if (!cache.TryGetValue(cacheKey, out var productList))
    {
        productList = GetProductList();

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(5));

        cache.Set(cacheKey, productList, cacheEntryOptions);
    }

    return productList;
});

app.Run();

static object[] GetProductList()
{
    return new[]
    {
        new
        {
            Id = 1,
            Name = "Laptop",
            Price = 1200.50,
            Stock = 25,
            Category = new { Id = 101, Name = "Electronics" }
        },
        new
        {
            Id = 2,
            Name = "Headphones",
            Price = 50.00,
            Stock = 100,
            Category = new { Id = 102, Name = "Accessories" }
        }
    };
}