using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LSW.Events;

namespace LSW.UI
{
	public class ShopkeeperDialogueScreenController : APanelController
	{
		[SerializeField]
		GameEvent eventPause = null;
		[SerializeField]
		GameEvent eventUnpause = null;
		[SerializeField]
		TMP_Text textSpeakerName = null;
		[SerializeField]
		TMP_Text textDialogue = null;
		[SerializeField]
		RectTransform choicePanel = null;
		[SerializeField]
		GameEvent eventOpenShopBuyScreen = null;
		[SerializeField]
		GameEvent eventOpenShopSellScreen = null;

		void OnEnable()
		{
			eventPause.Raise();
			choicePanel.gameObject.SetActive(false);
		}

		public void ShowDialogue(DialogueSettings dialogueSettings)
        {
			StartCoroutine(ShowDialogueCoroutine(dialogueSettings));
		}

		public void OpenBuyScreen()
		{
			eventOpenShopBuyScreen.Raise();
		}

		public void OpenSellScreen()
		{
			eventOpenShopSellScreen.Raise();
		}

		IEnumerator ShowDialogueCoroutine(DialogueSettings dialogueSettings)
		{
			textSpeakerName.text = dialogueSettings._SpeakerName;
			textDialogue.text = string.Empty;
			foreach (char letter in dialogueSettings._Dialogue.ToCharArray())
			{
				textDialogue.text += letter;
				yield return new WaitForSeconds(dialogueSettings._TextSpeed);
			}
			choicePanel.gameObject.SetActive(true);
		}
	}
}