using AutoMapper;
using DevbridgePoints.WebApi.DTOs;
using DevbridgePoints.WebApi.Entities;
using DevbridgePoints.WebApi.Helpers;
using DevbridgePoints.WebApi.Interfaces;
using DevbridgePoints.WebApi.Repositories;
using DevbridgePoints.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointController : ControllerBase
    {
        private readonly IPointRepository _repository;
        private readonly IFileService _fileService;
        private readonly IParsingService _parsingService;

        public PointController(IPointRepository repository, IFileService fileService, IParsingService parsingService, IFindSquareService findSquareService)
        {
            _repository = repository;
            _fileService = fileService;
            _parsingService = parsingService;
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
        public async Task<IEnumerable<Point>> UploadFromFile(IFormFile file)
        {
            var textFromFile = await _fileService.ReadFromFile(file);
            var parsed = _parsingService.ParseToPointList(textFromFile);
            return await _repository.UploadFromFileAsync(parsed);           
        }
    }
}
