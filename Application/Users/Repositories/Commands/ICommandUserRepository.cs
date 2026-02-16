using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Abstractions.Repository.Commands;
using Domain.Entities.Users;

namespace Application.Users.Repositories.Commands;

public interface ICommandUserRepository : ICommandGenericRepository<User>
{
}
