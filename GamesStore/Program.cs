using GameStore.Api.Data;
using GameStore.Api.Endpoints;

namespace GamesStore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connString = builder.Configuration.GetConnectionString("GameStore");
            builder.Services.AddSqlite<GameStoreContext>(connString);

            var app = builder.Build();

            app.MapGamesEndpoints();
            app.MapGenresEndpoints();

            await app.MigrateDbAsync();

            app.Run();

        }
    }
}
