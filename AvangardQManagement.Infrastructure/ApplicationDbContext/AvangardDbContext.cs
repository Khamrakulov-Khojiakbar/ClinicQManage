using AvangardQManagement.Application.Common.Interfaces;
using AvangardQManagement.Domain.Auth;
using AvangardQManagement.Domain.Enums;
using AvangardQManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvangardQManagement.Infrastructure.ApplicationDbContext;

public class AvangardDbContext : DbContext, IUnitOfWork
{

    public AvangardDbContext(DbContextOptions<AvangardDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }


    public DbSet<Reception> Receptions { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Reception>().ToTable("receptions");
        modelBuilder.Entity<Room>().ToTable("tables");
        modelBuilder.Entity<Ticket>().ToTable("tickets");

        
        modelBuilder.Entity<RolePermission>()
            .HasKey(rp => new {rp.RoleId, rp.PermissionId});

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Role)
            .WithMany(rp => rp.RolePermissions)
            .HasForeignKey(rp => rp.RoleId);

        modelBuilder.Entity<RolePermission>()
            .HasOne(rp => rp.Permission)
            .WithMany(rp => rp.RolePermissions)
            .HasForeignKey(rp => rp.PermissionId);


        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(ur => ur.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(ur => ur.UserRoles)
            .HasForeignKey(ur => ur.RoleId);


        modelBuilder.Entity<User>()
            .HasOne(u => u.Room)
            .WithMany(u => u.Users)
            .HasForeignKey(r => r.RoomId)
            .OnDelete(DeleteBehavior.SetNull);


        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Reception)
            .WithMany()
            .HasForeignKey(t => t.ReceptionId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tickets)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ticket>()
            .Property(t => t.Status)
            .HasConversion<string>();


    }
}
