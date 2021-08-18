namespace TikKok.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TikKok.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(1024)]
        public string CommentText { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        // public string Username { get; set; }
        public DateTime CommentDate { get; set; }

        [Required]
        public int ParentId { get; set; }

        [Required]
        public string PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}