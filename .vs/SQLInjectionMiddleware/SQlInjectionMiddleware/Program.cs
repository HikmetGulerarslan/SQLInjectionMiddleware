using SQlInjectionMiddleware.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
var app = builder.Build();

app.UseMiddleware<SqLInjectMiddleWare>();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());


app.Run();
