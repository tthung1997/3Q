using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

// holds the refs to all the Text, Images on the card
public class OneCardManager : MonoBehaviour {

    public HeroAsset heroAsset;
    public OneCardManager PreviewManager;
	public HealthVisual HealthBar;
	public DescriptionListVisual SkillList, SkillDescList;
    [Header("Text Component References")]
    public Text CountryText;
	public Text HeroNameText;
    [Header("Image References")]
    public Image CardGraphicImage;
    public Image CardBodyImage;
    public Image CardFaceFrameImage;
    public Image CardFaceGlowImage;
    public Image CardBackGlowImage;

    void Awake()
    {
        if (heroAsset != null)
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
       	HeroNameText.text = heroAsset.name;
		HeroNameText.color = heroAsset.Country.CardColor;
		CardBodyImage.color = heroAsset.Country.CardColor;
		CountryText.text = heroAsset.Country.name;
        CardGraphicImage.sprite = heroAsset.CardImage;
		HealthBar.HealthColor = heroAsset.Country.HealthColor;
		HealthBar.TotalHealth = heroAsset.MaxHealth;
		SkillList.TotalItems = heroAsset.SkillsName.Length;
		for (int i = 0; i < SkillList.TotalItems; i++) {
			SkillList.ListItems [i].GetComponentInChildren<Text> ().text = heroAsset.SkillsName [i];
			SkillList.ListItems [i].GetComponentInChildren<Image> ().color = heroAsset.Country.CardColor;
		}
		SkillDescList.TotalItems = heroAsset.SkillsDesc.Length;
		for (int i = 0; i < SkillList.TotalItems; i++) {
			SkillDescList.ListItems [i].GetComponent<Text> ().text = heroAsset.SkillsDesc [i];
		}

        if (PreviewManager != null)
        {
            PreviewManager.heroAsset = heroAsset;
            PreviewManager.ReadCardFromAsset();
        }
    }
}
