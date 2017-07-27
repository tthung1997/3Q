using UnityEngine;
using UnityEditor;

static class BasicCardUnityIntegration 
{

	[MenuItem("Assets/Create/BasicCardAsset")]
	public static void CreateYourScriptableObject() {
		ScriptableObjectUtility2.CreateAsset<BasicCardAsset>();
	}

}
