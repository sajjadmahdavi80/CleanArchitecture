using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Abstractions.Contexts.Commands;
using Application.Users.Repositories.Commands;
using Domain.Entities.Users;

namespace Infrastructure.Repository.RelationalDbs.Commands.Users;

internal sealed class CommandUserRepository(CommandDbContext context) : CommandGenericRepository<User>(context), ICommandUserRepository
{
}
