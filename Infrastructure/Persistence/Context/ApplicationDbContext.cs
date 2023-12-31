﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Company> Companies { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Message> Messages { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Offer> Responses { get; set; }
    public DbSet<Review> Reviews { get; set; }
    
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}