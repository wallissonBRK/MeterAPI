using MeterAPI.Common;
using MeterAPI.Common.ViewModels;
using MeterAPI.Models;

namespace MeterAPI.Endpoints.Customer;

//public class UpdateCostumerEndpoint : IEndpoint
//{
//    public static void Map(IEndpointRouteBuilder app)
//        => app.MapPut("/", async (
//            int id,
//            AppDbContext context,
//            UpdateCostumerViewModel model) =>
//        {
//            var smCostumer = await context.SmClientelicencas.FindAsync(id);

//            if (smCostumer == null)
//                return Results.NotFound(new { Message = "Cliente não encontrado." });

//            var costumer = model.MapTo(smCostumer);

//            if (!model.IsValid)
//                return Results.BadRequest(model.Notifications);

//            await context.SaveChangesAsync();
//            return Results.Ok(new { Message = "Cliente atualizado com sucesso." });
//        })
//        .Produces(200)
//        .Produces(400)
//        .Produces(401)
//        .Produces(404)
//        .WithSummary("Atualiza um Cliente pelo seu ID.")
//        .WithDescription("Este endpoint atualiza um Cliente especifico pelo seu ID. Se o Cliente não for encontrado, retorna 404.");
//}
