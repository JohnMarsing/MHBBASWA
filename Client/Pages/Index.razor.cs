using Microsoft.AspNetCore.Components;

namespace BlazorApp.Client.Pages;

public partial class Index
{
	[Inject]
	private IConfiguration? configuration { get; set; }

	protected string? AccountName { get; set; }  = 	string.Empty;
	protected string? AccountKey { get; set; }  = string.Empty;
	protected string? TableEndpoint { get; set; } = string.Empty;
	
	protected override void OnInitialized()
	{
		AccountName = configuration!["AccountName"];
		AccountKey = configuration!["AccountKey"];
		TableEndpoint = configuration!["TableEndpoint"];
	}
}