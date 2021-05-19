using DevbridgePoints.WebApi.Entities;
using DevbridgePoints.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Services
{
    public class FindSquareService : IFindSquareService
    {
        private readonly IPointRepository _pointRepository;

        public FindSquareService(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        static int DistSq(Point p, Point q)
        {
            return (p.XCoordinate - q.XCoordinate) * (p.XCoordinate - q.XCoordinate) + (p.YCoordinate - q.YCoordinate)
                * (p.YCoordinate - q.YCoordinate);
        }

        static bool IsSquare(Point p1, Point p2, Point p3, Point p4)
        {
            int d2 = DistSq(p1, p2);
            int d3 = DistSq(p1, p3);
            int d4 = DistSq(p1, p4);

            if (d2 == 0 || d3 == 0 || d4 == 0)
                return false;

            if (d2 == d3 && 2 * d2 == d4
                && 2 * DistSq(p2, p4) == DistSq(p2, p3))
            {
                return true;
            }

            if (d3 == d4 && 2 * d3 == d2
                && 2 * DistSq(p3, p2) == DistSq(p3, p4))
            {
                return true;
            }
            if (d2 == d4 && 2 * d2 == d3
                && 2 * DistSq(p2, p3) == DistSq(p2, p4))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Square>> GetSquares()
        {
            IEnumerable<Point> points = await _pointRepository.GetAllPoints();

            List<Square> squares = new();
            for (int i = 0; i < points.ToList().Count - 3; i++)
            {
                for (int j = i + 1; j < points.ToList().Count - 2; j++)
                {
                    for (int k = i + 2; k < points.ToList().Count - 1; k++)
                    {
                        for (int r = i + 3; r < points.ToList().Count; r++)
                        {
                            if (IsSquare(points.ToList()[i], points.ToList()[j], points.ToList()[k], points.ToList()[r]))
                            {
                                var square = new Square
                                {
                                    Point1 = points.ToList()[i],
                                    Point2 = points.ToList()[j],
                                    Point3 = points.ToList()[k],
                                    Point4 = points.ToList()[r]
                                };
                                squares.Add(square);
                            }
                        }
                    }
                }
            }
            return squares;
        }
    }
}
