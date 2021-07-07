namespace TikKok.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using TikKok.Data.Common.Models;

    public class UserFollow : BaseModel<int>
    {
        [ForeignKey(nameof(SourceUserId))]
        public ApplicationUser SourceUser { get; set; }

        public string SourceUserId { get; set; }

        [ForeignKey(nameof(FollowedUserId))]
        public ApplicationUser FollowedUser { get; set; }

        public string FollowedUserId { get; set; }
    }
}
