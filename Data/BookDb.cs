using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Data
{



        public class BookDb: DbContext
    {

        public BookDb(DbContextOptions<BookDb> options): base(options) {

        }
        public DbSet<Book> Books => Set<Book>();
protected override void OnModelCreating(ModelBuilder modelBuilder)
    => modelBuilder.Entity<Book>().Property(b => b.id).UseIdentityAlwaysColumn();
     


    }
}