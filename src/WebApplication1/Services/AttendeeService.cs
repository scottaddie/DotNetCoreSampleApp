using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AttendeeService : IAttendeeService
    {
        public List<Session> GetSessions() => 
            new List<Session>() {
                new Session {
                    TimeSlot = new TimeSpan(1, 9, 30, 0),
                    Title = "From Legacy MVC to Modern MVC: An ASP.NET Core Migration Path",
                    Track = Track.Web
                },
                new Session
                {
                    TimeSlot = new TimeSpan(1, 10, 45, 0),
                    Title = "Getting Started with ASP.NET Core in VS Code",
                    Track = Track.Web
                }
            };
    }
}
