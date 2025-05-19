using MeterAPI.Common;
using MeterAPI.Common.ViewModels;
using MeterAPI.Models;

namespace MeterAPI.Endpoints.Customer;

//public class CreateCostumerEndpoint : IEndpoint
//{
//    public static void Map(IEndpointRouteBuilder app)
//        => app.MapPost("/", async (
//            AppDbContext context,
//            CreateCostumerViewModel model) =>
//        {
//            var costumer = model.MapTo();

//            if (!model.IsValid)
//                return Results.BadRequest(model.Notifications);

//            context.SmClientelicencas.Add(costumer);
//            await context.SaveChangesAsync();

//            return Results.Created($"/v1/customer/{costumer.SmClId}", costumer);
//        })
//        .Produces<SmClientelicenca>(201)
//        .Produces(400)
//        .Produces(401)
//        .WithSummary("Cria um Cliente no banco de dados.")
//        .WithDescription("Este endpoint cria um novo Cliente no banco de dados. Se o formato estiver incorreto, retorna 400.");
//}
