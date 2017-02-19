using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MX6100API
{
    public partial class MX6100API1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest1(Context);
        }
        static object lockObj = new object();
        public void ProcessRequest1(HttpContext context)
        {
            //header[验证]=smeshlink(需添加)
            context.Response.ContentType = "application/json";
            if ( context.Request.Headers["user"] == "smeshlink")
            {
                string gateway = context.Request.Params["gateway"];
                string node = context.Request.Params["node"];
                string action = context.Request.Params["action"];
                string date = DateTime.Now.ToString();             
                lock (lockObj)
                {
                    try
                    {
                 
                        string path =Path.Combine(@"D:\MX6100API" ,"mx6100apiRecord.txt");
                   
                        File.AppendAllText(path, string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n", gateway, node, action, date));
                   
                    }
                    catch (Exception ee)
                    {
                        
                    }                                       
                }
                //if (context.Request.Params["gateway"] == "1")
                context.Response.Write("{\"result\":\"success\",\"description\":\"ok\"}");                
                //else if (context.Request.Params["state"] == "0")
                //    context.Response.Write("{\"result\":\"关闭成功\"}");
            }
            else
            {
                context.Response.Write("{\"result\":\"fail\",\"description\":\"Authentication failed\"}");
            }
        }
    }
}