using System.Collections.Generic;

namespace ZTM.Infrastructure.Entities;

public class Bus : BaseEntity
{
    public Driver Driver { get; set; }
    public int Line { get; set; }
    public string Destination { get; set; }
    public IEnumerable<Stop> Stops{ get; set; }

}