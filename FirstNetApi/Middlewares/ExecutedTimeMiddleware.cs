using System.Diagnostics;

public class ExecutedTimeMiddleware(ILogger<ExecutedTimeMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var stopwatch = Stopwatch.StartNew();
        await next(context);
        stopwatch.Stop();

        if (stopwatch.ElapsedMilliseconds >= 4000)
        {
            logger.LogInformation($"Request: {context.Request.Method}" +
                $" at path: {context.Request.Path} " +
                $"responded with status code: {context.Response.StatusCode}," +
                $" took: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
