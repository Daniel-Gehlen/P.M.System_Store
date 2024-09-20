var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços de controladores
builder.Services.AddControllers(); // Adicionar controladores

var app = builder.Build();

// Enable CORS
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseStaticFiles();  // Serve wwwroot content
app.UseRouting();

// Serve o arquivo index.html como página inicial
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync("wwwroot/index.html");
    });

    endpoints.MapControllers(); // Mapeamento de controladores para APIs
});

app.Run();
