using _2_gt4.Application.Common.Interfaces;
using System;

namespace _2_gt4.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
