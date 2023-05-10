using AutoMapper;
using REST_API_Top_Articles.Models;
using REST_API_Top_Articles.Models.Dtos;
using REST_API_Top_Articles.Requests.Interfaces;
using REST_API_Top_Articles.Services.Interfaces;

namespace REST_API_Top_Articles.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRequest articleRequest;
        private readonly IMapper mapper;

        public ArticleService(IArticleRequest articleRequest, IMapper mapper)
        {
            this.articleRequest = articleRequest;
            this.mapper = mapper;
        }

        public async Task<ArticleResponseDto> GetTopCommentedArticles(int limit)
        {
            try
            {
                var articleList = await articleRequest.GetArticles();
                var articleWithNames = DeleteArticlesWithoutNames(articleList);
                var articlesResponse = articleWithNames.OrderByDescending(x => x.NumComments)
                    .ThenBy(x => x.Title)
                    .ThenBy(x => x.StoryTitle).Take(limit);
                var articlesResponseDTO = new ArticleResponseDto()
                {
                    TotalResponse = articlesResponse.Count(),
                    Articles = new List<ArticleDTO>()
                };
                articlesResponseDTO.Articles = mapper.Map<List<ArticleDTO>>(articlesResponse.ToList());
                return articlesResponseDTO;
            }
            catch (Exception e)
            {
                Console.WriteLine("An Error ocurred while getting TopCommentedArticles." +
                    $"Message: {e.Message}. StackTrace: {e.StackTrace}");
                throw new Exception("Ocorreu um erro ao buscarmos os artigos mais comentados");
            }
        }

        private List<Articles> DeleteArticlesWithoutNames(List<Articles> articles)
        {
            var articlesWithNames = articles.Where(x => !string.IsNullOrEmpty(x.Title)).ToList();
            var articlesWithoutNames = articles.Where(x => string.IsNullOrEmpty(x.Title)).ToList();
            articlesWithNames.AddRange(articlesWithoutNames.Where(
                x => !string.IsNullOrEmpty(x.StoryTitle)));
            return articlesWithNames;
        }
    }
}
