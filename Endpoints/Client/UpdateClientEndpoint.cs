using MeterAPI.Common;
using MeterAPI.Common.ViewModels;
using MeterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Endpoints.Client;

public class UpdateClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/", async (
            string document,
            AppDbContext context,
            UpdateClientViewModel model) =>
        {
            if (string.IsNullOrEmpty(document))
                return Results.BadRequest(new { Message = "Documento inválido." });

            var existingClient = await context.Clients.Where(c => c.Document == document).FirstOrDefaultAsync();

            if (existingClient == null)
                return Results.NotFound(new { Message = "Cliente não encontrado." });

            var costumer = model.MapTo(existingClient);

            if (!model.IsValid)
                return Results.BadRequest(model.Notifications);

            await context.SaveChangesAsync();
            return Results.Ok(new { Message = "Cliente atualizado com sucesso." });
        })
        .Produces(200)
        .Produces(400)
        .Produces(401)
        .Produces(404)
        .WithSummary("Atualiza um Cliente pelo seu Documento.")
        .WithDescription("Este endpoint atualiza um Cliente especifico pelo seu Documento. Se o Cliente não for encontrado, retorna 404.");
}

