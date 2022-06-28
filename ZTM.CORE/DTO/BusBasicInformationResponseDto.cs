using System.Collections.Generic;
using ZTM.Infrastructure.Entities;

namespace ZTM.CORE.DTO;

public class BusBasicInformationResponseDto
{
    
    public int Line { get; set; }
    public string Destination { get; set; }
    public IEnumerable<Stop> Stops{ get; set; }

    public BusBasicInformationResponseDto(int line, string destination, IEnumerable<Stop> stops)
    {
        Line = line;
        Destination = destination;
        Stops = stops;
    }
    
}