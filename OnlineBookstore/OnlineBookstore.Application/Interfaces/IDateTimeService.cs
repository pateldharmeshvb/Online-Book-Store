using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBookstore.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
