using MeterAPI.Common;
using MeterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Endpoints.MeterEvent;

public class GetAllMeterEventByMeterEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("meter/{serialNumber}", async (
            string serialNumber,
            AppDbContext context) =>
        {
            if (string.IsNullOrEmpty(serialNumber))
                return Results.BadRequest(new { Message = "Numero de Serie inválido." });

            var existingMeterId = await context.Meters.Where(m => m.SerialNumber == serialNumber).Select(m => m.Id).FirstOrDefaultAsync();

            if (existingMeterId == 0)
                return Results.NotFound(new { Message = "Medidor não encontrado." });

            var meterEvents = await context.MeterEvents.Where(me => me.MeterId == existingMeterId).ToListAsync();

            if (meterEvents.Count == 0)
                return Results.NotFound(new { Message = "Registros de eventos do medidor não encontrado." });

            return Results.Ok(meterEvents);
        })
        .Produces<List<Models.MeterEvent>>(200)
        .Produces(404)
        .Produces(401)
        .WithSummary("Obtem todos os registros de eventos de um Medidor pelo Numero de Serie")
        .WithDescription("Este endpoint retorna todos os registros de eventos de um Medidor cadastrado no banco de dados pelo Numero de Serie. Se não houver Medidor cadastrado, retorna 404.");
}