using Newtonsoft.Json;
using REST_API_Top_Articles.Models;
using REST_API_Top_Articles.Requests.Interfaces;
using RestSharp;

namespace REST_API_Top_Articles.Requests
{
    public class ArticleRequest : IArticleRequest
    {
        public async Task<List<Articles>> GetArticles()
        {
            var articleList = new List<Articles>();
            try
			{
                var articleResponse = new ArticleResponseModel();
                var page = 0;
                do
                {
                    page++;
                    var client = new RestClient("http://mock-api.hypnobox.com.br:4011");
                    var request = new RestRequest($"/teste/api/articles?page={page}", Method.Get);
                    RestResponse response = await client.ExecuteAsync(request);
                    articleResponse = JsonConvert.DeserializeObject<ArticleResponseModel>(response.Content);
                    articleList.AddRange(articleResponse?.ArticlesData);
                } while (page <= articleResponse.TotalPages);
			}
			catch (Exception e)
			{
                Console.WriteLine("An error ocurred trying to get articleList." +
                    $"Message: {e.Message} - StackTrace: {e.StackTrace}");
            }
            return articleList;
        }
    }
}
