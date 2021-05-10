using DevbridgePoints.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Interfaces
{
    public interface IFileService
    {
        Task<string> ReadFromFile(IFormFile file);
    }
}