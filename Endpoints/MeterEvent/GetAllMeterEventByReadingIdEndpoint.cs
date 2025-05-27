using MeterAPI.Common;
using MeterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Endpoints.MeterEvent;

public class GetAllMeterEventByReadingIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("reading/{readingId}", async (
            int readingId,
            AppDbContext context) =>
        {
            if (readingId == 0)
                return Results.BadRequest(new { Message = "Id de leitura diaria inválida." });

            var meterEvents = await context.MeterEvents.Where(me => me.ReadingId == readingId).ToListAsync();

            if (meterEvents.Count == 0)
                return Results.NotFound(new { Message = "Registros de eventos do medidor não encontrado." });

            return Results.Ok(meterEvents);
        })
        .Produces<List<Models.MeterEvent>>(200)
        .Produces(404)
        .Produces(401)
        .WithSummary("Obtem todos os registros de eventos de um Medidor pelo Numero do Id da leitura diaria")
        .WithDescription("Este endpoint retorna todos os registros de eventos de um Medidor cadastrado no banco de dados pelo Numero do Id da leitura diaria. Se não houver Medidor cadastrado, retorna 404.");
}
