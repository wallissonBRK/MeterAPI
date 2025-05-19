using Microsoft.EntityFrameworkCore;
using MeterAPI.Common;
using MeterAPI.Models;

namespace MeterAPI.Endpoints.Customer;

//public class GetCostumerByCNPJEndpoint : IEndpoint
//{
//    public static void Map(IEndpointRouteBuilder app)
//        => app.MapGet("/{cnpj}", async (
//            string cnpj,
//            AppDbContext context) =>
//        {
//            var customer = await context.SmClientelicencas
//                .Where(c => c.SmClCnpj == cnpj)
//                .FirstOrDefaultAsync();

//            if (customer is null)
//                return Results.NotFound();

//            return Results.Ok(customer);
//        })
//        .Produces<SmClientelicenca>(200)
//        .Produces(404)
//        .Produces(401)
//        .WithSummary("Obtem um Cliente pelo CNPJ")
//        .WithDescription("Este endpoint retorna um Cliente cadastrado no banco de dados pelo CNPJ. Se não houver Cliente cadastrado, retorna 404.");
//}
