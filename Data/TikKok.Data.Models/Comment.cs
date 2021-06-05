namespace TikKok.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TikKok.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int VideoId { get; set; }

        public virtual Video Video { get; set; }

        public string CommentText { get; set; }

    }
}
