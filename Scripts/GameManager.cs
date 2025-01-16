using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
	public static GameManager Instance { get; set; }

	private int _enemiesKilled;
	private int _health;

	private Label _enemiesKilledLabel;
	private Label _healthLabel;

	private Card _activeCard;

	public int EnemiesKilled => _enemiesKilled;
	public bool Win { get; set; }
	public int Health
	{
		set
		{
			_health = value;
			UpdateUI();
		}
	}

	public List<Card> Cards { get; set; } = new();

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

		GetDeck();
	}

	public override void _Ready()
	{
		_enemiesKilledLabel = GetNode<Label>("CanvasLayer/EnemiesKilled/Label");
		_healthLabel = GetNode<Label>("CanvasLayer/Health/Label");

		_enemiesKilled = GameConstants.InitialEnemiesKilled;
		_health = GameConstants.InitialHealth;

		UpdateUI();
	}

	public void OnEnemyKilled()
	{
		_enemiesKilled++;
		UpdateUI();

		if (_enemiesKilled >= GameConstants.EnemiesToKill)
		{
			GlobalSceneManager.Instance.ChangeScene("res://Scenes/EndScene.tscn");
			Win = true;
		}
	}

	public void OnTowerHit()
	{
		_health--;
		UpdateUI();

		if (_health <= 0)
		{
			GlobalSceneManager.Instance.ChangeScene("res://Scenes/EndScene.tscn");
			Win = false;
		}
	}

	public void OnCardSelected(int cardId)
	{
		Card card = Cards.Find(c => c.Id == cardId);

		if (card != null)
		{
			ActiveCard = card;
		}
	}

	public void GetDeck()
	{
		var httpManager = new HttpManager();
		Cards = httpManager.GetDeck();
	}

	private void UpdateUI()
	{
		_enemiesKilledLabel.Text = $"{_enemiesKilled}";
		_healthLabel.Text = $"{_health}";
	}

	private void InitializeGame()
	{
		_enemiesKilled = GameConstants.InitialEnemiesKilled;
		_health = GameConstants.InitialHealth;
		UpdateUI();
	}
}
