using EtiqaContact.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EtiqaContact.Infrastructure.Data;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }
    public DbSet<Contact> Contacts { get; set; }
}
