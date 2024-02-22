using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using ThrottleCoreCRM.Client;
using Microsoft.AspNetCore.Components.Authorization;
using ThrottleCoreCRM.Client.Services;
using ThrottleCoreCRM.Client.Pages;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<Dashboard>("app");


builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddRadzenComponents();
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_WebSiteService>();
builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_SummaryService>();
builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_CustomerService>();
builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_ActivityService>();
builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_BillingService>();
builder.Services.AddSingleton<DataService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddHttpClient("ThrottleCoreCRM.Server", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ThrottleCoreCRM.Server"));
builder.Services.AddScoped<ThrottleCoreCRM.Client.SecurityService>();
builder.Services.AddScoped<AuthenticationStateProvider, ThrottleCoreCRM.Client.ApplicationAuthenticationStateProvider>();
var host = builder.Build();
await host.RunAsync();

//************************************************************************************************
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using Radzen;
//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using ThrottleCoreCRM.Client;
//using Microsoft.AspNetCore.Components.Authorization;
//using ThrottleCoreCRM.Client.Services;
//using ThrottleCoreCRM.Client.Pages;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<Dashboard>("app");

//builder.Services.AddRadzenComponents();
//builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_WebSiteService>();
//builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_SummaryService>();
//builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_CustomerService>();
//builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_ActivityService>();
//builder.Services.AddScoped<ThrottleCoreCRM.Client.Throttle_Core_BillingService>();

//// Add the DataService registration
//builder.Services.AddScoped<DataService>();

//builder.Services.AddAuthorizationCore();
//builder.Services.AddHttpClient("ThrottleCoreCRM.Server", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
//builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ThrottleCoreCRM.Server"));
//builder.Services.AddScoped<ThrottleCoreCRM.Client.SecurityService>();
//builder.Services.AddScoped<AuthenticationStateProvider, ThrottleCoreCRM.Client.ApplicationAuthenticationStateProvider>();

//var host = builder.Build();
//await host.RunAsync();
