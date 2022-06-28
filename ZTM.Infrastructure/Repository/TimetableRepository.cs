using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZTM.Infrastructure.Context;
using ZTM.Infrastructure.Entities;
using ZTM.Infrastructure.Exceptions;

namespace ZTM.Infrastructure.Repository;

public class TimetableRepository:ITimetableRepository
{

    private readonly MainContext _mainContext;

    public TimetableRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Timetable>> GetAll()
    {
        var timetables = await _mainContext.Timetable.ToListAsync();
        
        return timetables;
    }

    public async Task<Timetable> GetById(int id)
    {
        var timetable = await _mainContext.Timetable.SingleOrDefaultAsync(x => x.Id == id);
        if (timetable != null)
        {
            return timetable;
        }
        throw new EntityNotFoundException();
    }

    public async Task Add(Timetable entity)
    {
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();

    }

    public async Task Update(Timetable entity)
    {
        var timetableToUpdate = await _mainContext.Timetable.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (timetableToUpdate == null)
        {
            throw new EntityNotFoundException();
        }

        timetableToUpdate.Line = entity.Line;
        timetableToUpdate.ArriveTime = entity.ArriveTime;
        timetableToUpdate.LeaveTime = entity.LeaveTime;
        timetableToUpdate.DayOfWeek = entity.DayOfWeek;
        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteById(int id)
    {
        var timetableToDelete = await _mainContext.Timetable.SingleOrDefaultAsync(x => x.Id == id);
        if (timetableToDelete != null)
        {
            _mainContext.Timetable.Remove(timetableToDelete);
            await _mainContext.SaveChangesAsync();
        }

        throw new EntityNotFoundException();
    }
}