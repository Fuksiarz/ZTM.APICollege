using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZTM.Infrastructure.Context;
using ZTM.Infrastructure.Entities;
using ZTM.Infrastructure.Exceptions;

namespace ZTM.Infrastructure.Repository;

public class BusRepository:IBusRepository
{

    private readonly MainContext _mainContext;

    public BusRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Bus>> GetAll()
    {
        var buses = await _mainContext.Bus.ToListAsync();
        
        return buses;
    }

    public async Task<Bus> GetById(int id)
    {
        var bus = await _mainContext.Bus.SingleOrDefaultAsync(x => x.Id == id);
        if (bus != null)
        {
            return bus;
        }
        throw new EntityNotFoundException();
    }

    public async Task Add(Bus entity)
    {
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();

    }

    public Task Update(int id, Bus entity)
    {
        throw new NotImplementedException();
    }

    public async Task Update(Bus entity)
    {
        var busToUpdate = await _mainContext.Bus.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (busToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        busToUpdate.Destination = entity.Destination;
        busToUpdate.Driver = entity.Driver;
        busToUpdate.Line = entity.Line;
        busToUpdate.Stops = entity.Stops;
        
        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var busToDelete = await _mainContext.Bus.SingleOrDefaultAsync(x => x.Id == id);
        if (busToDelete != null)
        {
            _mainContext.Bus.Remove(busToDelete);
            await _mainContext.SaveChangesAsync();
        }

        throw new EntityNotFoundException();
    }
}