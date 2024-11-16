
using Message.Application.Features.Messages.Dtos;
using Message.Application.Features.Messages.Models;
using Message.Application.Features.Messages.Queries.GetByIdMessage;
using Message.Application.Features.Messages.Queries.GetListMessage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Message.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdMessageQuery getByIdMessageQuery)
    {
        MessageDto result = await Mediator.Send(getByIdMessageQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetListMessageQuery getListMessageQuery)
    {
        MessageListModel allMessage = await Mediator.Send(getListMessageQuery);
        return Ok(allMessage);
    }


    [HttpDelete]
    [Authorize()]
    public async Task<IActionResult> Delete([FromBody] DeleteMessageCommand deleteMessageCommand)
    {
        DeletedMessageDto result = await Mediator.Send(deleteMessageCommand);
        return Ok(result);
    }
}