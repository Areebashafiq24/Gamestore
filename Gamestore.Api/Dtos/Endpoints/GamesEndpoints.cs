// public static class GamesEndpoints
// {
//     const string GetGameEndpointName = "GetGame";
//     private static readonly List<GameDto> games = [
//       new (1, "Street Fighter", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
//     new (2, "Final Fantasy", "Roleplaying", 59.99M, new DateOnly(2010, 9, 30)),
//     new (3, "FIFA", "Sports", 69.9M, new DateOnly(2022, 9, 27))
//     ];

//     public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
//     {
//         var group =app.MapGroup("games").WithName(GetGameEndpointName);
//         group.MapGet("/", () => games);


//         group.MapGet("/{id}", (int id) =>
//         {
//             GameDto? game = games.Find(game => game.Id == id);

//             return game is null ? Results.NotFound() : Results.Ok(game);

//         });
        

//         //POST API / WHEN SOMEONE WILL POST SOMETHING IN GAMES 

//         group.MapPost("/", (CreateGameDto newGame) =>
//         {
//             if(string.IsNullOrEmpty(newGame.Name)){
//                 return Results.BadRequest("You have not specified the name");
//             }
//             GameDto game = new(
//                 games.Count + 1,
//                 newGame.Name,
//                 newGame.Genre,
//                 newGame.Price,
//                 newGame.ReleaseDate
//             );
//             games.Add(game);


//             return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id },
//             game);
//         }).WithParameterValidation();

//         group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
//         {
//             var index = games.FindIndex(game => game.Id == id);
//             if (index == -1)
//             {
//                 return Results.NotFound();
//             }
//             games[index] = new GameDto(
//                 id,
//                 updatedGame.Name,
//                 updatedGame.Genre,
//                 updatedGame.Price,
//                 updatedGame.ReleaseDate
//             );

//             return Results.NoContent();
//         });


//         group.MapDelete("/{id}", (int id) =>
//         {
//             games.RemoveAll(game => game.Id == id);
//             return Results.NoContent();

//         });
//         return group;
//     }

// }


using Gamestore.Api.Dtos;

namespace Gamestore.Api.Endpoints;

public static class GamesEndpoints
{
    private static readonly List<GameDto> games = new()
    {
        new(1, "Street Fighter", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
        new(2, "Final Fantasy", "Roleplaying", 59.99M, new DateOnly(2010, 9, 30)),
        new(3, "FIFA", "Sports", 69.9M, new DateOnly(2022, 9, 27))
    };

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games");

        group.MapGet("/", () => games).WithName("GetAllGames"); // Changed line

        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName("GetGameById"); // Changed line

        group.MapPost("/", (CreateGameDto newGame) =>
        {
            if (string.IsNullOrEmpty(newGame.Name))
            {
                return Results.BadRequest("You have not specified the name");
            }

            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(game);

            return Results.CreatedAtRoute("GetGameById", new { id = game.Id }, game); // Changed line
        }).WithParameterValidation();

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);
            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);
            return Results.NoContent();
        });

        return group;
    }
}

