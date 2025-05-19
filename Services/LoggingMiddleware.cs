using System.Text;

namespace MeterAPI.Services;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LoggingMiddleware> _logger;

    public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Captura o Body da Requisição
        context.Request.EnableBuffering();
        string requestBody;
        using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
        {
            requestBody = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;
        }

        // Substitui o Body da Resposta para capturar o conteúdo
        var originalResponseBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        // Processa a requisição
        await _next(context);

        // Loga o Body da Resposta
        context.Response.Body.Seek(0, SeekOrigin.Begin);
        string responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
        context.Response.Body.Seek(0, SeekOrigin.Begin);

        _logger.LogInformation("Request: {Method} {Path} - Body: {Body}",
            context.Request.Method,
            context.Request.Path,
            requestBody);

        _logger.LogInformation("Response: {StatusCode} - Body: {Body}",
            context.Response.StatusCode,
            responseBodyText);

        // Restaura o Stream Original
        await responseBody.CopyToAsync(originalResponseBodyStream);
    }
}
