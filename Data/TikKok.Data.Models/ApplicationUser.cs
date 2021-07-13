// ReSharper disable VirtualMemberCallInConstructor
namespace TikKok.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using TikKok.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntityRepository
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Posts = new HashSet<Post>();
            this.Likes = new HashSet<Like>();
        }

        // Audit info
        public string CredentialUsername { get; set; }

        public string Avatar { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<UserFollow> Following { get; set; }

        public virtual ICollection<UserFollow> Followers { get; set; }

        public virtual ICollection<UserBlock> BlockedUsers { get; set; }

    }
}
