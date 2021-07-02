namespace TikKok.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using TikKok.Data.Common.Models;

    public class Video : BaseDeletableModel<string>
    {
        public Video()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UploaderId { get; set; }

        public virtual ApplicationUser Uploader { get; set; }

        public TimeSpan Duration { get; set; }

        public int Size { get; set; }

        public string Extension { get; set; }

        public string Path { get; set; }

    }
}
