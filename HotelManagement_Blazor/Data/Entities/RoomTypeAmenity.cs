namespace HotelManagement_Blazor.Data.Entities
{
    public class RoomTypeAmenity
    {
        public short RoomTypeId { get; set; }
        public int AmenityId { get; set; }

        public int? AmenityUnit { get; set; }

        public virtual RoomType RoomType { get; set; }
        public virtual Amenity Amenity { get; set; }
    }
}
