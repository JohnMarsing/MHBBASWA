namespace BlazorApp.Shared
{
	public class HelloWorld
	{
		public string Msg { get; set; }
		public override string ToString()
		{
			return Msg;
		}
	}
}
