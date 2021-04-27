using DevbridgePoints.WebApi.Data;
using DevbridgePoints.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Repositories
{
    public class PointRepository
    {
        private readonly DataContext _dataContext;

        public PointRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Point>> GetAllPoints()
        {
            return await _dataContext.Points.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task CreatePoint(Point point)
        {
            _dataContext.Add(point);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeletePoint(int id)
        {
            var point = _dataContext.Points.FirstOrDefault(i => i.Id == id);
            _dataContext.Points.Remove(point);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ClearAllPoints()
        {
            var listOfPoints = await GetAllPoints();
            _dataContext.Points.RemoveRange(listOfPoints);
            await _dataContext.SaveChangesAsync();
        }
    }
}
