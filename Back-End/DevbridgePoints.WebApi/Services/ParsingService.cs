using AutoMapper;
using DevbridgePoints.WebApi.DTOs;
using DevbridgePoints.WebApi.Entities;
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
            var listOfNumbers = lineOfNumbers.Split(' ').Select(number => int.Parse(number)).ToList();
            List<Point> listOfPoints = new();

            for (var x = 0; x < listOfNumbers.Count; x+=2)
            {

                PointDto pointDto = new()
                {
                    //item.XCoordinate = listOfNumbers[x]
                    //item.YCoordinate = listOfNumbers[x + 1];
                    XCoordinate = listOfNumbers[x],
                    YCoordinate = listOfNumbers[x + 1]
                };

                var point = _mapper.Map<Point>(pointDto);
                listOfPoints.Add(point);

            }

            return listOfPoints;
        }
    }
}
