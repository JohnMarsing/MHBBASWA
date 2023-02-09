using Microsoft.AspNetCore.Components;
using BlazorApp.Shared;
using System.Net.Http.Json;

namespace BlazorApp.Client.Pages;

public partial class Scripture
{
	[Inject] public HttpClient Http { get; set; }
	[Inject] public ILogger<Scripture>? Logger { get; set; }

	private List<ScriptureVM>? ScriptureList;

	private const string AzureStorageTableName = "scripture0003";
	private const string PartitionKey = "gen001";

	Status _status;
	string _msg = string.Empty;

	protected override async Task OnInitializedAsync()
	{
		try
		{
			_status = Status.Loading;
			Logger!.LogInformation("...Calling Http.GetFromJsonAsync");

			await Task.Delay(0);
			//ScriptureList = await Http.GetFromJsonAsync<List<ScriptureVM>>("/api/Scripture") ?? new List<ScriptureVM> { };
			//_msg = await Http.GetFromJsonAsync<string>("/api/ScriptureFunction") { };
			//_msg = await Http.GetStringAsync<HelloWorld>("/api/ScriptureFunction");
			//_msg = await Http.GetFromJsonAsync<HelloWorld>("/api/ScriptureFunction");
			//_msg = await Http.GetAsync("/api/ScriptureFunction");
			_status = Status.Loaded;
		}
		catch (Exception ex)
		{
			_status = Status.Error;
			_msg = ex.ToString();
			Logger!.LogError(ex, "...Exception occurred");
		}
	}
}

