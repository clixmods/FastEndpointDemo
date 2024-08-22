using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;

WebApplicationBuilder builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();

//Add Swagger (this configures it especially for FastEndpoints)
builder.Services.SwaggerDocument(o =>
{
});

WebApplication app = builder.Build();
app.UseFastEndpoints();

app.UseSwaggerGen();

app.Run();