using AutoMapper;
using REST_API_Top_Articles.Models.Dtos;

namespace REST_API_Top_Articles.Models.Mappers
{
    public class ArticleMapper : Profile
    {
        public ArticleMapper()
        {
            CreateMap<Articles, ArticleDTO>().ReverseMap();
        }
    }
}
