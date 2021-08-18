namespace TikKok.Data.Models
{
    using TikKok.Data.Common.Models;

    public class Like : BaseModel<int>
    {
        public string PostId { get; set; }

        public virtual Post Post { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
