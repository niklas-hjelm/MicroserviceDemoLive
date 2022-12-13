using HeroApi.DataAccess.Contexts;
using HeroApi.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroApi.DataAccess.Repositories;

public class HeroRepository : IHeroRepository, IDisposable
{
    private readonly HeroContext _heroContext;

    public HeroRepository(HeroContext heroContext)
    {
        _heroContext = heroContext;
    }

    public async Task<IEnumerable<Hero>> GetAllHeroesAsync()
    {
        return _heroContext.Heroes;
    }

    public async Task<bool> AddHeroAsync(Hero newHero)
    {
        var existingHero = await _heroContext.Heroes.FirstOrDefaultAsync(h => h.Name == newHero.Name);
        if (existingHero is not null)
        {
            return false;
        }

        await _heroContext.Heroes.AddAsync(newHero);

        await _heroContext.SaveChangesAsync();

        return true;
    }

    public void Dispose()
    {
        _heroContext.Dispose();
    }
}