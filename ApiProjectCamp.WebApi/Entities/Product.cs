using System.Reflection.Metadata.Ecma335;

namespace ApiProjectCamp.WebApi.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
