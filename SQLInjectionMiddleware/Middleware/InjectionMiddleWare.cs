using System.Net;

namespace IpControl.Middleware
{
    public class InjectionMiddleWare
    {
        private static string[] SQLKeywords = new string[]
      {
            ";", "--", "EXECUTE ", "EXEC(", "SELECT", "INSERT", "UPDATE", "DELETE", "CREATE",
            "TRUNCATE ", "DROP", "ALTER TABLE", "TABLE", "DATABASE", "WHERE", "ORDER BY", "GROUP BY",
            "DECLARE ", "CAST(", "CONVERT(", "VARCHAR(", "NVARCHAR("
      };
        private readonly RequestDelegate _next;
        private readonly string[] _ipBlackList = { "127.0.0.1","::1"};
        public InjectionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var queryUrl = context.Request;
            string queryString = context.Request.QueryString.Value;
            string queryPath = context.Request.Path.ToString();
            queryPath = queryPath.ToUpper();
            queryString = queryString.ToUpper();
            foreach (string keyword in SQLKeywords)
            {
                if (queryString.IndexOf(keyword) != (-1) || queryPath.IndexOf(keyword) != (-1))
                {
                    context.Response.Redirect("/Home/ErrorPage");
                    return;
                }
            }
          
            await _next(context);
        }
    }
}
