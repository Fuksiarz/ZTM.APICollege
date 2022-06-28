using System.Collections.Generic;

namespace ZTM.Infrastructure.Entities;

public class Stop:BaseEntity
{
    
    public int Address { get; set; }
    public string Name { get; set; }
    public bool Side { get; set; }
    public List<Timetable> Timetables { get; set; }
    
}