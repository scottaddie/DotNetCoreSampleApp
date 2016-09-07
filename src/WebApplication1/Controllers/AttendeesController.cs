using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly IAttendeeService _attendeeService;
        private readonly IConfiguration _configuration;
        private readonly Attendee _attendee;

        public AttendeesController(IAttendeeService attendeeService,
                                   IOptions<Attendee> attendee,
                                   IConfiguration configuration)
        {
            _attendeeService = attendeeService;

            // APP SETTINGS APPROACH 1: strongly-typed IOptions<T>
            _attendee = attendee.Value;

            // APP SETTINGS APPROACH 2: IConfiguration.GetValue
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // APP SETTINGS APPROACH 1: strongly-typed IOptions<T>
            var firstName = _attendee.FirstName;

            // APP SETTINGS APPROACH 2: IConfiguration.GetValue
            //var firstName = _configuration.GetValue<string>("AttendeeInfo:FirstName");

            ViewBag.FirstName = firstName;

            var sessionList = _attendeeService.GetSessions();

            return View(sessionList);
        }
    }
}
