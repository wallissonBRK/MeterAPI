using MeterAPI.Common;
using MeterAPI.Models;

namespace MeterAPI.Endpoints.Customer;

//public class DeleteCostumerEndpoint : IEndpoint
//{
//    public static void Map(IEndpointRouteBuilder app)
//        => app.MapDelete("/", async (
//            int id,
//            AppDbContext context) =>
//        {
//            var smCostumer = await context.SmClientelicencas.FindAsync(id);

//            if (smCostumer == null)
//                return Results.NotFound(new { Message = "Cliente não encontrado." });

//            context.SmClientelicencas.Remove(smCostumer);
//            await context.SaveChangesAsync();

//            return Results.Ok(new { Message = "Cliente removido com sucesso." });
//        })
//        .Produces(200)
//        .Produces(404)
//        .Produces(401)
//        .WithSummary("Deleta um Cliente pelo ID.")
//        .WithDescription("Este endpoint deleta um Cliente especifico pelo seu ID. Se o Cliente não for encontrado, retorna 404.");
//}
