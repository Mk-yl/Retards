using Retards.DTO;
using Retards.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//on ajoute une instance de la classe stat_Compte_service
builder.Services.AddSingleton<IStats_service<Stats_DTO>>(new Stats_service());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();