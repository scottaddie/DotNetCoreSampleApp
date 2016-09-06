using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplication1.Models;
using WebApplication1.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApplication1.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly IAttendeeService _attendeeService;
        private Attendee _attendee;

        public AttendeesController(IAttendeeService attendeeService,
            IOptions<Attendee> attendee)
        {
            _attendeeService = attendeeService;
            _attendee = attendee.Value;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var sessionList = _attendeeService.GetSessions();

            return View(sessionList);
        }
    }
}
