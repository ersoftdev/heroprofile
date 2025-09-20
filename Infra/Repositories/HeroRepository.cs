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

        return await ctx.Heroes.AsNoTracking().ToListAsync();
    }

    public async Task<IReadOnlyList<_Hero.Herotype>?> GetHeroTypesAsync()
    {
        return await _cache.GetOrCreateAsync("Herotype", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            await using var ctx = _contextFactory.CreateDbContext();
            return await ctx.Herotype
                           .AsNoTracking()
                           .Select(h => new Herotype { id = h.id, name = h.name })
                           .ToListAsync();
        });
    }

    public async Task<_Hero.Hero?> GetHeroByIdAsync(int heroid)
    {
        await using var ctx = _contextFactory.CreateDbContext();

        return await ctx.Heroes.FirstOrDefaultAsync(h => h.id == heroid);
    }

    public async Task<_Hero.Heroattributes?> GetHeroAttributesAsync(int heroid)
    {
        await using var ctx = _contextFactory.CreateDbContext();

        return await ctx.Attributes.FirstOrDefaultAsync(h => h.heroid == heroid);
    }

    public async Task<_Hero.Hero> CreateHeroAsync(_Hero.Hero hero)
    {
        await using var ctx = _contextFactory.CreateDbContext();
        ctx.Heroes.Add(hero);
        await ctx.SaveChangesAsync();
        return hero;
    }

    public async Task<_Hero.Hero?> UpdateHeroAsync(_Hero.Hero hero)
    {
        await using var ctx = _contextFactory.CreateDbContext();
        var update = await ctx.Heroes.FindAsync(hero.id);
        if (update is null)
        {
            return null;
        }
        update.name = hero.name;
        update.type = hero.type;
        update.story = hero.story;
        await ctx.SaveChangesAsync();
        return update;
    }
}
