using MeterAPI.Common;
using MeterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Endpoints.Client;

public class DeleteClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/", async (
            string document,
            AppDbContext context) =>
        {
            if (string.IsNullOrEmpty(document))
                return Results.BadRequest(new { Message = "Documento inválido." });

            var existingClient = await context.Clients.Where(c => c.Document == document).FirstOrDefaultAsync();

            if (existingClient == null)
                return Results.NotFound(new { Message = "Cliente não encontrado." });

            context.Clients.Remove(existingClient);
            await context.SaveChangesAsync();

            return Results.Ok(new { Message = "Cliente removido com sucesso." });
        })
        .Produces(200)
        .Produces(404)
        .Produces(401)
        .WithSummary("Deleta um Cliente pelo Documento.")
        .WithDescription("Este endpoint deleta um Cliente especifico pelo seu Documento. Se o Cliente não for encontrado, retorna 404.");
}
