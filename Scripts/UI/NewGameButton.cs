using Godot;
using System;

public partial class NewGameButton : TextureButton
{
	private AudioStreamPlayer _audioStreamPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _OnPressed()
	{
		GlobalSceneManager.Instance.ChangeScene("res://Scenes/GameScene.tscn");
	}
}
