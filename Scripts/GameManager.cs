using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
	public static GameManager Instance { get; set; }

	private int _enemiesKilled = GameConstants.InitialEnemiesKilled;
	private int _health = GameConstants.InitialHealth;

	private Label _enemiesKilledLabel;
	private Label _healthLabel;

	private Card _activeCard;

	public int EnemiesKilled => _enemiesKilled;
	public int Health
	{
		set
		{
			_health = value;
			UpdateUI();
		}
	}

	public List<Card> Cards { get; set; } = new List<Card>
	{
		new Card { Id = 1, ImagePath = "earthquake.png" },
		new Card { Id = 2, ImagePath = "fire-arrows.png" },
		new Card { Id = 3, ImagePath = "health-potion.png" },
		new Card { Id = 4, ImagePath = "shadow-army.png" }
	};
	public Card ActiveCard
	{
		get => _activeCard;
		set
		{
			_activeCard = value;
			CardManager.Instance.Execute(_activeCard);
		}
	}

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
		Card card = Cards.Find(c => c.Id == cardId);

		if (card != null)
		{
			ActiveCard = card;
		}
	}

	private void UpdateUI()
	{
		_enemiesKilledLabel.Text = $"{_enemiesKilled}";
		_healthLabel.Text = $"{_health}";
	}
}
