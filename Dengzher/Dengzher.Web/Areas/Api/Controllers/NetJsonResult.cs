using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Newtonsoft.Json;

namespace Dengzher.Web.Areas.Api.Controllers
{
    public class NetJsonResult : ActionResult
    {
        private readonly Object _data;
        public NetJsonResult(Object data)
        {
            _data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.Write(JsonConvert.SerializeObject(_data, Newtonsoft.Json.Formatting.None));
        }
    }
}