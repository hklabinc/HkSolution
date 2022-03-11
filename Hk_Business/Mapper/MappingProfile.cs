using AutoMapper;
using Hk_DataAccess;
using Hk_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hk_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();        // 양방향 가능
            //CreateMap<CategoryDTO, Category>();  // 위에서 ReverseMap() 사용하면 이건 없어도 됨
        }
    }
}
