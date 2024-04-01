using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement_Blazor.Data.Entities
{
    public class Booking
    {
        [Key]   
        public long Id { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        [Required]
        public string GuestId { get; set; }
        public virtual ApplicationUser Guest { get; set; }

        public int Adults { get; set; }
        public int Children { get; set; }


        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate
        {
            get; set;

        }

        [Range(1, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        public DateTime BookOn {  get; set; }

        [MaxLength(150), Unicode(false)]
        public string? Remarks { get; set; }

    }
}
