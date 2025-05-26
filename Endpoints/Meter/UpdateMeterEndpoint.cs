using MeterAPI.Common;
using MeterAPI.Common.ViewModels;
using MeterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Endpoints.Meter;

public class UpdateMeterEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/", async (
            string serialNumber,
            AppDbContext context,
            UpdateMeterViewModel model) =>
        {
            if (string.IsNullOrEmpty(serialNumber))
                return Results.BadRequest(new { Message = "Numero de Serie inválido." });

            var existingMeter = await context.Meters.Where(m => m.SerialNumber == serialNumber).FirstOrDefaultAsync();

            if (existingMeter == null)
                return Results.NotFound(new { Message = "Medidor não encontrado." });

            var meter = model.MapTo(existingMeter);

            if (!model.IsValid)
                return Results.BadRequest(model.Notifications);

            await context.SaveChangesAsync();
            return Results.Ok(new { Message = "Medidor atualizado com sucesso." });
        })
        .Produces(200)
        .Produces(400)
        .Produces(401)
        .Produces(404)
        .WithSummary("Atualiza um Medidor pelo seu Numero de Serie.")
        .WithDescription("Este endpoint atualiza um Medidor especifico pelo seu Numero de Serie. Se o Medidor não for encontrado, retorna 404.");
}
