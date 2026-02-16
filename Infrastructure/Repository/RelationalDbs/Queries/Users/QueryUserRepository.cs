using System;
using System.Collections.Generic;
using System.Text;
using Application.Users.Repositories.Queries;
using Domain.Entities.Users;
using Infrastructure.Repository.RelationalDbs.Commands;

namespace Infrastructure.Repository.RelationalDbs.Queries.Users;

internal sealed class QueryUserRepository(QueryDbContext context) : QueryGenericRepository<User>(context), IQueryUserRepository
{
}
