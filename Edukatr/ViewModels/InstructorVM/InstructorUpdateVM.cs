using Edukatr.Models;

namespace Edukatr.ViewModels.InstructorVM
{
    public class InstructorUpdateVM
    {
        
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        
        public int PositionId { get; set; }
    }
}
