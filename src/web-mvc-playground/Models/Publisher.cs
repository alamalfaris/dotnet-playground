namespace web_mvc_playground.Models
{
    public class Publisher
    {
        public string PubId { get; set; } = string.Empty;
        public string PubName { get; set; } = string.Empty;

        // image -> byte[]
        public byte[]? Logo { get; set; }

        // text -> string
        public string? PrInfo { get; set; }
    }

}
