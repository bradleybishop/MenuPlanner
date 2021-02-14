using System;
using System.Collections.Generic;
using System.Linq;

namespace MenuPlanner.Models
{
    public class CalendarViewModel
    {
        public List<CalendarWeekViewModel> Weeks { get; set; }
        public CalendarViewModel()
        {
            Weeks = new List<CalendarWeekViewModel>();
        }

        public void BuildCalendar(int month, int year)
        {
            var startDate = new DateTime(year, month, 1);
            var endOfMonth = startDate.AddMonths(1).AddDays(-1);
            var startWeekDay = (int)(startDate.DayOfWeek);

            var currentDate = startDate;

           Weeks.Add(new CalendarWeekViewModel());
            for (DateTime i = startDate; i <= endOfMonth; i = i.AddDays(1))
            {
                var DayOfWeek = (int)(i.DayOfWeek);
                if (DayOfWeek == 0 && i.Day != 1)
                {
                    Weeks.Add(new CalendarWeekViewModel());
                }
            Weeks.Last().Days[DayOfWeek].Date = i.Day;
        }
    }


}

public class CalendarWeekViewModel
{
    public List<CalendarDayViewModel> Days { get; set; }

    public CalendarWeekViewModel()
    {
        Days = new List<CalendarDayViewModel>() {
                new CalendarDayViewModel(),
                new CalendarDayViewModel(),
                new CalendarDayViewModel(),
                new CalendarDayViewModel(),
                new CalendarDayViewModel(),
                new CalendarDayViewModel(),
                new CalendarDayViewModel()
            };
    }
}

public class CalendarDayViewModel
{
    public bool IsFilled { get; set; }
    private int _date;
    public int Date
    {
        get => _date;
        set
        {
            _date = value;
            IsFilled = true;
        }
    }
}
}