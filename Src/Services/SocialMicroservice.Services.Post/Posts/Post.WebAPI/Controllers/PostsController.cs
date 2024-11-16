using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Post.Application.Features.Posts.Commands.CreatedPost;
using Post.Application.Features.Posts.Commands.DeletePostCommand;
using Post.Application.Features.Posts.Commands.UpdatedPostCommand;
using Post.Application.Features.Posts.Dtos;
using Post.Application.Features.Posts.Model;
using Post.Application.Features.Posts.Queries.GetByIdPostQuery;
using Post.Application.Features.Posts.Queries.GetListPostQuery;
namespace Post.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdPostQuery getByIdPostQuery)
    {
        PostDto result = await Mediator.Send(getByIdPostQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListPostQuery getListPostQuery)
    {
        PostListModel allUsers = await Mediator.Send(getListPostQuery);
        return Ok(allUsers);
    }

    [HttpPost]
    [Authorize()]
    public async Task<IActionResult> Add([FromBody] CreatePostCommand createPostCommand)
    {
        createPostCommand.Files = (IFormFile?)Request.Form.Files;
        CreatedPostDto result = await Mediator.Send(createPostCommand);
        return Created("", result);
    }

    [HttpPut]
    [Authorize()]
    public async Task<IActionResult> Update([FromBody] UpdatedPostCommand updatePostCommand)
    {
        UpdatePostDto result = await Mediator.Send(updatePostCommand);
        return Ok(result);
    }

    [HttpDelete]
    [Authorize()]
    public async Task<IActionResult> Delete([FromBody] DeletePostCommand deletePostCommand)
    {
        DeletedPostDto result = await Mediator.Send(deletePostCommand);
        return Ok(result);
    }
}