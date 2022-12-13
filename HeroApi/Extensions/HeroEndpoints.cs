using HeroApi.DataAccess.Models;
using HeroApi.DataAccess.Repositories;

namespace HeroApi.Extensions;

public static class HeroEndpoints
{
    public static void MapHeroEndpoints(this WebApplication app)
    {
        app.MapGet("/heroes", GetAllHeroes);
        app.MapPost("/heroes", PostHero);
    }

    private static async Task<IResult> PostHero(IHeroRepository repo, Hero newHero)
    {
        var result = await repo.AddHeroAsync(newHero);

        return result
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }

    private static async Task<IResult> GetAllHeroes(IHeroRepository repo)
    {
        var result = await repo.GetAllHeroesAsync();

        return Results.Ok(result);
    }
}