using IntegratedProtection.Application;

namespace IntegratedProtection.API;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        #region Regiser Services

        #region Add Custome Services
        builder.Services
                .RegisterApplicationDependencies()
                .RegisterInfrastructureDependencies(builder.Configuration);
        #endregion

        #region Enable Cors Policy
        builder.Services
           // solve "Pre flaying problem (CORS)" problem
           .AddCors(options =>
           {
               options.AddPolicy("IntegratedProtectionPolicy", policyBuilder =>
               {
                   policyBuilder.AllowAnyOrigin();
                   policyBuilder.AllowAnyMethod();
                   policyBuilder.AllowAnyHeader();
               });
           });
        #endregion

        #region Handel Serialize loop references (but this in ASP.NetCore.OpenApi)
        builder.Services
           .AddControllers()
           .AddJsonOptions(options =>
           {
               /* Use JsonSerializerOptions Instead of using [JsonIgnore] */
               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
           });
        #endregion

        #endregion

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        #region Use Services
        app.UseCors("IntegratedProtectionPolicy");
        app.UseStaticFiles();
        #endregion

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}