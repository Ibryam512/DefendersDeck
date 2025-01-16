using Godot;

public partial class EndGameManager : Node 
{

	private Label _label;

	public override void _Ready()
	{
		_label = GetNode<Label>("ColorRect/Label");
		_label.Text = GameManager.Instance.Win ? "You Win!" : "You Lose!";
	}
}
