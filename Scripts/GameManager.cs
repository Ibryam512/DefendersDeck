using Godot;
using System;

public partial class GameManager : Node
{
    public static GameManager Instance { get; set; }

    private int _enemiesKilled = 0;
    private int _health = 10;

    private Label _enemiesKilledLabel;
    private Label _healthLabel;

    public override void _Ready()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            QueueFree();
        }

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

    private void UpdateUI()
    {
        _enemiesKilledLabel.Text = $"{_enemiesKilled}";
        _healthLabel.Text = $"{_health}";
    }
}