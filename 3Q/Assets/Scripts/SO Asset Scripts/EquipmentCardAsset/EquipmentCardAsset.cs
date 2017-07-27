using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EquipmentCardAsset : ScriptableObject 
{
	public Sprite CardImage;
	public string Range = "";
	[TextArea(2, 3)]
	public string Effect;
	public Sprite[] CardSuits;
}
