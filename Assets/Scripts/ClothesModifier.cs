using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesModifier : MonoBehaviour
{
	[SerializeField]
	Dictionary<BodyType, SpriteRenderer> spriteRenderersCharacter = new Dictionary<BodyType, SpriteRenderer>();
	[SerializeField]
	SpriteRenderer spriteRendererTorso = null, spriteRendererArmRight = null, spriteRendererArmLeft = null,
	spriteRendererLegRight = null, spriteRendererLegLeft = null, spriteRendererFootRight = null, spriteRendererFootLeft = null;

    private void Awake()
    {
		spriteRenderersCharacter[BodyType.Torso] = spriteRendererTorso;
		spriteRenderersCharacter[BodyType.ArmRight] = spriteRendererArmRight;
		spriteRenderersCharacter[BodyType.ArmLeft] = spriteRendererArmLeft;
		spriteRenderersCharacter[BodyType.LegRight] = spriteRendererLegRight;
		spriteRenderersCharacter[BodyType.LegLeft] = spriteRendererLegLeft;
		spriteRenderersCharacter[BodyType.FootRight] = spriteRendererFootRight;
		spriteRenderersCharacter[BodyType.FootLeft] = spriteRendererFootLeft;
	}

	public void ModifyClothes(Item item)
	{
		foreach (BodyPart bp in item._BodyPartsList)
		{
			spriteRenderersCharacter[bp._BodyType].sprite = bp._Sprite;
			spriteRenderersCharacter[bp._BodyType].flipX = bp._FlippedSprite;
		}
	}
}