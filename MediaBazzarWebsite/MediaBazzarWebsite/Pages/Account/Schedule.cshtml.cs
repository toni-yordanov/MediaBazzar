using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediaBazzarWebsite.Pages.Account
{
    [Authorize]
    public class ScheduleModel : PageModel
    {
        [BindProperty]
        public SelectList WeekSL { get; set; }
        [BindProperty]
        public List<int> Weeks { get; set; }
        [BindProperty]
        public List<string> Shifts { get; set; }
        [BindProperty]
        public Dictionary<int, string> Keys { get; set; }

        public ScheduleModel()
        {
            Shifts = new List<string>();
            Weeks = new List<int>();
            for (int i = 5; i < 1; i--)
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar calendar = dfi.Calendar;
                DateTime day = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday - 7 * i);
                Weeks.Add(calendar.GetWeekOfYear(day, dfi.CalendarWeekRule, dfi.FirstDayOfWeek));
            }

            Keys = new Dictionary<int, string>();

            Keys.Add(0, "Monday - Morning" );
            Keys.Add(1, "Monday - Afternoon");
            Keys.Add(2, "Monday - Evening");
            Keys.Add(3, "Tuesday - Morning");
            Keys.Add(4, "Tuesday - Afternoon");
            Keys.Add(5, "Tuesday - Evening");
            Keys.Add(6, "Wednesday - Morning");
            Keys.Add(7, "Wednesday - Afternoon");
            Keys.Add(8, "Wednesday - Evening");
            Keys.Add(9, "Thursday - Morning");
            Keys.Add(10, "Thursday - Afternoon");
            Keys.Add(11, "Thursday - Evening");
            Keys.Add(12, "Friday - Morning");
            Keys.Add(13, "Friday - Afternoon");
            Keys.Add(14, "Friday - Evening");
            Keys.Add(15, "Saturday - Morning");
            Keys.Add(16, "Saturday - Afternoon");
            Keys.Add(17, "Saturday - Evening");
            Keys.Add(18, "Sunday - Morning");
            Keys.Add(19, "Sunday - Afternoon");
            Keys.Add(20, "Sunday - Evening");



        }
        public void OnGet()
        {
            /*Data.DataHelper dh = new Data.DataHelper();
            try
            {
                foreach (var employee in dh.GetEmployees())
                {
                    if (employee.Email.Equals(User.Identity.Name))
                    {
                        foreach (var v in employee.Shifts)
                        {
                            string[] id = v.ToString().Split('-'); 
                            Shifts.Add(id[2].Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }*/
        }
    }
}
