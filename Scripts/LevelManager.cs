using Godot;
using System;

public partial class LevelManager : Node2D
{
	[Export]
	private PackedScene _enemyAsset;

	[Export]
	private PackedScene _shadowEnemyAsset;

	private Path2D _path;
	private Timer _shadowEnemySpawnTimer;
	private int _enemiesKilled = -1;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_path = GetNode<Path2D>("Path2D");

		_shadowEnemySpawnTimer = GetNode<Timer>("ShadowEnemySpawnTimer");
		CardManager.Instance.Timer = _shadowEnemySpawnTimer;
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

	public void _OnShadowEnemySpawn()
	{
		if (_enemiesKilled == -1)
		{
			_enemiesKilled = GameManager.Instance.EnemiesKilled;
		}

		Node shadowEnemy = _shadowEnemyAsset.Instantiate();
		_path.AddChild(shadowEnemy);
		_enemiesKilled--;

		if (_enemiesKilled == 0)
		{
			_shadowEnemySpawnTimer.Stop();
		}
	}
}
