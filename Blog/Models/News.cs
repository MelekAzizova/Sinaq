using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required,MaxLength(128)]
        public string Image { get; set; }
        [Required,MinLength(5),MaxLength(32)]
        public string Title { get; set; }
        [Required,MinLength(3),MaxLength(64)]
        public string Description { get; set; }
        
    }
}
