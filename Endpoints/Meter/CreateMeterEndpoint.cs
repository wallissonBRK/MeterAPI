using MeterAPI.Common;
using MeterAPI.Common.ViewModels.Meter;
using MeterAPI.Models;

namespace MeterAPI.Endpoints.Meter;

public class CreateMeterEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", async (
            AppDbContext context,
            CreateMeterViewModel model) =>
        {
            var meter = model.MapTo();

            if (!model.IsValid)
                return Results.BadRequest(model.Notifications);

            context.Meters.Add(meter);
            await context.SaveChangesAsync();

            return Results.Created($"/v1/meter/{meter.Id}", meter);
        })
        .Produces<Models.Meter>(201)
        .Produces(400)
        .Produces(401)
        .WithSummary("Cria um Medidor no banco de dados.")
        .WithDescription("Este endpoint cria um novo Medidor no banco de dados. Se o formato estiver incorreto, retorna 400.");
}
