using Evently.Api.Extensions;
using Evently.Modules.Events.Api;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Console.WriteLine(
    builder.Configuration.GetConnectionString("Database"));
builder.Services.AddEvenstModules(builder.Configuration);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

EventModule.MapEndpoints(app);

app.Run();
