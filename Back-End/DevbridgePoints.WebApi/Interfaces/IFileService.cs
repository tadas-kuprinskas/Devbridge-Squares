using DevbridgePoints.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Interfaces
{
    public interface IFileService
    {
        Task<string> ReadAsString(IFormFile file);
        Task<IEnumerable<Point>> ReadFromFile(IFormFile file);
    }
}