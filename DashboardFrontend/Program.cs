using DashboardFrontend.Components;
using DashboardFrontend.Services;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DashboardClient>(sp =>
{
  var httpClient = new HttpClient();
  return new DashboardClient("https://localhost:7187", httpClient);
});
builder.Services.AddSingleton<DashboardService, DashboardService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
