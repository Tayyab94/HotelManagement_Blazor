using HotelManagement_Blazor.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_Blazor.Data
{
    //public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    //{
    //}

    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }


        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomTypeAmenity> RoomTypeAmenities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Amenity> Amenities { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Model Configuration

            builder.Entity<RoomTypeAmenity>()
                .HasKey(ra => new { ra.RoomTypeId, ra.AmenityId });

            //builder.Entity<Room>().HasOne(e => e.RoomType).WithMany().HasForeignKey(s => s.RoomTypeId)
            //    .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder.Entity<RoomType>()
                .HasMany(s => s.Rooms).WithOne(r=>r.RoomType)
                .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
       
        }
    }
}
