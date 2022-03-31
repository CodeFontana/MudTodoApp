using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using MudTodo.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlite($@"Data Source={Environment.CurrentDirectory}\Todo.db;");
});
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

WebApplication app = builder.Build();

using IServiceScope scope = app.Services.CreateScope();
TodoDbContext db = scope.ServiceProvider.GetRequiredService<TodoDbContext>();
db.Database.Migrate();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
