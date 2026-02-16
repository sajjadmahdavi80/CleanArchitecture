using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Abstractions.Contexts.Commands;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.RelationalDbs.Commands;

internal sealed class CommandDbContext(DbContextOptions<CommandDbContext> options) : DbContext(options), ICommandDbContext
{
    public DbSet<User> Users { get; set; }
}
