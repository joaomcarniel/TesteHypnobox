using REST_API_Top_Articles.Models;
using REST_API_Top_Articles.Models.Dtos;

namespace REST_API_Top_Articles.Services.Interfaces
{
    public interface IArticleService
    {
        Task<ArticleResponseDto> GetTopCommentedArticles(int limit);
    }
}
