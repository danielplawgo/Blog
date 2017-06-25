using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DateService.Services
{
    public class DateService : IDateService
    {
        private TimeSpan _offset = new TimeSpan();

        public DateTime Now
        {
            get
            {
                return DateTime.Now + _offset;
            }
        }

        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow + _offset;
            }
        }

        public void SetNow(DateTime date)
        {
            _offset = date - DateTime.Now;
        }

        public void Reset()
        {
            _offset = new TimeSpan();
        }
    }
}