using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZTM.Infrastructure.Context;
using ZTM.Infrastructure.Entities;
using ZTM.Infrastructure.Exceptions;

namespace ZTM.Infrastructure.Repository;

public class DriverRepository:IDriverRepository
{

    private readonly MainContext _mainContext;

    public DriverRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Driver>> GetAll()
    {
        var drivers = await _mainContext.Driver.ToListAsync();
        
        return drivers;
    }

    public async Task<Driver> GetById(int id)
    {
        var driver = await _mainContext.Driver.SingleOrDefaultAsync(x => x.Id == id);
        if (driver != null)
        {
            return driver;
        }
        throw new EntityNotFoundException();
    }

    public async Task Add(Driver entity)
    {
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();

    }

    public async Task Update(int id, Driver entity)
    {
        var driverToUpdate = await _mainContext.Driver.FindAsync(id);
        if (driverToUpdate != null)
        { 
            driverToUpdate.Surname = entity.Surname;
            driverToUpdate.FirstName = entity.FirstName;
        }
        await _mainContext.SaveChangesAsync();
    }

   
    

    public async Task DeleteById(int id)
    {
        var driverToDelete = await _mainContext.Driver.SingleOrDefaultAsync(x => x.Id == id);
        if (driverToDelete != null)
        {
            _mainContext.Driver.Remove(driverToDelete);
            await _mainContext.SaveChangesAsync();
        }

        
    }

    
}