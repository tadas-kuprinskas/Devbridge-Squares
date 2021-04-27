using AutoMapper;
using DevbridgePoints.WebApi.DTOs;
using DevbridgePoints.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevbridgePoints.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PointDto, Point>().ReverseMap();
        }
    }
}
