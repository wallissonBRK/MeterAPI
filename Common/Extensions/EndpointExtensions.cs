using MeterAPI.Endpoints.Customer;
using MeterAPI.Endpoints.Login;

namespace MeterAPI.Common.Extensions;

public static class EndpointExtensions
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" })
        .Produces(200)
        .WithSummary("Retorna 200 se a API está funcional.")
        .WithDescription("Este endpoint serve para verificar se a API está funcional. Se a API estiver funcional, retorna 200.")
        .RequireAuthorization();

        endpoints.MapGroup("/v1/costumer")
            .WithTags("Costumer")
            .RequireAuthorization()
            .MapEndpoint<GetCostumerEndpoint>()
            .MapEndpoint<GetCostumerByCNPJEndpoint>()
            .MapEndpoint<CreateCostumerEndpoint>()
            .MapEndpoint<UpdateCostumerEndpoint>()
            .MapEndpoint<DeleteCostumerEndpoint>();

        endpoints.MapGroup("/v1/login")
            .WithTags("Login")
            .MapEndpoint<ValidateLoginEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
