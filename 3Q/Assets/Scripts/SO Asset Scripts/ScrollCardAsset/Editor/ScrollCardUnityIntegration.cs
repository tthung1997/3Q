using UnityEngine;
using UnityEditor;

static class ScrollCardUnityIntegration 
{

	[MenuItem("Assets/Create/ScrollCardAsset")]
	public static void CreateYourScriptableObject() {
		ScriptableObjectUtility2.CreateAsset<ScrollCardAsset>();
	}

}
