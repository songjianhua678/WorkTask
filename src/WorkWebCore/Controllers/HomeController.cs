using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkWebCore.Models;

namespace WorkWebCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {          
            return View();
        }

        public JsonResult SaveAdd(string WorkName, int WorkProcess, int WorkLevel, string WorkMark, DateTime StartTime, DateTime EndTime)
        {
            string result = "";
            try
            {
                using (var DB = new WorkRecordsContext())
                {
                    var entry = new WorkRecords() { WorkName = WorkName, WorkProcss = WorkProcess, WorkLevel = WorkLevel, WorkMark = WorkMark, StartTime = StartTime, EndTime = EndTime };
                    DB.WorkRecords.Add(entry);
                    DB.SaveChanges();
                    result = "0"; //成功
                }
            }
            catch (Exception ex)
            {
                result = "1";//失败
            }

            return Json(result);
        }
    }
}
