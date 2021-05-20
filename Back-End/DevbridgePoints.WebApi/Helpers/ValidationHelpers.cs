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
        public static string ValidateDublicates(List<Point> points, PointDto pointDto)
        {
            string dublicateText = null;
            foreach (var item in points)
            {
                if (item.XCoordinate == pointDto.XCoordinate && item.YCoordinate == pointDto.YCoordinate)
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

        public static string ValidatePointRange(PointDto pointDto)
        {
            string rangeText = null;

            if(pointDto.XCoordinate > 5000 || pointDto.YCoordinate > 5000 || pointDto.XCoordinate < -5000 || pointDto.YCoordinate < -5000)
            {
                rangeText = "Invalid range of the point. The range of the point is between -5000 and 5000";
                return rangeText;
            }
            return rangeText;
        }
    }
}
