using System;
using System.Collections.Generic;

namespace EventPlanner.Data
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? EventDate { get; set; }
    }
}
