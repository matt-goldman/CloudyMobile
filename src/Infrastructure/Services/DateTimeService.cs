using CloudyMobile.Application.Common.Interfaces;
using System;

namespace CloudyMobile.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
