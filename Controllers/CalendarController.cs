using System;
using MenuPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MenuPlanner.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ILogger<CalendarController> _logger;

        public CalendarController(ILogger<CalendarController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var calendarViewModel = new CalendarViewModel();
            calendarViewModel.BuildCalendar(startDate.Month, startDate.Year);
            return View(calendarViewModel);
        }
    }
}