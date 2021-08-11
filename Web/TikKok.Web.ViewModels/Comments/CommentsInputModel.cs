namespace TikKok.Web.ViewModels.Comments
{
    public class CommentsInputModel
    {
        public int ParentId { get; set; }

        public string CommentText { get; set; }

        public string PostId { get; set; }
    }
}
