using GamesStore.Api.DTOs;

namespace GamesStore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            const string GetGameEndpointName = "GetGame";

            List<GameDto> games = [
                new (
                    1,
                    "Fifa 14",
                    "Sport",
                    59.99M,
                    new DateOnly(2014,8,21)),
                new (
                    2,
                    "GTA V",
                    "IDK",
                    100M,
                    new DateOnly(2011,5,5))
                ];

            app.MapGet("games", () => games);

            app.MapGet("/", () => "Hello World!");

            app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id)).WithName(GetGameEndpointName);

            app.MapPost("games", (CreateGameDto newGame) =>
            {
                GameDto game = new(
                    games.Count + 1,
                    newGame.Name,
                    newGame.Genre,
                    newGame.Price,
                    newGame.ReleaseDate);

                games.Add(game);

                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            });

            app.Run();
        }
    }
}
