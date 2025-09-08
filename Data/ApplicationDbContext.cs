// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using StationNavigation.Models;

namespace StationNavigation.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Station> Stations { get; set; }
        public DbSet<Location> Locations { get; set; }
	public DbSet<SearchHistory> SearchHistories { get; set; }
        public DbSet<RouteImage> RouteImages { get; set; }

	public DbSet<StationFloor> StationFloors { get; set; }
	public DbSet<StationFacility> StationFacilities { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Station 설정
            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Region).HasMaxLength(50);
                entity.HasMany(e => e.Locations)
                      .WithOne(e => e.Station)
                      .HasForeignKey(e => e.StationId);
            });

            // Location 설정
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Category).HasMaxLength(50);
            });

            // RouteImage 설정
            modelBuilder.Entity<RouteImage>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ImagePath).HasMaxLength(500);
                entity.Property(e => e.Description).HasMaxLength(200);
                
                entity.HasOne(e => e.FromLocation)
                      .WithMany()
                      .HasForeignKey(e => e.FromLocationId)
                      .OnDelete(DeleteBehavior.Restrict);
                      
                entity.HasOne(e => e.ToLocation)
                      .WithMany()
                      .HasForeignKey(e => e.ToLocationId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

	    modelBuilder.Entity<StationFloor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FloorName).HasMaxLength(50);
                entity.Property(e => e.FloorPlanImagePath).HasMaxLength(255);

                entity.HasOne(e => e.Station)
                      .WithMany()
                      .HasForeignKey(e => e.StationId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

modelBuilder.Entity<StationFacility>(entity =>
{
    entity.HasKey(e => e.Id);
    entity.Property(e => e.FacilityType).HasMaxLength(50);
    entity.Property(e => e.Name).HasMaxLength(100);
    entity.Property(e => e.Location).HasMaxLength(100);
    
    entity.HasOne(e => e.Station)
          .WithMany()
          .HasForeignKey(e => e.StationId)
          .OnDelete(DeleteBehavior.Cascade);
});

        }
    }
}
