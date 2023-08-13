using IpControl.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
var app = builder.Build();

app.UseMiddleware<InjectionMiddleWare>();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());


app.Run();
