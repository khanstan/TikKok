namespace TikKok.Data.Models
{
    public class VideoTag
    {
        public int Id { get; set; }

        public int VideoId { get; set; }

        public virtual Post Video { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}