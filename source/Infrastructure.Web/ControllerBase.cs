namespace ByndyuSoft.Infrastructure.Web
{
    using System;
    using System.Text;
    using System.Web.Mvc;

    /// <summary>
    /// </summary>
    public abstract class ControllerBase : Controller
	{
	    protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
		{
			return new MyJsonResult(data, contentType, contentEncoding);
		}

        private class MyJsonResult : JsonResult
		{
			public MyJsonResult(object data, string contentType, Encoding contentEncoding)
			{
				Data = data;
				ContentType = contentType;
				ContentEncoding = contentEncoding;
			}

			public override void ExecuteResult(ControllerContext context)
			{
				if (context == null)
					throw new ArgumentNullException("context");

				var response = context.HttpContext.Response;
			    response.ContentType = !string.IsNullOrEmpty(ContentType)
			                               ? ContentType
			                               : "application/json";

                if (ContentEncoding != null)
                    response.ContentEncoding = ContentEncoding;

				if (Data == null)
					return;

				Data.ToJson(response.Output);
			}
		}
	}
}