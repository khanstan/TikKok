using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TikKok.Services.Data;
using TikKok.Web.ViewModels.Likes;

namespace TikKok.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : BaseController
    {
        private readonly ILikesService likesService;

        public LikesController(ILikesService likesService)
        {
            this.likesService = likesService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<LikeResponseModel>> Like(LikeInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.likesService.SetLikeAsync(input.PostId, userId);
            var totalVotes = this.likesService.GetTotalLikes(input.PostId);
            return new LikeResponseModel { TotalLikes = totalVotes };
        }
    }
}
