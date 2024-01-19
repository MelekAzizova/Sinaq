namespace TempData.Models
{
    public class SosialMedia
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public ICollection<MediaTeam>? MediaTeams { get; set; }
    }
}
