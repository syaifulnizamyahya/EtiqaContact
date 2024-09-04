using EtiqaContact.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EtiqaContact.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Contact> Contacts { get; set; }
}
