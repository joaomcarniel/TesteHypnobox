using Newtonsoft.Json;

namespace REST_API_Top_Articles.Models
{
    public partial class Articles
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public string Author { get; set; }

        [JsonProperty("num_comments")]
        public long? NumComments { get; set; }

        [JsonProperty("story_id")]
        public object StoryId { get; set; }

        [JsonProperty("story_title")]
        public string StoryTitle { get; set; }

        [JsonProperty("story_url")]
        public Uri StoryUrl { get; set; }

        [JsonProperty("parent_id")]
        public long? ParentId { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public long? CreatedAt { get; set; }
    }
}
