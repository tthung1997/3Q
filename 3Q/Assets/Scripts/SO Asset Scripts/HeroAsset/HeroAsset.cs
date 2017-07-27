using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CountryOptions { Wu, Shu, Wei, Heroes }
public enum GenderOptions { Male, Female }

public class HeroAsset : ScriptableObject 
{
	public Sprite CardImage;
	public CountryAsset Country;
	public GenderOptions Gender;
    public int MaxHealth;
	public string[] SkillsName;
	[TextArea(2, 3)]
	public string[] SkillsDesc;

}
