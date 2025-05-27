using MeterAPI.Common;
using MeterAPI.Common.ViewModels.MeterEvent;
using MeterAPI.Models;

namespace MeterAPI.Endpoints.MeterEvent;

public class CreateMeterEventEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", async (
            AppDbContext context,
            CreateMeterEventViewModel model) =>
        {
            var meterEvent = model.MapTo();
            meterEvent.EventDatetime = DateTime.UtcNow;

            if (!model.IsValid)
                return Results.BadRequest(model.Notifications);

            context.MeterEvents.Add(meterEvent);
            await context.SaveChangesAsync();

            return Results.Created($"/v1/meter-event/{meterEvent.Id}", meterEvent);
        })
        .Produces<Models.MeterEvent>(201)
        .Produces(400)
        .Produces(401)
        .WithSummary("Cria um registro de evento do medidor no banco de dados.")
        .WithDescription("Este endpoint cria um novo registro de evento do medidor no banco de dados. Se o formato estiver incorreto, retorna 400.");
}
