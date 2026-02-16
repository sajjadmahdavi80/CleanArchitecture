using Application.Common.Abstractions.Contexts.Queries;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.RelationalDbs.Queries;

internal class QueryDbContext(DbContextOptions dbContext) : DbContext(dbContext), IQueryDbContext
{
    public DbSet<User> Users { get; set; }
}
