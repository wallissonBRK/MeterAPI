using MeterAPI.Common;
using MeterAPI.Common.ViewModels.Client;
using MeterAPI.Models;

namespace MeterAPI.Endpoints.Client;

public class CreateClientEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", async (
            AppDbContext context,
            CreateClientViewModel model) =>
        {
            var client = model.MapTo();

            if (!model.IsValid)
                return Results.BadRequest(model.Notifications);

            context.Clients.Add(client);
            await context.SaveChangesAsync();

            return Results.Created($"/v1/client/{client.Id}", client);
        })
        .Produces<Models.Client>(201)
        .Produces(400)
        .Produces(401)
        .WithSummary("Cria um Cliente no banco de dados.")
        .WithDescription("Este endpoint cria um novo Cliente no banco de dados. Se o formato estiver incorreto, retorna 400.");
}
