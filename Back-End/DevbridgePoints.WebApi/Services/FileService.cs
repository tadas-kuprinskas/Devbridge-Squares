using DevbridgePoints.WebApi.Entities;
using DevbridgePoints.WebApi.Helpers;
using DevbridgePoints.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Services
{
    public class FileService : IFileService
    {
        private readonly IParsingService _parsingService;

        public FileService(IParsingService parsingService)
        {
            _parsingService = parsingService;
        }

        public async Task<string> ReadAsString(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return await Task.FromResult((string)null);
            }

            using var reader = new StreamReader(file.OpenReadStream());
            return await reader.ReadToEndAsync();
        }

        public async Task<IEnumerable<Point>> ReadFromFile(IFormFile file)
        {
            var text = await ReadAsString(file);

            return _parsingService.ParseToPointList(text);
        }

    }
}
