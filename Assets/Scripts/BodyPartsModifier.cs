using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsModifier : MonoBehaviour
{
	Dictionary<BodyType, SpriteRenderer> spriteRenderersCharacter = new Dictionary<BodyType, SpriteRenderer>();
	Dictionary<BodyType, BodyPart> equippedBodyParts = new Dictionary<BodyType, BodyPart>();
	[SerializeField]
	SpriteRenderer spriteRendererTorso = null, spriteRendererArmRight = null, spriteRendererArmLeft = null, spriteRendererLegRight = null, spriteRendererLegLeft = null, 
		spriteRendererFootRight = null, spriteRendererFootLeft = null, spriteRendererHandRight = null, spriteRendererHandLeft = null, spriteRendererHead = null;
	[SerializeField]
	BodyPartList defaultBodyPartList = null;
	[SerializeField]
	DirectionIndicator directionIndicator = null;

    private void Awake()
    {
		spriteRenderersCharacter[BodyType.Torso] = spriteRendererTorso;
		spriteRenderersCharacter[BodyType.ArmRight] = spriteRendererArmRight;
		spriteRenderersCharacter[BodyType.ArmLeft] = spriteRendererArmLeft;
		spriteRenderersCharacter[BodyType.LegRight] = spriteRendererLegRight;
		spriteRenderersCharacter[BodyType.LegLeft] = spriteRendererLegLeft;
		spriteRenderersCharacter[BodyType.FootRight] = spriteRendererFootRight;
		spriteRenderersCharacter[BodyType.FootLeft] = spriteRendererFootLeft;
		spriteRenderersCharacter[BodyType.HandRight] = spriteRendererHandRight;
		spriteRenderersCharacter[BodyType.HandLeft] = spriteRendererHandLeft;
		spriteRenderersCharacter[BodyType.Head] = spriteRendererHead;

		foreach(BodyPart bp in defaultBodyPartList._BodyPartList)
			equippedBodyParts[bp._BodyType] = bp;

		OnChangeDirection();
	}
	
	public void OnChangeDirection()
	{
		ChangeBodyPartsByDirection();
		AdjustBodyPartsSortingOrder();
	}

	public void ChangeBodyPartsByDirection()
    {
		foreach (KeyValuePair<BodyType, BodyPart> kvp in equippedBodyParts)
		{
			Sprite spriteToChangeTo = null;
			if (directionIndicator._CurrentDirection == Direction.Up)
				spriteToChangeTo = kvp.Value._SpriteUp;
			else if (directionIndicator._CurrentDirection == Direction.Down)
				spriteToChangeTo = kvp.Value._SpriteDown;
			else if (directionIndicator._CurrentDirection == Direction.Left)
				spriteToChangeTo = kvp.Value._SpriteLeft;
			else if (directionIndicator._CurrentDirection == Direction.Right)
				spriteToChangeTo = kvp.Value._SpriteRight;

			spriteRenderersCharacter[kvp.Key].sprite = spriteToChangeTo;


			bool flip = directionIndicator._CurrentDirection == Direction.Left || ((directionIndicator._CurrentDirection == Direction.Up || directionIndicator._CurrentDirection == Direction.Down) &&
				(kvp.Key == BodyType.HandLeft || kvp.Key == BodyType.ArmLeft || kvp.Key == BodyType.LegLeft || kvp.Key == BodyType.FootLeft));

			spriteRenderersCharacter[kvp.Key].flipX = flip;
		}
	}

	void AdjustBodyPartsSortingOrder()
    {
		if ((directionIndicator._CurrentDirection == Direction.Up || directionIndicator._CurrentDirection == Direction.Down) && 
			(directionIndicator._LastDirection == Direction.Right || directionIndicator._LastDirection == Direction.Left))
		{
			spriteRenderersCharacter[BodyType.Torso].sortingOrder = 3;
			spriteRenderersCharacter[BodyType.ArmRight].sortingOrder = 2;
			spriteRenderersCharacter[BodyType.ArmLeft].sortingOrder = 2;
			spriteRenderersCharacter[BodyType.HandRight].sortingOrder = 1;
			spriteRenderersCharacter[BodyType.HandLeft].sortingOrder = 1;
		}
		else if ((directionIndicator._CurrentDirection == Direction.Left || directionIndicator._CurrentDirection == Direction.Right) && 
			(directionIndicator._LastDirection == Direction.Up || directionIndicator._LastDirection == Direction.Down))
		{
			spriteRenderersCharacter[BodyType.Torso].sortingOrder = 2;
			spriteRenderersCharacter[BodyType.ArmRight].sortingOrder = 3;
			spriteRenderersCharacter[BodyType.ArmLeft].sortingOrder = 3;
			spriteRenderersCharacter[BodyType.HandRight].sortingOrder = 2;
			spriteRenderersCharacter[BodyType.HandLeft].sortingOrder = 2;
		}
	}

	public void ChangeToBodyPartsFromItem(Item item)
	{
		foreach (BodyPart bp in item._BodyPartsList)
		{
			equippedBodyParts[bp._BodyType] = bp;
			ChangeBodyPartsByDirection();
		}
	}
}