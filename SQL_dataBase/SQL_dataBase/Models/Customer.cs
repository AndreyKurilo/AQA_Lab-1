namespace SQL_dataBase.Models
{
    public record Customer
    {
        public int id { get; set; }
        public string? firstname { get; set; }
        public string? lastname { get; set; }
    }
}