using PROJECTNAME;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PROJECTNAME.Clients;
using PROJECTNAME.Services;
using Microsoft.JSInterop;
using System.Globalization;
using System.Text.Json;
using Mapster;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLocalization();

var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(Program).Assembly);

builder.Services.AddMudServices();
builder.Services.AddScoped<FolderClient>();
builder.Services.AddScoped<StoryClient>();
builder.Services.AddScoped<GeocodingClient>();
builder.Services.AddScoped<CultureService>();
builder.Services.AddScoped<IJsonContentService, JsonContentService>();
builder.Services.AddScoped(sp =>
{
    var baseUrl = builder.Configuration["API:BaseUrl"];

    if (string.IsNullOrEmpty(baseUrl))
    {
        var navManager = sp.GetService<NavigationManager>();
        baseUrl = navManager!.BaseUri;
    }

    return new HttpClient { BaseAddress = new Uri(baseUrl) };
});

var host = builder.Build();

var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
var storedCulture = await jsRuntime.InvokeAsync<string?>("blazorCulture.get");
var culture = new CultureInfo(storedCulture ?? "fr");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
