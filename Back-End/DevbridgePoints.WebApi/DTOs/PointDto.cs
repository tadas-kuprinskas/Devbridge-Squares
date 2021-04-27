using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.DTOs
{
    public class PointDto
    {
        [Range(-5000, 5000)]
        [Required]
        public int XCoordinate { get; set; }

        [Range(-5000, 5000)]
        [Required]
        public int YCoordinate { get; set; }
    }
}
