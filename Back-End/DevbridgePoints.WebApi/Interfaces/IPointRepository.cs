using DevbridgePoints.WebApi.DTOs;
using DevbridgePoints.WebApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Interfaces
{
    public interface IPointRepository
    {
        Task ClearAllPoints();
        Task<Point> CreatePoint(PointDto pointDto);
        Task DeletePoint(int id);
        Task<IEnumerable<Point>> GetAllPoints();
        Task<IEnumerable<Point>> UploadFromFileAsync(IEnumerable<Point> pointsFromFile);
    }
}