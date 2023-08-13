namespace SQlInjectionMiddleware.Middleware
{
    public class SqLInjectMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly static string[] SQLKeywords = new string[]
      {
            ";", "--", "EXECUTE ", "EXEC(", "SELECT", "INSERT", "UPDATE", "DELETE", "CREATE",
            "TRUNCATE ", "DROP", "ALTER TABLE", "TABLE", "DATABASE", "WHERE", "ORDER BY", "GROUP BY",
            "DECLARE ", "CAST(", "CONVERT(", "VARCHAR(", "NVARCHAR("
      };
        public SqLInjectMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context is not null)
            {
                var query = context.Request;
                string queryPath = query.Path;
                string queryString = query.QueryString.Value;

                queryPath = queryPath.ToUpper();
                queryString = queryString.ToUpper();

                foreach (string keyword in SQLKeywords)
                {
                    if (queryPath.IndexOf(keyword) != (-1) || queryString.IndexOf(keyword) != (-1))
                    {
                        context.Response.Redirect("/Home/ErrorPage");
                        await _next(context);
                        return;
                    }
                }
            }
            await _next(context);
        }
    }
}
