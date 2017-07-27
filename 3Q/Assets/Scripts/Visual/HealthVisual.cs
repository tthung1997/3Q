using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class HealthVisual : MonoBehaviour {

    //public int TestFullCrystals;
    public int TestTotalHealthThisTurn;
	public Color HealthColor;

	public Image[] HealthGems;
    //public Text ProgressText;

    private int totalHealth;
    public int TotalHealth
    {
        get{ return totalHealth; }

        set
        {
            //Debug.Log("Changed total mana to: " + value);

            if (value > HealthGems.Length)
                totalHealth = HealthGems.Length;
            else if (value < 0)
                totalHealth = 0;
            else
                totalHealth = value;

            for (int i = 0; i < HealthGems.Length; i++)
            {
				if (i < totalHealth) {
					//if (HealthGems [i].color == Color.clear)
						HealthGems [i].color = HealthColor;
					/*if (!Crystals [i].gameObject.activeSelf)
						Crystals [i].gameObject.SetActive (true);*/
				} else
					HealthGems [i].color = Color.clear;
            }

            // update the text
            //ProgressText.text = string.Format("{0}/{1}", availableCrystals.ToString(), totalCrystals.ToString());
        }
    }
    
    void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            TotalHealth = TestTotalHealthThisTurn;
        }
    }
	
}
