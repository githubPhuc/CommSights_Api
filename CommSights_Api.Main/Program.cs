
using CommSights_Api.Main.DIExtensions;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
});
builder.Services.AddAuthentication().AddCookie();
builder.Services.AddSystemSwagger();
builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddSystemJwtIdentity(builder.Configuration);
builder.Services.AddSystemDatabase(builder.Configuration);
builder.Services.AddMapper();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
});
app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseStaticFiles();
app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.Run();
//update model
//Scaffold-DbContext "Data Source=103.147.122.150;Initial Catalog=CommSights;Persist Security Info=True;User ID=sa;Password=@@@CommSights123@@@;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir  fordelname

