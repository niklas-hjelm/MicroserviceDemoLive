using HeroApi.DataAccess.Repositories;
using HeroApi.Endpoints.Requests;
using MediatR;

namespace HeroApi.Endpoints.Handlers;

public class GetAllHeroesHandler : IRequestHandler<GetAllHeroesRequest, IResult>
{
    private readonly IHeroRepository _heroRepository;

    public GetAllHeroesHandler(IHeroRepository heroRepository)
    {
        _heroRepository = heroRepository;
    }

    public async Task<IResult> Handle(GetAllHeroesRequest request, CancellationToken cancellationToken)
    {
        var result = await _heroRepository.GetAllHeroesAsync();

        return Results.Ok(result);
    }
}