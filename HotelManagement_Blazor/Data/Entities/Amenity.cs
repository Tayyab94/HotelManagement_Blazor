using System.ComponentModel.DataAnnotations;

namespace HotelManagement_Blazor.Data.Entities
{
    public class Amenity
    {
        [Key]   
        public int Id { get; set; }
        [Required,MaxLength(25)]
        public string Name { get; set; }
        [Required, MaxLength(35)]
        public string Icon { get; set; }
    }
}
