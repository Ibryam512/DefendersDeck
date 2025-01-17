using Godot;
using System;

public partial class LevelManager : Node2D
{
	[Export]
	private PackedScene _enemyAsset;

	[Export]
	private PackedScene _shadowEnemyAsset;

	[Export]
	private PackedScene _arrowAsset;

	private Path2D _path;
	private Timer _enemySpawnTimer;
	private Timer _shadowEnemySpawnTimer;
	private Timer _arrowSpawnTimer;
	private int _enemiesKilled = -1;
	private int _arrows = GameConstants.InitialArrows;
	private float _initialSpeed = GameConstants.InitialSpeed;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_path = GetNode<Path2D>("Path2D");

		_enemySpawnTimer = GetNode<Timer>("EnemySpawnTimer");

		_arrowSpawnTimer = GetNode<Timer>("ArrowSpawnTimer");
		CardManager.Instance.ArrowsTimer = _arrowSpawnTimer;

		_shadowEnemySpawnTimer = GetNode<Timer>("ShadowEnemySpawnTimer");
		CardManager.Instance.ShadowArmyTimer = _shadowEnemySpawnTimer;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _OnEnemySpawn()
	{
		EnemyManager enemy = _enemyAsset.Instantiate<EnemyManager>();
		enemy.Speed = _initialSpeed;
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

	public void _OnArrowsSpawn()
	{
		Node arrow = _arrowAsset.Instantiate();
		_path.AddChild(arrow);
		_arrows--;

		if (_arrows == 0)
		{
			_arrows = GameConstants.InitialArrows;
			_arrowSpawnTimer.Stop();
		}
	}

	public void _OnSpeedUp()
	{
		_initialSpeed += 0.5f;
		_enemySpawnTimer.WaitTime -= 0.125f;
	}
}
