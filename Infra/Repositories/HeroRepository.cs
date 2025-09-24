using Hero.Domain.Hero.Heroes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using _Hero = Hero.Domain.Hero.Heroes;

namespace Hero.Infra.Repositories;

public class HeroRepository(IDbContextFactory<ApplicationDbContext> contextFactory, IMemoryCache cache) 
    : _Hero.IHeroRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;
    private readonly IMemoryCache _cache = cache;
    //private readonly ApplicationDbContext _dbContext = context;

    public async Task<IReadOnlyList<_Hero.Hero>> GetAllHeroesAsync()
    {
        await using var ctx = _contextFactory.CreateDbContext();

        return await ctx.Heroes.AsNoTracking().ToListAsync().ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<_Hero.Herotype>?> GetHeroTypesAsync()
    {
        var list = new List<_Hero.Herotype>
        {
            new Herotype{ id = 1, name = "Warrior"},
            new Herotype{ id = 2, name = "Rogue"},
            new Herotype{ id = 3, name = "Mage"},
            new Herotype{ id = 4, name = "Archer"},
        };
        return await Task.FromResult(list);
        //return await _cache.GetOrCreateAsync("Herotype", async entry =>
        //{
        //    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
        //    await using var ctx = _contextFactory.CreateDbContext();
        //    return await ctx.Herotype
        //                   .AsNoTracking()
        //                   .Select(h => new Herotype { id = h.id, name = h.name })
        //                   .ToListAsync()
        //                   .ConfigureAwait(false);
        //});
    }

    public async Task<_Hero.Hero?> GetHeroByIdAsync(int heroid)
    {
        await using var ctx = _contextFactory.CreateDbContext();

        var result = await ctx.Heroes.FirstOrDefaultAsync(h => h.id == heroid).ConfigureAwait(false);

        return result;
    }

    public async Task<_Hero.Heroattributes?> GetHeroAttributesAsync(int heroid)
    {
        await using var ctx = _contextFactory.CreateDbContext();

        return await ctx.Attributes.FirstOrDefaultAsync(h => h.heroid == heroid).ConfigureAwait(false);
    }

    public async Task<_Hero.Hero> CreateHeroAsync(_Hero.Hero hero)
    {
        await using var ctx = _contextFactory.CreateDbContext();
        ctx.Heroes.Add(hero);
        await ctx.SaveChangesAsync().ConfigureAwait(false);
        return hero;
    }

    public async Task<_Hero.Hero?> UpdateHeroAsync(_Hero.Hero hero)
    {
        await using var ctx = _contextFactory.CreateDbContext();
        var update = await ctx.Heroes.FindAsync(hero.id).ConfigureAwait(false);
        if (update is null)
        {
            return null;
        }
        update.name = hero.name;
        update.type = hero.type;
        update.story = hero.story;
        await ctx.SaveChangesAsync().ConfigureAwait(false);
        return update;
    }
}
