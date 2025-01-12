using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
	public static GameManager Instance { get; set; }

	private int _enemiesKilled = 0;
	private int _health = 10;

	private Label _enemiesKilledLabel;
	private Label _healthLabel;

	public List<Card> Cards { get; set; } = new List<Card>
	{
		new Card { Id = 1, ImagePath = "earthquake.png" },
		new Card { Id = 2, ImagePath = "fire-arrows.png" },
		new Card { Id = 3, ImagePath = "health-potion.png" },
		new Card { Id = 4, ImagePath = "shadow-army.png" }
	};
	public Card ActiveCard { get; set; }

	public override void _EnterTree()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			QueueFree();
		}
	}

	public override void _Ready()
	{
		_enemiesKilledLabel = GetNode<Label>("CanvasLayer/EnemiesKilled/Label");
		_healthLabel = GetNode<Label>("CanvasLayer/Health/Label");

		UpdateUI();
	}

	public void OnEnemyKilled()
	{
		_enemiesKilled++;
		UpdateUI();
	}

	public void OnTowerHit()
	{
		_health--;
		UpdateUI();
	}

	public void OnCardSelected(int cardId)
	{
		GD.Print($"Selected card: {cardId}");
		Card card = Cards.Find(c => c.Id == cardId);
		GD.Print($"Selected card: {card.ImagePath}");

		if (card != null)
		{
			ActiveCard = card;
			GD.Print($"Selected card!!: {card.ImagePath}");
		}
	}

	private void UpdateUI()
	{
		_enemiesKilledLabel.Text = $"{_enemiesKilled}";
		_healthLabel.Text = $"{_health}";
	}
}
