using HeroApi.DataAccess.Models;

namespace HeroApi.Endpoints.Requests;

public class PostHeroRequest : IHttpRequest
{
    public Hero Hero { get; set; }
}