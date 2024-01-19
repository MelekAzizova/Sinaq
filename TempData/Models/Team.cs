namespace TempData.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public ICollection<MediaTeam>? MediaTeams { get; set; }
    }
}
