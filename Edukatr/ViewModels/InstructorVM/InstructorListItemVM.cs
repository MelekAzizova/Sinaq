using Edukatr.Models;

namespace Edukatr.ViewModels.InstructorVM
{
    public class InstructorListItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Position? Positions { get; set; }
    }
}
