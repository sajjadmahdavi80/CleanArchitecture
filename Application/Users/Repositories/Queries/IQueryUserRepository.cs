using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Abstractions.Repository.Queries;
using Domain.Entities.Users;

namespace Application.Users.Repositories.Queries;

public interface IQueryUserRepository : IQueryGenericRepository<User>
{
}
