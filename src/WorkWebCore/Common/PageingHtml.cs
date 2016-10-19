using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWebCore
{
    public class PageingHtml
    {

        #region..得到分页的HTML
        /// <summary>
        /// 得到分页的HTML
        /// </summary>
        /// <param name="rowCount">总共有多少条记录</param>
        /// <param name="pagesize">一页显示多少条</param>
        /// <param name="curpage">当前页</param>
        /// <param name="link">链接</param>
        /// <param name="showNumber">分页那块显示几页，一般5页</param>
        /// <param name="linkType">1:url 2 javascript</param>
        /// <returns></returns>
        public static string GetPagingHTML(int rowCount, int pagesize, int curpage, string link, int showNumber, int linkType)
        {
            StringBuilder ssb = new StringBuilder();
            int howMuchPage = (rowCount % pagesize == 0) ? rowCount / pagesize : (rowCount / pagesize + 1);
            int nextPage = (howMuchPage > curpage) ? (curpage + 1) : howMuchPage;
            int forwardPage = (curpage > 1) ? (curpage - 1) : 1;
            int startShowPageIndex = 0;
            int endShowPageIndex = 0;
            if (howMuchPage <= showNumber)
            {
                startShowPageIndex = 1;
                endShowPageIndex = howMuchPage;
            }
            else
            {
                if (curpage > 2)
                {
                    startShowPageIndex = curpage - 2;
                    if (curpage > howMuchPage - showNumber + 3)
                    {
                        endShowPageIndex = howMuchPage;
                        startShowPageIndex = howMuchPage - showNumber + 1;
                    }
                    else
                    {
                        endShowPageIndex = curpage + showNumber - 3;
                    }
                }
                else
                {
                    startShowPageIndex = 1;
                    endShowPageIndex = showNumber;
                }

            }
            ssb.Append(" 共" + rowCount.ToString() + "条记录&nbsp; ");
            if (linkType == 1)//URL
            {
                ssb.Append("<a  href=\"" + link.Replace("1Index1", "1") + "\" >首页</a>&nbsp;");
                ssb.Append("<a  href=\"" + link.Replace("1Index1", forwardPage.ToString()) + "\" >上一页</a>&nbsp;");
            }
            else if (linkType == 2)//javascript
            {
                ssb.Append("<a  onclick=\"" + link.Replace("1Index1", "1") + ";return false;\" href=\"#\"   >首页</a>&nbsp;");
                ssb.Append("<a   onclick=\"" + link.Replace("1Index1", forwardPage.ToString()) + ";return false;\" href=\"#\" >上一页</a>&nbsp;");
            }
            for (int i = startShowPageIndex; i <= endShowPageIndex; i++)
            {
                if (linkType == 1)//URL
                {
                    if (curpage == i)
                    {
                        ssb.Append("<a  href=\"" + link.Replace("1Index1", i.ToString()) + "\" >[<font  style=\"color:Red;\">" + i + "</font>]</a>&nbsp;");
                    }
                    else
                    {
                        ssb.Append("<a  href=\"" + link.Replace("1Index1", i.ToString()) + "\" >[" + i + "]</a>&nbsp;");
                    }
                }
                else if (linkType == 2)//javascript
                {
                    if (curpage == i)
                    {
                        ssb.Append("<a  onclick=\"" + link.Replace("1Index1", i.ToString()) + ";return false;\" href=\"#\"  >[<font  style=\"color:Red;\">" + i + "</font>]</a>&nbsp;");
                    }
                    else
                    {
                        ssb.Append("<a  onclick=\"" + link.Replace("1Index1", i.ToString()) + ";return false;\" href=\"#\" >[" + i + "]</a>&nbsp;");
                    }
                }

            }
            if (linkType == 1)//URL
            {
                ssb.Append("<a  href=\"" + link.Replace("1Index1", nextPage.ToString()) + "\" >下一页</a>&nbsp;");
                ssb.Append("<a  href=\"" + link.Replace("1Index1", howMuchPage.ToString()) + "\" >尾页</a>");
            }
            else if (linkType == 2)//javascript
            {
                ssb.Append("<a  onclick=\"" + link.Replace("1Index1", nextPage.ToString()) + ";return false;\" href=\"#\"   >下一页</a>&nbsp;");
                ssb.Append("<a   onclick=\"" + link.Replace("1Index1", howMuchPage.ToString()) + ";return false;\" href=\"#\" >尾页</a>");
            }
            return ssb.ToString();
        }
        #endregion
    }
}
