using Godot;
using System;

public partial class EnemyCollisionControl : Area2D
{
	private void _OnAreaEntered(Area2D area)
	{
		GetParent().QueueFree();
		
		if (area.IsInGroup("shadow"))
		{
			GameManager.Instance.OnEnemyKilled();
		}
	}
}
