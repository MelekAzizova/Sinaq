namespace TempData.Models
{
    public class MediaTeam
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public SosialMedia? SosialMedia { get; set; }
    }
}
