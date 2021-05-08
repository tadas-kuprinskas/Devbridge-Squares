using AutoMapper;
using DevbridgePoints.WebApi.DTOs;
using DevbridgePoints.WebApi.Entities;
using DevbridgePoints.WebApi.Helpers;
using DevbridgePoints.WebApi.Interfaces;
using DevbridgePoints.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
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
        private readonly IFileService _fileService;

        public PointController(PointRepository repository, IMapper mapper, IFileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IEnumerable<Point>> GetPoints()
        {
            return await _repository.GetAllPoints();
        }

        [HttpPost]
        public async Task<Point> AddPoint(PointDto pointDto)
        {
            var validatedLimit = ValidationHelpers.ValidateLimit((List<Point>)await _repository.GetAllPoints());
            var dublicate = ValidationHelpers.ValidateDublicates((List<Point>)await _repository.GetAllPoints(), pointDto);

            if(validatedLimit == null && dublicate == null)
                return await _repository.CreatePoint(pointDto);
            return null;
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

        [HttpPost("upload")]
        public async Task<IEnumerable<Point>> UploadFromFile(string filePath)
        {
            var pointsFromFile = await _fileService.ReadFromFile(filePath);
            return await _repository.UploadFromFileAsync((List<Point>)pointsFromFile);
        }
    }
}
