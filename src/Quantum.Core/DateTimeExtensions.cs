using System;

namespace Quantum.Core;

public static class DateTimeExtensions
{
    public static bool IsAfterDate(this DateTime firstDate, DateTime secondDate)
        => firstDate > secondDate;

    public static bool IsBeforeOrEqualDate(this DateTime firstDate, DateTime secondDate)
        => firstDate <= secondDate;
}