using System;
using System.Collections.Generic;

namespace Radiant.Business.Models
{
    public partial class Dates
    {
        public int DateDimId { get; set; }
        public DateTime DateActual { get; set; }
        public long Epoch { get; set; }
        public string DaySuffix { get; set; }
        public string DayName { get; set; }
        public int DayOfWeek { get; set; }
        public int DayOfMonth { get; set; }
        public int DayOfQuarter { get; set; }
        public int DayOfYear { get; set; }
        public int WeekOfMonth { get; set; }
        public int WeekOfYear { get; set; }
        public string WeekOfYearIso { get; set; }
        public int MonthActual { get; set; }
        public string MonthName { get; set; }
        public string MonthNameAbbreviated { get; set; }
        public int QuarterActual { get; set; }
        public string QuarterName { get; set; }
        public int YearActual { get; set; }
        public DateTime FirstDayOfWeek { get; set; }
        public DateTime LastDayOfWeek { get; set; }
        public DateTime FirstDayOfMonth { get; set; }
        public DateTime LastDayOfMonth { get; set; }
        public DateTime FirstDayOfQuarter { get; set; }
        public DateTime LastDayOfQuarter { get; set; }
        public DateTime FirstDayOfYear { get; set; }
        public DateTime LastDayOfYear { get; set; }
        public string Mmyyyy { get; set; }
        public string Mmddyyyy { get; set; }
        public bool WeekendIndr { get; set; }
    }
}
