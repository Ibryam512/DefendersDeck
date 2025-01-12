using Godot;

public partial class CardManager : Node
{
    public static CardManager Instance { get; set; }

    private Timer _timer;

    public Timer Timer { set => _timer = value; }

    public ICommand ActiveCommand { get; set; }

    public override void _Ready()
    {
        Instance ??= this;
    }

    public void Execute(Card card)
    {
        switch (card.Id)
        {
            case 4:
                ActiveCommand = new ShadowArmyCommand(_timer);
                break;
        }

        ActiveCommand.Execute();
    }
}