using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace Radiant.API.App_Config
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if ((string.Equals(context.Request.Method, "POST", StringComparison.InvariantCultureIgnoreCase)
                || string.Equals(context.Request.Method, "PUT", StringComparison.InvariantCultureIgnoreCase))
                && !context.Request.Path.ToString().EndsWith("upload_file"))
            {
                string body = string.Empty;
                using (StreamReader stream = new StreamReader(context.Request.Body))
                {
                    body = await stream.ReadToEndAsync();
                }
                try
                {
                    var jsonInput = JObject.Parse(body);

                    if (string.Equals(context.Request.Method, "POST", StringComparison.InvariantCultureIgnoreCase))
                    {
                        //if (jsonInput.ContainsKey("CreatedOn"))
                        //{
                        jsonInput["CreatedOn"] = DateTime.Now;
                        //}

                        //if (jsonInput.ContainsKey("CreatedBy"))
                        //{
                        jsonInput["CreatedBy"] = long.Parse(context.Request.HttpContext.User.FindFirst("UserId")?.Value);
                        //}
                    }

                    //if (jsonInput.ContainsKey("UpdatedOn"))
                    //{
                    jsonInput["UpdatedOn"] = DateTime.Now;
                    //}
                    //if (jsonInput.ContainsKey("UpdatedBy"))
                    //{
                    jsonInput["UpdatedBy"] = long.Parse(context.Request.HttpContext.User.FindFirst("UserId")?.Value);
                    //}

                    var requestData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(jsonInput));
                    context.Request.Body = new MemoryStream(requestData);
                    context.Request.ContentLength = context.Request.Body.Length;

                }
                catch
                {
                    var requestData = Encoding.UTF8.GetBytes(body);
                    context.Request.Body = new MemoryStream(requestData);
                    context.Request.ContentLength = context.Request.Body.Length;
                }
            }

            await _next.Invoke(context);
        }
    }

    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
