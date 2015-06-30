using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoForPark.Controllers
{
    /// <summary>
    /// 文件上传
    /// </summary>
    public class FileController : Controller
    {
        //
        // GET: /File/


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Upload(HttpPostedFileBase Filedata)
        {
            // 如果没有上传文件
            if (Filedata == null ||
                string.IsNullOrEmpty(Filedata.FileName) ||
                Filedata.ContentLength == 0)
            {
                return this.HttpNotFound();
            }

            // 保存到 ~/photos 文件夹中，名称不变
            string filename = System.IO.Path.GetFileName(Filedata.FileName);
            string virtualPath =
                string.Format("~/photos/{0}", filename);
            // 文件系统不能使用虚拟路径
            string path = this.Server.MapPath(virtualPath);

            Filedata.SaveAs(path);
            return this.Json(new { });
        }
    }
}
