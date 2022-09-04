using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyPartsModifierUI : MonoBehaviour
{
	[SerializeField]
	Dictionary<BodyType, Image> imagesCharacter = new Dictionary<BodyType, Image>();
	[SerializeField]
	Image imageTorso = null, imageArmRight = null, imageArmLeft = null,
	imageLegRight = null, imageLegLeft = null, imageFootRight = null, imageFootLeft = null;

	private void Awake()
	{
		imagesCharacter[BodyType.Torso] = imageTorso;
		imagesCharacter[BodyType.ArmRight] = imageArmRight;
		imagesCharacter[BodyType.ArmLeft] = imageArmLeft;
		imagesCharacter[BodyType.LegRight] = imageLegRight;
		imagesCharacter[BodyType.LegLeft] = imageLegLeft;
		imagesCharacter[BodyType.FootRight] = imageFootRight;
		imagesCharacter[BodyType.FootLeft] = imageFootLeft;
	}

	public void ModifyClothes(Item item)
	{
		foreach (BodyPart bp in item._BodyPartsList)
		{
			imagesCharacter[bp._BodyType].sprite = bp._SpriteDown;
			float x = (bp._FlippedSprite)? -1f : 1f;
			Vector2 scale = new Vector2(x, 1);
			imagesCharacter[bp._BodyType].GetComponent<RectTransform>().localScale = scale;
		}
	}
}
