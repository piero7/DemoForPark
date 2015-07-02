using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendFile
{
    class Program
    {
        static void Main(string[] args)
        {
            SendToApi();
        }



        static public void SendToApi()
        {
            string[] uploadfiles = new string[] { "D:\\2d.jpg", "d:\\140317.ajk" }; //上传文件路径
            string url = "http://localhost:49840//api/fileapi"; //服务地址

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                using (var content = new System.Net.Http.MultipartFormDataContent())//表明是通过multipart/form-data的方式上传数据
                {
                    //循环添加文件至列表
                    foreach (var path in uploadfiles)
                    {
                        var fileContent = new System.Net.Http.ByteArrayContent(System.IO.File.ReadAllBytes(path));
                        fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                        {
                            FileName = System.IO.Path.GetFileName(path),//此处可以自定义文件名
                        };
                        content.Add(fileContent);
                    }
                    var result = client.PostAsync(url, content).Result;//提交post请求
                }

            }
        }
    }
}
