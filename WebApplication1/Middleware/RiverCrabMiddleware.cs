using System.Text;

namespace WebApplication1.Middleware
{
    public class RiverCrabMiddleware
    {
        private readonly RequestDelegate _next;

        public RiverCrabMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            var originalRequestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;

            var modifiedRequestBody = ModifyContent(originalRequestBody);
            var requestStream = new MemoryStream(Encoding.UTF8.GetBytes(modifiedRequestBody));
            context.Request.Body = requestStream;

            // get originalBodyStream
            var originalBodyStream = context.Response.Body;
            using var newBodyStream = new MemoryStream();
            context.Response.Body = newBodyStream;

            // 調用下一個中間件（包括Controller Action）
            await _next(context);

            // 修改響應體
            newBodyStream.Position = 0; // 重置新響應流的位置
            var responseBody = await new StreamReader(newBodyStream).ReadToEndAsync();
            var modifiedResponseBody = ModifyContent(responseBody);

            // 將修改後的響應寫回originalResponse
            var responseBytes = Encoding.UTF8.GetBytes(modifiedResponseBody);
            await originalBodyStream.WriteAsync(responseBytes, 0, responseBytes.Length);

            // 確保將原始ResponseStream放回HttpContext
            context.Response.Body = originalBodyStream;
        }
        private string ModifyContent(string content)
        {
            // 替換內容的邏輯
            return content.Replace("習維尼", "偉大的領導")
                .Replace("警察","佛伯樂").Replace("一中各表","一家和樂")
                .Replace("台獨萬歲","國內免運");
        }
    }


    public static class RiverCrabExtension
    {
        public static IApplicationBuilder UseRiverCrab(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RiverCrabMiddleware>();
        }
    }
}
