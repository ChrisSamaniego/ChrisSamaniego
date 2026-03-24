using Microsoft.EntityFrameworkCore;
using SchoolPortal.Data;
using SchoolPortal.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<AppStateService>();
builder.Services.AddScoped<SchoolDataService>();
builder.Services.AddScoped<LanguageService>();

builder.Services.AddDbContext<SchoolPortalDbContext>(options =>
    options.UseInMemoryDatabase("SchoolPortalDb"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<SchoolPortal.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();
