using DevbridgePoints.WebApi.Entities;
using System.Collections.Generic;

namespace DevbridgePoints.WebApi.Interfaces
{
    public interface IParsingService
    {
        IEnumerable<Point> ParseToPointList(string lineOfNumbers);
    }
}