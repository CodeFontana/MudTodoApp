using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using MudTodo.Shared;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlite($@"Data Source={Environment.CurrentDirectory}\Todo.db;");
});
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

WebApplication app = builder.Build();

using IServiceScope scope = app.Services.CreateScope();
TodoDbContext db = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
db.Database.Migrate();

if (app.Environment.IsDevelopment() == false)
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
