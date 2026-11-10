var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/.well-known/jwks.json", async () =>
{
    using var reader = new StreamReader("public.pem");
    var publicKeyRaw = await reader.ReadToEndAsync();

    return publicKeyRaw;
});

app.Run();
