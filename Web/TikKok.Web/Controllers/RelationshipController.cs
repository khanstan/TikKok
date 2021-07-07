namespace TikKok.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TikKok.Services.Data;
    using TikKok.Web.ViewModels.Relationship;

    [ApiController]
    [Route("api/[controller]")]
    public class RelationshipController : BaseController
    {
        private readonly IRelationshipService relationshipService;

        public RelationshipController(IRelationshipService relationshipService)
        {
            this.relationshipService = relationshipService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<RelationshipResponseModel>> Follow(RelationshipInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.relationshipService.SetFollowAsync(input.UserToFollow, userId);
            return this.Json("Ok");
        }
    }
}
