using Microsoft.EntityFrameworkCore;
using MeterAPI.Common;
using MeterAPI.Models;

namespace MeterAPI.Endpoints.Customer;

//public class GetCostumerEndpoint : IEndpoint
//{
//    public static void Map(IEndpointRouteBuilder app)
//        => app.MapGet("/", async (
//            AppDbContext context) =>
//        {
//            var customers = await context.SmClientelicencas.ToListAsync();
//            return Results.Ok(customers);
//        })
//        .Produces<List<SmClientelicenca>>(200)
//        .Produces(401)
//        .WithSummary("Obtem todos os Clientes")
//        .WithDescription("Este endpoint retorna todos Cliente cadastrados no banco de dados. Se não houver Clientes cadastrados, retorna uma lista vazia.");
//}
