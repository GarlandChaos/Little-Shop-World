using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LSW.Gameplay;

namespace LSW.UI
{
	public class BodyPartsModifierUI : MonoBehaviour
	{
		[SerializeField]
		Dictionary<BodyType, Image> imagesCharacter = new Dictionary<BodyType, Image>();
		[SerializeField]
		Image imageTorso = null, imageArmRight = null, imageArmLeft = null,
		imageLegRight = null, imageLegLeft = null, imageFootRight = null, imageFootLeft = null, imageHandRight = null, imageHandLeft = null, imageHead = null;

		private void Awake()
		{
			imagesCharacter[BodyType.Torso] = imageTorso;
			imagesCharacter[BodyType.ArmRight] = imageArmRight;
			imagesCharacter[BodyType.ArmLeft] = imageArmLeft;
			imagesCharacter[BodyType.LegRight] = imageLegRight;
			imagesCharacter[BodyType.LegLeft] = imageLegLeft;
			imagesCharacter[BodyType.FootRight] = imageFootRight;
			imagesCharacter[BodyType.FootLeft] = imageFootLeft;
			imagesCharacter[BodyType.HandRight] = imageHandRight;
			imagesCharacter[BodyType.HandLeft] = imageHandLeft;
			imagesCharacter[BodyType.Head] = imageHead;
		}

		public void ModifyClothes(Item item)
		{
			foreach (BodyPart bp in item._BodyPartsList)
			{
				imagesCharacter[bp._BodyType].sprite = bp._SpriteDown;
				float x = (bp._BodyType == BodyType.HandLeft || bp._BodyType == BodyType.ArmLeft || bp._BodyType == BodyType.LegLeft || bp._BodyType == BodyType.FootLeft) ? -1f : 1f;
				Vector2 scale = new Vector2(x, 1);
				imagesCharacter[bp._BodyType].GetComponent<RectTransform>().localScale = scale;
			}
		}
	}
}