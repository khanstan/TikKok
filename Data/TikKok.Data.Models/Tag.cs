namespace TikKok.Data.Models
{
    using System.Collections.Generic;
    using TikKok.Data.Common.Models;

    public class Tag : BaseDeletableModel<int>
    {
        public Tag()
        {
            this.Videos = new HashSet<VideoTag>();
        }

        public string Name { get; set; }

        public ICollection<VideoTag> Videos { get; set; }
    }
}
