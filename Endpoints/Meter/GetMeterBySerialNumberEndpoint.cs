using MeterAPI.Common;
using MeterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Endpoints.Meter;

public class GetMeterBySerialNumberEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{serialNumber}", async (
            string serialNumber,
            AppDbContext context) =>
        {
            if (string.IsNullOrEmpty(serialNumber))
                return Results.BadRequest(new { Message = "Numero de Serie inválido." });

            var existingMeter = await context.Meters.Where(m => m.SerialNumber == serialNumber).FirstOrDefaultAsync();

            if (existingMeter == null)
                return Results.NotFound(new { Message = "Medidor não encontrado." });

            return Results.Ok(existingMeter);
        })
        .Produces<Models.Meter>(200)
        .Produces(404)
        .Produces(401)
        .WithSummary("Obtem um Medidor pelo Numero de Serie")
        .WithDescription("Este endpoint retorna um Medidor cadastrado no banco de dados pelo Numero de Serie. Se não houver Medidor cadastrado, retorna 404.");
}