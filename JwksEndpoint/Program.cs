using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/.well-known/jwks.json", async () =>
{
    using var reader = new StreamReader("public.pem");
    var publicKeyPem = await reader.ReadToEndAsync();

    var rsa = RSA.Create();
    rsa.ImportFromPem(publicKeyPem);

    var rsaParameters = rsa.ExportParameters(false);

    var jwk = new
    {
        kty = "RSA",
        use = "sig",
        kid = "1234567890",
        n = Base64UrlEncoder.Encode(rsaParameters.Modulus),
        e = Base64UrlEncoder.Encode(rsaParameters.Exponent)
    };

    return Results.Ok(new { keys = new[] { jwk } });
});

app.Run();
