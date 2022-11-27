namespace SuperHeroAPI.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<List<SuperHero>> AddSuperHero(SuperHero hero);
        Task<List<SuperHero>?> UpdateSingleHero(int id, SuperHero request);
        Task<List<SuperHero>?> DeleteSingleHero(int id);
    }
}
