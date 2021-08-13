namespace TikKok.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using TikKok.Services.Data;
    using TikKok.Web.ViewModels.Comments;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public IActionResult Index(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var postId = id;

            var viewModel = this.commentsService.GetAll(postId);
            this.ViewBag.PostId = postId;

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CommentsViewModel>> AddNewComment([FromBody] CommentsInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var model = await this.commentsService.AddComment(input, userId);

            return model;
        }
    }
}
