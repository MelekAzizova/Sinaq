using Edukatr.Models;

namespace Edukatr.ViewModels.InstructorVM
{
    public class InstructorCreateVM
    {
      
        public string Name { get; set; }
        public IFormFile Image { get; set; }
      
        public int PositionId { get; set; }
    }
}
