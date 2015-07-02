using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoForPark.Controllers
{
    public class FileApiController : ApiController
    {
        /// <summary>
        /// 接收上传文件 from client
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async System.Threading.Tasks.Task Upload()
        {
            System.Web.HttpPostedFile file = System.Web.HttpContext.Current.Request.Files[0];
            var provider = new CustomMultipartFormDataStreamProvider(System.Web.HttpContext.Current.Server.MapPath("~/photos"));

            await Request.Content.ReadAsMultipartAsync(provider);

        }

    }


    /// <summary>
    /// 用于是实现重命名上传文件(使用client提交的文件名)
    /// </summary>
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path) { }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            return headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        }
    }


}
