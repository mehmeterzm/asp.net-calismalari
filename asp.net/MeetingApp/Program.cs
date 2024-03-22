var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();


//mvc
//rest api
//razor page

// app.MapGet("/", () => "Hello World!");
// app.MapGet("/abc", () => "abc yazii");

//{controller=Home}/{action=index}/{id?}
// app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}"
);

app.Run();
