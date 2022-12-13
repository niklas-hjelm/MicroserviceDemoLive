using HeroApi.Endpoints.Requests;
using MediatR;

namespace HeroApi.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication MediateGet<TRequest>(
        this WebApplication app,
        string template) where TRequest : IHttpRequest
    {
        app.MapGet(template,
            async (IMediator mediator, [AsParameters] TRequest request)
                => await mediator.Send(request));
        return app;
    }

    public static WebApplication MediatePost<TRequest>(
        this WebApplication app,
        string template) where TRequest : IHttpRequest
    {
        app.MapPost(template,
            async (IMediator mediator, [AsParameters] TRequest request)
                => await mediator.Send(request));
        return app;
    }
}