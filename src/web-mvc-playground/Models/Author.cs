namespace web_mvc_playground.Models
{
    public class Author
    {
        // varchar(11) -> string
        public string AuId { get; set; } = string.Empty;

        // varchar(40) -> string
        public string AuLname { get; set; } = string.Empty;

        // varchar(20) -> string
        public string AuFname { get; set; } = string.Empty;

        // char(12) -> string (biasanya format phone, lebih aman tetap string)
        public string Phone { get; set; } = string.Empty;

        // varchar(40) NULL -> string? (nullable)
        public string? Address { get; set; }

        // varchar(20) NULL -> string? (nullable)
        public string? City { get; set; }

        // char(2) NULL -> string? (nullable)
        public string? State { get; set; }

        // char(5) NULL -> string? (nullable)
        public string? Zip { get; set; }

        // bit NOT NULL -> bool
        public bool Contract { get; set; }
    }
}
