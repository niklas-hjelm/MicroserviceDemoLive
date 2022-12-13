using HeroApi.DataAccess.Models;

namespace HeroApi.DataAccess.Repositories;

public interface IHeroRepository
{
    Task<IEnumerable<Hero>> GetAllHeroesAsync();
    Task<bool> AddHeroAsync(Hero newHero);
}