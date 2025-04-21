using GamesStore.Api.Data;
using GameStore.Api.ApiEndpoints;

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
            app.MigrateDb();

            app.Run();
        }
    }
}
