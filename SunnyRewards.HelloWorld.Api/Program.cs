using SunnyRewards.HelloWorld.Common.Extensions;
using SunnyRewards.HelloWorld.Common.ServiceRegistry;
using SunnyRewards.HelloWorld.Api.Helpers;
using SunnyRewards.HelloWorld.Api.Helpers.Interfaces;
using SunnyRewards.HelloWorld.Api.Mappings;
using SunnyRewards.HelloWorld.Api.Repos;
using SunnyRewards.HelloWorld.Api.Repos.Interfaces;
using SunnyRewards.HelloWorld.Api.Services;
using SunnyRewards.HelloWorld.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*");
            policy.AllowAnyOrigin();

        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
           .Build();

//string srConnectionStr = configuration.GetConnectionString("SRConnectionString") ?? "";


//builder.Services.AddNhibernate<RewardsModelMap>(srConnectionStr);
builder.Services.AddHttpContextAccessor();

//builder.Services.InitDependencies(x =>
//{
//    x.AddScoped<IRewardsService, RewardsService>();
//    //x.AddScoped<IRewardsHelper, RewardsHelper>();
//    //x.AddScoped<IRewardsRepo, RewardsRepo>();
//});


// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
