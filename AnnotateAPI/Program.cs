using AnnotateAPI;
using Microsoft.EntityFrameworkCore;
using Services.Annotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AnnotateDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"), x => x.UseNetTopologySuite());
});
builder.Services.AddTransient<IAnnotationService, AnnotationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
