using System;

namespace Quantum.Core
{
    public interface IDateTimeProvider
    {
        DateTimeOffset UtcDateTimeNow();
        DateTimeOffset Yesterday();
        DateTimeOffset Friday();
        DateTimeOffset OneWeekFromNow();
        (short PersianYear, short PersianMonth) PersianYearMonth();
    }
}