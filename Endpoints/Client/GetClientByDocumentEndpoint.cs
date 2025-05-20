using MeterAPI.Common;
using MeterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MeterAPI.Endpoints.Client;

public class GetClientByDocumentEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{document}", async (
            string document,
            AppDbContext context) =>
        {
            if (string.IsNullOrEmpty(document))
                return Results.BadRequest(new { Message = "Documento inválido." });

            var existingClient = await context.Clients.Where(c => c.Document == document).FirstOrDefaultAsync();

            if (existingClient == null)
                return Results.NotFound(new { Message = "Cliente não encontrado." });

            return Results.Ok(existingClient);
        })
        .Produces<Models.Client>(200)
        .Produces(404)
        .Produces(401)
        .WithSummary("Obtem um Cliente pelo Documento")
        .WithDescription("Este endpoint retorna um Cliente cadastrado no banco de dados pelo Documento. Se não houver Cliente cadastrado, retorna 404.");
}
