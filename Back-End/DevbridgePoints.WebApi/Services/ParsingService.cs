using AutoMapper;
using DevbridgePoints.WebApi.DTOs;
using DevbridgePoints.WebApi.Entities;
using DevbridgePoints.WebApi.Helpers;
using DevbridgePoints.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Services
{
    public class ParsingService : IParsingService
    {
        private readonly IMapper _mapper;

        public ParsingService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<Point> ParseToPointList(string lineOfNumbers)
        {
            var listOfNumbers = lineOfNumbers.Split('\n').ToList();
            List<Point> listOfPoints = new();

            for (int x = 0; x < listOfNumbers.Count; x++)
            {
                var pair = listOfNumbers[x].Split(" ");

                PointDto pointDto = new()
                {
                    XCoordinate = int.Parse(pair[0]),
                    YCoordinate = int.Parse(pair[1])
                };
 
                var dublicate = ValidationHelpers.ValidateDublicates(listOfPoints, pointDto);
                var pointRange = ValidationHelpers.ValidatePointRange(pointDto);

                
                if(dublicate == null && pointRange == null)
                {
                    var point = _mapper.Map<Point>(pointDto);

                    listOfPoints.Add(point);
                }
            }
            var validatedLimit = ValidationHelpers.ValidateLimit(listOfPoints);

            if (validatedLimit == null)
            {
                return listOfPoints;
            }
            else
            {
                return listOfPoints.Take(10000);
            }
        }
    }
}
