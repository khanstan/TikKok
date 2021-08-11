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

        public IActionResult Test(CommentsViewModel model)
        {
            var postId = "66ed34d2-dd76-4316-9bd2-fe783d0aad18";
            var viewModel = this.commentsService.GetAll(postId);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CommentsViewModel>> AddNewComment([FromBody] CommentsInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //var deserialized = Newtonsoft.Json.Linq.JObject.Parse(input);

            var model = await this.commentsService.AddComment(input, userId);

            return model;
        }
    }
}
