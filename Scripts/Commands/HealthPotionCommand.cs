using Godot;

public class HealthPotionCommand : ICommand
{
	public void Execute()
	{
		GameManager.Instance.Health = GameConstants.InitialHealth;
	}
}
