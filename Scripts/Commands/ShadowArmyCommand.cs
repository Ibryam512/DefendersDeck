using Godot;

public class ShadowArmyCommand : ICommand
{
    private Timer _timer;
    
    public ShadowArmyCommand(Timer timer)
    {
        _timer = timer;
    }

    public void Execute()
    {
        _timer.Start();
    }
}