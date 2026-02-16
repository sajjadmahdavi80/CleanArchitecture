using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Abstractions.UnitOfWork.Query;
using Application.Users.DTOs;
using MediatR;

namespace Application.Users.Queries;

public sealed record GetUserByUsernameQuery : IRequest<BasicUserInformationDTO>
{
    public string Username { get; set; }
}
public sealed record GetUserByUsernameQueryHandler(IQueryUnitOfWork UnitOfWork) : IRequestHandler<GetUserByUsernameQuery, BasicUserInformationDTO>
{

    public async Task<BasicUserInformationDTO> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        return await UnitOfWork.User.FirstOrDefaultAsync(f => f.FullName == request.Username, f => new BasicUserInformationDTO { FullName = f.FullName, Status = f.Status });
    }
}
