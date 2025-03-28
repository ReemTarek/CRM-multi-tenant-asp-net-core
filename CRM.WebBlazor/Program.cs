using CRM.WebBlazor.Components;
using Microsoft.AspNetCore.Localization;
using MudBlazor.Services;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
//configure api project address
var apiAddress = builder.Configuration["ApiAddress"];
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiAddress) });
builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("EN"),
        new CultureInfo("AR"),
    };
    options.DefaultRequestCulture = new RequestCulture("EN");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

//mudblazor
builder.Services.AddMudServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
