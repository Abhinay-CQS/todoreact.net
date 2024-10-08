﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Models.ApplicationDbContext
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ToDoList> Lists { get; set; }

        public DbSet<ListUser> ListUser { get; set; }
        public DbSet<Stage> Stages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoList>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Stage>()
            .HasOne(e => e.List)
            .WithMany(e => e.Stages)
            .HasForeignKey(e => e.ListId);
            modelBuilder.Entity<Stage>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<ToDoList>()
                .HasOne(m => m.CreatedBy)
                .WithMany(u => u.ToDoLists)
                .HasForeignKey(m => m.CreatedById);

            modelBuilder.Entity<ListUser>()
                .HasKey(ls => new { ls.ToDoListId, ls.UserId });

            modelBuilder.Entity<ListUser>()
                .HasOne(e => e.User)
                .WithMany(e => e.ListUsers)
                .HasForeignKey(e => e.UserId);
            modelBuilder.Entity<ListUser>()
                .HasOne(e => e.ToDoList)
                .WithMany(e => e.ListUsers)
                .HasForeignKey(e => e.ToDoListId);

        }
    }
}
