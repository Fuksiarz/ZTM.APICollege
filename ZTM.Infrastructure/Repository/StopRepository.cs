using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZTM.Infrastructure.Context;
using ZTM.Infrastructure.Entities;
using ZTM.Infrastructure.Exceptions;

namespace ZTM.Infrastructure.Repository;

public class StopRepository:IStopRepository
{

    private readonly MainContext _mainContext;

    public StopRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Stop>> GetAll()
    {
        var stop = await _mainContext.Stop.ToListAsync();
        
        return stop;
    }

    public async Task<Stop> GetById(int id)
    {
        var stop = await _mainContext.Stop.SingleOrDefaultAsync(x => x.Id == id);
        if (stop != null)
        {
            return stop;
        }
        throw new EntityNotFoundException();
    }

    public async Task Add(Stop entity)
    {
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();

    }

    public async Task Update(Stop entity)
    {
        var stopToUpdate = await _mainContext.Stop.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (stopToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        stopToUpdate.Address = entity.Address;
        stopToUpdate.Name = entity.Name;
        stopToUpdate.Side = entity.Side;
        stopToUpdate.Timetables = entity.Timetables;
        
        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var stopToDelete = await _mainContext.Stop.SingleOrDefaultAsync(x => x.Id == id);
        if (stopToDelete != null)
        {
            _mainContext.Stop.Remove(stopToDelete);
            await _mainContext.SaveChangesAsync();
        }

        throw new EntityNotFoundException();
    }
}