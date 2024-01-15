using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.NewVM
{
    public class NewsListItemVM
    {
        public int Id { get; set; }
       
        public string Image { get; set; }
       
        public string Title { get; set; }
      
        public string Description { get; set; }
    }
}
