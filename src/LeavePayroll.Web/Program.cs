using LeavePayroll.Infrastructure.Persistence;
using LeavePayroll.Web.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add EF Core DbContext (In-Memory database for development & demonstration)
builder.Services.AddDbContext<LeavePayrollDbContext>(options =>
    options.UseInMemoryDatabase("LeavePayrollDb"));

var app = builder.Build();

// Seed initial master data (Job Grades 1-9, Org Units, Positions, Anonymized Master Data)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<LeavePayrollDbContext>();
    await DataSeeder.SeedAsync(dbContext);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
