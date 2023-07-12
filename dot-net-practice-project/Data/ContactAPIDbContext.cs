using System;
using dot_net_practice_project.Models;
using Microsoft.EntityFrameworkCore;

namespace dot_net_practice_project.Data
{
    public class ContactAPIDbContext : DbContext
    {

        public ContactAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}

