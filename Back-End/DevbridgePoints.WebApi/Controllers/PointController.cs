using AutoMapper;
using DevbridgePoints.WebApi.DTOs;
using DevbridgePoints.WebApi.Entities;
using DevbridgePoints.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointController : ControllerBase
    {
        private readonly PointRepository _repository;
        private readonly IMapper _mapper;

        public PointController(PointRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Point>> GetPoints()
        {
            return await _repository.GetAllPoints();
        }

        [HttpPost]
        public async Task AddPoint(PointDto pointDto)
        {
            var point = _mapper.Map<Point>(pointDto);
            await _repository.CreatePoint(point);
        }

        [HttpDelete("{id}")]
        public async Task DeletePoint(int id)
        {
            await _repository.DeletePoint(id);
        }
        
        [HttpDelete]
        public async Task DeleteAllPoints()
        {
            await _repository.ClearAllPoints();
        }
    }
}
