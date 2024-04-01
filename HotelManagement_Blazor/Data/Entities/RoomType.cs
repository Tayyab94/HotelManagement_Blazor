using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_Blazor.Data.Entities
{
    public class RoomType
    {
        public short Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MinLength(250)]
        public string Iamge { get; set; }
        [Required, Range(1, double.MaxValue)]
        public decimal Price { get; set; }
        [Required, MaxLength(250)]
        public string Description { get; set; }

        public int MaxAdults {  get; set; }
        public int MaxChildren {  get; set; }   


        public bool IsActive { get; set; }
        public DateTime AddedOn { get; set; }

        [Required]
        public string AddedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }

        [ForeignKey(nameof(AddedBy))]
        public virtual ApplicationUser AddedByUser { get; set; }

        public ICollection<RoomTypeAmenity> Amenities { get; set; }

        public ICollection<Room>Rooms { get; set; }
    }
}
