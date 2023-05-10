using Newtonsoft.Json;

namespace REST_API_Top_Articles.Models.Dtos
{
    public class ArticleDTO
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("story_title")]
        public string StoryTitle { get; set; }

        [JsonProperty("num_comments")]
        public long? NumComments { get; set; }
    }
}
