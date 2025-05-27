using MeterAPI.Common;
using MeterAPI.Common.ViewModels.DailyReading;
using MeterAPI.Models;

namespace MeterAPI.Endpoints.DailyReading;

public class CreateDailyReadingEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", async (
            AppDbContext context,
            CreateDailyReadViewModel model) =>
        {
            var daily = model.MapTo();
            daily.ReadingDate = DateTime.Now;

            if (!model.IsValid)
                return Results.BadRequest(model.Notifications);

            context.DailyReadings.Add(daily);
            await context.SaveChangesAsync();

            return Results.Created($"/v1/daily/{daily.Id}", daily);
        })
        .Produces<Models.DailyReading>(201)
        .Produces(400)
        .Produces(401)
        .WithSummary("Cria um registro de leitura diaria no banco de dados.")
        .WithDescription("Este endpoint cria um novo registro de leitura diaria no banco de dados. Se o formato estiver incorreto, retorna 400.");
}