namespace TikKok.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    using TikKok.Data.Models;

    public class CommentsViewModel
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public int ParentId { get; set; }

        public string CommentDate { get; set; }

        public ApplicationUser User { get; set; }

        public int ChildCommentsCount { get; set; }

        public IEnumerable<Comment> ChildComments { get; set; }
    }
}
