namespace Sandbox;

[Title( "Map Instance (Custom)" )] 
[Category( "World" )] 
[Icon( "travel_explore" )]
public class CustomMapInstance : MapInstance
{
	public CustomMapInstance() => OnMapLoaded = () =>
	{
		// Get map information, then delete map.
		new Map( MapName, new CustomMapLoader( Scene, GameObject ) ).Delete();
	};
}



public class CustomMapLoader : MapLoader
{
	public CustomMapLoader( Scene scene, GameObject gameObject ) : base( scene.SceneWorld, scene.PhysicsWorld )
	{
		mapObject = gameObject;
		index = 0;
	}

	readonly GameObject mapObject;
	int index;
	
	/// <summary>
	/// Override hammer entities with a specified class type.
	/// </summary>
	/// <param name="hammerData">The hammer entity data.</param>
	protected override void CreateObject( ObjectEntry hammerData )
	{
		// Get object in the order.
		var hammerObject = mapObject.Children[index++];
		
		switch ( hammerData.TypeName )
		{
			case "prefab":
				CreatePrefab( hammerObject, hammerData );
				return;
			
			case "example_component":
				CreateExampleComponent( hammerObject, hammerData );
				return;
		}
	}
	
	
	
	protected virtual void CreatePrefab( GameObject hammerObject, ObjectEntry hammerData )
	{
		var prefabPath = hammerData.GetString( "prefabpath" );
		if ( !ResourceLibrary.TryGet<PrefabFile>( prefabPath, out var prefab ) )
		{
			Log.Warning( $"Prefab path {prefabPath} on {hammerObject} not found." );
			return;
		}

		var serializedData = prefab.RootObject;
		SceneUtility.MakeGameObjectsUnique( serializedData );

		// Apply prefab
		hammerObject.SetPrefabSource( prefabPath );
		hammerObject.Deserialize( serializedData );
		
		hammerObject.Flags &= ~GameObjectFlags.Error;
		hammerObject.Transform.World = hammerData.Transform;
	}
	
	
	
	protected virtual void CreateExampleComponent( GameObject hammerObject, ObjectEntry hammerData )
	{
		var example = hammerObject.Components.Create<ExampleComponent>();
		hammerObject.Networked = true;

		// We get the value of the "mystring" key on the hammer entity.
		example.MyString = hammerData.GetString( "mystring" );
		
		// This removes the error symbol in the hierarchy.
		hammerObject.Flags &= ~GameObjectFlags.Error;
	}
}