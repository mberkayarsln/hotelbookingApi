using System.ComponentModel.DataAnnotations;

namespace HotelBookingApi.Models;

public class Booking
{
    [Key] public int Id { get; set; }
    [Required] public int RoomNumber { get; set; }
    [Required] [MaxLength(50)] public string? CustomerName { get; set; }
}