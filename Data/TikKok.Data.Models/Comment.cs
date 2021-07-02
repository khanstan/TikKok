namespace TikKok.Data.Models
{
    using TikKok.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int VideoId { get; set; }

        public virtual Post Video { get; set; }

        public string CommentText { get; set; }
    }
}
