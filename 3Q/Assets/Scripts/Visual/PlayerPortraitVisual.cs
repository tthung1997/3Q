﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerPortraitVisual : MonoBehaviour {

    // TODO : get ID from players when game starts

    //public GameObject Explosion;
    public CharacterAsset charAsset;
    [Header("Text Component References")]
    //public Text NameText;
    public Text HealthText;
	public Text ArmorText;
	public Transform HealthTransform;
    [Header("Image References")]
	public GameObject ArmorGameObject;
    public Image HeroPowerIconImage;
    public Image HeroPowerBackgroundImage;
    public Image PortraitImage;
    public Image PortraitBackgroundImage;

	public void Awake()
	{
		if(charAsset != null)
			ApplyLookFromAsset();
	}

    public void ApplyLookFromAsset()
    {
        HealthText.text = charAsset.MaxHealth.ToString();
        HeroPowerIconImage.sprite = charAsset.HeroPowerIconImage;
        HeroPowerBackgroundImage.sprite = charAsset.HeroPowerBGImage;
        PortraitImage.sprite = charAsset.AvatarImage;
        PortraitBackgroundImage.sprite = charAsset.AvatarBGImage;

        HeroPowerBackgroundImage.color = charAsset.HeroPowerBGTint;
        PortraitBackgroundImage.color = charAsset.AvatarBGTint;

    }

	public void TakeDamage(int amount, int healthAfter, int armorAfter)
    {
		if (amount != 0) {
				// TODO 
			DamageEffect.CreateDamageEffect (transform.position, amount);
			HealthText.text = healthAfter.ToString ();
			//Shield (armorAfter);
		}
    }

	/*public void Heal(int amount, int healthAfter)
	{
		if (amount > 0)
		{
			// TODO 
			HealEffect.CreateHealEffect(HealthTransform.position, amount);
			if (healthAfter <= charAsset.MaxHealth) 
				HealthText.text = healthAfter.ToString();
			else
				HealthText.text = charAsset.MaxHealth.ToString();
		}	
	}

	public void Shield(int armorAfter)
	{
		if (armorAfter > 0) {
			if (!ArmorGameObject.activeSelf)
				ArmorGameObject.SetActive (true);
			ArmorText.text = armorAfter.ToString();
		} else
			ArmorGameObject.SetActive (false);
	}*/

    public void Explode()
    {
	/* TODO */
        Instantiate(GlobalSettings.Instance.ExplosionPrefab, transform.position, Quaternion.identity);
        Sequence s = DOTween.Sequence();
        s.PrependInterval(2f);
		s.OnComplete(() => GlobalSettings.Instance.GameOverPanel.SetActive(true));
	/**/
    }



}
