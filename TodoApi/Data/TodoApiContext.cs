using System;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Data
{

    public class TodoApiContext : DbContext
    {

        public TodoApiContext(DbContextOptions<TodoApiContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ManyToManyRelationshipConfiguration(modelBuilder);
        }


        private void ManyToManyRelationshipConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Has_Job>()
                .HasKey(t => new { t.UserId, t.JobId });

            modelBuilder.Entity<User_Has_Job>()
                .HasOne(am => am.job)
                .WithMany(a => a.user_Has_jobs)
                .HasForeignKey(am => am.JobId);

            modelBuilder.Entity<User_Has_Job>()
                .HasOne(am => am.user)
                .WithMany(m => m.user_Has_jobs)
                .HasForeignKey(am => am.UserId);
        }


        public DbSet<User> users { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<User_Has_Job> user_Has_jobs{ get; set; }

    }




}
