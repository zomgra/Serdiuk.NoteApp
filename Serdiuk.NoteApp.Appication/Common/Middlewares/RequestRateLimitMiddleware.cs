using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

public class RequestRateLimitMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMemoryCache _cache;
    private readonly int _limit;
    private readonly TimeSpan _period;

    /// <param name="limit">Count transition</param>
    public RequestRateLimitMiddleware(RequestDelegate next, IMemoryCache cache, int limit, TimeSpan period)
    {
        _next = next;
        _cache = cache;
        _limit = limit;
        _period = period;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var ip = context.Connection.RemoteIpAddress.ToString();
        var key = $"request_rate_limit_{ip}";

        if (_cache.TryGetValue(key, out int count))
        {
            if (count >= _limit)
            {
                context.Response.StatusCode = 429; // Too Many Requests
                return;
            }
            _cache.Set(key, count + 1, _period);
        }
        else
        {
            _cache.Set(key, 1, _period);
        }

        await _next(context);
    }
}
