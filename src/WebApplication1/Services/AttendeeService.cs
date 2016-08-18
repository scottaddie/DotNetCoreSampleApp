using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AttendeeService : IAttendeeService
    {
        public List<Session> GetSessions() => 
            new List<Session>() {
                new Session {
                    SeatsAvailable = 5,
                    Title = "From Legacy MVC to Modern MVC: An ASP.NET Core Migration Path"
                },
                new Session
                {
                    SeatsAvailable = 2,
                    Title = "Getting Started with ASP.NET Core in VS Code"
                }
            };
    }
}
