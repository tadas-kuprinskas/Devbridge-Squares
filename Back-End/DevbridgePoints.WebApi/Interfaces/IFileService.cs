using DevbridgePoints.WebApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Interfaces
{
    public interface IFileService
    {
        //string FilePath { get; set; }

        Task<IEnumerable<Point>> ReadFromFile(string filePath);
    }
}