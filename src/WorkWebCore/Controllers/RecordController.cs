﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkWebCore.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkWebCore.Controllers
{
    public class RecordController : Controller
    {
        //默认一页多少条
        int PageSize = 10;

        /// <summary>
        /// 展示workrecord记录
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [Authorize]
        public IActionResult Index(int StartTime=0,int EndTime = 0, int WorkProcss=0, int WorkLevel=0,int page = 1)
        {
            try
            {
                using (var DB = new WorkRecordsContext())
                {
                    //mysql的EF入口没发现sql的执行方法，暂时先这么写
                    if (StartTime > 0)
                    {
                        if (StartTime == 1)
                        {
                            ViewBag.Record = DB.WorkRecords.ToList().OrderBy(i => i.StartTime).Skip((page - 1) * PageSize).Take(PageSize).ToList();
                        }
                        else
                        {
                            ViewBag.Record = DB.WorkRecords.ToList().OrderByDescending(i => i.StartTime).Skip((page - 1) * PageSize).Take(PageSize).ToList();
                        }
                    }
                    else if (EndTime > 0)
                    {
                        if (EndTime == 1)
                        {
                            ViewBag.Record = DB.WorkRecords.ToList().OrderBy(i => i.EndTime).Skip((page - 1) * PageSize).Take(PageSize).ToList();
                        }
                        else
                        {
                            ViewBag.Record = DB.WorkRecords.ToList().OrderByDescending(i => i.EndTime).Skip((page - 1) * PageSize).Take(PageSize).ToList();
                        }
                    }
                    else if (WorkProcss > 0)
                    {
                        if (WorkProcss == 1)
                        {
                            ViewBag.Record = DB.WorkRecords.ToList().OrderBy(i => i.WorkProcss).Skip((page - 1) * PageSize).Take(PageSize).ToList();
                        }
                        else
                        {
                            ViewBag.Record = DB.WorkRecords.ToList().OrderByDescending(i => i.WorkProcss).Skip((page - 1) * PageSize).Take(PageSize).ToList();
                        }
                    }
                    else if (WorkLevel > 0)
                    {
                        if (WorkLevel == 1)
                        {
                            ViewBag.Record = DB.WorkRecords.ToList().OrderBy(i => i.WorkLevel).Skip((page - 1) * PageSize).Take(PageSize).ToList();
                        }
                        else
                        {
                            ViewBag.Record = DB.WorkRecords.ToList().OrderByDescending(i => i.WorkLevel).Skip((page - 1) * PageSize).Take(PageSize).ToList();
                        }
                    }
                    else
                    {
                        ViewBag.Record = DB.WorkRecords.ToList().Skip((page - 1) * PageSize).Take(PageSize).ToList();
                    }

                    ViewBag.PageHtml = PageingHtml.GetPagingHTML(DB.WorkRecords.ToList().Count, PageSize, page, "turnPage(1Index1)", 5, 2);
                }
            }
            catch (Exception ex)
            {
                //写日志记录错误
            }
            return View();
        }

        /// <summary>
        /// 更新workRecord
        /// </summary>
        /// <param name="WorkName"></param>
        /// <param name="WorkProcess"></param>
        /// <param name="WorkLevel"></param>
        /// <param name="WorkMark"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public JsonResult SaveUpdate(int Id,string WorkName, int WorkProcess, int WorkLevel, string WorkMark, DateTime StartTime, DateTime EndTime)
        {
            string result = "";
            if (Id > 0)
            {
                try
                {
                    using (var DB = new WorkRecordsContext())
                    {
                        var entry = (from t in DB.WorkRecords where t.Id == Id select t).FirstOrDefault();
                        entry.WorkName = WorkName;
                        entry.WorkProcss = WorkProcess;
                        entry.WorkLevel = WorkLevel;
                        entry.WorkMark = WorkMark;
                        entry.StartTime = StartTime;
                        entry.EndTime = EndTime;
                        DB.WorkRecords.Update(entry);
                        DB.SaveChanges();
                        result = entry.Id.ToString(); //成功
                    }
                }
                catch (Exception ex)
                {
                    result = "0";//失败
                }
            }


            return Json(result);
        }
    }
}
