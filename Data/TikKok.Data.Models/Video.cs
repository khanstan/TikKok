using System;
using System.Collections.Generic;
using System.Text;
using TikKok.Data.Common.Models;

namespace TikKok.Data.Models
{
    public class Video : BaseDeletableModel<string>
    {
        public Video()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
            this.Tags = new HashSet<Tag>();

        }

        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public int Size { get; set; }

        public string Path { get; set; }

        public string UploaderId { get; set; }

        public virtual ApplicationUser Uploader { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }


    }
}
