using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
using Azure.Data.Tables;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
	sp => new HttpClient 
		{ BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });

//builder.Services.AddSingleton(x => new Azure.Data.Tables.TableClient(
//		new System.Uri("https://YOUR_ACCOUNT_NAME.table.cosmos.azure.com/"),
//		new Azure.Core.TokenCredential("YOUR_ACCESS_KEY")));

await builder.Build().RunAsync();
