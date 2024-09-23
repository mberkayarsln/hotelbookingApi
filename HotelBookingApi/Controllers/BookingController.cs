using HotelBookingApi.Data;
using HotelBookingApi.Identity;
using HotelBookingApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BookingController : Controller
{
    private readonly ApiDbContext _context;

    public BookingController(ApiDbContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet]
    public JsonResult Get(int id)
    {
        var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);

        if (booking == null)
        {
            return Json(NotFound());
        }

        return Json(Ok(booking));
    }

    [Authorize]
    [HttpGet]
    public JsonResult GetAll()
    {
        var bookings = _context.Bookings.ToList();
        return Json(Ok(bookings));
    }

    [Authorize(IdentityData.AdminUserPolicyName)]
    [HttpPost]
    public JsonResult Post(Booking booking)
    {
        _context.Bookings.Add(booking);
        _context.SaveChanges();
        return Json(Ok(booking));
    }

    [Authorize(IdentityData.AdminUserPolicyName)]
    [HttpPut]
    public JsonResult Put(Booking booking)
    {
        _context.Bookings.Update(booking);
        _context.SaveChanges();
        return Json(Ok(booking));
    }

    [Authorize(IdentityData.AdminUserPolicyName)]
    [HttpDelete]
    public JsonResult Delete(int id)
    {
        var booking = _context.Bookings.FirstOrDefault(b => b.Id == id);

        if (booking == null)
        {
            return Json(NotFound());
        }

        _context.Bookings.Remove(booking);
        _context.SaveChanges();
        return Json(NoContent());
    }
}