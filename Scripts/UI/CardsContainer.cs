using Godot;
using System.Collections.Generic;
public partial class CardsContainer : Node
{
	private ScrollContainer _scrollContainer;
	private VBoxContainer _vBoxContainer;
	private List<Card> _cards;

	public override void _Ready()
	{
		_scrollContainer = GetNode<ScrollContainer>("ScrollContainer");
		_vBoxContainer = _scrollContainer.GetNode<VBoxContainer>("VBoxContainer");

		_cards = GameManager.Instance.Cards;

		foreach (var card in _cards)
		{
			AddCard(card);
		}
	}

	private void AddCard(Card card)
	{
		// Create a MarginContainer for margins
		MarginContainer marginContainer = new MarginContainer();
		marginContainer.AddThemeConstantOverride("margin_left", 60);
		marginContainer.AddThemeConstantOverride("margin_top", 20);
		marginContainer.AddThemeConstantOverride("margin_right", 60);
		marginContainer.AddThemeConstantOverride("margin_bottom", 220);

		// Center-align the TextureRect
		marginContainer.SizeFlagsHorizontal = Control.SizeFlags.ShrinkCenter;
		marginContainer.SizeFlagsVertical = Control.SizeFlags.ShrinkCenter;

		TextureRect textureRect = new TextureRect();
		textureRect.Texture = GD.Load<Texture2D>($"res://Assets/Cards/{card.ImagePath}");
		textureRect.StretchMode = TextureRect.StretchModeEnum.KeepAspect;
		textureRect.SizeFlagsHorizontal = Control.SizeFlags.Expand;
		textureRect.SizeFlagsVertical = Control.SizeFlags.Expand;

		CardControl cardControl = new CardControl();
		cardControl.SizeFlagsHorizontal = Control.SizeFlags.Expand;
		cardControl.SizeFlagsVertical = Control.SizeFlags.Expand;
		cardControl.TextureRect = textureRect;
		cardControl.Card = card;
		cardControl.AddChild(textureRect);

		marginContainer.AddChild(cardControl);
		_vBoxContainer.AddChild(marginContainer);
	}
}
