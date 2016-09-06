using System;

namespace WebApplication1.Models
{
    public class Session
    {
        public TimeSpan TimeSlot { get; set; }
        public string Title { get; set; }
        public Track Track { get; set; }
    }

    public enum Track
    {
        Cloud = 0,
        Mobile = 1,
        Web = 2
    }
}
