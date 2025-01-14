using Godot;
using System;

public partial class ArrowManager : PathFollow2D
{
	private PathFollow2D _pathFollow;

	private float _speed = 1f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_pathFollow = GetNode<PathFollow2D>(GetPath());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_pathFollow.ProgressRatio += (float)delta * _speed * 0.3f;
		if (_pathFollow.ProgressRatio >= 1)
			_Pass();
	}

	private void _Pass()
	{
		QueueFree();
	}
}
