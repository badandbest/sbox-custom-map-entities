namespace Sandbox;

public class ExampleComponent : Component
{
	[Property, TextArea]
	public string MyString { get; set; }
	
	protected override void OnUpdate()
	{
		Log.Info( MyString );
	}
}
