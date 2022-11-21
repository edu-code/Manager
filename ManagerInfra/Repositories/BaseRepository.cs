using ManagerDomain.Entities;
using ManagerInfra.Context;
using ManagerInfra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManagerInfra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    private readonly ManagerContext _context;

    public BaseRepository(ManagerContext context)
    {
        _context = context;
    }

    public virtual async Task<T> CreateAsync(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<T> UpdateAsync(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<T> RemoveAsync(long id)
    {
        var obj = await GetAsync(id);
        
        if (obj != null){
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        return obj;
    }

    public virtual async Task<T> GetAsync(long id)
    {
        var obj = await _context.Set<T>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync();

        return obj.FirstOrDefault();
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }
}