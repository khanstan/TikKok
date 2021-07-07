namespace TikKok.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using TikKok.Data.Common.Models;

    public class UserBlock : BaseModel<int>
    {
        [ForeignKey(nameof(SourceUserId))]
        public ApplicationUser SourceUser { get; set; }

        public string SourceUserId { get; set; }

        [ForeignKey(nameof(BlockedUserId))]
        public ApplicationUser BlockedUser { get; set; }

        public string BlockedUserId { get; set; }
    }
}
