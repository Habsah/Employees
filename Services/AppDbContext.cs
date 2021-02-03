using System;
using Microsoft.EntityFrameworkCore;

namespace Employees.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}