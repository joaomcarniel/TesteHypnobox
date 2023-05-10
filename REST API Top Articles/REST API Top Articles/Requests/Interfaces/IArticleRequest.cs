using REST_API_Top_Articles.Models;

namespace REST_API_Top_Articles.Requests.Interfaces
{
    public interface IArticleRequest
    {
        Task<List<Articles>> GetArticles();
    }
}
