var builder = WebApplication.CreateBuilder(args);
var connectionStringMSQL = builder.Configuration.GetConnectionString("MSQLConnection");
var connectionStringPSQL = builder.Configuration.GetConnectionString("PSQLConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISuperHeroService, SuperHeroService>();

builder.Services.AddNamed<ISuperHeroesRepo>("RepoMSQL", provider => new SuperHeroesRepoMSQL(connectionStringMSQL!));
builder.Services.AddNamed<ISuperHeroesRepo>("RepoPSQL", provider => new SuperHeroesRepoPSQL(connectionStringPSQL!));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
