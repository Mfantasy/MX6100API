using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MX6100API
{
    /// <summary>
    /// MX6100API 的摘要说明
    /// </summary>
    public class MX6100API : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //header[验证]=smeshlink(需添加)
            context.Response.ContentType = "application/json";
            if (context.Request.Params["state"] == "1")
                context.Response.Write("{result:\"MX6100\",\"description\":\"null\"}");
            else if (context.Request.Params["state"] == "0")
                context.Response.Write("{result:\"关闭成功\"}");
        }

        //"result": "OK",success／fail
        //"description": "timeout/working"

        //param: gateway:"0100000000000412" 
        //       node:"02"
        //action:"on|off|standby"


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}