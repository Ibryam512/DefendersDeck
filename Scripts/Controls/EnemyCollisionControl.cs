using Godot;

public partial class EnemyCollisionControl : Area2D
{
	private void _OnAreaEntered(Area2D area)
	{
		if (
			this.IsInGroup(GameConstants.EnemyGroup) && 
			(area.IsInGroup(GameConstants.ShadowGroup) || area.IsInGroup(GameConstants.ArrowGroup))
		)
		{
			GetParent().QueueFree();
			area.GetParent().QueueFree();

			GameManager.Instance.OnEnemyKilled();
		}
	}
}
