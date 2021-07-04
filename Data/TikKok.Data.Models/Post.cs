namespace TikKok.Data.Models
{
    using System;
    using System.Collections.Generic;

    using TikKok.Data.Common.Models;

    public class Post : BaseDeletableModel<string>
    {
        public Post()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
            this.Tags = new HashSet<Tag>();
            this.Likes = new HashSet<Like>();
        }

        public string VideoId { get; set; }

        public virtual Video Video { get; set; }

        public string Description { get; set; }

        public int Shares { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
