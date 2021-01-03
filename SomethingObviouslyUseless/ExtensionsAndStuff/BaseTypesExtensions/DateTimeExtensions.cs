using System;

namespace ExtensionsAndStuff.BaseTypesExtensions
{
     public static class DateTimeExtensions
     {
         public static DateTime GetMonday(this DateTime date)
             => date.AddDays(-(date.DayOfWeek == DayOfWeek.Sunday
                 ? 6
                 : (int)date.DayOfWeek - 1));
         
         public static int Week(this DateTime date)
         {
             var div = Math.DivRem(date.DayOfYear, 7, out var rem);
             return rem > 0
                 ? div + 1
                 : div;
         }

         public static TimeSpan Time(this DateTime date)
             => date - date.Date;
     }
}