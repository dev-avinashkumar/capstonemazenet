using flamingoflights.Data;
using flamingoflights.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace flamingoflights.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FlightsController : ControllerBase
  {
    private readonly FlightContext _context;

    public FlightsController(FlightContext context)
    {
      _context = context;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchFlights(string origin, string destination, DateTime date)
    {
      var flights = await _context.Flights
          .Where(f => f.Origin == origin && f.Destination == destination && f.TravelDate.Date == date.Date)
          .ToListAsync();

      if (flights == null || flights.Count == 0)
      {
        return NotFound("No flights found for the selected route and date.");
      }

      return Ok(flights);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllFlights()
    {
      var flights = await _context.Flights.ToListAsync();
      return Ok(flights);
    }
  }
}
