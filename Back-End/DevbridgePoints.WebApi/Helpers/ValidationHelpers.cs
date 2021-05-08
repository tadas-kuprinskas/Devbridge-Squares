using DevbridgePoints.WebApi.DTOs;
using DevbridgePoints.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Helpers
{
    public static class ValidationHelpers
    {
        public static string ValidateDublicates(List<Point> points, PointDto point)
        {
            string dublicateText = null;
            foreach (var item in points)
            {
                if (item.XCoordinate == point.XCoordinate && item.YCoordinate == point.YCoordinate)
                {
                    dublicateText = "Such point already exists";
                    break;
                }
            }
            return dublicateText;
        }

        public static string ValidateLimit(List<Point> points)
        {
            string limitText = null;
            if (points.Count > 10000)
            {
                limitText = "The limit for coordinates is 10000";
                return limitText;
            }
            return limitText;
        }
    }
}
