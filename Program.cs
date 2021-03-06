using BlazorDeploymentTest;
using System.Globalization;
using BlazorDeploymentTest.Pages;
using BlazorDeploymentTest.Shared.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Localization;
using BlazorDeploymentTest.Shared.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLocalization();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<TasksViewModel>();
builder.Services.AddScoped<Disclaimer>();
builder.Services.AddSingleton<DisclaimerViewModel>();
builder.Services.AddSingleton<CultureSelectorViewModel>();

var host = builder.Build();
await host.SetDefaultCulture();

await host.RunAsync();
