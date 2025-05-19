using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using MeterAPI.Common;
using MeterAPI.Common.Extensions;
using MeterAPI.Common.ViewModels;
using MeterAPI.Models;
using System.IdentityModel.Tokens.Jwt;

namespace MeterAPI.Endpoints.Login;

//public class ValidateLoginEndpoint : IEndpoint
//{
//    public static void Map(IEndpointRouteBuilder app)
//        => app.MapPost("/", async (
//            AppDbContext context,
//            LoginViewModel model) =>
//        {
//            var user = await context.SmUsuarios.FirstOrDefaultAsync(u => u.SmUsUserName == model.Usuario);

//            if (user == null)
//                return Results.NotFound(new { Message = "Usuário não encontrado." });

//            var validPassword = user.SmUsSenha == model.Senha;

//            if (!validPassword)
//                return Results.BadRequest(new { Message = "Senha inválida." });

//            var token = LicenceExtensions.GenerateToken(user);
//            return Results.Ok(new { Token = token });
//        })
//        .Produces(200)
//        .Produces(404)
//        .Produces(400)
//        .WithSummary("Obtem o Token de autenticação.")
//        .WithDescription("Este endpoint retorna o Token de autenticação se o login for valido. Se o login não for valido, retorna 400.");
//}
