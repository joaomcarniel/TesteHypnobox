using Newtonsoft.Json;

namespace REST_API_Top_Articles.Models.Dtos
{
    public class ArticleResponseDto
    {
        [JsonProperty("title")]
        public int TotalResponse { get; set; }
        public List<ArticleDTO> Articles { get; set; }

    }
}
