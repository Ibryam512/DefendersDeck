using Godot;
using System;

public partial class LevelManager : Node2D
{
	[Export]
	private PackedScene _enemyAsset;

	private Path2D _path;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_path = GetNode<Path2D>("Path2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _OnEnemySpawn()
	{
		Node enemy = _enemyAsset.Instantiate();
		_path.AddChild(enemy);
	}
}
