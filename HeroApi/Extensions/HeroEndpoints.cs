using HeroApi.DataAccess.Models;
using HeroApi.DataAccess.Repositories;
using HeroApi.Endpoints.Requests;

namespace HeroApi.Extensions;

public static class HeroEndpoints
{
    public static void MapHeroEndpoints(this WebApplication app)
    {
        app.MediateGet<GetAllHeroesRequest>("/heroes");
        app.MediatePost<PostHeroRequest>("/heroes");
    }
}