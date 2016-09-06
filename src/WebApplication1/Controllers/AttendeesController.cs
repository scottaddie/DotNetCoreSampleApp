using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WebApplication1.Models;
using WebApplication1.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApplication1.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly IAttendeeService _attendeeService;
        private readonly IConfiguration _configuration;
        private Attendee _attendee;

        public AttendeesController(IAttendeeService attendeeService,
                                   IOptions<Attendee> attendee,
                                   IConfiguration configuration)
        {
            _attendeeService = attendeeService;

            // Option 1: strongly-typed IOptions<T> approach
            _attendee = attendee.Value;

            // Option 2: IConfiguration.GetValue approach
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var sessionList = _attendeeService.GetSessions();

            return View(sessionList);
        }

        //public string AttendeeName()
        //{
        //    var firstName = _configuration.GetValue<string>("AttendeeInfo:FirstName");
        //    var lastName = _configuration.GetValue<string>("AttendeeInfo:LastName");

        //    return $"{firstName} {lastName}";
        //}
    }
}
