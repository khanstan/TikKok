namespace TikKok.Data.Common.Models
{
    using System;

    public interface IDeletableEntityRepository
    {
        bool IsDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
