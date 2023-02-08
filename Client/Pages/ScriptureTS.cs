using Azure;
using Azure.Data.Tables;

namespace BlazorApp.Client.Pages;

public class ScriptureTS : ITableEntity
{
	public string PartitionKey { get; set; } = default!;
	public string RowKey { get; set; } = default!;
	public string? KJV { get; set; }
	public string? VerseOffset { get; set; }
	public string? DescH { get; set; }
	public string? DescD { get; set; }
	public string? DescHSlug { get; set; }

	public DateTimeOffset? Timestamp { get; set; }
	public ETag ETag { get; set; }
}

