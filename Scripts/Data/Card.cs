using Godot;

public class Card
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public CardType Type { get; set; }
    public int Amount { get; set; }
    public int Price { get; set; }
    public int Turns { get; set; }
}