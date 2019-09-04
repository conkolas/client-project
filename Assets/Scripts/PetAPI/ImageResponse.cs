using Newtonsoft.Json;

public class ImageResponse {
    [JsonProperty("thumbnail_url")]
    public string ThumbnailURL { get; }

    [JsonProperty("thumbnail_width")]
    public int ThumbnailWidth { get; }

    [JsonProperty("thumbnail_height")]
    public int ThumbnailHeight { get; }

    [JsonProperty("original_url")]
    public string OriginalURL { get; }

    [JsonProperty("original_width")]
    public int OriginalWidth { get; }

    [JsonProperty("original_height")]
    public int OriginalHeight { get; }
}