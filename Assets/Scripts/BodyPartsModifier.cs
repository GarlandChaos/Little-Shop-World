using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
	Up,
	Down,
	Right,
	Left
}

public class BodyPartsModifier : MonoBehaviour
{
	Dictionary<BodyType, SpriteRenderer> spriteRenderersCharacter = new Dictionary<BodyType, SpriteRenderer>();
	Dictionary<BodyType, BodyPart> equippedBodyParts = new Dictionary<BodyType, BodyPart>();
	[SerializeField]
	SpriteRenderer spriteRendererTorso = null, spriteRendererArmRight = null, spriteRendererArmLeft = null, spriteRendererLegRight = null, spriteRendererLegLeft = null, 
		spriteRendererFootRight = null, spriteRendererFootLeft = null, spriteRendererHandRight = null, spriteRendererHandLeft = null, spriteRendererHead = null;
	[SerializeField]
	BodyPartList defaultBodyPartList = null;
	public Direction currentDirection = Direction.Down;

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

		ChangeDirection(Direction.Down);
	}

    private void Update()
    {
		CheckForDirectionChange();
	}

	void CheckForDirectionChange()
    {
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		if (x != 0)
		{
			if (x < 0) //left
				ChangeDirection(Direction.Left);
			else if (x > 0) //right
				ChangeDirection(Direction.Right);
		}
		else
		{
			if (y < 0) //down
				ChangeDirection(Direction.Down);
			else if (y > 0) //up
				ChangeDirection(Direction.Up);
		}
	}

	void ChangeDirection(Direction direction)
	{
		if(currentDirection != direction)
        {
			ChangeBodyPartsByDirection(direction);
			AdjustBodyPartsSortingOrder(direction);
			currentDirection = direction;
		}
	}

	void ChangeBodyPartsByDirection(Direction direction)
    {
		foreach (KeyValuePair<BodyType, BodyPart> kvp in equippedBodyParts)
		{
			Sprite spriteToChangeTo = null;
			if (direction == Direction.Up)
				spriteToChangeTo = kvp.Value._SpriteUp;
			else if (direction == Direction.Down)
				spriteToChangeTo = kvp.Value._SpriteDown;
			else if (direction == Direction.Left)
				spriteToChangeTo = kvp.Value._SpriteLeft;
			else if (direction == Direction.Right)
				spriteToChangeTo = kvp.Value._SpriteRight;

			spriteRenderersCharacter[kvp.Key].sprite = spriteToChangeTo;


			bool flip = direction == Direction.Left || ((direction == Direction.Up || direction == Direction.Down) &&
				(kvp.Key == BodyType.HandLeft || kvp.Key == BodyType.ArmLeft || kvp.Key == BodyType.LegLeft || kvp.Key == BodyType.FootLeft));

			spriteRenderersCharacter[kvp.Key].flipX = flip;
		}
	}

	void AdjustBodyPartsSortingOrder(Direction direction)
    {
		if ((direction == Direction.Up || direction == Direction.Down) && (currentDirection == Direction.Right || currentDirection == Direction.Left))
		{
			spriteRenderersCharacter[BodyType.Torso].sortingOrder = 3;
			spriteRenderersCharacter[BodyType.ArmRight].sortingOrder = 2;
			spriteRenderersCharacter[BodyType.ArmLeft].sortingOrder = 2;
			spriteRenderersCharacter[BodyType.HandRight].sortingOrder = 1;
			spriteRenderersCharacter[BodyType.HandLeft].sortingOrder = 1;
		}
		else if ((direction == Direction.Left || direction == Direction.Right) && (currentDirection == Direction.Up || currentDirection == Direction.Down))
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
			spriteRenderersCharacter[bp._BodyType].sprite = bp._SpriteDown;
		}
	}
}