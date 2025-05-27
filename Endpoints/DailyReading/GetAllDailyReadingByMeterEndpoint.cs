using MeterAPI.Common;
using MeterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Endpoints.DailyReading;

public class GetAllDailyReadingByMeterEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{serialNumber}", async (
            string serialNumber,
            AppDbContext context) =>
        {
            if (string.IsNullOrEmpty(serialNumber))
                return Results.BadRequest(new { Message = "Numero de Serie inválido." });

            var existingMeterId = await context.Meters.Where(m => m.SerialNumber == serialNumber).Select(m => m.Id).FirstOrDefaultAsync();

            if (existingMeterId == 0)
                return Results.NotFound(new { Message = "Medidor não encontrado." });

            var dailyReadings = await context.DailyReadings.Where(dr => dr.MeterId == existingMeterId).ToListAsync();

            if (dailyReadings.Count == 0)
                return Results.NotFound(new { Message = "Registros de leituras diarias não encontrado." });

            return Results.Ok(dailyReadings);
        })
        .Produces<List<Models.DailyReading>>(200)
        .Produces(404)
        .Produces(401)
        .WithSummary("Obtem todos os registros de leituras diarias de um Medidor pelo Numero de Serie")
        .WithDescription("Este endpoint retorna todos os registros de leituras diarias de um Medidor cadastrado no banco de dados pelo Numero de Serie. Se não houver Medidor cadastrado, retorna 404.");
}