using Application.Common.Abstractions.UnitOfWork.Commands;
using Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class UserController(IMediator mediator) : BaseController(mediator)
{


    [HttpGet]
    public async Task<IActionResult> GetUser(string userName)
    {
        return Ok(await mediator.Send(new GetUserByUsernameQuery { Username = userName }));
    }

    //[HttpGet]
    //public async Task<IActionResult> GetUserById(int id)
    //{
    //    return Ok(await unitOfWork.User.GetById(id));
    //}

    //[HttpGet]
    //public async Task<IActionResult> UpdateUser(int id)
    //{
    //    return Ok(await unitOfWork.User.GetById(id));
}
