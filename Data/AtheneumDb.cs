using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practice.Models;


namespace Practice.Data
{

    public class AtheneumDb: DbContext
    {

        public AtheneumDb(DbContextOptions<AtheneumDb> options): base(options) {

        }
        public DbSet<Atheneum> Atheneums => Set<Atheneum>();
protected override void OnModelCreating(ModelBuilder modelBuilder)
    => modelBuilder.Entity<Atheneum>().Property(a => a.id).UseIdentityAlwaysColumn();
     


    }



}