using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TargetingOptions
{
	NoTarget,
	EnemyCards
}

public class BasicCardAsset : ScriptableObject 
{
	public Sprite CardImage;
	public Sprite[] CardSuits;
	public TargetingOptions Targets;
}
