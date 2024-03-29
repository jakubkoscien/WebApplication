using System.ComponentModel.DataAnnotations;

namespace CustomAPI.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}