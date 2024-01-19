namespace Edukatr.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Position? Positions { get; set; }
        public int PositionId { get; set; }
    }
}
