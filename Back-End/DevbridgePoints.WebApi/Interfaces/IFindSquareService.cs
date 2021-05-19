using DevbridgePoints.WebApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Interfaces
{
    public interface IFindSquareService
    {
        Task<List<Square>> GetSquares();
    }
}