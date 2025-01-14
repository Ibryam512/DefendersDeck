using Godot;

public class ShootingArrowsCommand : ICommand
{
	private Timer _timer;
	
	public ShootingArrowsCommand(Timer timer)
	{
		_timer = timer;
	}

	public void Execute()
	{
		_timer.Start();
	}
}
