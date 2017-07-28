using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollCardAsset : ScriptableObject 
{
	public Sprite CardImage;
	[TextArea(2, 3)]
	public string Effect;
	public Sprite[] CardSuits;
	public TargetingOptions Targets;
}
