using Microsoft.EntityFrameworkCore;
using Project.Api.Configurations.Swagger;
using Project.Core;
using Project.Core.Middleware;
using Project.EF;
using Project.Service;
using Project.Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
#region Dependencies
builder.Services.AddServiceDependencies()
   .AddCoreDependencies()
   .AddEFDependencies()
   .AddServiceRegisteration(builder.Configuration);

builder.Services.AddSwagger();
#endregion
#region Connection
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion

#region AllowCORS
const string cors = "_cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500") // مكان ما فاتح chat.html
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                      });
});
#endregion
// SignalR + controllers + presence
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddSingleton<PresenceTracker>();
var app = builder.Build();
#region Update Database on Startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();

    try
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred during database migration.");
    }
}
#endregion
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

//}
app.UseRouting();
app.UseCors(cors);
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();
app.MapHub<ChatHub>("/chathub");
app.Run();

