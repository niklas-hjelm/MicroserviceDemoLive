using HeroApi.DataAccess.Repositories;
using HeroApi.Endpoints.Requests;
using MediatR;

namespace HeroApi.Endpoints.Handlers;

public class PostHeroHandler : IRequestHandler<PostHeroRequest, IResult>
{
    private readonly IHeroRepository _heroRepository;

    public PostHeroHandler(IHeroRepository heroRepository)
    {
        _heroRepository = heroRepository;
    }

    public async Task<IResult> Handle(PostHeroRequest request, CancellationToken cancellationToken)
    {
        var result = await _heroRepository.AddHeroAsync(request.Hero);

        return result
            ? Results.Ok(result)
            : Results.BadRequest(result);
    }
}