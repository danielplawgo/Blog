using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateService.Services
{
    public interface IDateService
    {
        DateTime Now { get; }

        DateTime UtcNow { get; }
    }
}
