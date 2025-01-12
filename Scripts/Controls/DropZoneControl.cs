using Godot;
using Godot.Collections;

public partial class DropZoneControl : TextureRect
{
	public override bool _CanDropData(Vector2 atPosition, Variant data)
	{
		if (data.VariantType != Variant.Type.Dictionary)
		{
			return false;
		}

		Dictionary dictionary = data.AsGodotDictionary();

		return dictionary.ContainsKey("cardId");
	}

	public override void _DropData(Vector2 atPosition, Variant data)
	{
		Dictionary dictionary = data.AsGodotDictionary();
		var cardId = (int)dictionary["cardId"];
		GameManager.Instance.OnCardSelected(cardId);
	}
}
