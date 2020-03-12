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
             => date.DayOfYear % 7 > 0 
                 ? date.DayOfYear / 7 + 1
                 : date.DayOfYear / 7;
     }
}