using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace flamingoflights.Models
{
  public class Flight
  {
    [Key] 
    public int FlightId { get; set; } 

    [Required]
    public string FlightNumber { get; set; } = string.Empty;

    [Required]
    public string Origin { get; set; } = string.Empty;

    [Required]
    public string Destination { get; set; } = string.Empty;

    public DateTime TravelDate { get; set; }

    public int AvailableSeats { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

  }
}
