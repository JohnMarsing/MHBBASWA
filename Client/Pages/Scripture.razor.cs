using Microsoft.AspNetCore.Components;
using Azure.Data.Tables;
using Azure;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Client.Pages;

public partial class Scripture
{
	[Inject]
	public ILogger<Scripture>? Logger { get; set; }


	private List<ScriptureTS>? ScriptureList;

	private const string AzureStorageTableName = "scripture0003";
	private const string PartitionKey = "gen001";

	Status _status;
	string _msg = string.Empty;

	protected override async Task OnInitializedAsync()
	{
		await GetByPartitionKey(PartitionKey, "001");
	}

	public async Task GetByPartitionKey(string partitionKey, string key)
	{
		string inside = $"Inside {nameof(Scripture)}!{nameof(GetByPartitionKey)}; partitionKey:{partitionKey}; Table: {AzureStorageTableName}";
		Logger!.LogInformation(string.Format("{0}", inside));
		try
		{
			_status = Status.Loading;

			Logger!.LogInformation("...Calling GetTableClient");
			TableClient tableClient = await GetTableClient(AzureStorageTableName);

			Logger!.LogInformation("...Setting qry to use PartitionKey filter");
			Pageable<ScriptureTS> qry = tableClient.Query<ScriptureTS>
				(filter: TableClient.CreateQueryFilter($"PartitionKey eq {partitionKey}"));

			Logger!.LogInformation("...Setting =ScriptureList = qry.ToList()");
			ScriptureList = qry.ToList();
			_status = Status.Loaded;
		}
		catch (Exception ex)
		{
			_status = Status.Error;
			_msg = ex.Message;
			Logger!.LogError(ex, "...Exception occurred");
		}

	}

	private static async Task<TableClient> GetTableClient(string? tableName)
	{
		//ExtractConnectionString.GetByType(ConnectionStringType.TableStorage);
		string connectionString = "DefaultEndpointsProtocol=https;AccountName=myhebrewbible5;AccountKey=noTx48U+Dv0xb+V/LzgxrGO/MYlkgfIKbc51J4NpfPJug/C/EGnXvay6matKnKATee5EWepTevPMzLggDz4Rhw==;TableEndpoint=https://myhebrewbible5.table.core.windows.net/;";
		TableServiceClient tableServiceClient = new TableServiceClient(connectionString);
		var tableClient = tableServiceClient.GetTableClient(tableName);
		await tableClient.CreateIfNotExistsAsync();
		return tableClient;
	}

}