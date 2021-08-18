namespace TikKok.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TikKok.Data.Common.Models;

    public class Post : BaseDeletableModel<string>
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
            this.Likes = new HashSet<Like>();
        }

        public string VideoId { get; set; }

        public virtual Video Video { get; set; }

        [MaxLength(1024)]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
