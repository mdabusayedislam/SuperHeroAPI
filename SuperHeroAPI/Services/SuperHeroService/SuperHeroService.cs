using SuperHeroAPI.Data;

namespace SuperHeroAPI.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _dataContext;
        public SuperHeroService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<SuperHero>> AddSuperHero(SuperHero hero)
        {
             await _dataContext.SuperHeroes.AddAsync(hero);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.SuperHeroes.ToListAsync();
        }
        public async Task<List<SuperHero>> GetAllHeroes()
        {
            return await _dataContext.SuperHeroes.ToListAsync();
        }
        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;
            return hero;
        }
        public async Task<List<SuperHero>?> UpdateSingleHero(int id, SuperHero request)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;
            hero.Name = request.Name;
            hero.FirstName = request.Name;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            await _dataContext.SaveChangesAsync();
            return await _dataContext.SuperHeroes.ToListAsync();
        }
        public async Task<List<SuperHero>?> DeleteSingleHero(int id)
        {
            var hero = await _dataContext.SuperHeroes.FindAsync(id);
            if (hero is null)
                return null;
            _dataContext.SuperHeroes.Remove(hero);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.SuperHeroes.ToListAsync();
        }
    }
}
