using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkWebCore.Models;
using Microsoft.AspNetCore.Authorization;

namespace WorkWebCore.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {          
            return View();
        }

        public JsonResult SaveAdd(string WorkName, int WorkProcess, int WorkLevel, string WorkMark, DateTime StartTime, DateTime EndTime,string UserName)
        {
            string result = "";
            try
            {
                using (var DB = new WorkRecordsContext())
                {
                    var entry = new WorkRecords() { WorkName = WorkName, WorkProcss = WorkProcess, WorkLevel = WorkLevel, WorkMark = WorkMark, StartTime = StartTime, EndTime = EndTime, UserName=UserName };
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
