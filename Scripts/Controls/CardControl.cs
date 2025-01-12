using Godot;
using Godot.Collections;

public partial class CardControl : TextureRect
{
	public TextureRect TextureRect { get; set; }

	public Card Card { get; set;}

	public override Variant _GetDragData(Vector2 atPosition)
	{
		var dragPreview = new TextureRect
		{
			Texture = TextureRect.Texture,
			StretchMode = TextureRect.StretchModeEnum.KeepAspect,
			SizeFlagsHorizontal = SizeFlags.Expand,
			SizeFlagsVertical = SizeFlags.Expand
		};

		SetDragPreview(dragPreview);

		return new Dictionary()
		{
			{ "cardId", Card.Id },
		};
	}
}
