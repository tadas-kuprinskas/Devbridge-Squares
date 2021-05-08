using AutoMapper;
using DevbridgePoints.WebApi.Data;
using DevbridgePoints.WebApi.DTOs;
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
        private readonly IMapper _mapper;

        public PointRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Point>> GetAllPoints()
        {
            return await _dataContext.Points.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Point> CreatePoint(PointDto pointDto)
        {
            var point = _mapper.Map<Point>(pointDto);
            _dataContext.Add(point);
            await _dataContext.SaveChangesAsync();
            return point;
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

        public async Task<IEnumerable<Point>> UploadFromFileAsync(IEnumerable<Point> pointsFromFile)
        {
            await ClearAllPoints();

            List<Point> pointListFromFile = new();

            foreach (var item in pointsFromFile)
            {        
                _dataContext.Add(item);
            }
            await _dataContext.SaveChangesAsync();

            await GetAllPoints();

            return pointListFromFile;
        }
    }
}
