using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Response> Responses { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Chat - Company (Many-to-One)
        modelBuilder.Entity<Chat>()
            .HasOne(c => c.Company)
            .WithMany(company => company.Chats)
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // Chat - User (Many-to-One)
        modelBuilder.Entity<Chat>()
            .HasOne(c => c.User)
            .WithMany(user => user.Chats)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Chat - Message (One-to-Many)
        modelBuilder.Entity<Chat>()
            .HasMany(c => c.Messages)
            .WithOne(m => m.Chat)
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        // Request - User (Many-to-One)
        modelBuilder.Entity<Request>()
            .HasOne(r => r.User)
            .WithMany(user => user.Requests)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Response - Team (One-to-One)
        modelBuilder.Entity<Response>()
            .HasOne(r => r.OfferedTeam)
            .WithOne()
            .HasForeignKey<Team>(t => t.ResponseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Response - Company (Many-to-One)
        modelBuilder.Entity<Response>()
            .HasOne(r => r.Company)
            .WithMany(company => company.Responses)
            .HasForeignKey(r => r.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // Response - Request (Many-to-One)
        modelBuilder.Entity<Response>()
            .HasOne(r => r.Request)
            .WithMany(req => req.Response)
            .HasForeignKey(r => r.RequestId)
            .OnDelete(DeleteBehavior.Restrict);

        // Response - Reservation (One-to-One)
        modelBuilder.Entity<Response>()
            .HasOne(r => r.Reservation)
            .WithOne(reservation => reservation.Response)
            .HasForeignKey<Reservation>(r => r.ResponseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}