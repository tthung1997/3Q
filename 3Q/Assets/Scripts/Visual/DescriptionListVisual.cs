using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class DescriptionListVisual : MonoBehaviour {

	//public int TestFullCrystals;
	public int TestTotalItemsThisTurn;

	public GameObject[] ListItems;
	//public Text ProgressText;

	private int totalItems;
	public int TotalItems
	{
		get{ return totalItems; }

		set
		{
			//Debug.Log("Changed total mana to: " + value);

			if (value > ListItems.Length)
				totalItems = ListItems.Length;
			else if (value < 0)
				totalItems = 0;
			else
				totalItems = value;

			for (int i = 0; i < ListItems.Length; i++)
			{
				if (i < totalItems) {
					if (!ListItems [i].activeSelf)
						ListItems [i].SetActive (true);
				} else
					ListItems [i].SetActive (false);
			}

			// update the text
			//ProgressText.text = string.Format("{0}/{1}", availableCrystals.ToString(), totalCrystals.ToString());
		}
	}

	void Update()
	{
		if (Application.isEditor && !Application.isPlaying)
		{
			TotalItems = TestTotalItemsThisTurn;
		}
	}

}
