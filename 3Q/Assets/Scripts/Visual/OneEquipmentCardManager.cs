using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// holds the refs to all the Text, Images on the card
public class OneEquipmentCardManager : MonoBehaviour {

	public EquipmentCardAsset cardAsset;
	public OneEquipmentCardManager PreviewManager;
	[Header("Text Component References")]
	public Text CardTitleText;
	public Text EffectText;
	public Text CardNumber;
	public Text RangeText;
	[Header("Image References")]
	public Image CardSuit;
	public Image CardGraphicImage;
	public Image CardBodyImage;
	public Image CardFaceFrameImage;
	public Image CardFaceGlowImage;
	public Image CardBackGlowImage;

	private string[] num = { "", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

	void Awake()
	{
		//Debug.Log ("In Awake");
		if (cardAsset != null && PreviewManager != null)
			ReadCardFromAsset();
	}

	private bool canBePlayedNow = false;
	public bool CanBePlayedNow
	{
		get
		{
			return canBePlayedNow;
		}

		set
		{
			canBePlayedNow = value;

			CardFaceGlowImage.enabled = value;
		}
	}

	public void ReadCardFromAsset()
	{
		//Debug.Log ("In main method");
		CardTitleText.text = cardAsset.name;
		if (EffectText != null)
			EffectText.text = cardAsset.Effect;
		if (RangeText != null) 
			RangeText.text = cardAsset.Range;
		CardGraphicImage.sprite = cardAsset.CardImage;
		if (cardAsset.name != "LIGHTNING")
			CardNumber.text = num [Random.Range (1, 14)];
		else
			CardNumber.text = num [1];
		CardSuit.sprite = cardAsset.CardSuits [Random.Range(0, cardAsset.CardSuits.Length)];
		if (CardSuit.sprite.name == "Heart2" || CardSuit.sprite.name == "Diamond2")
			CardNumber.color = Color.red;
		else
			CardNumber.color = Color.black;
		//Debug.Log (CardNumber.text);

		if (PreviewManager != null)
		{
			PreviewManager.cardAsset = cardAsset;
			PreviewManager.ReadCardFromAsset(CardNumber, CardSuit);
		}
	}

	public void ReadCardFromAsset(Text cardNumber, Image cardSuit)
	{
		//Debug.Log ("In override method");
		//Debug.Log (cardNumber.text);
		CardTitleText.text = cardAsset.name;
		if (EffectText != null)
			EffectText.text = cardAsset.Effect;
		if(RangeText != null)
			RangeText.text = cardAsset.Range;
		CardGraphicImage.sprite = cardAsset.CardImage;
		CardNumber.text = cardNumber.text;
		CardNumber.color = cardNumber.color;
		CardSuit.sprite = cardSuit.sprite;

		if (PreviewManager != null)
		{
			PreviewManager.cardAsset = cardAsset;
			PreviewManager.ReadCardFromAsset();
		}
	}
}
