using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkWebCore.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkWebCore.Controllers
{
    public class RecordController : Controller
    {
        int PageSize = 10;
        
        public IActionResult Index(int page = 1)
        {
            try
            {
                using (var DB = new WorkRecordsContext())
                {
                    ViewBag.Record = DB.WorkRecords.ToList().Skip((page - 1) * PageSize).Take(PageSize).ToList(); ;
                    ViewBag.PageHtml = PageingHtml.GetPagingHTML(DB.WorkRecords.ToList().Count, PageSize, page, "turnPage(1Index1)", 5, 2);
                }
            }
            catch (Exception ex)
            {
                //写日志记录错误
            }
            return View();
        }
    }
}
