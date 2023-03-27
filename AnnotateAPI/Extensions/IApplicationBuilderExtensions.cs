using AnnotateAPI.Seeders;

namespace AnnotateAPI.Extensions; 

public static class IApplicationBuilderExtensions {
    public static IApplicationBuilder AddSeeding(this IApplicationBuilder app) {
        using var serviceScope = app.ApplicationServices.CreateScope();
        using var dbContext = serviceScope.ServiceProvider.GetRequiredService<AnnotateDbContext>();

        new MainSeeder()
            .Seed(dbContext)
            .GetAwaiter()
            .GetResult();

        return app;
    }
}