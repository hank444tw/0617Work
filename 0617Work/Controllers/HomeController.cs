using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using _0617Work.Models;

namespace _0617Work.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["bar"] = 33;
            Session["barText"] = "上傳csv檔";
            Session["progress"] = 1;
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            //------------------------儲存檔案---------------------------------
            string fileName = Path.GetFileName(file.FileName);
            var FolderPath = Server.MapPath("~/csvFile/");
            var path = Path.Combine(FolderPath, "0.csv");
            file.SaveAs(path);
            //-----------------------------------------------------------------

            string cmd = @"cd C:\Users\hankh\Desktop\ASP_NET_MVC\0617Work\0617Work\Python";
            string cmd_py = $@"python 0617Work.py --chooseDef 1 --fileName {fileName}";

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.RedirectStandardInput = true;
            p.Start();

            StreamWriter myStreamWriter = p.StandardInput;
            myStreamWriter.WriteLine(cmd);
            myStreamWriter.WriteLine(cmd_py);
            myStreamWriter.Close();

            //-----------------------------------取得回傳值，並存入List----------------------------------------
            string bigstr = p.StandardOutput.ReadToEnd(); //取得cmd文字
            string[] NSelect = Regex.Split(bigstr, "--分割--", RegexOptions.IgnoreCase); //正規表示式做分割

            List<csvData> data = new List<csvData>();
            for (int x = 0; x < NSelect.Count(); x++)
            {
                if (NSelect[x].IndexOf("\r\n") != -1)
                    continue;

                data.Add(new csvData
                {
                    fileName = fileName,
                    csvIndex = NSelect[x]
                });
            }
            //----------------------------------------------------------------------------------------------------
            p.WaitForExit(); //等待程式執行完畢，並Exit
            p.Close(); //釋放Process記憶體

            Session["bar"] = 66;
            Session["barText"] = "設定折線圖參數";
            Session["progress"] = 2;
            return View(data);
        }

        [HttpPost]
        public ActionResult makeImage
        (string title,string titleSize,string xAxis,string xTitle,string xTitleSize,
         string yTitle,string yTitleSize, string[] data,string[] color,string xyfontsize,
         string legendSize, string width,string height,string grid){

            //----------------------將陣列文字串接起來，以','分隔--------------------------
            String strData = string.Join(",",data).Replace(" ","");
            String strColor = string.Join(",", color).Replace(" ","");
            //-----------------------------------------------------------------------------

            if (grid == null) 
                grid = "false";
            else
                grid = "true";

            string cmd = @"cd C:\Users\hankh\Desktop\ASP_NET_MVC\0617Work\0617Work\Python";
            string cmd_py = $@"python 0617Work.py --chooseDef 2 --title {title.Trim()} --titleSize {titleSize.Trim()} "+
                             $"--xAxis {xAxis.Trim()} --xTitle {xTitle.Trim()} --xTitleSize {xTitleSize.Trim()} --yTitle {yTitle.Trim()} "+
                             $"--yTitleSize {yTitleSize.Trim()} --data {strData.Trim()} --color {strColor.Trim()} --xyfontsize {xyfontsize.Trim()} "+
                             $"--legendSize {legendSize.Trim()} --width {width.Trim()} --height {height.Trim()} --grid {grid.Trim()}";

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.RedirectStandardInput = true;
            p.Start();

            StreamWriter myStreamWriter = p.StandardInput;
            myStreamWriter.WriteLine(cmd);
            myStreamWriter.WriteLine(cmd_py);
            myStreamWriter.Close();

            p.WaitForExit(); //等待程式執行完畢，並Exit
            p.Close(); //釋放Process記憶體

            Session["bar"] = 100;
            Session["barText"] = "下載折線圖";
            Session["progress"] = 3;
            return View("index");
        }

        [HttpPost]
        public ActionResult downloadImg()
        {
            //Server端路徑
            string filePath = Server.MapPath($@"..\Python\file.png"); //相對路徑

            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename =" + $"file.png"); //下載檔案名稱
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
            return View("Index");
        }
    }
}