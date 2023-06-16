using IntegratedProtection.API.Helpers;

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
        builder.Services.AddTransient(typeof(IFileHelper), typeof(FilesHelper));
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
           .AddControllersWithViews()
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
           });

        builder.Services
            .AddHttpClient();
        #endregion
        #endregion

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