using Godot;

public partial class CardManager : Node
{
    public static CardManager Instance { get; set; }

    public Timer ArrowsTimer { private get; set; }
    public Timer ShadowArmyTimer { private get; set; }

    public ICommand ActiveCommand { get; set; }

    public override void _Ready()
    {
        Instance ??= this;
    }

    public void Execute(Card card)
    {
        switch (card.Id)
        {
            case 2:
                ActiveCommand = new ShootingArrowsCommand(ArrowsTimer);
                break;
            case 3:
                ActiveCommand = new HealthPotionCommand();
                break;
            case 4:
                ActiveCommand = new ShadowArmyCommand(ShadowArmyTimer);
                break;
        }

        ActiveCommand.Execute();
    }
}