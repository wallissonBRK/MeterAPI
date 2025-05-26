using MeterAPI.Common;
using MeterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Endpoints.Meter;

public class DeleteMeterEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/", async (
            string serialNumber,
            AppDbContext context) =>
        {
            if (string.IsNullOrEmpty(serialNumber))
                return Results.BadRequest(new { Message = "Numero Serie inválido." });

            var existingMeter = await context.Meters.Where(m => m.SerialNumber == serialNumber).FirstOrDefaultAsync();

            if (existingMeter == null)
                return Results.NotFound(new { Message = "Medidor não encontrado." });

            context.Meters.Remove(existingMeter);
            await context.SaveChangesAsync();

            return Results.Ok(new { Message = "Medidor removido com sucesso." });
        })
        .Produces(200)
        .Produces(404)
        .Produces(401)
        .WithSummary("Deleta um Medidor pelo Numero de Serie.")
        .WithDescription("Este endpoint deleta um Medidor especifico pelo seu Numero de Serie. Se o Medidor não for encontrado, retorna 404.");
}
