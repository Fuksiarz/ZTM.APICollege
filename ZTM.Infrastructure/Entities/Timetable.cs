using System;
using System.Globalization;
using Microsoft.VisualBasic;

namespace ZTM.Infrastructure.Entities;

public class Timetable:BaseEntity
{
    
    public DateTime ArriveTime { get; set; }
    public DateTime LeaveTime { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public Bus Line { get; set; }

}