using DevbridgePoints.WebApi.Entities;
using DevbridgePoints.WebApi.Interfaces;
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
    public class SquareController
    {
        private readonly IFindSquareService _findSquareService;

        public SquareController(IFindSquareService findSquareService)
        {
            _findSquareService = findSquareService;
        }

        [HttpGet]
        public async Task<List<Square>> GetSquares()
        {
            return await _findSquareService.GetSquares();
        }
    }
}
