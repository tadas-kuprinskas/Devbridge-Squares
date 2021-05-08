using DevbridgePoints.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Helpers
{
    public class ParsingHelpers
    {
        public static IEnumerable<Point> ParseToPointList(string lineOfNumbers)
        {
            var listOfNumbers = lineOfNumbers.Split(' ').Select(number => int.Parse(number)).ToList();
            List<Point> listOfPoints = new();

            for(var x=0; x<lineOfNumbers.Length; x++)
            {
                foreach (var item in listOfPoints)
                {
                    item.XCoordinate = listOfNumbers[x];
                    item.YCoordinate = listOfNumbers[x+1];
                }
            }

            return listOfPoints;
        }
    }
}
