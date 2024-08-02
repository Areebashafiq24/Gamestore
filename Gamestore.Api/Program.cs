using Gamestore.Api.Endpoints;
using Gamestore.Api.Data;

var builder = WebApplication.CreateBuilder(args);
 
var connString =builder.Configuration.GetConnectionString("Gamestore");
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();
app.MigrateDb();

app.Run();
