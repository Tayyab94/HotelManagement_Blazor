using System.ComponentModel.DataAnnotations;

namespace HotelManagement_Blazor.Data.Entities
{

    public class Room
    {
        [Key]
        public int Id { get; set; }

        public short RoomTypeId { get; set; }

        [Required,MaxLength(25)]
        public string RoomNumber { get; set; }

        public bool IsAvailable { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}
