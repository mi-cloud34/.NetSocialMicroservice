using Comment.WepAPI.Model;
using Comment.WepAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Comment.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController:CustomBaseController
    {
        private readonly ICommentService _commentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CommentsController(ICommentService commentService,IHttpContextAccessor httpContextAccessor)
        {
            _commentService = commentService;
             _httpContextAccessor = httpContextAccessor;
    }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return CreateActionResultInstance(await _commentService.GetAll());
        }

        [HttpPost]
        [Authorize()]
        public async Task<IActionResult> SaveOrUpdateBasket(Comments comment)
        {
            comment.UserUd = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var response = await _commentService.Save(comment);

            return CreateActionResultInstance(response);
        }

        [HttpDelete]
        [Authorize()]
        public async Task<IActionResult> DeleteBasket(int id)

        {
            return CreateActionResultInstance(await _commentService.Delete(id));
        }
        [HttpGet("getbyuserId")]
        public async Task<IActionResult> GetCommentByUserId()
        {
            int id = Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var response= await _commentService.GetByCommentUserId(id);
            return CreateActionResultInstance(response);
        }
    }
}
