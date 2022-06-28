using System;

namespace ZTM.Infrastructure.Entities;

public class Timetable:BaseEntity
{
    
    public TimeOnly ArriveTime { get; set; }
    public TimeOnly LeaveTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public Bus Line { get; set; }

}