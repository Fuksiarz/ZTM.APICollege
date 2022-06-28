using System.Collections.Generic;

namespace ZTM.Infrastructure.Entities;

public class Bus : BaseEntity
{
    public Driver Driver { get; set; }
    public int Line { get; set; }
    public int Destination { get; set; }
    public List<Stop> Stops{ get; set; }

}