using DevbridgePoints.WebApi.Entities;
using DevbridgePoints.WebApi.Helpers;
using DevbridgePoints.WebApi.Interfaces;
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
        //const string fileUrl = "..\\..\\..\\..\\CommonData\\Coordinates.txt";

        //public string FilePath { get; set; } = $"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileUrl)}";
        public async Task<IEnumerable<Point>> ReadFromFile(string filePath)
        {           
            using StreamReader streamReader = new(filePath);
            string stringOfNumbers = await streamReader.ReadToEndAsync();

            return ParsingHelpers.ParseToPointList(stringOfNumbers);
        }
    }
}
