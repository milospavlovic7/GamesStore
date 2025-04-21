using GamesStore.Api.Data;
using GameStore.Api.ApiEndpoints;

namespace GamesStore.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            var connString = builder.Configuration.GetConnectionString("GameStore");
            builder.Services.AddSqlite<GameStoreContext>(connString);

            app.MapGamesEndpoints();

            app.Run();
        }
    }
}
