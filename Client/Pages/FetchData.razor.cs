using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using BlazorApp.Shared;

namespace BlazorApp.Client.Pages;

public partial class FetchData
{
	[Inject] public HttpClient Http { get; set; }
	[Inject] public ILogger<FetchData>? Logger { get; set; }

	private WeatherForecast[] forecasts = new WeatherForecast[] { };

	protected Status _status;
	protected string _msg = string.Empty;

	protected override async Task OnInitializedAsync()
	{
		try
		{
			_status = Status.Loading;
			Logger!.LogInformation("...Calling Http.GetFromJsonAsync");
			forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("/api/WeatherForecast") ?? new WeatherForecast[] { };
			_status = Status.Loaded;
		}
		catch (Exception ex)
		{
			_status = Status.Error;
			_msg = ex.ToString();
			Logger!.LogError(ex, "...Exception occurred");
			//Console.WriteLine(ex.ToString());
		}
	}
}